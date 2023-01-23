# LabSchoolAPI - DevInHouse[EDP] Module 2 Project 2
Project did on the DevInHouse[EDP] Fullstack course, to simulate a DB sistem to store information related to the students, professors and pedagogues. of the school **Lab School**, using ASP.NET and SSMS
##
## Controllers
To this project I maded four controllers, three Controllers to the models for "Aluno"(students), "Professor"(professors) and "Pedagogo"(pedagogues), plus one for "Atendimento"(pedagogue services for the school). Using DTO and AutoMapper.
### AlunoController
This controller need registrate, get all records, get all records by student situation, get by id (on project need be 'codigo' instead id), edit the student registration situation, delete record.
- GET /api/alunos
  - Here the controller can get all students or get all related by student registration situation.
  - The registration need be valid on [ MatriculaSituacao enum ](https://github.com/leonardoGasperin/LabSchoolAPI/blob/master/LabSchoolAPI/Abstract/MatriculaSituacao.cs) or else will return 404 not found situation of registry is invalid, in portuguese. 
  - the situation value is not sense case.
- GET /api/alunos/{codigo}
  - This GET can return one object Aluno what contains all student information with this object codigo (ID) otherwise it's will return 404 not found invalid code, in portuguese.
- POST /api/alunos
This post registrate one student, geting all model props less the codigo (ID)
  - Will check if the CPF do not exist yet otherwise will return conflict CPF alredy registred on the system, in portuguese.
  - Will check if the registration situation is valid or will return conflict situation not valid, in portugese.
  - And try registration, if something more is invalid it will return 500 bad request.
- PUT /api/alunos/{codigo}
Here will get one student by codigo (ID) and will update the new registration situation if is valid
- DELETE /api/alunos/{codigo}
Will search one student by codigo (ID) and remove it from DB, if codigo is not valid will return 404 not found codigo is not valid, in portuguese.
### ProfessorController
This controller got nothing much diferent then usual, only the use of the DTO to hide codigo props on POST.
- GET /api/professores
  - Get all professors
- GET /api/professores/{codigo}
  - Get one professor by codigo (ID)
  - if codigo is not valid will return 404 not found.
- PUT /api/professores/{codigo}
  - get one professor by codigo (ID) if valid otherwise return 404 not found.
  - Update any professor prop.
- DELETE
  - Will search one professor by codigo (ID) and remove it from DB, if codigo is valid otherwise will return 404 not found.
### PedagogoController
This controller work equal professor.
### AtendimentoController
This controller registry a requeriment for pedagogues services and update if student situation to 'ATENDIMENTO_PEDAGOGO', plus increment on the student and pedagogue Atendimento props (attendence).
- PUT /api/atendimentos
  - the body request ask only for codigo (ID) for student and pedagogue to realize the registry and alterations
  - if the codigo is invalid will return 404 not found
  - if anything goes wrong on update before save will return 500 bad request.
# Instalation && Requirements
To run this webAPI you will need one PC with internet acess, VStudio or VSCode or any equivalent ID that you can run ASP.NET and C# NuGet packages and a SQL DataBase, I recommend use what I used SSMS.
- SSMS version 18 or +
### Using VStudio 2022
- Version: 17.4.1 or +
- .Net version: net7.0
- Packages:
  - Microsoft.AspNetCore.OpenApi version: 7.0.1 or +
  - Swashbuckle.AspNetCore version: 6.4.0 or +
  - Microsoft.EntetyFrameworkCore version: 7.0.1 or +
  - Microsoft.EntetyFrameworkCore.Design version: 7.0.0 or +
  - Microsoft.EntetyFrameworkCore.SqlServer version: 7.0.1 or +
  - Microsoft.EntetyFrameworkCore.Tools version: 7.0.1 or +
  - AutoMapper version: 12.0.0 or +
  - AutoMapper.Extensions.Microsoft.DependencyInjection version: 12.0.0 or +
### Using VSCode
- Version: any version what can run .Net 7
- Extensions:
  - .NET Extension Pack version: 1.0.12 or +
  - .NET Install Tool for Extension Authors version: 1.6.0 or +
  - C# version: 1.25.2 or +
# Running
to can run you will need have an SQL server string connection properly referencied on your project, can be used any type of server, I've used local.
with a SQL working on your IDE properly you will need run the command on the terminal inside the projext folder
  <code>dotnet ef migrations add 'migration_name'</code>
and after the update using
  <code>dotnet ef migrations add</code>
after it you'll need choosen the ISS Express depuration or HTTPS and it'll can be run.
# Acess and usage
This project is all open source, and it's free, can be cloned and can open a branch for new updates if you want.
But this repository is my portifolio and you are free to download and make a personal repository with this project if you plea.
