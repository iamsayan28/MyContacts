using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyContactsApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAddressBook2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressBookId",
                table: "Contacts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AddressBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressBooks", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_AddressBookId",
                table: "Contacts",
                column: "AddressBookId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_AddressBooks_AddressBookId",
                table: "Contacts",
                column: "AddressBookId",
                principalTable: "AddressBooks",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_AddressBooks_AddressBookId",
                table: "Contacts");

            migrationBuilder.DropTable(
                name: "AddressBooks");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_AddressBookId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "AddressBookId",
                table: "Contacts");
        }
    }
}
