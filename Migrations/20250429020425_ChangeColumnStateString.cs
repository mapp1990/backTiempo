using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace arq_micro_pru_tiempo.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnStateString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_State_StateId",
                table: "Offers");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropIndex(
                name: "IX_Offers_StateId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Offers");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Offers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "Offers");

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "Offers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sigla = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offers_StateId",
                table: "Offers",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_State_StateId",
                table: "Offers",
                column: "StateId",
                principalTable: "State",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
