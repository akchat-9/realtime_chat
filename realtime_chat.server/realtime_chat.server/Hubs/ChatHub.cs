using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using realtime_chat.server.Data;
using realtime_chat.server.Models;
using realtime_chat.server.Models.Entities;

namespace realtime_chat.server.Hubs
{
    public class ChatHub : Hub
    {
        private readonly ChatDbContext _dbContext;

        public ChatHub(ChatDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task JoinSpecificChatRoom(UserConnection conn)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, conn.ChatRoomId.ToString());

            var chatHistory = await _dbContext.Message
                .Where(m => m.ChatRoomId == conn.ChatRoomId)
                .OrderBy(m => m.Timestamp)
                .ToListAsync();

            await Clients.Caller.SendAsync("ChatHistory", chatHistory);
            await Clients.Group(conn.ChatRoomId.ToString()).SendAsync("UserJoined", conn.UserName, $"{conn.UserName} has joined {conn.ChatRoomName}");
        }

        public async Task LeaveChatRoom(UserConnection conn)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, conn.ChatRoomId.ToString());
            await Clients.Group(conn.ChatRoomId.ToString()).SendAsync("UserLeft", conn.UserName, $"{conn.UserName} has joined {conn.ChatRoomName}");
        }

        public async Task SendMessage(Message message)
        {
            var newMessage = new Message
            {
                UserId = message.UserId,
                ChatRoomId = message.ChatRoomId,
                Content = message.Content,
                Upvotes = 0,
                Downvotes = 0,
                Timestamp = DateTime.UtcNow
            };
            _dbContext.Message.Add(newMessage);
            await _dbContext.SaveChangesAsync();

            await Clients.Group(message.ChatRoomId.ToString()).SendAsync("ReceiveMessage", message.User, message.Content);
        }

        public async Task VoteMessage(int messageId, bool isUpvote)
        {
            var message = await _dbContext.Message.FindAsync(messageId);
            if (message == null)
            {
                return;
            }

            if (isUpvote)
            {
                message.Upvotes++;
            }
            else
            {
                message.Downvotes++;
            }

            await _dbContext.SaveChangesAsync();

            var voteCount = message.Upvotes - message.Downvotes;

            await Clients.Group(message.ChatRoomId.ToString()).SendAsync("UpdateVoteCount", messageId, voteCount);
        }
    }
}
