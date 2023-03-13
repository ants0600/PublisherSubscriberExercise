using PubSubDomain.Domain;
using System.Collections.Generic;

namespace PubSubDomain.Services
{
	public interface ISubscriberService : IChatService
	{
		bool Subscribe(Subscriber subscriber, Publisher publisher);

		bool Unsubscribe(Subscriber subscriber, Publisher publisher);

		List<ChatMessage> GetMessagesBySubscriber(Subscriber subscriber);

		string GetChatHistoryTextForSubscriber(List<ChatMessage> source, Subscriber subscriber);
		List<ErrorType> Validate(Subscriber subscriber);
	}
}
