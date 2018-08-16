﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using PrestacionMedicaMvc.Models;
using System;

namespace PrestacionMedicaMvc.Migrations
{
    [DbContext(typeof(PrestMedicaContext))]
    [Migration("20180430222842_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity("PrestacionMedicaMvc.Models.Banco", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CodigoCuentaAhorro");

                    b.Property<int>("CodigoCuentaCorriente");

                    b.Property<int>("Correlativo");

                    b.Property<string>("FormatoArchivo");

                    b.Property<string>("NombreBanco")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("ID");

                    b.ToTable("Banco");
                });

            modelBuilder.Entity("PrestacionMedicaMvc.Models.Empleado", b =>
                {
                    b.Property<int>("IDempleado");

                    b.Property<string>("Apellido");

                    b.Property<int?>("BancoCuentaID");

                    b.Property<string>("CentroDeCosto");

                    b.Property<string>("DUI");

                    b.Property<int?>("EmpresaID");

                    b.Property<string>("Nombre");

                    b.Property<string>("NombrePlanilla");

                    b.Property<string>("NumeroCuenta");

                    b.Property<string>("Status");

                    b.Property<string>("TipoCuenta");

                    b.HasKey("IDempleado");

                    b.HasIndex("BancoCuentaID");

                    b.HasIndex("EmpresaID");

                    b.ToTable("Empleado");
                });

            modelBuilder.Entity("PrestacionMedicaMvc.Models.Empresa", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Departamento");

                    b.Property<string>("Direccion");

                    b.Property<int>("IDBanco");

                    b.Property<string>("Municipio");

                    b.Property<string>("NIT");

                    b.Property<string>("NombreEmpresa");

                    b.Property<string>("NumCuentaBancaria");

                    b.Property<string>("NumIva");

                    b.Property<string>("NumPatronal");

                    b.Property<string>("RazonSocial");

                    b.Property<string>("Telefono");

                    b.HasKey("ID");

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("PrestacionMedicaMvc.Models.Expediente", b =>
                {
                    b.Property<string>("NumCarnet");

                    b.Property<bool>("Activo");

                    b.Property<bool>("Beneficiario");

                    b.Property<int?>("EmpleadoIDempleado");

                    b.Property<DateTime>("FechaNacimiento");

                    b.Property<string>("Nombre");

                    b.Property<string>("Parentesco");

                    b.Property<string>("TipoDeducible");

                    b.HasKey("NumCarnet");

                    b.HasIndex("EmpleadoIDempleado");

                    b.ToTable("Expediente");
                });

            modelBuilder.Entity("PrestacionMedicaMvc.Models.Factura", b =>
                {
                    b.Property<string>("NumeroFactura");

                    b.Property<decimal>("Coaseguro");

                    b.Property<decimal>("Deducible");

                    b.Property<DateTime>("FechaFactura");

                    b.Property<decimal>("GastoNoCubierto");

                    b.Property<decimal>("GastoPresentado");

                    b.Property<string>("ProveedorCodigoProveedor");

                    b.Property<int?>("ReclamoID");

                    b.Property<decimal>("Valor");

                    b.HasKey("NumeroFactura");

                    b.HasIndex("ProveedorCodigoProveedor");

                    b.HasIndex("ReclamoID");

                    b.ToTable("Factura");
                });

            modelBuilder.Entity("PrestacionMedicaMvc.Models.Planilla", b =>
                {
                    b.Property<string>("IDPlanilla");

                    b.Property<string>("Descripcion");

                    b.Property<int?>("EmpresaID");

                    b.Property<DateTime>("FechaFinal");

                    b.Property<DateTime>("FechaInicial");

                    b.Property<bool>("PlanillaAbierta");

                    b.HasKey("IDPlanilla");

                    b.HasIndex("EmpresaID");

                    b.ToTable("Planilla");
                });

            modelBuilder.Entity("PrestacionMedicaMvc.Models.Proveedor", b =>
                {
                    b.Property<string>("CodigoProveedor");

                    b.Property<string>("Nombre");

                    b.Property<int>("TipoProveedor");

                    b.HasKey("CodigoProveedor");

                    b.ToTable("Proveedor");
                });

            modelBuilder.Entity("PrestacionMedicaMvc.Models.Reclamo", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Año");

                    b.Property<int>("CorrelativoAño");

                    b.Property<string>("Diagnostico");

                    b.Property<DateTime>("FechaNomina");

                    b.Property<int>("Fuente");

                    b.Property<string>("PacienteNumCarnet");

                    b.Property<string>("PlanillaIDPlanilla");

                    b.HasKey("ID");

                    b.HasIndex("PacienteNumCarnet");

                    b.HasIndex("PlanillaIDPlanilla");

                    b.ToTable("Reclamo");
                });

            modelBuilder.Entity("PrestacionMedicaMvc.Models.Empleado", b =>
                {
                    b.HasOne("PrestacionMedicaMvc.Models.Banco", "BancoCuenta")
                        .WithMany()
                        .HasForeignKey("BancoCuentaID");

                    b.HasOne("PrestacionMedicaMvc.Models.Empresa", "Empresa")
                        .WithMany("Empleados")
                        .HasForeignKey("EmpresaID");
                });

            modelBuilder.Entity("PrestacionMedicaMvc.Models.Expediente", b =>
                {
                    b.HasOne("PrestacionMedicaMvc.Models.Empleado", "Empleado")
                        .WithMany("Expedientes")
                        .HasForeignKey("EmpleadoIDempleado");
                });

            modelBuilder.Entity("PrestacionMedicaMvc.Models.Factura", b =>
                {
                    b.HasOne("PrestacionMedicaMvc.Models.Proveedor", "Proveedor")
                        .WithMany()
                        .HasForeignKey("ProveedorCodigoProveedor");

                    b.HasOne("PrestacionMedicaMvc.Models.Reclamo", "Reclamo")
                        .WithMany("Facturas")
                        .HasForeignKey("ReclamoID");
                });

            modelBuilder.Entity("PrestacionMedicaMvc.Models.Planilla", b =>
                {
                    b.HasOne("PrestacionMedicaMvc.Models.Empresa", "Empresa")
                        .WithMany()
                        .HasForeignKey("EmpresaID");
                });

            modelBuilder.Entity("PrestacionMedicaMvc.Models.Reclamo", b =>
                {
                    b.HasOne("PrestacionMedicaMvc.Models.Expediente", "Paciente")
                        .WithMany()
                        .HasForeignKey("PacienteNumCarnet");

                    b.HasOne("PrestacionMedicaMvc.Models.Planilla", "Planilla")
                        .WithMany("Reclamos")
                        .HasForeignKey("PlanillaIDPlanilla");
                });
#pragma warning restore 612, 618
        }
    }
}
