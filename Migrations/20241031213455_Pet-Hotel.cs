﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace pet_hotel_7._0.Migrations
{
    /// <inheritdoc />
    public partial class PetHotel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PetOwners",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetOwners", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    petBreed = table.Column<int>(type: "integer", nullable: false),
                    petColor = table.Column<int>(type: "integer", nullable: false),
                    checkedInAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    petOwnerid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.id);
                    table.ForeignKey(
                        name: "FK_Pets_PetOwners_petOwnerid",
                        column: x => x.petOwnerid,
                        principalTable: "PetOwners",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pets_petOwnerid",
                table: "Pets",
                column: "petOwnerid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "PetOwners");
        }
    }
}
