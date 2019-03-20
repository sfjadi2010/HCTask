using Microsoft.EntityFrameworkCore.Migrations;

namespace HCTask.Migrations
{
    public partial class AddedPersonRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "People",
                maxLength: 64,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PictureName",
                table: "People",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "People",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "People",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "People",
                maxLength: 256,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "People");

            migrationBuilder.DropColumn(
                name: "PictureName",
                table: "People");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "People");

            migrationBuilder.DropColumn(
                name: "State",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Street",
                table: "People");

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    City = table.Column<string>(maxLength: 64, nullable: false),
                    PersonId = table.Column<int>(nullable: false),
                    PostalCode = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: true),
                    Street = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_PersonId",
                table: "Addresses",
                column: "PersonId",
                unique: true);
        }
    }
}
