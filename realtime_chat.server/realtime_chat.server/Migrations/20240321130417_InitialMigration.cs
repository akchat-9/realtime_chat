using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace realtime_chat.server.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatRoom",
                columns: table => new
                {
                    ChatRoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatRoom", x => x.ChatRoomId);
                });

            migrationBuilder.CreateTable(
                name: "UserDetail",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetail", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ChatRoomId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Upvotes = table.Column<int>(type: "int", nullable: false),
                    Downvotes = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Message_ChatRoom_ChatRoomId",
                        column: x => x.ChatRoomId,
                        principalTable: "ChatRoom",
                        principalColumn: "ChatRoomId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Message_UserDetail_UserId",
                        column: x => x.UserId,
                        principalTable: "UserDetail",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ChatRoom",
                columns: new[] { "ChatRoomId", "Name" },
                values: new object[,]
                {
                    { 1, "Room 1" },
                    { 2, "Room 2" },
                    { 3, "Room 3" },
                    { 4, "Room 4" },
                    { 5, "Room 5" },
                    { 6, "Room 6" },
                    { 7, "Room 7" },
                    { 8, "Room 8" },
                    { 9, "Room 9" },
                    { 10, "Room 10" }
                });

            migrationBuilder.InsertData(
                table: "UserDetail",
                columns: new[] { "UserId", "Email", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, "user1@example.com", "123", "user1" },
                    { 2, "user2@example.com", "123", "user2" },
                    { 3, "user3@example.com", "123", "user3" },
                    { 4, "user4@example.com", "123", "user4" },
                    { 5, "user5@example.com", "123", "user5" }
                });

            migrationBuilder.InsertData(
                table: "Message",
                columns: new[] { "MessageId", "ChatRoomId", "Content", "Downvotes", "Timestamp", "Upvotes", "UserId" },
                values: new object[,]
                {
                    { 1, 1, "Message from user1 in Room 1", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2174), 0, 1 },
                    { 2, 1, "Message from user2 in Room 1", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2188), 0, 2 },
                    { 3, 1, "Message from user3 in Room 1", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2200), 0, 3 },
                    { 4, 1, "Message from user4 in Room 1", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2212), 0, 4 },
                    { 5, 1, "Message from user5 in Room 1", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2221), 0, 5 },
                    { 6, 2, "Message from user1 in Room 2", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2233), 0, 1 },
                    { 7, 2, "Message from user2 in Room 2", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2244), 0, 2 },
                    { 8, 2, "Message from user3 in Room 2", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2254), 0, 3 },
                    { 9, 2, "Message from user4 in Room 2", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2265), 0, 4 },
                    { 10, 2, "Message from user5 in Room 2", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2302), 0, 5 },
                    { 11, 3, "Message from user1 in Room 3", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2313), 0, 1 },
                    { 12, 3, "Message from user2 in Room 3", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2324), 0, 2 },
                    { 13, 3, "Message from user3 in Room 3", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2335), 0, 3 },
                    { 14, 3, "Message from user4 in Room 3", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2345), 0, 4 },
                    { 15, 3, "Message from user5 in Room 3", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2355), 0, 5 },
                    { 16, 4, "Message from user1 in Room 4", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2365), 0, 1 },
                    { 17, 4, "Message from user2 in Room 4", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2376), 0, 2 },
                    { 18, 4, "Message from user3 in Room 4", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2387), 0, 3 },
                    { 19, 4, "Message from user4 in Room 4", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2397), 0, 4 },
                    { 20, 4, "Message from user5 in Room 4", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2408), 0, 5 },
                    { 21, 5, "Message from user1 in Room 5", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2418), 0, 1 },
                    { 22, 5, "Message from user2 in Room 5", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2429), 0, 2 },
                    { 23, 5, "Message from user3 in Room 5", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2440), 0, 3 },
                    { 24, 5, "Message from user4 in Room 5", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2450), 0, 4 },
                    { 25, 5, "Message from user5 in Room 5", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2460), 0, 5 },
                    { 26, 6, "Message from user1 in Room 6", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2471), 0, 1 },
                    { 27, 6, "Message from user2 in Room 6", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2481), 0, 2 },
                    { 28, 6, "Message from user3 in Room 6", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2491), 0, 3 },
                    { 29, 6, "Message from user4 in Room 6", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2501), 0, 4 },
                    { 30, 6, "Message from user5 in Room 6", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2510), 0, 5 },
                    { 31, 7, "Message from user1 in Room 7", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2543), 0, 1 },
                    { 32, 7, "Message from user2 in Room 7", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2555), 0, 2 },
                    { 33, 7, "Message from user3 in Room 7", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2566), 0, 3 },
                    { 34, 7, "Message from user4 in Room 7", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2576), 0, 4 },
                    { 35, 7, "Message from user5 in Room 7", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2587), 0, 5 },
                    { 36, 8, "Message from user1 in Room 8", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2597), 0, 1 },
                    { 37, 8, "Message from user2 in Room 8", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2607), 0, 2 },
                    { 38, 8, "Message from user3 in Room 8", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2618), 0, 3 },
                    { 39, 8, "Message from user4 in Room 8", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2628), 0, 4 },
                    { 40, 8, "Message from user5 in Room 8", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2638), 0, 5 },
                    { 41, 9, "Message from user1 in Room 9", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2648), 0, 1 },
                    { 42, 9, "Message from user2 in Room 9", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2659), 0, 2 },
                    { 43, 9, "Message from user3 in Room 9", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2669), 0, 3 },
                    { 44, 9, "Message from user4 in Room 9", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2679), 0, 4 },
                    { 45, 9, "Message from user5 in Room 9", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2689), 0, 5 },
                    { 46, 10, "Message from user1 in Room 10", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2699), 0, 1 },
                    { 47, 10, "Message from user2 in Room 10", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2709), 0, 2 },
                    { 48, 10, "Message from user3 in Room 10", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2719), 0, 3 },
                    { 49, 10, "Message from user4 in Room 10", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2730), 0, 4 },
                    { 50, 10, "Message from user5 in Room 10", 0, new DateTime(2024, 3, 21, 13, 4, 17, 163, DateTimeKind.Utc).AddTicks(2740), 0, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Message_ChatRoomId",
                table: "Message",
                column: "ChatRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Message_UserId",
                table: "Message",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "ChatRoom");

            migrationBuilder.DropTable(
                name: "UserDetail");
        }
    }
}
