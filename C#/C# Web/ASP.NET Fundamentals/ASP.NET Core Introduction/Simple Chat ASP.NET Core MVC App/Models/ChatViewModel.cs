namespace Simple_Chat_ASP.NET_Core_MVC_App.Models
{
    public class ChatViewModel
    {
        public MessageViewModel CurrentMessage { get; set; }
        public List<MessageViewModel> Messages { get; set; }
    }
}
