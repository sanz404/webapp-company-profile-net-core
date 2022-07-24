using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class FixTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faq_CategoryArticle_CategoryId",
                table: "Faq");

            migrationBuilder.DropForeignKey(
                name: "FK_Faq_CategoryFaq_CategoryFaqId",
                table: "Faq");

            migrationBuilder.DropIndex(
                name: "IX_Faq_CategoryFaqId",
                table: "Faq");

            migrationBuilder.DropColumn(
                name: "CategoryFaqId",
                table: "Faq");

            migrationBuilder.AddForeignKey(
                name: "FK_Faq_CategoryFaq_CategoryId",
                table: "Faq",
                column: "CategoryId",
                principalTable: "CategoryFaq",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faq_CategoryFaq_CategoryId",
                table: "Faq");

            migrationBuilder.AddColumn<long>(
                name: "CategoryFaqId",
                table: "Faq",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Faq_CategoryFaqId",
                table: "Faq",
                column: "CategoryFaqId");

            migrationBuilder.AddForeignKey(
                name: "FK_Faq_CategoryArticle_CategoryId",
                table: "Faq",
                column: "CategoryId",
                principalTable: "CategoryArticle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Faq_CategoryFaq_CategoryFaqId",
                table: "Faq",
                column: "CategoryFaqId",
                principalTable: "CategoryFaq",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
