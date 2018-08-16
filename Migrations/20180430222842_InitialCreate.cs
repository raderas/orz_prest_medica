using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace PrestacionMedicaMvc.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banco",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CodigoCuentaAhorro = table.Column<int>(nullable: false),
                    CodigoCuentaCorriente = table.Column<int>(nullable: false),
                    Correlativo = table.Column<int>(nullable: false),
                    FormatoArchivo = table.Column<string>(nullable: true),
                    NombreBanco = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banco", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Departamento = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    IDBanco = table.Column<int>(nullable: false),
                    Municipio = table.Column<string>(nullable: true),
                    NIT = table.Column<string>(nullable: true),
                    NombreEmpresa = table.Column<string>(nullable: true),
                    NumCuentaBancaria = table.Column<string>(nullable: true),
                    NumIva = table.Column<string>(nullable: true),
                    NumPatronal = table.Column<string>(nullable: true),
                    RazonSocial = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    CodigoProveedor = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    TipoProveedor = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.CodigoProveedor);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    IDempleado = table.Column<int>(nullable: false),
                    Apellido = table.Column<string>(nullable: true),
                    BancoCuentaID = table.Column<int>(nullable: true),
                    CentroDeCosto = table.Column<string>(nullable: true),
                    DUI = table.Column<string>(nullable: true),
                    EmpresaID = table.Column<int>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    NombrePlanilla = table.Column<string>(nullable: true),
                    NumeroCuenta = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    TipoCuenta = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.IDempleado);
                    table.ForeignKey(
                        name: "FK_Empleado_Banco_BancoCuentaID",
                        column: x => x.BancoCuentaID,
                        principalTable: "Banco",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Empleado_Empresa_EmpresaID",
                        column: x => x.EmpresaID,
                        principalTable: "Empresa",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Planilla",
                columns: table => new
                {
                    IDPlanilla = table.Column<string>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    EmpresaID = table.Column<int>(nullable: true),
                    FechaFinal = table.Column<DateTime>(nullable: false),
                    FechaInicial = table.Column<DateTime>(nullable: false),
                    PlanillaAbierta = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planilla", x => x.IDPlanilla);
                    table.ForeignKey(
                        name: "FK_Planilla_Empresa_EmpresaID",
                        column: x => x.EmpresaID,
                        principalTable: "Empresa",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Expediente",
                columns: table => new
                {
                    NumCarnet = table.Column<string>(nullable: false),
                    Activo = table.Column<bool>(nullable: false),
                    Beneficiario = table.Column<bool>(nullable: false),
                    EmpleadoIDempleado = table.Column<int>(nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Parentesco = table.Column<string>(nullable: true),
                    TipoDeducible = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expediente", x => x.NumCarnet);
                    table.ForeignKey(
                        name: "FK_Expediente_Empleado_EmpleadoIDempleado",
                        column: x => x.EmpleadoIDempleado,
                        principalTable: "Empleado",
                        principalColumn: "IDempleado",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reclamo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Año = table.Column<int>(nullable: false),
                    CorrelativoAño = table.Column<int>(nullable: false),
                    Diagnostico = table.Column<string>(nullable: true),
                    FechaNomina = table.Column<DateTime>(nullable: false),
                    Fuente = table.Column<int>(nullable: false),
                    PacienteNumCarnet = table.Column<string>(nullable: true),
                    PlanillaIDPlanilla = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reclamo", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reclamo_Expediente_PacienteNumCarnet",
                        column: x => x.PacienteNumCarnet,
                        principalTable: "Expediente",
                        principalColumn: "NumCarnet",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reclamo_Planilla_PlanillaIDPlanilla",
                        column: x => x.PlanillaIDPlanilla,
                        principalTable: "Planilla",
                        principalColumn: "IDPlanilla",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Factura",
                columns: table => new
                {
                    NumeroFactura = table.Column<string>(nullable: false),
                    Coaseguro = table.Column<decimal>(nullable: false),
                    Deducible = table.Column<decimal>(nullable: false),
                    FechaFactura = table.Column<DateTime>(nullable: false),
                    GastoNoCubierto = table.Column<decimal>(nullable: false),
                    GastoPresentado = table.Column<decimal>(nullable: false),
                    ProveedorCodigoProveedor = table.Column<string>(nullable: true),
                    ReclamoID = table.Column<int>(nullable: true),
                    Valor = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura", x => x.NumeroFactura);
                    table.ForeignKey(
                        name: "FK_Factura_Proveedor_ProveedorCodigoProveedor",
                        column: x => x.ProveedorCodigoProveedor,
                        principalTable: "Proveedor",
                        principalColumn: "CodigoProveedor",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Factura_Reclamo_ReclamoID",
                        column: x => x.ReclamoID,
                        principalTable: "Reclamo",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_BancoCuentaID",
                table: "Empleado",
                column: "BancoCuentaID");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_EmpresaID",
                table: "Empleado",
                column: "EmpresaID");

            migrationBuilder.CreateIndex(
                name: "IX_Expediente_EmpleadoIDempleado",
                table: "Expediente",
                column: "EmpleadoIDempleado");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_ProveedorCodigoProveedor",
                table: "Factura",
                column: "ProveedorCodigoProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_ReclamoID",
                table: "Factura",
                column: "ReclamoID");

            migrationBuilder.CreateIndex(
                name: "IX_Planilla_EmpresaID",
                table: "Planilla",
                column: "EmpresaID");

            migrationBuilder.CreateIndex(
                name: "IX_Reclamo_PacienteNumCarnet",
                table: "Reclamo",
                column: "PacienteNumCarnet");

            migrationBuilder.CreateIndex(
                name: "IX_Reclamo_PlanillaIDPlanilla",
                table: "Reclamo",
                column: "PlanillaIDPlanilla");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Factura");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "Reclamo");

            migrationBuilder.DropTable(
                name: "Expediente");

            migrationBuilder.DropTable(
                name: "Planilla");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "Banco");

            migrationBuilder.DropTable(
                name: "Empresa");
        }
    }
}
