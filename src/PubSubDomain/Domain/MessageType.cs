using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubDomain.Domain
{
	public enum MessageType
	{
		SubscriberToPublisher = 1,
		PublisherToSubscriber = 2,
		Subscribing = 3,
		Unsubscribing = 4,

	}
}
