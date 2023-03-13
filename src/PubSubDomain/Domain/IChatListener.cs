namespace PubSubDomain.Domain
{
	public interface IChatListener
	{
		bool OnReceivingNewMessage(ChatMessage message);
	}
}
