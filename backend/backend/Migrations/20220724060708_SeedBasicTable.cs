using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Backend.Migrations
{
    public partial class SeedBasicTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            int max = 100;
            int i = 1;
            while(i <= max)
            {
                migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Name", "Email", "Website", "Phone", "Address", "CreatedAt", "UpdatedAt" },
                values: new object[]
                {
                    Faker.Name.FullName(),
                    Faker.Internet.Email(),
                    Faker.Internet.DomainName(),
                    Faker.Phone.Number(),
                    Faker.Address.StreetAddress(), 
                    DateTime.Now, 
                    DateTime.Now
                }
            );
                i++;
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Contacts", true);
        }
    }
}
