using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WSArtemisaApi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSchema2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropColumn(
                name: "account",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "branch",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "deleted_at",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "issuer",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "operation_type",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "pos",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "reference",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "response",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "response_code",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "transaction_date",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "seller_business_phone_number",
                table: "merchant");

            migrationBuilder.DropColumn(
                name: "seller_business_registration_number",
                table: "merchant");

            migrationBuilder.DropColumn(
                name: "seller_currency_code",
                table: "merchant");

            migrationBuilder.DropColumn(
                name: "seller_dba_name",
                table: "merchant");

            migrationBuilder.RenameColumn(
                name: "address_id",
                table: "users",
                newName: "card_brand_id");

            migrationBuilder.RenameColumn(
                name: "created_at",
                table: "transactions",
                newName: "transaction_time");

            migrationBuilder.RenameColumn(
                name: "seller_url",
                table: "merchant",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "seller_status",
                table: "merchant",
                newName: "rfc");

            migrationBuilder.RenameColumn(
                name: "seller_mcc",
                table: "merchant",
                newName: "phone_number");

            migrationBuilder.RenameColumn(
                name: "seller_legal_name",
                table: "merchant",
                newName: "legal_name");

            migrationBuilder.RenameColumn(
                name: "seller_id",
                table: "merchant",
                newName: "identifier");

            migrationBuilder.RenameColumn(
                name: "seller_email_address",
                table: "merchant",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "brand",
                table: "card_brand",
                newName: "brandName");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<string>(
                name: "last_name",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "wallet",
                table: "users",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "from_card_brand_id",
                table: "transactions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "from_user_id",
                table: "transactions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "to_card_brand_id",
                table: "transactions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "to_user_id",
                table: "transactions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_users_card_brand_id",
                table: "users",
                column: "card_brand_id");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_from_card_brand_id",
                table: "transactions",
                column: "from_card_brand_id");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_from_user_id",
                table: "transactions",
                column: "from_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_to_card_brand_id",
                table: "transactions",
                column: "to_card_brand_id");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_to_user_id",
                table: "transactions",
                column: "to_user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_card_brand_from_card_brand_id",
                table: "transactions",
                column: "from_card_brand_id",
                principalTable: "card_brand",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_card_brand_to_card_brand_id",
                table: "transactions",
                column: "to_card_brand_id",
                principalTable: "card_brand",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_users_from_user_id",
                table: "transactions",
                column: "from_user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_transactions_users_to_user_id",
                table: "transactions",
                column: "to_user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_users_card_brand_card_brand_id",
                table: "users",
                column: "card_brand_id",
                principalTable: "card_brand",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_transactions_card_brand_from_card_brand_id",
                table: "transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_transactions_card_brand_to_card_brand_id",
                table: "transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_transactions_users_from_user_id",
                table: "transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_transactions_users_to_user_id",
                table: "transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_users_card_brand_card_brand_id",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_users_card_brand_id",
                table: "users");

            migrationBuilder.DropIndex(
                name: "IX_transactions_from_card_brand_id",
                table: "transactions");

            migrationBuilder.DropIndex(
                name: "IX_transactions_from_user_id",
                table: "transactions");

            migrationBuilder.DropIndex(
                name: "IX_transactions_to_card_brand_id",
                table: "transactions");

            migrationBuilder.DropIndex(
                name: "IX_transactions_to_user_id",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "last_name",
                table: "users");

            migrationBuilder.DropColumn(
                name: "name",
                table: "users");

            migrationBuilder.DropColumn(
                name: "wallet",
                table: "users");

            migrationBuilder.DropColumn(
                name: "from_card_brand_id",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "from_user_id",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "to_card_brand_id",
                table: "transactions");

            migrationBuilder.DropColumn(
                name: "to_user_id",
                table: "transactions");

            migrationBuilder.RenameColumn(
                name: "card_brand_id",
                table: "users",
                newName: "address_id");

            migrationBuilder.RenameColumn(
                name: "transaction_time",
                table: "transactions",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "merchant",
                newName: "seller_url");

            migrationBuilder.RenameColumn(
                name: "rfc",
                table: "merchant",
                newName: "seller_status");

            migrationBuilder.RenameColumn(
                name: "phone_number",
                table: "merchant",
                newName: "seller_mcc");

            migrationBuilder.RenameColumn(
                name: "legal_name",
                table: "merchant",
                newName: "seller_legal_name");

            migrationBuilder.RenameColumn(
                name: "identifier",
                table: "merchant",
                newName: "seller_id");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "merchant",
                newName: "seller_email_address");

            migrationBuilder.RenameColumn(
                name: "brandName",
                table: "card_brand",
                newName: "brand");

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                table: "users",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AddColumn<string>(
                name: "account",
                table: "transactions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "branch",
                table: "transactions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "deleted_at",
                table: "transactions",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "issuer",
                table: "transactions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "operation_type",
                table: "transactions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "pos",
                table: "transactions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "reference",
                table: "transactions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "response",
                table: "transactions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "response_code",
                table: "transactions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "transaction_date",
                table: "transactions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "transactions",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "seller_business_phone_number",
                table: "merchant",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "seller_business_registration_number",
                table: "merchant",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "seller_currency_code",
                table: "merchant",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "seller_dba_name",
                table: "merchant",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    address_line_1 = table.Column<string>(type: "text", nullable: false),
                    address_line_2 = table.Column<string>(type: "text", nullable: false),
                    address_line_3 = table.Column<string>(type: "text", nullable: false),
                    address_line_4 = table.Column<string>(type: "text", nullable: false),
                    city_name = table.Column<string>(type: "text", nullable: false),
                    country_iso_code = table.Column<string>(type: "text", nullable: false),
                    country_name = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    deleted_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    postal_code = table.Column<string>(type: "text", nullable: false),
                    region_code = table.Column<string>(type: "text", nullable: false),
                    region_name = table.Column<string>(type: "text", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.id);
                });
        }
    }
}
