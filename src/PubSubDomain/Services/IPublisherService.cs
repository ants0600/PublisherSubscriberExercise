using PubSubDomain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubDomain.Services
{
	public interface IPublisherService : IChatService
	{
		bool PublishMessage(ChatMessage sent);

		List<ChatMessage> GetMessagesByPublisher(Publisher publisher);
		List<ErrorType> Validate(ChatMessage sent);
	}
}
