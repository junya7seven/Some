using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Quest_QuestId",
                table: "Enrollment");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollment_Warrior_WarriorId",
                table: "Enrollment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Warrior",
                table: "Warrior");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quest",
                table: "Quest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrollment",
                table: "Enrollment");

            migrationBuilder.RenameTable(
                name: "Warrior",
                newName: "Warriors");

            migrationBuilder.RenameTable(
                name: "Quest",
                newName: "Quests");

            migrationBuilder.RenameTable(
                name: "Enrollment",
                newName: "Enrollments");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollment_WarriorId",
                table: "Enrollments",
                newName: "IX_Enrollments_WarriorId");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollment_QuestId",
                table: "Enrollments",
                newName: "IX_Enrollments_QuestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Warriors",
                table: "Warriors",
                column: "WarriorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quests",
                table: "Quests",
                column: "QuestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrollments",
                table: "Enrollments",
                column: "EnrollmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Quests_QuestId",
                table: "Enrollments",
                column: "QuestId",
                principalTable: "Quests",
                principalColumn: "QuestId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollments_Warriors_WarriorId",
                table: "Enrollments",
                column: "WarriorId",
                principalTable: "Warriors",
                principalColumn: "WarriorId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Quests_QuestId",
                table: "Enrollments");

            migrationBuilder.DropForeignKey(
                name: "FK_Enrollments_Warriors_WarriorId",
                table: "Enrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Warriors",
                table: "Warriors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Quests",
                table: "Quests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrollments",
                table: "Enrollments");

            migrationBuilder.RenameTable(
                name: "Warriors",
                newName: "Warrior");

            migrationBuilder.RenameTable(
                name: "Quests",
                newName: "Quest");

            migrationBuilder.RenameTable(
                name: "Enrollments",
                newName: "Enrollment");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_WarriorId",
                table: "Enrollment",
                newName: "IX_Enrollment_WarriorId");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_QuestId",
                table: "Enrollment",
                newName: "IX_Enrollment_QuestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Warrior",
                table: "Warrior",
                column: "WarriorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quest",
                table: "Quest",
                column: "QuestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrollment",
                table: "Enrollment",
                column: "EnrollmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Quest_QuestId",
                table: "Enrollment",
                column: "QuestId",
                principalTable: "Quest",
                principalColumn: "QuestId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enrollment_Warrior_WarriorId",
                table: "Enrollment",
                column: "WarriorId",
                principalTable: "Warrior",
                principalColumn: "WarriorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
