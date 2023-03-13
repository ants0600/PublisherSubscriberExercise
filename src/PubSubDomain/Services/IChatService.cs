using PubSubDomain.Domain;

namespace PubSubDomain.Services
{
	public interface IChatService : IService
	{
		bool Initialize();

		IChatListener Listener { get; set; }

		bool WriteMessage(ChatMessage sent);
	}
}
