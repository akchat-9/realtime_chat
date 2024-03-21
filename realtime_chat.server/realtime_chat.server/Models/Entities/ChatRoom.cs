namespace realtime_chat.server.Models.Entities
{
    public class ChatRoom
    {
        public int ChatRoomId { get; set; }
        public string Name { get; set; }


        public List<Message> Message { get; set; }
    }
}
