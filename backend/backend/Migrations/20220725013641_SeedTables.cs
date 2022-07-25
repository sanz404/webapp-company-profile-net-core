using Microsoft.EntityFrameworkCore.Migrations;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace Backend.Migrations
{
    public partial class SeedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // this.SeedAbout(migrationBuilder);
            // this.SeedCountry(migrationBuilder);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }

        private void SeedCountry(MigrationBuilder migrationBuilder)
        {
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
                        code,
                        name,
                        DateTime.Now,
                        DateTime.Now
                    }
                );
            }
        }

        private void SeedAbout(MigrationBuilder migrationBuilder)
        {
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
    }
}
