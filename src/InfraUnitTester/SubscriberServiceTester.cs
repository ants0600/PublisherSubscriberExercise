using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublisherUi.Extensions;
using PubSubDomain.Domain;
using PubSubDomain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfraUnitTester
{
	/// <summary>
	/// Used for integration testing against real API.
	/// Ex: in DEV, STAGING, or PROD environments.
	/// Only covers few cases.
	/// </summary>
	[TestClass]
	public class SubscriberServiceTester
	{
		private readonly ISubscriberService _subscriberService;

		public SubscriberServiceTester()
		{
			_subscriberService = InfraDependencyInjector.Resolve<ISubscriberService>();
		}

		[TestMethod]
		public void Subscribing_MustBe_Successful()
		{
			// Arrange.
			var subscriber = new Subscriber("subscriber from unit test");
			var publisher = new Publisher("publisher from unit test");

			// Act.
			_subscriberService.Initialize();
			var isSubscribing = _subscriberService.Subscribe(subscriber, publisher);

			// Assert.
			Assert.IsTrue(isSubscribing);
		}

		[TestMethod]
		public void Unsubscribing_MustBe_Successful()
		{
			// Arrange.
			var subscriber = new Subscriber("subscriber from unit test");
			var publisher = new Publisher("publisher from unit test");

			// Act.
			_subscriberService.Initialize();
			var isUnsubscribing = _subscriberService.Subscribe(subscriber, publisher);

			// Assert.
			Assert.IsTrue(isUnsubscribing);
		}

		[TestMethod]
		public void SendMessageFromSubscriberToPublisher_MustBe_Successful()
		{
			// Arrange.
			var subscriber = new Subscriber("subscriber from unit test");
			var publisher = new Publisher("publisher from unit test");
			string message = "SendMessageFromSubscriberToPublisher_MustBe_Successful from test project";
			ChatMessage sent = new ChatMessage(MessageType.SubscriberToPublisher, publisher, subscriber, message);

			// Act.
			bool isSent = _subscriberService.WriteMessage(sent);

			// Assert.
			Assert.IsTrue(isSent);
		}
	}
}
