

namespace Simple_Chat_ASP.NET_Core_MVC_App.Controllers
{
    using Microsoft.AspNetCore.Mvc;
using Simple_Chat_ASP.NET_Core_MVC_App.Models;
    public class ChatController : Controller
    {
        public static List<KeyValuePair<string,string>> s_messages = new List<KeyValuePair<string,string>>();

        public IActionResult Show()
        {
            if (s_messages.Count() < 1)
            {
                return View(new ChatViewModel());
            }
            var chatModel = new ChatViewModel()
            {
                Messages = s_messages.Select(m =>
                new MessageViewModel()
                {
                    Sender = m.Key,
                    MessageText = m.Value
                }).ToList()
            };

            return View(chatModel);
        }
        [HttpPost]
        public IActionResult Send(ChatViewModel chat)
        {
            var newMessage = chat.CurrentMessage;
            s_messages.Add(new KeyValuePair<string, string>(newMessage.Sender, newMessage.MessageText));
            return RedirectToAction("Show");
        }
    }
}
