using Microsoft.EntityFrameworkCore;
using realtime_chat.server.Models.Entities;

namespace realtime_chat.server.Data
{
    public class ChatDbContext : DbContext
    {
        public ChatDbContext(DbContextOptions<ChatDbContext> options) : base(options)
        {
        }

        public DbSet<UserDetail> UserDetail { get; set; }
        public DbSet<Message> Message { get; set; }
        public DbSet<ChatRoom> ChatRoom { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define primary keys and relationships...
            modelBuilder.Entity<UserDetail>().HasKey(u => u.UserId);
            modelBuilder.Entity<ChatRoom>().HasKey(c => c.ChatRoomId);
            modelBuilder.Entity<Message>().HasKey(m => m.MessageId);

            // Define relationships between entities...
            modelBuilder.Entity<Message>()
                .HasOne(m => m.User)
                .WithMany(u => u.Message)
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.ChatRoom)
                .WithMany(c => c.Message)
                .HasForeignKey(m => m.ChatRoomId)
                .OnDelete(DeleteBehavior.Cascade);


            // Seed initial data
            SeedUsers(modelBuilder);
            SeedChatRooms(modelBuilder);
            SeedMessages(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void SeedUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserDetail>().HasData(
                new UserDetail { UserId = 1, UserName = "user1", Email = "user1@example.com", Password = "123" },
                new UserDetail { UserId = 2, UserName = "user2", Email = "user2@example.com", Password = "123" },
                new UserDetail { UserId = 3, UserName = "user3", Email = "user3@example.com", Password = "123" },
                new UserDetail { UserId = 4, UserName = "user4", Email = "user4@example.com", Password = "123" },
                new UserDetail { UserId = 5, UserName = "user5", Email = "user5@example.com", Password = "123" }
            );
        }

        private void SeedChatRooms(ModelBuilder modelBuilder)
        {
            for (int i = 1; i <= 10; i++)
            {
                modelBuilder.Entity<ChatRoom>().HasData(
                    new ChatRoom { ChatRoomId = i, Name = $"Room {i}" }
                );
            }
        }

        private void SeedMessages(ModelBuilder modelBuilder)
        {
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 5; j++)
                {
                    modelBuilder.Entity<Message>().HasData(
                        new Message { MessageId = (i - 1) * 5 + j, UserId = j, ChatRoomId = i, Content = $"Message from user{j} in Room {i}", Timestamp = DateTime.UtcNow }
                    );
                }
            }
        }
    }
}
