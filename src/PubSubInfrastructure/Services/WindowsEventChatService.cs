using Newtonsoft.Json;
using PubSubDomain.Domain;
using PubSubDomain.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PubSubInfrastructure.Services
{
	public class WindowsEventChatService : IChatService
	{
		private AutoResetEvent Signal { get; } = new AutoResetEvent(false);

		public IChatListener Listener { get; set; }

		private EventLog EventLogger { get; set; }

		public bool Initialize()
		{
			EventLogger = new EventLog(ConstantValues.LogName, ConstantValues.MachineName, ConstantValues.Source);

			// Bind events.
			EventLogger.EntryWritten += EventLog_EntryWritten;
			EventLogger.EnableRaisingEvents = true;
			return true;
		}

		private void EventLog_EntryWritten(object sender, EntryWrittenEventArgs e)
		{
			EventLogEntry entry = e.Entry;
			ChatMessage message = CreateMessage(entry);
			Listener.OnReceivingNewMessage(message);
			Signal.Set();
		}

		private ChatMessage CreateMessage(EventLogEntry entry)
		{
			return JsonConvert.DeserializeObject<ChatMessage>(entry.Message);
		}

		/// <summary>
		/// Serialize message object.
		/// </summary>
		public bool WriteMessage(ChatMessage sent)
		{
			var publisher = sent.Publisher;
			string source = publisher.Name;
			var message = JsonConvert.SerializeObject(sent);
			EventLog.WriteEntry(source, message, EventLogEntryType.Information);
			return true;
		}
	}
}
