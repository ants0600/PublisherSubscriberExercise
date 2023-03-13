using PubSubDomain.Domain;
using PubSubDomain.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PubSubInfrastructure.Extensions
{
	public static class ChatHistoryExtensions
	{
		/// <summary>
		/// Get messages displayed to publisher (ex: customer service).
		/// </summary>
		public static string GetChatHistoryTextForPublisher(IEnumerable<ChatMessage> source)
		{
			source = source ?? new List<ChatMessage>();
			string value = string.Empty;

			foreach (ChatMessage item in source)
			{
				value += $"{GetChatHistoryTextForPublisher(item.Subscriber.Name, item.CreatedDate, item.Message)}{Environment.NewLine}";
			}

			return value;
		}

		/// <summary>
		/// Get messages displayed to subscriber.
		/// </summary>
		public static string GetChatHistoryTextForSubscriber(IEnumerable<ChatMessage> source)
		{
			source = source ?? new List<ChatMessage>();
			string value = string.Empty;

			foreach (ChatMessage item in source)
			{
				var createdDate = item.CreatedDate;
				switch (item.MessageType)
				{
					case MessageType.Subscribing:
						{
							value += string.Format(FieldText.YouAreSubscribingFormat, createdDate);
							break;
						}

					case MessageType.Unsubscribing:
						{
							value += string.Format(FieldText.YouAreUnsubscribingFormat, createdDate);
							break;
						}

					case MessageType.PublisherToSubscriber:
						{
							value += GetChatHistoryTextForPublisher(item.Publisher.Name, createdDate, item.Message);
							break;
						}

					case MessageType.SubscriberToPublisher:
						{
							value += string.Format(FieldText.YouSendMessageFormat, createdDate, item.Message);
							break;
						}
				}

				value += Environment.NewLine;
			}

			return value;
		}

		private static string GetChatHistoryTextForPublisher(string name, DateTime date, string message)
		{
			return string.Format(FieldText.ChatHistoryFormat, name, date, message);
		}
	}
}
