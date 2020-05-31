using Microsoft.EntityFrameworkCore.Migrations;

namespace Assignment2.Migrations
{
    public partial class SeedGendreAndRelationshipTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Genders (Type) " +
                              "VALUES ('Male')," +
                              "('Female')");

            migrationBuilder.Sql("INSERT INTO Relationships (Type) " +
                                 "VALUES ('Self')," +
                                 "('Spouse')," +
                                 "('Son')," +
                                 "('Daughter')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Gendres WHERE Id IN (1,2)");

            migrationBuilder.Sql("DELETE FROM Relationships WHERE Id IN (1,2,3,4)");
        }
    }
}
