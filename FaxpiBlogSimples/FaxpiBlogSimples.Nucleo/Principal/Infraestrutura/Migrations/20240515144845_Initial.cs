using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FaxpiBlogSimples.Nucleo.Principal.Infraestrutura.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "postagem",
                columns: table => new
                {
                    postagem_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    postagem_titulo = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    postagem_conteudo = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    postagem_usuario_id = table.Column<int>(type: "integer", nullable: false),
                    postagem_data_criacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_postagem", x => x.postagem_id);
                });

            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    usuario_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    usuario_lg = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    usuario_ee_email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    usuario_sh = table.Column<string>(type: "text", nullable: true),
                    usuario_flg_ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.usuario_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "postagem");

            migrationBuilder.DropTable(
                name: "usuario");
        }
    }
}
