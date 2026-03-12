using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DemoApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddWolverineEnvelopeStorage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(name: "wolverine");

            migrationBuilder.CreateTable(
                name: "wolverine_incoming_envelopes",
                schema: "wolverine",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    attempts = table.Column<int>(type: "int", nullable: false),
                    body = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    execution_time = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    keep_until = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    message_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    owner_id = table.Column<int>(type: "int", nullable: false),
                    received_at = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table => table.PrimaryKey("PK_wolverine_incoming_envelopes", x => x.id));

            migrationBuilder.CreateTable(
                name: "wolverine_outgoing_envelopes",
                schema: "wolverine",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    attempts = table.Column<int>(type: "int", nullable: false),
                    body = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    deliver_by = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    destination = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    message_type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    owner_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table => table.PrimaryKey("PK_wolverine_outgoing_envelopes", x => x.id));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "wolverine_incoming_envelopes", schema: "wolverine");
            migrationBuilder.DropTable(name: "wolverine_outgoing_envelopes", schema: "wolverine");
            migrationBuilder.DropSchema(name: "wolverine");
        }
    }
}
