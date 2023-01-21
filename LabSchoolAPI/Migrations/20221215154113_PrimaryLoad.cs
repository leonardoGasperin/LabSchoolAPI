﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabSchoolAPI.Migrations
{
    /// <inheritdoc />
    public partial class PrimaryLoad : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Alunos (Nome, Telefone, DataNascimento, Cfp, SituacaoMatricula, Nota, QtdAtendimentos) VALUES ('Bart Simpson', '11-11111-1212', '2014-10-29', 11839750073, 'IRREGULAR', 3.5, 0);");
            migrationBuilder.Sql("INSERT INTO Alunos (Nome, Telefone, DataNascimento, Cfp, SituacaoMatricula, Nota, QtdAtendimentos) VALUES ('Lisa Simpson', '11-22222-2222', '2012-10-29', 17158947076, 'ATIVO', 10, 0);");
            migrationBuilder.Sql("INSERT INTO Alunos (Nome, Telefone, DataNascimento, Cfp, SituacaoMatricula, Nota, QtdAtendimentos) VALUES ('Meggie Simpson', '12-20002-2200', '2019-10-29', 63701210020, 'ATIVO', 9, 0);");
            migrationBuilder.Sql("INSERT INTO Alunos (Nome, Telefone, DataNascimento, Cfp, SituacaoMatricula, Nota, QtdAtendimentos) VALUES ('Milhouse Van Houten', '11-33333-2222', '2014-10-29', 30119137062, 'ATIVO', 8, 0);");
            migrationBuilder.Sql("INSERT INTO Alunos (Nome, Telefone, DataNascimento, Cfp, SituacaoMatricula, Nota, QtdAtendimentos) VALUES ('Nelson Muntz', '11-44333-4444', '2007-10-29', 95704094015, 'INATIVO', 2, 0);");

            migrationBuilder.Sql("INSERT INTO Professores (Nome, Telefone, DataNascimento, Cfp, Estado, Experiencia, FormacaoAcademica) VALUES ('Walter White', '14-22998-1882', '1982-10-30', 40539019011, 0, 0, 1);");
            migrationBuilder.Sql("INSERT INTO Professores (Nome, Telefone, DataNascimento, Cfp, Estado, Experiencia, FormacaoAcademica) VALUES ('Jesse Pinkman', '44-11111-1992', '1997-10-30', 96107295097, 0, 1, 4);");
            migrationBuilder.Sql("INSERT INTO Professores (Nome, Telefone, DataNascimento, Cfp, Estado, Experiencia, FormacaoAcademica) VALUES ('Hank Schrader', '44-11111-1002', '1984-10-30', 70685977005, 0, 0, 1);");
            migrationBuilder.Sql("INSERT INTO Professores (Nome, Telefone, DataNascimento, Cfp, Estado, Experiencia, FormacaoAcademica) VALUES ('Gustavo Fring', '44-11001-1002', '1977-10-30', 57408927085, 1, 2, 0);");
            migrationBuilder.Sql("INSERT INTO Professores (Nome, Telefone, DataNascimento, Cfp, Estado, Experiencia, FormacaoAcademica) VALUES ('Saul Goodman', '44-11998-1882', '1980-10-30', 86940162062, 0, 0, 1);");

            migrationBuilder.Sql("INSERT INTO Pedagogos (Nome, Telefone, DataNascimento, Cfp, QtdAtendimentos) VALUES ('John Snow', '11-67333-4454', '2000-10-30', 62316840086, 0);");
            migrationBuilder.Sql("INSERT INTO Pedagogos (Nome, Telefone, DataNascimento, Cfp, QtdAtendimentos) VALUES ('Sansa Stark', '22-22333-4454', '2004-10-30', 49850253053, 0);");
            migrationBuilder.Sql("INSERT INTO Pedagogos (Nome, Telefone, DataNascimento, Cfp, QtdAtendimentos) VALUES ('Tyrion Lannister', '33-77333-4454', '1990-10-30', 39125106015, 0);");
            migrationBuilder.Sql("INSERT INTO Pedagogos (Nome, Telefone, DataNascimento, Cfp, QtdAtendimentos) VALUES ('Sandor Clegane', '44-33333-2222', '1995-10-30', 89089606009, 0);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
