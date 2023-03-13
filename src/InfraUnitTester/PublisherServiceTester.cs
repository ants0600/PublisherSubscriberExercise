using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublisherUi.Extensions;
using PubSubDomain.Domain;
using PubSubDomain.Services;
using System;

namespace InfraUnitTester
{
	/// <summary>
	/// Used for integration testing against real API.
	/// Contains test cases for publisher service.
	/// This class only covers some of test cases.
	/// NOT ALL cases are covered yet.
	/// </summary>
	[TestClass]
	public class PublisherServiceTester
	{
		private readonly IPublisherService _publisherService;

		public PublisherServiceTester()
		{
			_publisherService = InfraDependencyInjector.Resolve<IPublisherService>();
		}

		/// <summary>
		/// Ex: really invoke API and assert the result.
		/// </summary>
		[TestMethod]
		public void PublishMessageFromPublisherToSubscriber_MustBe_Successful()
		{
			// Arrange.
			Publisher publisher = new Publisher("publisher from unit testing");
			Subscriber subscriber = new Subscriber("subscriber from unit testing");
			string message = "test message";
			ChatMessage sent = new ChatMessage(MessageType.PublisherToSubscriber, publisher, subscriber, message);

			// Act.
			_publisherService.Initialize();
			bool isPublished = _publisherService.PublishMessage(sent);

			// Assert.
			Assert.IsTrue(isPublished);
		}
	}
}
