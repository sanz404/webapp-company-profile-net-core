using Microsoft.EntityFrameworkCore.Migrations;
using Newtonsoft.Json.Linq;
using Slugify;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Backend.Migrations
{
    public partial class SeedTables : Migration
    {

        static string DEFAULT_ADMIN_USERNAME = "admin";
        static string DEFAULT_ADMIN_EMAIL = "admin@devel.com";
        static string DEFAULT_PASSWORD = "5ecReT!";

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            this.SeedAbout(migrationBuilder);
            this.SeedCountry(migrationBuilder);
            this.SeedCategoryArticle(migrationBuilder);
            this.SeedCategoryFaq(migrationBuilder);
            this.SeedCategoryProduct(migrationBuilder);
            this.SeedCategoryProject(migrationBuilder);
            this.SeedContact(migrationBuilder);
            this.SeedContent(migrationBuilder);
            this.SeedFeature(migrationBuilder);
            this.SeedMessage(migrationBuilder);
            this.SeedTeam(migrationBuilder);
            this.SeedProduct(migrationBuilder);
            this.SeedProject(migrationBuilder);
            this.SeedFaq(migrationBuilder);
            this.SeedUser(migrationBuilder);
            this.SeedNotification(migrationBuilder);
            this.SeedArticle(migrationBuilder);
        }

       
        private void SeedUser(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"public\".\"EmailVerification\" ");
            migrationBuilder.Sql("DELETE FROM \"public\".\"User\" ");

            int max = 100;
            int num = 1;
           
            while (num < max)
            {
                var Email = num == 1 ? DEFAULT_ADMIN_USERNAME : Faker.Internet.Email();
                var UserName = num == 1 ? DEFAULT_ADMIN_EMAIL :  Faker.Internet.UserName();
                var IsAdmin = num == 1 ? "true" : "false";
                var Country = "SELECT \"public\".\"Country\".\"Id\" FROM \"public\".\"Country\" ORDER BY RANDOM() LIMIT 1";
                var Values = "" +
                    "(" + Country + ")," +
                    "'" + UserName + "'," +
                    "'" + Email + "'," +
                    "'" + Faker.Phone.Number() + "'," +
                    "'" + Faker.Address.StreetAddress().Replace("'", "") + "'," +
                    "'" + Faker.Address.StreetAddress().Replace("'", "") + "'," +
                    "'" + Faker.Address.City().Replace("'", "") + "'," +
                    "'" + Faker.Address.ZipCode() + "'," +
                    "'" + BCrypt.Net.BCrypt.HashPassword(DEFAULT_PASSWORD) + "'," +
                    "'" + BCrypt.Net.BCrypt.HashPassword(Email) + "'," +
                    ""  + IsAdmin+"," +
                    "true," +
                    "'" + DateTime.Now + "',"+
                    "'" + DateTime.Now + "'";

                migrationBuilder.Sql("INSERT INTO  \"public\".\"User\" (" +
                    "\"CountryId\" , " +
                    "\"Username\" ,  " +
                    "\"Email\" , " +
                    "\"Phone\", " +
                    "\"Address1\", " +
                    "\"Address2\", " +
                    "\"City\", " +
                    "\"ZipCode\", " +
                    "\"Password\", " +
                    "\"Token\" , " +
                    "\"IsAdmin\" , " +
                    "\"Status\" , " +
                    "\"CreatedAt\" , " +
                    "\"UpdatedAt\" " +
                ") VALUES ("+Values+")");

                num++;
            }

        }

        private void SeedNotification(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"public\".\"Notification\" ");

            int max = 100;
            int num = 1;

            while(num < max)
            {
                var User = "SELECT \"public\".\"User\".\"Id\" FROM \"public\".\"User\" ORDER BY RANDOM() LIMIT 1";

                var Values = "" +
                  "(" + User + ")," +
                  "'" + Faker.Company.Name().Replace("'", "") + "'," +
                  "'" + Faker.Lorem.Sentence().Replace("'", "") + "'," +
                  "'" + Faker.Lorem.Paragraph(5).Replace("'", "") + "'," +
                  "'" + DateTime.Now + "'," +
                  "'" + DateTime.Now + "'";

                migrationBuilder.Sql("INSERT INTO  \"public\".\"Notification\" (" +
                    "\"UserId\" , " +
                    "\"Subject\" ,  " +
                    "\"SortContent\" , " +
                    "\"FullContent\", " +
                    "\"CreatedAt\" , " +
                    "\"UpdatedAt\" " +
                ") VALUES (" + Values + ")");

                num++;
            }
        }


        private void SeedArticle(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"public\".\"ArticleCategoryArticle\" ");
            migrationBuilder.Sql("DELETE FROM \"public\".\"ArticleComment\" ");
            migrationBuilder.Sql("DELETE FROM \"public\".\"Article\" ");
          

            int max = 100;
            int num = 1;

            while (num < max)
            {
                SlugHelper helper = new SlugHelper();
                var User = "SELECT \"public\".\"User\".\"Id\" FROM \"public\".\"User\" WHERE \"public\".\"User\".\"IsAdmin\" = true LIMIT 1";
                var Title = Faker.Lorem.Sentence().Replace("'", "");
                var Slug = helper.GenerateSlug(Title);

                var Values = "" +
                  "(" + User + ")," +
                  "'" + Slug + "'," +
                  "'" + Title + "'," +
                  "'" + Faker.Lorem.Paragraph(5).Replace("'", "") + "'," +
                  "true," +
                  "'" + DateTime.Now + "'," +
                  "'" + DateTime.Now + "'";

                migrationBuilder.Sql("INSERT INTO  \"public\".\"Article\" (" +
                    "\"UserId\" , " +
                    "\"Slug\" ,  " +
                    "\"Title\" , " +
                    "\"Content\", " +
                    "\"IsPublished\", " +
                    "\"CreatedAt\" , " +
                    "\"UpdatedAt\" " +
                ") VALUES (" + Values + ")");

                var Category = "SELECT \"public\".\"CategoryArticle\".\"Id\" FROM \"public\".\"CategoryArticle\" ORDER BY RANDOM() LIMIT 1";
                var Article = "SELECT \"public\".\"Article\".\"Id\" FROM \"public\".\"Article\" WHERE \"public\".\"Article\".\"Id\" NOT IN (SELECT \"public\".\"ArticleCategoryArticle\".\"ArticleId\" FROM \"public\".\"ArticleCategoryArticle\") ORDER BY RANDOM() LIMIT 1";
                migrationBuilder.Sql("INSERT INTO \"public\".\"ArticleCategoryArticle\" (\"ArticleId\" , \"CategoriesId\") VALUES (("+Article+") , ("+Category+"))");

                num++;
            }


        }

        private void SeedFaq(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"public\".\"Faq\" ");
            var myJsonString = File.ReadAllText("Storages/json/faqs.json");
            dynamic jToken = JToken.Parse(myJsonString);
            var Data = jToken.Value<Object>("RECORDS");
            List<Object> ListData = Data.ToObject<List<Object>>();
            for (int i = 0; i < ListData.Count; i++)
            {
                var row = ListData[i];
                var item = JObject.FromObject(row);
                var Category = "SELECT \"public\".\"CategoryFaq\".\"Id\" FROM \"public\".\"CategoryFaq\" ORDER BY RANDOM() LIMIT 1";
                migrationBuilder.Sql("" +
                    "INSERT INTO  \"public\".\"Faq\" (\"CategoryId\" , \"Question\" ,  \"Answer\" , \"Sort\", \"IsPublished\" , \"CreatedAt\" , \"UpdatedAt\" )" +
                    " VALUES ((" + Category + "), '" + item.GetValue("question").ToString() + "',  '"+Faker.Lorem.Paragraph(5)+"',"+i+", true, '" + DateTime.Now + "', '" + DateTime.Now + "')");
            }
        }

        private void SeedProject(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"public\".\"Project\" ");
            var myJsonString = File.ReadAllText("Storages/json/projects.json");
            dynamic jToken = JToken.Parse(myJsonString);
            var Data = jToken.Value<Object>("RECORDS");
            List<Object> ListData = Data.ToObject<List<Object>>();
            for (int i = 0; i < ListData.Count; i++)
            {
                var row = ListData[i];
                var item = JObject.FromObject(row);
                var Category = "SELECT \"public\".\"CategoryProject\".\"Id\" FROM \"public\".\"CategoryProject\" ORDER BY RANDOM() LIMIT 1";
                migrationBuilder.Sql("" +
                    "INSERT INTO  \"public\".\"Project\" (\"CategoryId\" , \"Name\" ,  \"Description\" , \"IsPublished\" , \"CreatedAt\" , \"UpdatedAt\" )" +
                    " VALUES ((" + Category + "), '" + item.GetValue("name").ToString() + "',  '" + item.GetValue("description").ToString() + "', true, '" + DateTime.Now + "', '" + DateTime.Now + "')");
            }
        }


        private void SeedProduct(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"public\".\"Product\" ");
            var myJsonString = File.ReadAllText("Storages/json/products.json");
            dynamic jToken = JToken.Parse(myJsonString);
            var Data = jToken.Value<Object>("RECORDS");
            List<Object> ListData = Data.ToObject<List<Object>>();
            for (int i = 0; i < ListData.Count; i++)
            {
                var row = ListData[i];
                var item = JObject.FromObject(row);
                var Category = "SELECT \"public\".\"CategoryProduct\".\"Id\" FROM \"public\".\"CategoryProduct\" ORDER BY RANDOM() LIMIT 1";
               
                migrationBuilder.Sql("" +
                    "INSERT INTO  \"public\".\"Product\" (\"CategoryId\" , \"Name\" , \"Price\" , \"Description\" , \"IsPublished\" , \"CreatedAt\" , \"UpdatedAt\" )" +
                    " VALUES ((" + Category + "), '" + item.GetValue("name").ToString()+"', "+ item.GetValue("price").ToString()+ ", '" + item.GetValue("description").ToString() + "', true, '" + DateTime.Now + "', '" + DateTime.Now + "')");
            }
        }

        private void SeedTeam(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"public\".\"Team\" ");
            var myJsonString = File.ReadAllText("Storages/json/teams.json");
            dynamic jToken = JToken.Parse(myJsonString);
            var Data = jToken.Value<Object>("RECORDS");
            List<Object> ListData = Data.ToObject<List<Object>>();
            for (int i = 0; i < ListData.Count; i++)
            {
                var row = ListData[i];
                var item = JObject.FromObject(row);
                migrationBuilder.InsertData(
                    table: "Team",
                    columns: new[] {  "Name", "Position", "Description", "IsPublished", "CreatedAt", "UpdatedAt" },
                    values: new object[]
                    {
                        item.GetValue("name").ToString(),
                        item.GetValue("position").ToString().Replace("'", ""),
                        item.GetValue("description").ToString().Replace("'", ""),
                        true,
                        DateTime.Now,
                        DateTime.Now
                    }
                );
            }
        }

        private void SeedMessage(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"public\".\"Message\" ");
            var myJsonString = File.ReadAllText("Storages/json/messages.json");
            dynamic jToken = JToken.Parse(myJsonString);
            var Data = jToken.Value<Object>("RECORDS");
            List<Object> ListData = Data.ToObject<List<Object>>();
            for (int i = 0; i < ListData.Count; i++)
            {
                var row = ListData[i];
                var item = JObject.FromObject(row);
                migrationBuilder.InsertData(
                    table: "Message",
                    columns: new[] { "FullName", "Email", "Phone", "Content", "CreatedAt", "UpdatedAt" },
                    values: new object[]
                    {
                        item.GetValue("full_name").ToString().Replace("'", ""),
                        item.GetValue("email").ToString().Replace("'", ""),
                        item.GetValue("phone").ToString().Replace("'", ""),
                        item.GetValue("message").ToString().Replace("'", ""),
                        DateTime.Now,
                        DateTime.Now
                    }
                );
            }
        }

        private void SeedFeature(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"public\".\"Feature\" ");
            var myJsonString = File.ReadAllText("Storages/json/features.json");
            dynamic jToken = JToken.Parse(myJsonString);
            var Data = jToken.Value<Object>("RECORDS");
            List<Object> ListData = Data.ToObject<List<Object>>();
            for (int i = 0; i < ListData.Count; i++)
            {
                var row = ListData[i];
                var item = JObject.FromObject(row);
                migrationBuilder.InsertData(
                    table: "Feature",
                    columns: new[] { "Title", "Description", "IsPublished", "CreatedAt", "UpdatedAt" },
                    values: new object[]
                    {
                        item.GetValue("title").ToString(),
                        item.GetValue("description").ToString(),
                        true,
                        DateTime.Now,
                        DateTime.Now
                    }
                );
            }
        }

        private void SeedContent(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"public\".\"Content\" ");
            var myJsonString = File.ReadAllText("Storages/json/contents.json");
            dynamic jToken = JToken.Parse(myJsonString);
            var Data = jToken.Value<Object>("RECORDS");
            List<Object> ListData = Data.ToObject<List<Object>>();
            for (int i = 0; i < ListData.Count; i++)
            {
                var row = ListData[i];
                var item = JObject.FromObject(row);
                migrationBuilder.InsertData(
                    table: "Content",
                    columns: new[] { "KeyName", "KeyValue", "CreatedAt", "UpdatedAt" },
                    values: new object[]
                    {
                        item.GetValue("key_name").ToString().Replace("'", ""),
                        item.GetValue("key_value").ToString().Replace("'", ""),
                        DateTime.Now,
                        DateTime.Now
                    }
                );
            }
        }

        private void SeedContact(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"public\".\"Contact\" ");
            var myJsonString = File.ReadAllText("Storages/json/contacts.json");
            dynamic jToken = JToken.Parse(myJsonString);
            var Data = jToken.Value<Object>("RECORDS");
            List<Object> ListData = Data.ToObject<List<Object>>();
            for (int i = 0; i < ListData.Count; i++)
            {
                var row = ListData[i];
                var item = JObject.FromObject(row);
                migrationBuilder.InsertData(
                    table: "Contact",
                    columns: new[] { "Name", "Email", "Phone", "Website", "Address", "CreatedAt", "UpdatedAt" },
                    values: new object[]
                    {
                        item.GetValue("name").ToString().Replace("'", ""),
                        item.GetValue("email").ToString().Replace("'", ""),
                        item.GetValue("phone").ToString().Replace("'", ""),
                        item.GetValue("website").ToString().Replace("'", ""),
                        item.GetValue("address").ToString().Replace("'", ""),
                        DateTime.Now,
                        DateTime.Now
                    }
                );
            }
        }

        private void SeedCategoryProject(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"public\".\"CategoryProject\" ");
            var myJsonString = File.ReadAllText("Storages/json/category_projects.json");
            dynamic jToken = JToken.Parse(myJsonString);
            var Data = jToken.Value<Object>("RECORDS");
            List<Object> ListData = Data.ToObject<List<Object>>();
            for (int i = 0; i < ListData.Count; i++)
            {
                var row = ListData[i];
                var item = JObject.FromObject(row);
                migrationBuilder.InsertData(
                    table: "CategoryProject",
                    columns: new[] { "Name", "Description", "CreatedAt", "UpdatedAt" },
                    values: new object[]
                    {
                        item.GetValue("name").ToString(),
                        item.GetValue("description").ToString(),
                        DateTime.Now,
                        DateTime.Now
                    }
                );
            }
        }

        private void SeedCategoryProduct(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"public\".\"CategoryProduct\" ");
            var myJsonString = File.ReadAllText("Storages/json/category_products.json");
            dynamic jToken = JToken.Parse(myJsonString);
            var Data = jToken.Value<Object>("RECORDS");
            List<Object> ListData = Data.ToObject<List<Object>>();
            for (int i = 0; i < ListData.Count; i++)
            {
                var row = ListData[i];
                var item = JObject.FromObject(row);
                migrationBuilder.InsertData(
                    table: "CategoryProduct",
                    columns: new[] { "Name", "Description", "CreatedAt", "UpdatedAt" },
                    values: new object[]
                    {
                        item.GetValue("name").ToString(),
                        item.GetValue("description").ToString(),
                        DateTime.Now,
                        DateTime.Now
                    }
                );
            }
        }

        private void SeedCategoryFaq(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"public\".\"CategoryFaq\" ");
            var myJsonString = File.ReadAllText("Storages/json/category_faqs.json");
            dynamic jToken = JToken.Parse(myJsonString);
            var Data = jToken.Value<Object>("RECORDS");
            List<Object> ListData = Data.ToObject<List<Object>>();
            for (int i = 0; i < ListData.Count; i++)
            {
                var row = ListData[i];
                var item = JObject.FromObject(row);
                migrationBuilder.InsertData(
                    table: "CategoryFaq",
                    columns: new[] { "Name", "Description", "CreatedAt", "UpdatedAt" },
                    values: new object[]
                    {
                        item.GetValue("name").ToString(),
                        item.GetValue("description").ToString(),
                        DateTime.Now,
                        DateTime.Now
                    }
                );
            }
        }

        private void SeedCategoryArticle(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"public\".\"CategoryArticle\" ");
            var myJsonString = File.ReadAllText("Storages/json/category_articles.json");
            dynamic jToken = JToken.Parse(myJsonString);
            var Data = jToken.Value<Object>("RECORDS");
            List<Object> ListData = Data.ToObject<List<Object>>();
            for (int i = 0; i < ListData.Count; i++)
            {
                var row = ListData[i];
                var item = JObject.FromObject(row);
                migrationBuilder.InsertData(
                    table: "CategoryArticle",
                    columns: new[] { "Name", "Description", "CreatedAt", "UpdatedAt" },
                    values: new object[]
                    {
                        item.GetValue("name").ToString(),
                        item.GetValue("description").ToString(),
                        DateTime.Now,
                        DateTime.Now
                    }
                );
            }
        }

      
        private void SeedCountry(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"public\".\"Country\" ");
            var myJsonString = File.ReadAllText("Storages/json/countries.json");
            dynamic jToken = JToken.Parse(myJsonString);
            var Data = jToken.Value<Object>("ref_country_codes");
            List<Object> ListData = Data.ToObject<List<Object>>();
            for (int i = 0; i < ListData.Count; i++)
            {
                var row = ListData[i];
                var item = JObject.FromObject(row);
                var code = item.GetValue("alpha2").ToString();
                var name = item.GetValue("country").ToString();
                migrationBuilder.InsertData(
                    table: "Country",
                    columns: new[] { "Code", "Name", "CreatedAt", "UpdatedAt" },
                    values: new object[]
                    {
                        code.Replace("'", ""),
                        name.Replace("'", ""),
                        DateTime.Now,
                        DateTime.Now
                    }
                );
            }
        }

        private void SeedAbout(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"public\".\"About\" ");
            var myJsonString = File.ReadAllText("Storages/json/abouts.json");
            dynamic jToken = JToken.Parse(myJsonString);
            var Data = jToken.Value<Object>("RECORDS");
            List<Object> ListData = Data.ToObject<List<Object>>();
            for (int i = 0; i < ListData.Count; i++)
            {
                var row = ListData[i];
                var item = JObject.FromObject(row);
                var title = item.GetValue("title").ToString();
                var description = item.GetValue("description").ToString();
                migrationBuilder.InsertData(
                    table: "About",
                    columns: new[] { "Title", "Description", "IsPublished", "CreatedAt", "UpdatedAt" },
                    values: new object[]
                    {
                        title,
                        description,
                        true,
                        DateTime.Now,
                        DateTime.Now
                    }
                );
            }
        }

        
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }

    }
}
