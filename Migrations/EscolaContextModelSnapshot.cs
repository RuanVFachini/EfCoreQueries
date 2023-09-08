﻿// <auto-generated />
using System;
using EfCoreQueries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EfCoreQueries.Migrations
{
    [DbContext(typeof(EscolaContext))]
    partial class EscolaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AlunoTurma", b =>
                {
                    b.Property<int>("AlunosAlunoId")
                        .HasColumnType("int");

                    b.Property<int>("TurmasTurmaId")
                        .HasColumnType("int");

                    b.HasKey("AlunosAlunoId", "TurmasTurmaId");

                    b.HasIndex("TurmasTurmaId");

                    b.ToTable("AlunoTurma");
                });

            modelBuilder.Entity("EfCoreQueries.Entities.Aluno", b =>
                {
                    b.Property<int>("AlunoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Idade")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AlunoId");

                    b.ToTable("Alunos");
                });

            modelBuilder.Entity("EfCoreQueries.Entities.Disciplina", b =>
                {
                    b.Property<int>("DisciplinaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DisciplinaId");

                    b.ToTable("Disciplinas");
                });

            modelBuilder.Entity("EfCoreQueries.Entities.Escola", b =>
                {
                    b.Property<int>("EscolaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EscolaId");

                    b.ToTable("Escolas");
                });

            modelBuilder.Entity("EfCoreQueries.Entities.Professor", b =>
                {
                    b.Property<int>("ProfessorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProfessorId");

                    b.ToTable("Professores");
                });

            modelBuilder.Entity("EfCoreQueries.Entities.SalaDeAula", b =>
                {
                    b.Property<int>("SalaDeAulaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EscolaId")
                        .HasColumnType("int");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SalaDeAulaId");

                    b.HasIndex("EscolaId");

                    b.ToTable("SalasDeAula");
                });

            modelBuilder.Entity("EfCoreQueries.Entities.Turma", b =>
                {
                    b.Property<int>("TurmaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DisciplinaId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProfessorId")
                        .HasColumnType("int");

                    b.Property<int?>("SalaDeAulaId")
                        .HasColumnType("int");

                    b.HasKey("TurmaId");

                    b.HasIndex("DisciplinaId");

                    b.HasIndex("ProfessorId");

                    b.HasIndex("SalaDeAulaId");

                    b.ToTable("Turmas");
                });

            modelBuilder.Entity("AlunoTurma", b =>
                {
                    b.HasOne("EfCoreQueries.Entities.Aluno", null)
                        .WithMany()
                        .HasForeignKey("AlunosAlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EfCoreQueries.Entities.Turma", null)
                        .WithMany()
                        .HasForeignKey("TurmasTurmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EfCoreQueries.Entities.SalaDeAula", b =>
                {
                    b.HasOne("EfCoreQueries.Entities.Escola", null)
                        .WithMany("SalasDeAula")
                        .HasForeignKey("EscolaId");
                });

            modelBuilder.Entity("EfCoreQueries.Entities.Turma", b =>
                {
                    b.HasOne("EfCoreQueries.Entities.Disciplina", "Disciplina")
                        .WithMany("Turmas")
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EfCoreQueries.Entities.Professor", "Professor")
                        .WithMany("Turmas")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EfCoreQueries.Entities.SalaDeAula", null)
                        .WithMany("Turmas")
                        .HasForeignKey("SalaDeAulaId");

                    b.Navigation("Disciplina");

                    b.Navigation("Professor");
                });

            modelBuilder.Entity("EfCoreQueries.Entities.Disciplina", b =>
                {
                    b.Navigation("Turmas");
                });

            modelBuilder.Entity("EfCoreQueries.Entities.Escola", b =>
                {
                    b.Navigation("SalasDeAula");
                });

            modelBuilder.Entity("EfCoreQueries.Entities.Professor", b =>
                {
                    b.Navigation("Turmas");
                });

            modelBuilder.Entity("EfCoreQueries.Entities.SalaDeAula", b =>
                {
                    b.Navigation("Turmas");
                });
#pragma warning restore 612, 618
        }
    }
}
