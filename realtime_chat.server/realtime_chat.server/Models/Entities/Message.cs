namespace realtime_chat.server.Models.Entities
{
    public class Message
    {
        public int MessageId { get; set; }
        public int UserId { get; set; }
        public int ChatRoomId { get; set; }
        public string Content { get; set; }
        public int Upvotes { get; set; }
        public int Downvotes { get; set; }
        public DateTime Timestamp { get; set; }

        // Navigation properties
        public UserDetail User { get; set; }
        public ChatRoom ChatRoom { get; set; }
    }

}
