using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VoteService.Migrations
{
    public partial class Added_pollId_in_votes_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PollId",
                table: "Votes",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PollId",
                table: "Votes");
        }
    }
}
