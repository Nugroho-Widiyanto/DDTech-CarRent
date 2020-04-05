using Microsoft.EntityFrameworkCore.Migrations;

namespace CarRent.Core.Migrations
{
    public partial class SeedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO [dbo].[Cars]([Plate],[Make],[Model],[Capacity],[Year]) VALUES('B2009ABC','Honda','Jazz','5','2009')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Cars]([Plate],[Make],[Model],[Capacity],[Year]) VALUES('B2010ABC','Suzuki','Ertiga','7','2010')");
            migrationBuilder.Sql("INSERT INTO [dbo].[Cars]([Plate],[Make],[Model],[Capacity],[Year]) VALUES('B2011ABC','Toyota','Innova','8','2011')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [dbo].[Cars]");
        }
    }
}
