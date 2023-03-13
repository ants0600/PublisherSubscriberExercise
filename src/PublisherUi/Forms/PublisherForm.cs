using Autofac.Features.Metadata;
using CoreUi.Extensions;
using PublisherUi.Extensions;
using PubSubDomain.Domain;
using PubSubDomain.Resources;
using PubSubDomain.Services;
using PubSubInfrastructure.Extensions;
using PubSubInfrastructure.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PublisherUi
{
	public partial class PublisherForm : Form, IChatListener
	{

		private readonly IErrorHandlerService _errorHandlerService = InfraDependencyInjector.Resolve<IErrorHandlerService>();
		private readonly IPublisherService _publisherService = InfraDependencyInjector.Resolve<IPublisherService>();

		public PublisherForm()
		{
			InitializeComponent();
		}

		#region properties

		/// <summary>
		/// Assuming the publisher is only one.
		/// Whom is a customer service staff.
		/// </summary>
		private Publisher Publisher { get; } = new Publisher(FieldText.DefaultPublisherName);

		/// <summary>
		/// Gets subscriber from combo box.
		/// </summary>
		private Subscriber Subscriber
		{
			get
			{
				var name = $"{cbSubscriber.SelectedItem}";
				return new Subscriber(name);
			}
		}

		/// <summary>
		/// Gets from text box.
		/// </summary>
		private string Message => $"{this.txMessage.Text}".Trim();

		private List<ChatMessage> Messages { get; set; } = new List<ChatMessage>();

		#endregion

		private void buttons_Click(object sender, EventArgs e)
		{
			try
			{
				if (sender == this.btPublish)
				{
					SendMessageAsPublisher();
				}
			}
			catch (Exception x)
			{
				_errorHandlerService.HandleError(x);
			}
		}

		/// <summary>
		/// Validate input.
		/// Send message to the selected subscriber.
		/// </summary>
		private bool SendMessageAsPublisher()
		{
			var sent = new ChatMessage(MessageType.PublisherToSubscriber, Publisher, Subscriber, Message);
			var errors = _publisherService.Validate(sent);
			if (errors.Count > 0)
			{
				return UiExtensions.PopupErrors(errors);
			}

			_publisherService.PublishMessage(sent);

			// Clear input.
			txMessage.Text = string.Empty;

			return true;
		}

		private void PublisherForm_Load(object sender, EventArgs e)
		{
			this.InitializeMessageOperations();
		}

		private void InitializeMessageOperations()
		{
			try
			{
				// Initialize services.
				_publisherService.Initialize();
				_publisherService.Listener = this;

				// Get chat messages.
				Messages = _publisherService.GetMessagesByPublisher(Publisher);
				RefreshChatHistory();

				// Update UI states.
				UpdateUi();
			}
			catch (Exception x)
			{
				_errorHandlerService.HandleError(x);
			}
		}

		private void UpdateUi()
		{
			this.cbSubscriber.Items.Add(FieldText.All);
		}

		/// <summary>
		/// Refresh chat history.
		/// Display chat history in text box.
		/// </summary>
		private bool RefreshChatHistory()
		{
			var text = ChatHistoryExtensions.GetChatHistoryTextForPublisher(Messages);
			return UiExtensions.WriteTextSafe(txChatHistory, text);
		}

		/// <summary>
		/// Event on receiving a new message.
		/// Display message in the text box.
		/// </summary>
		public bool OnReceivingNewMessage(ChatMessage message)
		{
			try
			{
				Messages.Add(message);

				// Add subscriber
				RefreshSubscribers(message);

				// Display in text.
				return RefreshChatHistory();
			}
			catch (Exception x)
			{
				_errorHandlerService.HandleError(x);
			}

			return false;
		}

		private void RefreshSubscribers(ChatMessage message)
		{
			var messageType = message.MessageType;
			var subscriber = message.Subscriber;
			var subscriberName = subscriber.Name;
			if (messageType == MessageType.Subscribing)
			{
				UiExtensions.WriteItemsSafe(cbSubscriber, subscriberName, true);
			}
			else if (messageType == MessageType.Unsubscribing)
			{
				UiExtensions.WriteItemsSafe(cbSubscriber, subscriberName, false);
			}
		}
	}
}
