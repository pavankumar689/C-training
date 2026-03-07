using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookManageMentSystem.Migrations
{
    /// <inheritdoc />
    public partial class bookmanager : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "Author", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "F. Scott Fitzgerald", "The Great Gatsby", 15.99m },
                    { 2, "Harper Lee", "To Kill a Mockingbird", 18.5m },
                    { 3, "George Orwell", "1984", 14.99m },
                    { 4, "Jane Austen", "Pride and Prejudice", 12.99m },
                    { 5, "J.D. Salinger", "The Catcher in the Rye", 16.75m },
                    { 6, "J.K. Rowling", "Harry Potter and the Sorcerer's Stone", 22.99m },
                    { 7, "J.R.R. Tolkien", "The Hobbit", 19.99m },
                    { 8, "J.R.R. Tolkien", "The Lord of the Rings", 35.99m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
