using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubDomain.Domain
{
	public enum ErrorType
	{
		EmptySubscriber = 1,
		EmptyPublisher = 2,
		EmptyMessage = 3,
	}
}
