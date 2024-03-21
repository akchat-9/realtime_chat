using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using realtime_chat.server.Data;
using realtime_chat.server.Models.Entities;

namespace realtime_chat.server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatRoomController : ControllerBase
    {
        private readonly ChatDbContext _dbContext;

        public ChatRoomController(ChatDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateChatRoom(ChatRoom chatRoom)
        {
            _dbContext.ChatRoom.Add(chatRoom);
            await _dbContext.SaveChangesAsync();

            return Ok(chatRoom);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllChatRooms()
        {
            var chatRooms = await _dbContext.ChatRoom.ToListAsync();
            return Ok(chatRooms);
        }

    }
}
