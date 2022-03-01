Create Database EnalyserATM 

Use EnalyserATM  
  
Create table Notes(Id int primary key identity(1,1), Amount int not null, NoteType bit not null, Size int null)  

Insert into Notes Values(1000, 1, null)
Insert into Notes Values(500, 1, null)
Insert into Notes Values(200, 1, null)
Insert into Notes Values(100, 1, null)
Insert into Notes Values(50, 1, null)
Insert into Notes Values(20, 0, 40)
Insert into Notes Values(10, 0, 20)
Insert into Notes Values(5, 0, 50)
Insert into Notes Values(3, 0, 30)
Insert into Notes Values(1, 0, 10)
