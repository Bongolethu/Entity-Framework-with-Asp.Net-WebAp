using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Primitives;
using System.Text;

namespace EntityFrameworkUnitTestingWithAspNetWebApi.Migrations
{
    public partial class IndexIDnumberField : Migration
    {
        private StringBuilder _sqlScript;
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            //Create Index
            _sqlScript = new StringBuilder();
            //Update column size, to able to be indexed, because i did not cator for this in my Annotations.
            //I will not be dropping this change if something goes wrong.
            _sqlScript.Append(@" ALTER TABLE [Person]  ALTER COLUMN IDNumber NVARCHAR(500) NOT NULL ;");
            _sqlScript.Append(@" CREATE INDEX idx_Person_idnumber ");
            _sqlScript.Append(@" ON dbo.Person(idnumber); ");
            //I will be dropping this index if something goes wrong

            migrationBuilder.Sql(_sqlScript.ToString());
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //Drop Index
            _sqlScript = new StringBuilder();
            _sqlScript.Append("BEGIN                                                                  "); 
            _sqlScript.Append("     IF EXISTS(SELECT * FROM sys.indexes  WHERE name = 'idx_Person_idnumber'         ");
            _sqlScript.Append("                 AND object_id = OBJECT_ID('[dbo].[Person]'))                  ");
            _sqlScript.Append("     BEGIN                                                                  ");
            _sqlScript.Append("     DROP INDEX[idx_Person_idnumber] ON[dbo].[Person];                      ");
            _sqlScript.Append(" END                                                                    ");
            _sqlScript.Append("                                                                       ");
            _sqlScript.Append("END");
        }
    }
}
