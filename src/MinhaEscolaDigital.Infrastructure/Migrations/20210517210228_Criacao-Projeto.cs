using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MinhaEscolaDigital.Infrastructure.Migrations
{
    public partial class CriacaoProjeto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enderecos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Logradouro = table.Column<string>(type: "varchar(200)", nullable: false),
                    Numero = table.Column<string>(type: "varchar(50)", nullable: false),
                    Complemento = table.Column<string>(type: "varchar(250)", nullable: true),
                    Bairro = table.Column<string>(type: "varchar(100)", nullable: false),
                    Cep = table.Column<string>(type: "varchar(20)", nullable: false),
                    Cidade = table.Column<string>(type: "varchar(100)", nullable: false),
                    Estado = table.Column<string>(type: "varchar(50)", nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Observacoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Texto = table.Column<string>(type: "varchar(8000)", nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Observacoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Escolas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RazaoSocial = table.Column<string>(type: "varchar(200)", nullable: false),
                    NomeFantasia = table.Column<string>(type: "varchar(200)", nullable: false),
                    Cpnj = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: true),
                    Email = table.Column<string>(type: "varchar(254)", maxLength: 254, nullable: true),
                    Telefone = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: true),
                    Celular = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: true),
                    ObservacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnderecoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escolas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Escolas_Enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Escolas_Observacoes_ObservacaoId",
                        column: x => x.ObservacaoId,
                        principalTable: "Observacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Responsaveis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rg = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: true),
                    Cpf = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: true),
                    Email = table.Column<string>(type: "varchar(254)", maxLength: 254, nullable: true),
                    Telefone = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: true),
                    Celular = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: true),
                    ObservacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responsaveis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Responsaveis_Observacoes_ObservacaoId",
                        column: x => x.ObservacaoId,
                        principalTable: "Observacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Turmas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    EscolaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ObservacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turmas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turmas_Escolas_EscolaId",
                        column: x => x.EscolaId,
                        principalTable: "Escolas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Turmas_Observacoes_ObservacaoId",
                        column: x => x.ObservacaoId,
                        principalTable: "Observacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rg = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: true),
                    Cpf = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: true),
                    TurmaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnderecoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ObservacaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alunos_Enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Enderecos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alunos_Observacoes_ObservacaoId",
                        column: x => x.ObservacaoId,
                        principalTable: "Observacoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alunos_Turmas_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "Turmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AlunosResponsaveis",
                columns: table => new
                {
                    AlunoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ResponsavelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosResponsaveis", x => new { x.AlunoId, x.ResponsavelId });
                    table.ForeignKey(
                        name: "FK_AlunosResponsaveis_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AlunosResponsaveis_Responsaveis_ResponsavelId",
                        column: x => x.ResponsavelId,
                        principalTable: "Responsaveis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResumosDias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataResumo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Texto = table.Column<string>(type: "varchar(8000)", nullable: false),
                    AlunoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResumosDias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResumosDias_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_EnderecoId",
                table: "Alunos",
                column: "EnderecoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_ObservacaoId",
                table: "Alunos",
                column: "ObservacaoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_TurmaId",
                table: "Alunos",
                column: "TurmaId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosResponsaveis_ResponsavelId",
                table: "AlunosResponsaveis",
                column: "ResponsavelId");

            migrationBuilder.CreateIndex(
                name: "IX_Escolas_EnderecoId",
                table: "Escolas",
                column: "EnderecoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Escolas_ObservacaoId",
                table: "Escolas",
                column: "ObservacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Responsaveis_ObservacaoId",
                table: "Responsaveis",
                column: "ObservacaoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResumosDias_AlunoId",
                table: "ResumosDias",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_EscolaId",
                table: "Turmas",
                column: "EscolaId");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_ObservacaoId",
                table: "Turmas",
                column: "ObservacaoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunosResponsaveis");

            migrationBuilder.DropTable(
                name: "ResumosDias");

            migrationBuilder.DropTable(
                name: "Responsaveis");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Turmas");

            migrationBuilder.DropTable(
                name: "Escolas");

            migrationBuilder.DropTable(
                name: "Enderecos");

            migrationBuilder.DropTable(
                name: "Observacoes");
        }
    }
}
