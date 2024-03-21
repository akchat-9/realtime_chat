namespace realtime_chat.server.Models.Entities
{
    public class UserDetail
    {
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public List<Message> Message { get; set; }
    }
}
