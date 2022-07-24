using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Backend.Migrations
{
    public partial class MainTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "About",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Image = table.Column<string>(type: "varchar(64)", nullable: true),
                    Title = table.Column<string>(type: "varchar(191)", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_About", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryArticle",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar(191)", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryArticle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryFaq",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar(191)", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryFaq", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar(191)", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryProject",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar(191)", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProject", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "varchar(64)", nullable: false),
                    Email = table.Column<string>(type: "varchar(64)", nullable: true),
                    Phone = table.Column<string>(type: "varchar(64)", nullable: true),
                    Website = table.Column<string>(type: "varchar(64)", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Code = table.Column<string>(type: "varchar(64)", nullable: false),
                    Name = table.Column<string>(type: "varchar(64)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Feature",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Icon = table.Column<string>(type: "varchar(64)", nullable: true),
                    Title = table.Column<string>(type: "varchar(191)", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsPublished = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feature", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "varchar(64)", nullable: false),
                    Email = table.Column<string>(type: "varchar(64)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(64)", nullable: false),
                    Content = table.Column<string>(type: "Text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Image = table.Column<string>(type: "varchar(64)", nullable: true),
                    Name = table.Column<string>(type: "varchar(191)", nullable: false),
                    Position = table.Column<string>(type: "varchar(191)", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsPublished = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Faq",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    Question = table.Column<string>(type: "varchar(191)", nullable: false),
                    Answer = table.Column<string>(type: "text", nullable: false),
                    Sort = table.Column<int>(type: "integer", nullable: false),
                    IsPublished = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CategoryFaqId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faq", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faq_CategoryArticle_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CategoryArticle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Faq_CategoryFaq_CategoryFaqId",
                        column: x => x.CategoryFaqId,
                        principalTable: "CategoryFaq",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "varchar(64)", nullable: false),
                    Image = table.Column<string>(type: "varchar(191)", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsPublished = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_CategoryProduct_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CategoryProduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "varchar(64)", nullable: false),
                    Image = table.Column<string>(type: "varchar(191)", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsPublished = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Project_CategoryProject_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CategoryProject",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CountryId = table.Column<long>(type: "bigint", nullable: false),
                    Username = table.Column<string>(type: "varchar(64)", nullable: false),
                    Email = table.Column<string>(type: "varchar(64)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(64)", nullable: true),
                    Address1 = table.Column<string>(type: "text", nullable: true),
                    Address2 = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "varchar(64)", nullable: true),
                    ZipCode = table.Column<string>(type: "varchar(64)", nullable: true),
                    Password = table.Column<string>(type: "varchar(191)", nullable: true),
                    Token = table.Column<string>(type: "text", nullable: true),
                    IsAdmin = table.Column<bool>(type: "boolean", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Image = table.Column<string>(type: "varchar(64)", nullable: true),
                    Slug = table.Column<string>(type: "varchar(191)", nullable: false),
                    Title = table.Column<string>(type: "varchar(191)", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    IsPublished = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Article_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "EmailVerification",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Code = table.Column<string>(type: "varchar(191)", nullable: false),
                    Token = table.Column<string>(type: "varchar(191)", nullable: false),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    IsExpired = table.Column<bool>(type: "boolean", nullable: false),
                    ExpiredAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailVerification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmailVerification_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Subject = table.Column<string>(type: "varchar(64)", nullable: false),
                    SortContent = table.Column<string>(type: "varchar(191)", nullable: false),
                    FullContent = table.Column<string>(type: "text", nullable: false),
                    ReadedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notification_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ArticleCategoryArticle",
                columns: table => new
                {
                    ArticleId = table.Column<long>(type: "bigint", nullable: false),
                    CategoriesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleCategoryArticle", x => new { x.ArticleId, x.CategoriesId });
                    table.ForeignKey(
                        name: "FK_ArticleCategoryArticle_Article_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ArticleCategoryArticle_CategoryArticle_CategoriesId",
                        column: x => x.CategoriesId,
                        principalTable: "CategoryArticle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ArticleComment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ArticleId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleComment_Article_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_ArticleComment_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_About_CreatedAt",
                table: "About",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_About_Image",
                table: "About",
                column: "Image");

            migrationBuilder.CreateIndex(
                name: "IX_About_Title",
                table: "About",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_About_UpdatedAt",
                table: "About",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Article_CreatedAt",
                table: "Article",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Article_Image",
                table: "Article",
                column: "Image");

            migrationBuilder.CreateIndex(
                name: "IX_Article_IsPublished",
                table: "Article",
                column: "IsPublished");

            migrationBuilder.CreateIndex(
                name: "IX_Article_Slug",
                table: "Article",
                column: "Slug");

            migrationBuilder.CreateIndex(
                name: "IX_Article_Title",
                table: "Article",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_Article_UpdatedAt",
                table: "Article",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Article_UserId",
                table: "Article",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCategoryArticle_CategoriesId",
                table: "ArticleCategoryArticle",
                column: "CategoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleComment_ArticleId",
                table: "ArticleComment",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleComment_CreatedAt",
                table: "ArticleComment",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleComment_UpdatedAt",
                table: "ArticleComment",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleComment_UserId",
                table: "ArticleComment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryArticle_CreatedAt",
                table: "CategoryArticle",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryArticle_Name",
                table: "CategoryArticle",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryArticle_UpdatedAt",
                table: "CategoryArticle",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryFaq_CreatedAt",
                table: "CategoryFaq",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryFaq_Name",
                table: "CategoryFaq",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryFaq_UpdatedAt",
                table: "CategoryFaq",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_CreatedAt",
                table: "CategoryProduct",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_Name",
                table: "CategoryProduct",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_UpdatedAt",
                table: "CategoryProduct",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProject_CreatedAt",
                table: "CategoryProject",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProject_Name",
                table: "CategoryProject",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProject_UpdatedAt",
                table: "CategoryProject",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_CreatedAt",
                table: "Contact",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_Email",
                table: "Contact",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_Name",
                table: "Contact",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_Phone",
                table: "Contact",
                column: "Phone");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_UpdatedAt",
                table: "Contact",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_Website",
                table: "Contact",
                column: "Website");

            migrationBuilder.CreateIndex(
                name: "IX_Country_Code",
                table: "Country",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_Country_CreatedAt",
                table: "Country",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Country_Name",
                table: "Country",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Country_UpdatedAt",
                table: "Country",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_EmailVerification_Code",
                table: "EmailVerification",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_EmailVerification_CreatedAt",
                table: "EmailVerification",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_EmailVerification_EmailConfirmed",
                table: "EmailVerification",
                column: "EmailConfirmed");

            migrationBuilder.CreateIndex(
                name: "IX_EmailVerification_ExpiredAt",
                table: "EmailVerification",
                column: "ExpiredAt");

            migrationBuilder.CreateIndex(
                name: "IX_EmailVerification_IsExpired",
                table: "EmailVerification",
                column: "IsExpired");

            migrationBuilder.CreateIndex(
                name: "IX_EmailVerification_Token",
                table: "EmailVerification",
                column: "Token");

            migrationBuilder.CreateIndex(
                name: "IX_EmailVerification_UpdatedAt",
                table: "EmailVerification",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_EmailVerification_UserId",
                table: "EmailVerification",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Faq_CategoryFaqId",
                table: "Faq",
                column: "CategoryFaqId");

            migrationBuilder.CreateIndex(
                name: "IX_Faq_CategoryId",
                table: "Faq",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Faq_CreatedAt",
                table: "Faq",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Faq_IsPublished",
                table: "Faq",
                column: "IsPublished");

            migrationBuilder.CreateIndex(
                name: "IX_Faq_Question",
                table: "Faq",
                column: "Question");

            migrationBuilder.CreateIndex(
                name: "IX_Faq_Sort",
                table: "Faq",
                column: "Sort");

            migrationBuilder.CreateIndex(
                name: "IX_Faq_UpdatedAt",
                table: "Faq",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Feature_CreatedAt",
                table: "Feature",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Feature_Icon",
                table: "Feature",
                column: "Icon");

            migrationBuilder.CreateIndex(
                name: "IX_Feature_IsPublished",
                table: "Feature",
                column: "IsPublished");

            migrationBuilder.CreateIndex(
                name: "IX_Feature_Title",
                table: "Feature",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_Feature_UpdatedAt",
                table: "Feature",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Message_CreatedAt",
                table: "Message",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Message_Email",
                table: "Message",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Message_FullName",
                table: "Message",
                column: "FullName");

            migrationBuilder.CreateIndex(
                name: "IX_Message_Phone",
                table: "Message",
                column: "Phone");

            migrationBuilder.CreateIndex(
                name: "IX_Message_UpdatedAt",
                table: "Message",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_CreatedAt",
                table: "Notification",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_ReadedAt",
                table: "Notification",
                column: "ReadedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_SortContent",
                table: "Notification",
                column: "SortContent");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_Subject",
                table: "Notification",
                column: "Subject");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_UpdatedAt",
                table: "Notification",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_UserId",
                table: "Notification",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CreatedAt",
                table: "Product",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Image",
                table: "Product",
                column: "Image");

            migrationBuilder.CreateIndex(
                name: "IX_Product_IsPublished",
                table: "Product",
                column: "IsPublished");

            migrationBuilder.CreateIndex(
                name: "IX_Product_Price",
                table: "Product",
                column: "Price");

            migrationBuilder.CreateIndex(
                name: "IX_Product_UpdatedAt",
                table: "Product",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Project_CategoryId",
                table: "Project",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Project_CreatedAt",
                table: "Project",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Project_Image",
                table: "Project",
                column: "Image");

            migrationBuilder.CreateIndex(
                name: "IX_Project_IsPublished",
                table: "Project",
                column: "IsPublished");

            migrationBuilder.CreateIndex(
                name: "IX_Project_UpdatedAt",
                table: "Project",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Team_CreatedAt",
                table: "Team",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Team_Image",
                table: "Team",
                column: "Image");

            migrationBuilder.CreateIndex(
                name: "IX_Team_IsPublished",
                table: "Team",
                column: "IsPublished");

            migrationBuilder.CreateIndex(
                name: "IX_Team_Name",
                table: "Team",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Team_Position",
                table: "Team",
                column: "Position");

            migrationBuilder.CreateIndex(
                name: "IX_Team_UpdatedAt",
                table: "Team",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_User_City",
                table: "User",
                column: "City");

            migrationBuilder.CreateIndex(
                name: "IX_User_CountryId",
                table: "User",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_User_CreatedAt",
                table: "User",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_User_IsAdmin",
                table: "User",
                column: "IsAdmin");

            migrationBuilder.CreateIndex(
                name: "IX_User_Phone",
                table: "User",
                column: "Phone");

            migrationBuilder.CreateIndex(
                name: "IX_User_Status",
                table: "User",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_User_UpdatedAt",
                table: "User",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_User_Username",
                table: "User",
                column: "Username");

            migrationBuilder.CreateIndex(
                name: "IX_User_ZipCode",
                table: "User",
                column: "ZipCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "About");

            migrationBuilder.DropTable(
                name: "ArticleCategoryArticle");

            migrationBuilder.DropTable(
                name: "ArticleComment");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "EmailVerification");

            migrationBuilder.DropTable(
                name: "Faq");

            migrationBuilder.DropTable(
                name: "Feature");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropTable(
                name: "CategoryArticle");

            migrationBuilder.DropTable(
                name: "CategoryFaq");

            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.DropTable(
                name: "CategoryProject");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
