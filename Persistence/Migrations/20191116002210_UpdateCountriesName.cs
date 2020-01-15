using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class UpdateCountriesName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coutries_Languages_LanguageId",
                table: "Coutries");

            migrationBuilder.DropForeignKey(
                name: "FK_Streams_Coutries_CountryId",
                table: "Streams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coutries",
                table: "Coutries");

            migrationBuilder.RenameTable(
                name: "Coutries",
                newName: "Countries");

            migrationBuilder.RenameIndex(
                name: "IX_Coutries_LanguageId",
                table: "Countries",
                newName: "IX_Countries_LanguageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Countries_Languages_LanguageId",
                table: "Countries",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Streams_Countries_CountryId",
                table: "Streams",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Countries_Languages_LanguageId",
                table: "Countries");

            migrationBuilder.DropForeignKey(
                name: "FK_Streams_Countries_CountryId",
                table: "Streams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.RenameTable(
                name: "Countries",
                newName: "Coutries");

            migrationBuilder.RenameIndex(
                name: "IX_Countries_LanguageId",
                table: "Coutries",
                newName: "IX_Coutries_LanguageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coutries",
                table: "Coutries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Coutries_Languages_LanguageId",
                table: "Coutries",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Streams_Coutries_CountryId",
                table: "Streams",
                column: "CountryId",
                principalTable: "Coutries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
