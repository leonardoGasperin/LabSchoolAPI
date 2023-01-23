# LabSchoolAPI - DevInHouse[EDP] Module 2 Project 2
Project did on the DevInHouse[EDP] Fullstack course, to simulate a DB sistem to store information related to the students, professors and pedagogues. of the school **Lab School**, using ASP.NET and SSMS
##
# Controllers
To this project I maded four controllers, three Controllers to the models for "Aluno"(students), "Professor"(professors) and "Pedagogo"(pedagogues), plus one for "Atendimento"(pedagogue services for the school).
### AlunoController
This controller need registrate, get all records, get all records by student situation, get by id (on project need be 'codigo' instead id), edit the student registration situation, delete record.
- GET /api/alunos
  - Here the controller can get all students or get all related by student registration situation.
  - The registration need be valid on [ MatriculaSituacao enum ](https://github.com/leonardoGasperin/LabSchoolAPI/blob/master/LabSchoolAPI/Abstract/MatriculaSituacao.cs) or else will return 404 situation of registry is invalid, in portuguese. 
  - the situation value is not sense case.
- GET /api/alunos/codigo
  - This GET can return one object Aluno what contains all student information with this object codigo (ID) otherwise it's will return 404 invalide code, in portuguese.
