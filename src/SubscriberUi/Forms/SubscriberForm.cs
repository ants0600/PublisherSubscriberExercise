using CoreUi.Extensions;
using PublisherUi.Extensions;
using PubSubDomain.Domain;
using PubSubDomain.Resources;
using PubSubDomain.Services;
using PubSubInfrastructure.Extensions;
using PubSubInfrastructure.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.Remoting.Messaging;
using System.Threading;
using System.Windows.Forms;

namespace SubscriberUi
{
	public partial class SubscriberForm : Form, IChatListener
	{
		private readonly ISubscriberService _subscriberService = InfraDependencyInjector.Resolve<ISubscriberService>();
		private readonly IErrorHandlerService _errorHandlerService = new ErrorHandlerService();

		public SubscriberForm()
		{
			InitializeComponent();
		}

		#region properties

		private List<ChatMessage> Messages { get; set; } = new List<ChatMessage>();

		private Subscriber Subscriber
		{
			get
			{
				var text = $"{txSubscriberName.Text}".Trim();
				return new Subscriber(text);
			}
		}

		private Publisher Publisher => new Publisher(FieldText.DefaultPublisherName);

		private string Message => $"{this.txMessage.Text}".Trim();

		public bool IsSubscribing { get; private set; }

		#endregion

		private void buttons_Click(object sender, EventArgs e)
		{
			try
			{
				if (sender == btSubscribe)
				{
					Subscribe();
				}
				else if (sender == btSendMessage)
				{
					SendMessageAsSubscriber();
				}
				else if (sender == btUnsubscribe)
				{
					Unsubscribe();
				}
			}
			catch (Exception x)
			{
				_errorHandlerService.HandleError(x);
			}
		}

		/// <summary>
		/// Unsubscribe, dont listen to the message anymore.
		/// </summary>
		private bool Unsubscribe()
		{
			_subscriberService.Unsubscribe(Subscriber, Publisher);

			// Set flag.
			IsSubscribing = false;
			return UpdateUi(false);
		}

		/// <summary>
		/// Send message to publisher.
		/// Then clear message.
		/// </summary>
		private bool SendMessageAsSubscriber()
		{
			var sent = new ChatMessage(MessageType.SubscriberToPublisher, Publisher, Subscriber, Message);
			_subscriberService.WriteMessage(sent);

			txMessage.Text = string.Empty;
			return true;
		}

		/// <summary>
		/// Subscribe, always listen to the message.
		/// </summary>
		private bool Subscribe()
		{
			var errors = _subscriberService.Validate(Subscriber);
			if (errors.Count > 0)
			{
				return UiExtensions.PopupErrors(errors);
			}

			_subscriberService.Subscribe(Subscriber, Publisher);

			// Set flag.
			IsSubscribing = true;
			return UpdateUi(true);
		}

		private void SubscriberForm_Load(object sender, EventArgs e)
		{
			InitializeMessageOperations();
		}

		/// <summary>
		/// Initialize subscriber fuctions.
		/// Set UI state.
		/// </summary>
		private void InitializeMessageOperations()
		{
			try
			{
				this.BackColor = UiExtensions.GetRandomColorForSubscriberForm();

				// Initialize subscriber service.
				_subscriberService.Initialize();
				_subscriberService.Listener = this;

				// Set UI state.
				this.UpdateUi(false);
			}
			catch (Exception x)
			{
				_errorHandlerService.HandleError(x);
			}
		}

		private bool UpdateUi(bool isSubscribing)
		{
			this.btSubscribe.Enabled = !isSubscribing;
			this.btUnsubscribe.Enabled = isSubscribing;
			this.btSendMessage.Enabled = isSubscribing;

			this.txMessage.Enabled = isSubscribing;
			this.txSubscriberName.Enabled = !isSubscribing;

			return true;
		}

		/// <summary>
		/// Add message to the bottom.
		/// </summary>
		public bool OnReceivingNewMessage(ChatMessage message)
		{
			if (!IsSubscribing)
			{
				return false;
			}

			Messages.Add(message);

			// Display in grid.
			return RefreshChatHistory();
		}

		/// <summary>
		/// Refresh chat history.
		/// Display chat history in text box.
		/// </summary>
		private bool RefreshChatHistory()
		{
			var text = _subscriberService.GetChatHistoryTextForSubscriber(Messages, this.Subscriber);
			return UiExtensions.WriteTextSafe(txChatHistory, text);
		}
	}
}
