using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AgendaMedica.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    EnderecoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CEP = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    Bairro = table.Column<string>(nullable: true),
                    Rua = table.Column<string>(nullable: true),
                    Numero = table.Column<int>(nullable: false),
                    Complemento = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.EnderecoId);
                });

            migrationBuilder.CreateTable(
                name: "Especialidade",
                columns: table => new
                {
                    EspecialidadeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Codigo = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidade", x => x.EspecialidadeId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    SobreNome = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: true),
                    EnderecoId = table.Column<int>(nullable: true),
                    Cpf = table.Column<string>(nullable: true),
                    Cnpj = table.Column<string>(nullable: true),
                    Orgao = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    Registro = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "EnderecoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Agenda",
                columns: table => new
                {
                    AgendaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Titulo = table.Column<string>(nullable: true),
                    DataHoraInicio = table.Column<DateTime>(nullable: false),
                    DataHoraFim = table.Column<DateTime>(nullable: false),
                    PrecoConsulta = table.Column<decimal>(nullable: true),
                    ProfissionalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agenda", x => x.AgendaId);
                    table.ForeignKey(
                        name: "FK_Agenda_AspNetUsers_ProfissionalId",
                        column: x => x.ProfissionalId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consulta",
                columns: table => new
                {
                    ConsultaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(nullable: false),
                    HoraInicio = table.Column<TimeSpan>(nullable: false),
                    HoraFim = table.Column<TimeSpan>(nullable: false),
                    PagamentoConfirmado = table.Column<bool>(nullable: false),
                    PacienteId = table.Column<int>(nullable: false),
                    ProfissionalId = table.Column<int>(nullable: false),
                    EspecialidadeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consulta", x => x.ConsultaId);
                    table.ForeignKey(
                        name: "FK_Consulta_Especialidade_EspecialidadeId",
                        column: x => x.EspecialidadeId,
                        principalTable: "Especialidade",
                        principalColumn: "EspecialidadeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consulta_AspNetUsers_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Consulta_AspNetUsers_ProfissionalId",
                        column: x => x.ProfissionalId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioProfissionalEspecialidade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    EspecialidadeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioProfissionalEspecialidade", x => new { x.EspecialidadeId, x.Id });
                    table.ForeignKey(
                        name: "FK_UsuarioProfissionalEspecialidade_Especialidade_EspecialidadeId",
                        column: x => x.EspecialidadeId,
                        principalTable: "Especialidade",
                        principalColumn: "EspecialidadeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioProfissionalEspecialidade_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Horario",
                columns: table => new
                {
                    HorarioId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DiaSemana = table.Column<int>(nullable: false),
                    HoraInicio = table.Column<TimeSpan>(nullable: false),
                    HoraFim = table.Column<TimeSpan>(nullable: false),
                    AgendaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horario", x => x.HorarioId);
                    table.ForeignKey(
                        name: "FK_Horario_Agenda_AgendaId",
                        column: x => x.AgendaId,
                        principalTable: "Agenda",
                        principalColumn: "AgendaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HorarioExcecao",
                columns: table => new
                {
                    HorarioExcecaoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(nullable: false),
                    HoraInicio = table.Column<TimeSpan>(nullable: false),
                    HoraFim = table.Column<TimeSpan>(nullable: false),
                    Atende = table.Column<bool>(nullable: false),
                    AgendaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorarioExcecao", x => x.HorarioExcecaoId);
                    table.ForeignKey(
                        name: "FK_HorarioExcecao_Agenda_AgendaId",
                        column: x => x.AgendaId,
                        principalTable: "Agenda",
                        principalColumn: "AgendaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Endereco",
                columns: new[] { "EnderecoId", "Bairro", "CEP", "Cidade", "Complemento", "Estado", "Numero", "Rua" },
                values: new object[,]
                {
                    { 1, "Laranjeiras", "29050-902", "Vitória", "Casa", "ES", 56, "Av. Américo Buaiz" },
                    { 2, "Enseada do Suá", "29045-250", "Vitória", "Casa", "ES", 51, "Juiz Alexandre Martins de Castro Filho" },
                    { 3, "Vila Velha", "29100-000", "Vila Velha", "Casa", "ES", 851, "Av. São Paulo" },
                    { 4, "Feu Rosa", "29166-820", "Serra", "Casa", "ES", 711, "Av. Copacabana" }
                });

            migrationBuilder.InsertData(
                table: "Especialidade",
                columns: new[] { "EspecialidadeId", "Codigo", "Nome" },
                values: new object[,]
                {
                    { 1, "ANSTSLG", "Anestesiologia" },
                    { 2, "CIRUR. PLAST.", "Cirurgia Plástica" },
                    { 3, "MED. ESP.", "Medicina Esportiva" },
                    { 4, "ORTOP. E TRAUM.", "Ortopedia e Traumatologia" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "DataNascimento", "EnderecoId", "Nome", "SobreNome", "Cpf" },
                values: new object[,]
                {
                    { 1, 0, "d7d50895-1e1c-4582-8bd1-6badd9daea7e", "UsuarioPaciente", "vanessa@teste.com", false, true, null, "VANESSA@TESTE.COM", "VANESSA@TESTE.COM", "AQAAAAEAACcQAAAAEEVjXvqjVsNgg//Kp2nmmIc8cVqwehn9NayYOAl6iqthSU3yClvT5iQDdDc4J5lKHg==", "994839210", false, "KRV4CMQKAQCZGZYKSMRW3L7NIJ7CTS6C", false, "vanessa@teste.com", new DateTime(1941, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Vanessa", "Bianca da Cruz", "71985694719" },
                    { 2, 0, "d7d50895-1e1c-4582-8bd1-6badd9daea7e", "UsuarioPaciente", "victor@teste.com", false, true, null, "VICTOR@TESTE.COM", "VICTOR@TESTE.COM", "AQAAAAEAACcQAAAAEEVjXvqjVsNgg//Kp2nmmIc8cVqwehn9NayYOAl6iqthSU3yClvT5iQDdDc4J5lKHg==", "997965652", false, "KRV4CMQKAQCZGZYKSMRW3L7NIJ7CTS6C", false, "victor@teste.com", new DateTime(1946, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Victor", "Nelson Martin Caldeira", "52435366442" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "DataNascimento", "EnderecoId", "Nome", "SobreNome", "Cnpj", "Estado", "Orgao", "Registro" },
                values: new object[,]
                {
                    { 3, 0, "d7d50895-1e1c-4582-8bd1-6badd9daea7e", "UsuarioProfissional", "rodrigo@teste.com", false, true, null, "RODRIGO@TESTE.COM", "RODRIGO@TESTE.COM", "AQAAAAEAACcQAAAAEEVjXvqjVsNgg//Kp2nmmIc8cVqwehn9NayYOAl6iqthSU3yClvT5iQDdDc4J5lKHg==", "99349-5462", false, "KRV4CMQKAQCZGZYKSMRW3L7NIJ7CTS6C", false, "rodrigo@teste.com", new DateTime(1971, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Rodrigo", "Vitor Kevin Ferreira", "63.029.660/0001-15", null, null, null },
                    { 4, 0, "d7d50895-1e1c-4582-8bd1-6badd9daea7e", "UsuarioProfissional", "augusto@teste.com", false, true, null, "AUGUSTO@TESTE.COM", "AUGUSTO@TESTE.COM", "AQAAAAEAACcQAAAAEEVjXvqjVsNgg//Kp2nmmIc8cVqwehn9NayYOAl6iqthSU3yClvT5iQDdDc4J5lKHg==", "99598-2285", false, "KRV4CMQKAQCZGZYKSMRW3L7NIJ7CTS6C", false, "augusto@teste.com", new DateTime(1982, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Augusto", "Menezes da Costa", "35.172.039/0001-70", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Agenda",
                columns: new[] { "AgendaId", "DataHoraFim", "DataHoraInicio", "PrecoConsulta", "ProfissionalId", "Titulo" },
                values: new object[] { 1, new DateTime(2099, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(1899, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), null, 3, null });

            migrationBuilder.InsertData(
                table: "UsuarioProfissionalEspecialidade",
                columns: new[] { "EspecialidadeId", "Id" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 2, 3 },
                    { 4, 3 },
                    { 3, 4 }
                });

            migrationBuilder.InsertData(
                table: "Horario",
                columns: new[] { "HorarioId", "AgendaId", "DiaSemana", "HoraFim", "HoraInicio" },
                values: new object[,]
                {
                    { 1, 1, 0, new TimeSpan(0, 8, 30, 0, 0), new TimeSpan(0, 7, 30, 0, 0) },
                    { 27, 1, 3, new TimeSpan(0, 13, 30, 0, 0), new TimeSpan(0, 12, 30, 0, 0) },
                    { 28, 1, 3, new TimeSpan(0, 14, 30, 0, 0), new TimeSpan(0, 13, 30, 0, 0) },
                    { 29, 1, 4, new TimeSpan(0, 8, 30, 0, 0), new TimeSpan(0, 7, 30, 0, 0) },
                    { 30, 1, 4, new TimeSpan(0, 9, 30, 0, 0), new TimeSpan(0, 8, 30, 0, 0) },
                    { 31, 1, 4, new TimeSpan(0, 10, 30, 0, 0), new TimeSpan(0, 9, 30, 0, 0) },
                    { 32, 1, 4, new TimeSpan(0, 11, 30, 0, 0), new TimeSpan(0, 10, 30, 0, 0) },
                    { 33, 1, 4, new TimeSpan(0, 12, 30, 0, 0), new TimeSpan(0, 11, 30, 0, 0) },
                    { 34, 1, 4, new TimeSpan(0, 13, 30, 0, 0), new TimeSpan(0, 12, 30, 0, 0) },
                    { 35, 1, 4, new TimeSpan(0, 14, 30, 0, 0), new TimeSpan(0, 13, 30, 0, 0) },
                    { 36, 1, 5, new TimeSpan(0, 8, 30, 0, 0), new TimeSpan(0, 7, 30, 0, 0) },
                    { 37, 1, 5, new TimeSpan(0, 9, 30, 0, 0), new TimeSpan(0, 8, 30, 0, 0) },
                    { 38, 1, 5, new TimeSpan(0, 10, 30, 0, 0), new TimeSpan(0, 9, 30, 0, 0) },
                    { 39, 1, 5, new TimeSpan(0, 11, 30, 0, 0), new TimeSpan(0, 10, 30, 0, 0) },
                    { 40, 1, 5, new TimeSpan(0, 12, 30, 0, 0), new TimeSpan(0, 11, 30, 0, 0) },
                    { 41, 1, 5, new TimeSpan(0, 13, 30, 0, 0), new TimeSpan(0, 12, 30, 0, 0) },
                    { 42, 1, 5, new TimeSpan(0, 14, 30, 0, 0), new TimeSpan(0, 13, 30, 0, 0) },
                    { 43, 1, 6, new TimeSpan(0, 8, 30, 0, 0), new TimeSpan(0, 7, 30, 0, 0) },
                    { 44, 1, 6, new TimeSpan(0, 9, 30, 0, 0), new TimeSpan(0, 8, 30, 0, 0) },
                    { 45, 1, 6, new TimeSpan(0, 10, 30, 0, 0), new TimeSpan(0, 9, 30, 0, 0) },
                    { 46, 1, 6, new TimeSpan(0, 11, 30, 0, 0), new TimeSpan(0, 10, 30, 0, 0) },
                    { 47, 1, 6, new TimeSpan(0, 12, 30, 0, 0), new TimeSpan(0, 11, 30, 0, 0) },
                    { 26, 1, 3, new TimeSpan(0, 12, 30, 0, 0), new TimeSpan(0, 11, 30, 0, 0) },
                    { 48, 1, 6, new TimeSpan(0, 13, 30, 0, 0), new TimeSpan(0, 12, 30, 0, 0) },
                    { 25, 1, 3, new TimeSpan(0, 11, 30, 0, 0), new TimeSpan(0, 10, 30, 0, 0) },
                    { 23, 1, 3, new TimeSpan(0, 9, 30, 0, 0), new TimeSpan(0, 8, 30, 0, 0) },
                    { 2, 1, 0, new TimeSpan(0, 9, 30, 0, 0), new TimeSpan(0, 8, 30, 0, 0) },
                    { 3, 1, 0, new TimeSpan(0, 10, 30, 0, 0), new TimeSpan(0, 9, 30, 0, 0) },
                    { 4, 1, 0, new TimeSpan(0, 11, 30, 0, 0), new TimeSpan(0, 10, 30, 0, 0) },
                    { 5, 1, 0, new TimeSpan(0, 12, 30, 0, 0), new TimeSpan(0, 11, 30, 0, 0) },
                    { 6, 1, 0, new TimeSpan(0, 13, 30, 0, 0), new TimeSpan(0, 12, 30, 0, 0) },
                    { 7, 1, 0, new TimeSpan(0, 14, 30, 0, 0), new TimeSpan(0, 13, 30, 0, 0) },
                    { 8, 1, 1, new TimeSpan(0, 8, 30, 0, 0), new TimeSpan(0, 7, 30, 0, 0) },
                    { 9, 1, 1, new TimeSpan(0, 9, 30, 0, 0), new TimeSpan(0, 8, 30, 0, 0) },
                    { 10, 1, 1, new TimeSpan(0, 10, 30, 0, 0), new TimeSpan(0, 9, 30, 0, 0) },
                    { 11, 1, 1, new TimeSpan(0, 11, 30, 0, 0), new TimeSpan(0, 10, 30, 0, 0) },
                    { 12, 1, 1, new TimeSpan(0, 12, 30, 0, 0), new TimeSpan(0, 11, 30, 0, 0) },
                    { 13, 1, 1, new TimeSpan(0, 13, 30, 0, 0), new TimeSpan(0, 12, 30, 0, 0) },
                    { 14, 1, 1, new TimeSpan(0, 14, 30, 0, 0), new TimeSpan(0, 13, 30, 0, 0) },
                    { 15, 1, 2, new TimeSpan(0, 8, 30, 0, 0), new TimeSpan(0, 7, 30, 0, 0) },
                    { 16, 1, 2, new TimeSpan(0, 9, 30, 0, 0), new TimeSpan(0, 8, 30, 0, 0) },
                    { 17, 1, 2, new TimeSpan(0, 10, 30, 0, 0), new TimeSpan(0, 9, 30, 0, 0) },
                    { 18, 1, 2, new TimeSpan(0, 11, 30, 0, 0), new TimeSpan(0, 10, 30, 0, 0) },
                    { 19, 1, 2, new TimeSpan(0, 12, 30, 0, 0), new TimeSpan(0, 11, 30, 0, 0) },
                    { 20, 1, 2, new TimeSpan(0, 13, 30, 0, 0), new TimeSpan(0, 12, 30, 0, 0) },
                    { 21, 1, 2, new TimeSpan(0, 14, 30, 0, 0), new TimeSpan(0, 13, 30, 0, 0) },
                    { 22, 1, 3, new TimeSpan(0, 8, 30, 0, 0), new TimeSpan(0, 7, 30, 0, 0) },
                    { 24, 1, 3, new TimeSpan(0, 10, 30, 0, 0), new TimeSpan(0, 9, 30, 0, 0) },
                    { 49, 1, 6, new TimeSpan(0, 14, 30, 0, 0), new TimeSpan(0, 13, 30, 0, 0) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_ProfissionalId",
                table: "Agenda",
                column: "ProfissionalId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_EnderecoId",
                table: "AspNetUsers",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_EspecialidadeId",
                table: "Consulta",
                column: "EspecialidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_PacienteId",
                table: "Consulta",
                column: "PacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_ProfissionalId",
                table: "Consulta",
                column: "ProfissionalId");

            migrationBuilder.CreateIndex(
                name: "IX_Horario_AgendaId",
                table: "Horario",
                column: "AgendaId");

            migrationBuilder.CreateIndex(
                name: "IX_HorarioExcecao_AgendaId",
                table: "HorarioExcecao",
                column: "AgendaId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioProfissionalEspecialidade_Id",
                table: "UsuarioProfissionalEspecialidade",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Consulta");

            migrationBuilder.DropTable(
                name: "Horario");

            migrationBuilder.DropTable(
                name: "HorarioExcecao");

            migrationBuilder.DropTable(
                name: "UsuarioProfissionalEspecialidade");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Agenda");

            migrationBuilder.DropTable(
                name: "Especialidade");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Endereco");
        }
    }
}
