using PubSubDomain.Domain;
using PubSubDomain.Resources;
using PubSubDomain.Services;
using PubSubInfrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubInfrastructure.Services
{
	public class SubscriberService : BaseChatService, ISubscriberService
	{
		public SubscriberService(IChatService chatService) : base(chatService)
		{
		}

		/// <summary>
		/// Filter messages for certain subscriber only.
		/// </summary>
		public string GetChatHistoryTextForSubscriber(List<ChatMessage> source, Subscriber subscriber)
		{
			source = source ?? new List<ChatMessage>();

			source = source.Where(i => this.ShouldSubscriberReceiveMessage(subscriber, i)).ToList();

			var text = ChatHistoryExtensions.GetChatHistoryTextForSubscriber(source);
			return text;
		}

		private bool ShouldSubscriberReceiveMessage(Subscriber subscriber, ChatMessage chatMessage)
		{
			if (subscriber == null)
			{
				return false;
			}

			var targetSubscriber = chatMessage.Subscriber;
			var targetSubscriberName = $"{targetSubscriber.Name}";
			bool isForAll = targetSubscriberName.Equals(FieldText.All, StringComparison.OrdinalIgnoreCase);
			if (isForAll)
			{
				return true;
			}

			var subscriberName = $"{subscriber?.Name}";
			return subscriberName.Equals(targetSubscriberName, StringComparison.OrdinalIgnoreCase);
		}

		/// <summary>
		/// Create an empty message list for subscriber.
		/// </summary>
		public List<ChatMessage> GetMessagesBySubscriber(Subscriber subscriber)
		{
			return new List<ChatMessage>();
		}

		/// <summary>
		/// Subscribe by name.
		/// Always listen to the new message.
		/// </summary>
		public bool Subscribe(Subscriber subscriber, Publisher publisher)
		{
			var message = string.Format(FieldText.SubscribingFormat, subscriber.Name);
			var sent = new ChatMessage(MessageType.Subscribing, publisher, subscriber, message);
			return WriteMessage(sent);
		}

		/// <summary>
		/// Unsubscribe by name.
		/// Dont want to listen to the new message anymore.
		/// </summary>
		public bool Unsubscribe(Subscriber subscriber, Publisher publisher)
		{
			var message = string.Format(FieldText.UnsubscribingFormat, subscriber.Name);
			var sent = new ChatMessage(MessageType.Unsubscribing, publisher, subscriber, message);
			return WriteMessage(sent);
		}

		public List<ErrorType> Validate(Subscriber subscriber)
		{
			var values = new List<ErrorType>();

			// For empty subscriber.
			if (subscriber == null)
			{
				values.Add(ErrorType.EmptySubscriber);
			}
			else if (string.IsNullOrEmpty(subscriber.Name))
			{
				values.Add(ErrorType.EmptySubscriber);
			}

			return values;
		}

		public bool WriteMessage(ChatMessage sent)
		{
			return _chatService.WriteMessage(sent);
		}
	}
}
