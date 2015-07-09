using Microsoft.AspNet.SignalR;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        public ChatHub(TestClass a)
        {
            // We don't need TestClass, but this is a sanity check so we know that DI is working
            var b = a;
        }
        public void Send(string name, string message)
        {
            // Call the addNewMessageToPage method to update clients.
            Clients.All.addNewMessageToPage(name, message);
        }
    }

    public class TestClass
    {
        public string Name { get; set; }
    }
}
