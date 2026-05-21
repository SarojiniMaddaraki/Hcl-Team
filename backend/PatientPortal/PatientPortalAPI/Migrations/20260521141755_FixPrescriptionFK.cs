using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientPortalAPI.Migrations
{
    /// <inheritdoc />
    public partial class FixPrescriptionFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_MedicalRecords_MedicalRecordRecordID",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_MedicalRecordRecordID",
                table: "Prescriptions");

            migrationBuilder.DropColumn(
                name: "MedicalRecordRecordID",
                table: "Prescriptions");

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_RecordID",
                table: "Prescriptions",
                column: "RecordID");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_MedicalRecords_RecordID",
                table: "Prescriptions",
                column: "RecordID",
                principalTable: "MedicalRecords",
                principalColumn: "RecordID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prescriptions_MedicalRecords_RecordID",
                table: "Prescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Prescriptions_RecordID",
                table: "Prescriptions");

            migrationBuilder.AddColumn<int>(
                name: "MedicalRecordRecordID",
                table: "Prescriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Prescriptions_MedicalRecordRecordID",
                table: "Prescriptions",
                column: "MedicalRecordRecordID");

            migrationBuilder.AddForeignKey(
                name: "FK_Prescriptions_MedicalRecords_MedicalRecordRecordID",
                table: "Prescriptions",
                column: "MedicalRecordRecordID",
                principalTable: "MedicalRecords",
                principalColumn: "RecordID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
