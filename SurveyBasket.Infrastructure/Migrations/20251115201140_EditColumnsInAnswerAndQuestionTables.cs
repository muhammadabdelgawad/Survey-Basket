using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SurveyBasket.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditColumnsInAnswerAndQuestionTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Check if IsAcvite column exists in Questions table and rename it
            migrationBuilder.Sql(@"
                IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS 
                          WHERE TABLE_NAME = 'Questions' AND COLUMN_NAME = 'IsAcvite')
                BEGIN
                    EXEC sp_rename 'Questions.IsAcvite', 'IsActive', 'COLUMN'
                END
            ");

            // Check if IsAcvite column exists in Answers table and rename it
            migrationBuilder.Sql(@"
                IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS 
                          WHERE TABLE_NAME = 'Answers' AND COLUMN_NAME = 'IsAcvite')
                BEGIN
                    EXEC sp_rename 'Answers.IsAcvite', 'IsActive', 'COLUMN'
                END
            ");

            // If IsActive doesn't exist and IsAcvite doesn't exist either, add the IsActive column
            migrationBuilder.Sql(@"
                IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS 
                              WHERE TABLE_NAME = 'Questions' AND COLUMN_NAME = 'IsActive')
                   AND NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS 
                                  WHERE TABLE_NAME = 'Questions' AND COLUMN_NAME = 'IsAcvite')
                BEGIN
                    ALTER TABLE Questions ADD IsActive bit NOT NULL DEFAULT 1
                END
            ");

            migrationBuilder.Sql(@"
                IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS 
                              WHERE TABLE_NAME = 'Answers' AND COLUMN_NAME = 'IsActive')
                   AND NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS 
                                  WHERE TABLE_NAME = 'Answers' AND COLUMN_NAME = 'IsAcvite')
                BEGIN
                    ALTER TABLE Answers ADD IsActive bit NOT NULL DEFAULT 1
                END
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Reverse the operation - rename IsActive back to IsAcvite if needed
            migrationBuilder.Sql(@"
                IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS 
                          WHERE TABLE_NAME = 'Questions' AND COLUMN_NAME = 'IsActive')
                BEGIN
                    EXEC sp_rename 'Questions.IsActive', 'IsAcvite', 'COLUMN'
                END
            ");

            migrationBuilder.Sql(@"
                IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.COLUMNS 
                          WHERE TABLE_NAME = 'Answers' AND COLUMN_NAME = 'IsActive')
                BEGIN
                    EXEC sp_rename 'Answers.IsActive', 'IsAcvite', 'COLUMN'
                END
            ");
        }
    }
}
