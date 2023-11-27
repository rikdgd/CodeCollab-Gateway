using CarrotMQ;

namespace CodeCollab___Gateway;


class BasicMessageHandler : IMessageHandler
{
        public void HandleMessage(string message)
        {
                Console.WriteLine($"Received the following message: \n{message}");
        }
}