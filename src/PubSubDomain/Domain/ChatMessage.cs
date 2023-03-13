using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubDomain.Domain
{
	public class ChatMessage
	{
		public ChatMessage()
		{

		}

		public ChatMessage(MessageType messageType, Publisher publisher, Subscriber subscriber, string message)
		{
			MessageType = messageType;
			Publisher = publisher;
			Subscriber = subscriber;
			Message = message;
			CreatedDate = DateTime.Now;
		}

		public MessageType MessageType { get; set; }

		public Publisher Publisher { get; set; }

		public Subscriber Subscriber { get; set; }

		public string Message { get; set; }

		public DateTime CreatedDate { get; set; }
	}
}
