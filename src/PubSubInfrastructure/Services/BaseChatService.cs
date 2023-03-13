using PubSubDomain.Domain;
using PubSubDomain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PubSubInfrastructure.Services
{
	public abstract class BaseChatService
	{
		protected readonly IChatService _chatService;

		protected BaseChatService(IChatService chatService)
		{
			this._chatService = chatService;
		}

		public IChatListener Listener
		{
			get => _chatService.Listener;
			set => _chatService.Listener = value;
		}

		public bool Initialize()
		{
			return _chatService.Initialize();
		}
	}
}
