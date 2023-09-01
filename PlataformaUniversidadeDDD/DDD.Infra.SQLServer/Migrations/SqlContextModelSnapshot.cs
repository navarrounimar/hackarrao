﻿// <auto-generated />
using System;
using DDD.Infra.SQLServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DDD.Infra.SQLServer.Migrations
{
    [DbContext(typeof(SqlContext))]
    partial class SqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DDD.Domain.SecretariaContext.Disciplina", b =>
                {
                    b.Property<int>("DisciplinaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DisciplinaId"));

                    b.Property<bool>("Disponivel")
                        .HasColumnType("bit");

                    b.Property<bool>("Ead")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("DisciplinaId");

                    b.ToTable("Disciplinas");
                });

            modelBuilder.Entity("DDD.Domain.SecretariaContext.Matricula", b =>
                {
                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<int>("DisciplinaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.HasKey("AlunoId", "DisciplinaId");

                    b.HasIndex("DisciplinaId");

                    b.ToTable("Matriculas");
                });

            modelBuilder.Entity("DDD.Domain.UserManagementContext.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("DDD.Domain.SecretariaContext.Aluno", b =>
                {
                    b.HasBaseType("DDD.Domain.UserManagementContext.User");

                    b.Property<int>("AlunoId")
                        .HasColumnType("int");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("Aluno");
                });

            modelBuilder.Entity("DDD.Domain.SecretariaContext.Matricula", b =>
                {
                    b.HasOne("DDD.Domain.SecretariaContext.Aluno", "Aluno")
                        .WithMany("Matriculas")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DDD.Domain.SecretariaContext.Disciplina", "Disciplina")
                        .WithMany("Matriculas")
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Aluno");

                    b.Navigation("Disciplina");
                });

            modelBuilder.Entity("DDD.Domain.SecretariaContext.Disciplina", b =>
                {
                    b.Navigation("Matriculas");
                });

            modelBuilder.Entity("DDD.Domain.SecretariaContext.Aluno", b =>
                {
                    b.Navigation("Matriculas");
                });
#pragma warning restore 612, 618
        }
    }
}