using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _3S.Task.Persistence.Migrations.ApplicationWriteDb
{
    public partial class addTriggersAndLookUps : Migration
    {
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql(@"
            CREATE TRIGGER createGovCountRecordOn
            ON Governate
            AFTER INSERT
            AS
            BEGIN
                INSERT INTO UsersGovsCounts (GovName, GovernateId, Count)
                SELECT GovernateName, Id, 0
                FROM inserted;
            END;
        ");

			migrationBuilder.Sql(@"
            CREATE TRIGGER IncrementGovernateCountOnAddressInsert
                    ON Address
                AFTER INSERT
                AS
                BEGIN
                    UPDATE UsersGovsCounts
                    SET Count = Count + 1
                    FROM UsersGovsCounts
                    INNER JOIN inserted ON UsersGovsCounts.GovernateId = inserted.GovernateId;
                END;
        ");

            migrationBuilder.Sql(@"
			      
			         INSERT INTO Governate ( GovernateName) VALUES ('Cairo');
			         INSERT INTO Governate ( GovernateName) VALUES ('Alexandria');
			         INSERT INTO Governate ( GovernateName) VALUES ('Giza');

			         

			         
			         INSERT INTO City ( CityName, GovernateId) VALUES ('Cairo City', 1);
			         INSERT INTO City ( CityName, GovernateId) VALUES ('Giza City', 3);
			         INSERT INTO City ( CityName, GovernateId) VALUES ('Alexandria City', 2);

			      
			     ");
        }

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.Sql("DROP TRIGGER createGovCountRecordOn");
			migrationBuilder.Sql("DROP TRIGGER IncrementGovernateCountOnAddressInsert");
			migrationBuilder.Sql(@"
            DELETE FROM City;
            DELETE FROM Governate;
        ");

		}
	}
}
