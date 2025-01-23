using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnlineSurvey.Repos.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Objective",
                columns: table => new
                {
                    ObjectiveID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FocusArea = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    ExpectedWeight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objective", x => x.ObjectiveID);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    QuestionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionDescription = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.QuestionID);
                });

            migrationBuilder.CreateTable(
                name: "Respondent",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    RoleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respondent", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "RespondentResult",
                columns: table => new
                {
                    ResponseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    QuestionID = table.Column<int>(type: "int", nullable: false),
                    ResponseWeight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespondentResult", x => x.ResponseID);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.RoleID);
                });

            migrationBuilder.InsertData(
                table: "Objective",
                columns: new[] { "ObjectiveID", "ExpectedWeight", "FocusArea" },
                values: new object[,]
                {
                    { 1, 8, "Internal Meetings" },
                    { 2, 8, "Client Meetings" },
                    { 3, 5, "Emails & Phone / Skype calls" },
                    { 4, 5, "Research" },
                    { 5, 2, "DB Design" },
                    { 6, 5, "Architecture Design and Planning" },
                    { 7, 30, "Back-end Development" },
                    { 8, 22, "Front-end Development" },
                    { 9, 5, "Integration" },
                    { 10, 10, "Testing" }
                });

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "QuestionID", "QuestionDescription" },
                values: new object[,]
                {
                    { 1, "Internal Meetings" },
                    { 2, "Client Meetings" },
                    { 3, "Emails & Phone / Skype calls" },
                    { 4, "Research" },
                    { 5, "DB Design" },
                    { 6, "Architecture Design and Planning" },
                    { 7, "Back-end Development" },
                    { 8, "Front-end Development" },
                    { 9, "Integration" },
                    { 10, "Testing" }
                });

            migrationBuilder.InsertData(
                table: "Respondent",
                columns: new[] { "UserID", "Password", "RoleID", "UserName" },
                values: new object[,]
                {
                    { 1, "Smith", 1, "Marcell" },
                    { 2, "Snow", 2, "John" },
                    { 3, "Eleven", 2, "Kevin" },
                    { 4, "DuoLingo", 2, "Joe" },
                    { 5, "Watermellons", 2, "Carl" }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleID", "RoleName" },
                values: new object[,]
                {
                    { 1, "Administrator" },
                    { 2, "Worker" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Objective");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Respondent");

            migrationBuilder.DropTable(
                name: "RespondentResult");

            migrationBuilder.DropTable(
                name: "UserRole");
        }
    }
}
