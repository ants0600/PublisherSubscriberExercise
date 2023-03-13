using PubSubDomain.Domain;
using PubSubDomain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubInfrastructure.Services
{
	public class PublisherService : BaseChatService, IPublisherService
	{
		public PublisherService(IChatService chatService) : base(chatService)
		{
		}

		/// <summary>
		/// Create an empty message list for a publisher.
		/// </summary>
		public List<ChatMessage> GetMessagesByPublisher(Publisher publisher)
		{
			return new List<ChatMessage>();
		}

		public bool PublishMessage(ChatMessage sent)
		{
			return WriteMessage(sent);
		}

		public List<ErrorType> Validate(ChatMessage sent)
		{
			List<ErrorType> values = new List<ErrorType>();

			// For empty Publisher
			Publisher publisher = sent.Publisher;
			if (publisher == null)
			{
				values.Add(ErrorType.EmptyPublisher);
			}
			else if (string.IsNullOrEmpty(publisher.Name))
			{
				values.Add(ErrorType.EmptyPublisher);
			}

			// For empty subscriber.
			Subscriber subscriber = sent.Subscriber;
			if (subscriber == null)
			{
				values.Add(ErrorType.EmptySubscriber);
			}
			else if (string.IsNullOrEmpty(subscriber.Name))
			{
				values.Add(ErrorType.EmptySubscriber);
			}

			// For empty message.
			var message = $"{sent.Message}".Trim();
			if (string.IsNullOrEmpty(message))
			{
				values.Add(ErrorType.EmptyMessage);
			}

			return values;
		}

		public bool WriteMessage(ChatMessage sent)
		{
			return _chatService.WriteMessage(sent);
		}
	}
}
