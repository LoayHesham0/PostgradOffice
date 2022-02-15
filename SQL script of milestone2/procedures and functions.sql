use Postgradoffice

go

--1(a)(1)  procedure
create proc StudentRegister
@first_name varchar(20),
@last_name varchar(20),
@password varchar(20),
@faculty varchar(20),
@Gucian bit,
@email varchar(50),
@address varchar(50)
as
IF @first_name IS NULL or @last_name is null or @password IS NULL or @faculty IS NULL or @Gucian IS NULL or @email IS NULL or @address is null
     print 'One of the inputs is null'
else 
begin
insert into postgraduser (email,password) values (@email,@password)
if @Gucian = '1'
     insert into GucianStudent (id,firstname,lastname,faculty,address) values (SCOPE_IDENTITY(),@first_name,@last_name,@faculty,@address)
else
     insert into NonGucianStudent (id,firstname,lastname,faculty,address) values (SCOPE_IDENTITY(),@first_name,@last_name,@faculty,@address)
end

go

--1(a)(2) procedure

create proc SupervisorRegister
@first_name varchar(20),
@last_name varchar(20),
@password varchar(20),
@faculty varchar(20),
@email varchar(50)
as
IF @first_name IS NULL or @last_name is null or @password IS NULL or @faculty IS NULL or @email IS NULL 
     print 'One of the inputs is null'
else
begin
insert into PostGradUser (email,password) values (@email,@password)
insert into Supervisor (id,name,faculty) values (SCOPE_IDENTITY(),@first_name+' '+@last_name,@faculty)
end

go

create proc ExaminerRegister
@first_name varchar(20),
@last_name varchar(20),
@password varchar(20),
@fieldOfWork varchar(20),
@email varchar(50),
@isNational bit
as
IF @first_name IS NULL or @last_name is null or @password IS NULL or @fieldOfWork IS NULL or @email IS NULL  or @isNational is null
     print 'One of the inputs is null'
else
begin
insert into PostGradUser (email,password) values (@email,@password)
insert into examiner (id,name,fieldOfWork,isNational) values (SCOPE_IDENTITY(),@first_name+' '+@last_name,@fieldOfWork,@isNational)
end

go

--2(a) procedure

CREATE proc userlogin
@id INT,
@password varchar(20),
@success bit output
as
IF(EXISTS (SELECT * FROM PostGradUser WHERE @id=Postgraduser.id   AND @password=PostGradUser.password  ))
begin
SET @success = '1'
end
ELSE
begin
SET @success = '0'
end

go

--2(b) procedure

create proc addMobile 
@id int, 
@mobile_number varchar(20)
as
IF(EXISTS (SELECT id FROM GUCStudentPhoneNumber WHERE @id=GUCStudentPhoneNumber.id) )
insert into GUCStudentPhoneNumber (id,phone) values (@id,@mobile_number)
else
IF(EXISTS (SELECT id FROM nonGUCStudentPhoneNumber WHERE @id=nonGUCStudentPhoneNumber.id) )
insert into nonGUCStudentPhoneNumber (id,phone) values (@id,@mobile_number)

go

--3(a) procedure
create proc AdminListSup
as
Select PostGradUser.id,PostGradUser.email,PostGradUser.password,supervisor.name, supervisor.faculty
from PostGradUser inner join Supervisor  on PostGradUser.id = Supervisor.id

go

--3(b) procedure
create proc AdminViewSupervisorProfile
@supid int
as
select * from Supervisor where Supervisor.id = @supid

go

--3(c) procedure
create proc AdminViewAllTheses
as
select * from thesis

go

--3(d) prodeure
create proc adminViewOnGoingTheses
@thesesCount int output
as
select @thesesCount=count(serialnumber)  from thesis where thesis.endDate>CURRENT_TIMESTAMP 

go

--3(e) procedure
create proc  AdminViewStudentThesisBySupervisor
as
select title,firstname,lastname,name from  thesis inner join GUCianStudentRegisterThesis 
on Thesis.serialNumber=GUCianStudentRegisterThesis.serial_no join GucianStudent 
on GUCianStudentRegisterThesis.sid = GucianStudent.id inner join supervisor on
GUCianStudentRegisterThesis.supid=supervisor.id where thesis.endDate>CURRENT_TIMESTAMP 
union
select title,firstname,lastname,name from  thesis inner join NonGUCianStudentRegisterThesis 
on Thesis.serialNumber=NonGUCianStudentRegisterThesis.serial_no inner join NonGucianStudent on
NonGUCianStudentRegisterThesis.sid = NonGucianStudent.id inner join supervisor on 
NonGUCianStudentRegisterThesis.supid=supervisor.id where thesis.endDate>CURRENT_TIMESTAMP 

go

--3(f) procedure

create proc AdminListNonGucianCourse
@courseID int
as 
select firstname,lastname,code,grade 
from NonGucianStudentTakeCourse inner join NonGucianStudent 
on  NonGucianStudentTakeCourse.sid=NonGucianStudent.id 
inner join course on NonGucianStudentTakeCourse.cid=course.id
where @courseID=course.id


go

--3(g) procedure

create proc AdminUpdateExtension
@ThesisSerialNo int
as
if(exists(select noExtension from thesis where thesis.serialNumber=@ThesisSerialNo))
UPDATE thesis
SET noExtension=noExtension + 1
WHERE thesis.serialNumber=@ThesisSerialNo


go

--3(h) procedure

create proc AdminIssueThesisPayment
@ThesisSerialNo int,
@amount decimal(10,5), 
@noOfInstallments int, 
@fundPercentage decimal(10,5)
as
if(exists(select * from Thesis where serialNumber=@ThesisSerialNo))
begin
insert into Payment(amount,no_Installments,fundPercentage)
values(@amount,@noOfInstallments,@fundPercentage)
declare @id int
SELECT @id=SCOPE_IDENTITY()
update Thesis
set payment_id=@id
where thesis.serialNumber=@ThesisSerialNo
end


go

--3(i) procedure

create proc AdminViewStudentProfile
@sid int
as
if(exists(select * from gucianstudent where GucianStudent.id=@sid ))
        select * from GucianStudent where GucianStudent.id=@sid
else
begin
if(exists(select id from NonGucianStudent where NonGucianStudent.id=@sid ))
        select * from NonGucianStudent where NonGucianStudent.id=@sid
else
        print 'student not found'
end

go

--3(j) procedure

create proc AdminIssueInstallPayment
@paymentID int, 
@InstallStartDate date
as 
declare @no_installments int;
declare @amount decimal(10,5);
declare @fund_percentage decimal(10,5);
declare @installment_amount decimal(10,5);
select @no_installments=no_installments,@amount=amount,@fund_percentage=fundPercentage
from payment where payment.id=@paymentID
set @installment_amount=(@amount/@no_installments+(@amount/@no_installments)*@fund_percentage)
while @no_installments<>0
begin
       insert into Installment (date,paymentId,amount,done)
       values (@InstallStartDate,@paymentID,@installment_amount,'0')
       set @no_installments=@no_installments-1
       SET @InstallStartDate = DATEADD(month, 6, @InstallStartDate);
end;


go

--3(k) procedure

create proc AdminListAcceptPublication
as 
select title from publication where accepted='1'

go

--3(l)(1) procedure

create proc  AddCourse
@courseCode varchar(10),
@creditHrs int,
@fees decimal(10,5)
as
insert into Course (code,creditHours,fees) values (@courseCode,@creditHrs,@fees)

go

--3(l)(2) procedure
 create proc linkCourseStudent
 @courseID int,
 @studentID int
 as
 insert into NonGucianStudentTakeCourse (cid,sid,grade) values (@courseID,@studentID,null)

 go

 --3(l)(3) procedure
create proc  addStudentCourseGrade
 @courseID int,
 @studentID int,
 @grade decimal(10,5)
as 
insert into NonGucianStudentTakeCourse (cid,sid,grade) values (@courseID,@studentID,@grade)

go

--3(m) procedure 
create proc  ViewExamSupDefense
@defenseDate date
as
select examiner.name,Supervisor.name from
ExaminerEvaluateDefense inner join examiner on ExaminerEvaluateDefense.examinerId=examiner.id
inner join GUCianStudentRegisterThesis on ExaminerEvaluateDefense.serialNo=GUCianStudentRegisterThesis.serial_no
inner join Supervisor on GUCianStudentRegisterThesis.supid=supervisor.id
where @defenseDate=ExaminerEvaluateDefense.date
union
select examiner.name,supervisor.name from
ExaminerEvaluateDefense inner join examiner on ExaminerEvaluateDefense.examinerId=examiner.id
inner join NonGUCianStudentRegisterThesis on ExaminerEvaluateDefense.serialNo=NonGUCianStudentRegisterThesis.serial_no
inner join Supervisor on NonGUCianStudentRegisterThesis.supid=supervisor.id
where @defenseDate=ExaminerEvaluateDefense.date

go

--4(a) procedure

create proc EvaluateProgressReport
@supervisorID int,
@thesisSerialNo int,
@progressReportNo int,
@evaluation int
as
if exists(select gpr.eval
          from GUCianProgressReport gpr
          where gpr.thesisSerialNumber=@thesisSerialNo and gpr.no=@progressReportNo and gpr.eval<>null and gpr.supid=@supervisorID
)print 'report already evaluated'
else if exists(select ngpr.eval
          from NonGUCianProgressReport ngpr
          where ngpr.thesisSerialNumber=@thesisSerialNo and ngpr.no=@progressReportNo and ngpr.eval<>null and ngpr.supid=@supervisorID
)print 'report already evaluated'
else if exists(select gpr.eval
          from GUCianProgressReport gpr
          where gpr.thesisSerialNumber=@thesisSerialNo and gpr.no=@progressReportNo and gpr.supid<>@supervisorID
)print 'another supervisor is in charge of this report'
else if exists(select ngpr.eval
          from NonGUCianProgressReport ngpr
          where ngpr.thesisSerialNumber=@thesisSerialNo and ngpr.no=@progressReportNo and ngpr.supid<>@supervisorID
)print 'another supervisor is in charge of this report'
else if exists(select ngpr.eval
          from NonGUCianProgressReport ngpr
          where ngpr.thesisSerialNumber=@thesisSerialNo and ngpr.no=@progressReportNo and ngpr.supid=@supervisorID
)update NonGUCianProgressReport
    set eval=@evaluation where thesisSerialNumber=@thesisSerialNo and no=@progressReportNo and supid=@supervisorID;
else 
update GUCianProgressReport
    set eval=@evaluation where thesisSerialNumber=@thesisSerialNo and no=@progressReportNo and supid=@supervisorID;


go

--4(b) procedure
create proc ViewSupStudentsYears
@supervisorID int
as 
if exists(select *
          from GUCianProgressReport gpr 
               inner join GucianStudent gs on gpr.sid=gs.id
          where gpr.supid=@supervisorID
) or exists(select *
          from NonGUCianProgressReport ngpr 
               inner join NonGucianStudent ngs on ngpr.sid=ngs.id
          where ngpr.supid=@supervisorID
)begin
select gs.firstName, gs.lastName , t.years
          from Supervisor s inner join  
          GUCianProgressReport gpr on s.id=gpr.supid
               inner join GucianStudent gs on gpr.sid=gs.id
               inner join thesis t on t.serialNumber=gpr.thesisSerialNumber
          where gpr.supid=@supervisorID
union
select ngs.firstName, ngs.lastName , t.years
          from Supervisor s inner join  
          NonGUCianProgressReport ngpr on s.id=ngpr.supid
               inner join NonGucianStudent ngs on ngpr.sid=ngs.id
               inner join thesis t on t.serialNumber=ngpr.thesisSerialNumber
          where ngpr.supid=@supervisorID
end
else print 'No students under your supervision'

go

--4(c)(1) procedure
create proc SupViewProfile
@supervisorID int
as
if exists(select *
from Supervisor s
where s.id=@supervisorID
)select *
from Supervisor s
where s.id=@supervisorID
else print 'Supervisor Does not exist'

go

--4(c)(2) procedure
create proc UpdateSupProfile
@supervisorID int,
@name varchar(20), 
@faculty varchar(20)
as
if exists(select *
from Supervisor s
where s.id=@supervisorID
)
update Supervisor set name=@name , faculty=@faculty
where id=@supervisorID
else print 'Supervisor Does not exist'
 
go

--4(d) procedure
create proc ViewAStudentPublications
@StudentID int
as 
if (exists( select * 
            from GucianStudent gs
            where @StudentID=gs.id)
) 
select p.id, p.title, p.place, p.accepted, p.host
from Publication p inner join ThesisHasPublication thp on p.id=thp.pubid
    inner join Thesis t on thp.serialNo=t.serialNumber
    inner join GUCianProgressReport gpa on t.serialNumber=gpa.thesisSerialNumber
where @StudentID=gpa.sid
else if (exists( select * 
            from NonGucianStudent ngs
            where @StudentID=ngs.id)
) 
select p.id, p.title, p.place, p.accepted, p.host
from Publication p inner join ThesisHasPublication thp on p.id=thp.pubid
    inner join Thesis t on thp.serialNo=t.serialNumber
    inner join NonGUCianProgressReport ngpa on t.serialNumber=ngpa.thesisSerialNumber
where @StudentID=ngpa.sid
else 
print 'It is not a student id'

go

--4(e)(1) procedure
create proc AddDefenseGucian
@ThesisSerialNo int ,
@DefenseDate Datetime ,
@DefenseLocation varchar(15)
as
if exists(select *
from Thesis t inner join GUCianProgressReport gpa on t.serialNumber=gpa.thesisSerialNumber
where t.serialNumber=@ThesisSerialNo)
insert into defense (serialNumber,Date,location) values (@ThesisSerialNo,@DefenseDate,@DefenseLocation)
else print 'Not gucian student'

go

--4(e)(2) procedure
create proc AddDefenseNonGucian
@ThesisSerialNo int ,
@DefenseDate Datetime ,
@DefenseLocation varchar(15)
as
if exists(select *
from Thesis t inner join NonGUCianProgressReport ngpa on t.serialNumber=ngpa.thesisSerialNumber
where t.serialNumber=@ThesisSerialNo)
if @ThesisSerialNo in ( 
            select ngpa1.thesisSerialNumber
            from NonGucianStudentTakeCourse ngstc1 
            inner join NonGucianStudent ngs1 on ngstc1.sid=ngs1.id
            inner join NonGUCianProgressReport ngpa1 on ngs1.id=ngpa1.sid
            group by ngpa1.thesisSerialNumber
            having min(ngstc1.grade)>50
)insert into defense (serialNumber,Date,location) values (@ThesisSerialNo,@DefenseDate,@DefenseLocation)
else print 'has grades less than 50' 
else print 'Not a Nongucian student'

go 


--4(f) procedure  
create proc AddExaminer
@thesisserialNo int,
@DefenseDate Date,
@ExaminerName varchar(26),
@National bit,
@Fieldofwork varchar(20)
as
declare @identification int;
select @identification=examiner.id from examiner where @ExaminerName=Examiner.name and @National=Examiner.isNational and @fieldofwork=Examiner .fieldofwork
insert into ExaminerEvaluateDefense (date, serialNo, examinerId, comment)
values (@DefenseDate, @ThesisserialNo, @identification, 'good work')

go


--4(g) procedure
create proc CancelThesis
@ThesisSerialNo int,
@success bit output
as
if exists(select *
          from thesis t inner join GUCianProgressReport gpr on t.serialNumber=gpr.thesisSerialNumber
          where gpr.eval=0 and t.serialNumber=@ThesisSerialNo
)
begin
delete from  thesis  where Thesis.serialNumber=@ThesisSerialNo;
set @success = '1';
end
else if exists(select *
          from thesis t inner join NonGUCianProgressReport ngpr on t.serialNumber=ngpr.thesisSerialNumber
          where ngpr.eval=0 and t.serialNumber=@ThesisSerialNo
) 
begin 
delete from  thesis  where Thesis.serialNumber=@ThesisSerialNo;
set @success='1';
end 
else 
set @success='0';

go

--4(h) procedure
create proc AddGrade
@ThesisSerialNo int
as 
declare @grade decimal(10,5)
if exists(select *
          from thesis t inner join defense d on t.serialNumber=d.serialNumber
          where d.grade is not null)
begin
    select @grade=grade from defense d where d.serialNumber=@ThesisSerialNo;
    update thesis
    set grade=@grade where thesis.serialnumber=@thesisSerialNo;
end
else
print 'grade in defense is null'

go 

--5(a) procedure
create proc AddDefenseGrade
@ThesisSerialNo int , 
@DefenseDate Datetime , 
@grade decimal(10,5),
@success bit output
as
if exists(select d.grade
          from Defense d
          where d.serialNumber=@ThesisSerialNo and d.date=@DefenseDate and grade <> null)
begin
set @success = '1';
print 'defense already graded'
end
else if exists (select *
from thesis t
where @ThesisSerialNo= t.serialNumber) 
Begin
set @success = '0';
update Defense
    set grade=@grade where Defense.serialNumber=@thesisSerialNo and Defense.date=@DefenseDate

end
go


--5(b) procedure
CREATE proc AddCommentsGrade
@ThesisSerialNo int ,
@DefenseDate Datetime ,
@comments varchar(300),
@success bit output
as
if exists(select eed.comment
          from ExaminerEvaluateDefense eed 
          where eed.serialNo=@ThesisSerialNo and eed.date=@DefenseDate and eed.comment <> null)
begin
set @success = '1';
print 'defense already already commented on'
end
else if exists (select *
from thesis t
where @ThesisSerialNo= t.serialNumber) 
Begin
set @success = '0';
update ExaminerEvaluateDefense
    set comment=@comments where ExaminerEvaluateDefense.serialNo=@thesisSerialNo and ExaminerEvaluateDefense.date=@DefenseDate
end
go

--6(a) procedure

create proc viewMyProfile
@studentId int
as
if(exists(
select * from GucianStudent where id = @studentId
))
begin
select G.*,P.email
from GucianStudent G
inner join PostGradUser P
on G.id = P.id
where G.id = @studentId
end
else
begin
select N.*,P.email
from NonGucianStudent N
inner join PostGradUser P
on N.id = P.id
where N.id = @studentId
end


go

--6(b) procedure
create proc editMyProfile
@StudentID int,
@firstName varchar(10),
@lastName varchar(10),
@password varchar(10),
@email varchar(10),
@address varchar(10),
@type varchar(10)
as
IF(EXISTS (SELECT GUC.id FROM GucianStudent GUC WHERE @studentID = GUC.id) )
Update GucianStudent
set firstName = @firstName, lastName = @lastName, address = @address, type = @type 
where id = @studentID 
else
IF(EXISTS (SELECT NON.id FROM nonGUCianStudent NON WHERE NON.id = @studentid) )
Update GucianStudent
set firstName = @firstName, lastName = @lastName, address = @address, type = @type 
where id = @studentID 

Update PostGradUser
set email = @email, password = @password 
where id = @StudentID

 go 

 --6(c) procedure
create proc addUndergradID
@studentID int,
@undergradID varchar(10)
as
update GUCianStudent
set undergradID = @undergradID
where id = @studentID 

go

--6(d) procedure
create proc ViewCoursesGrades
@studentID int 
as 
select C.code as 'Course Code', NGC.grade as 'Grade' 
from NonGucianStudentTakeCourse NGC inner join Course C on NGC.cid = C.id  
where sid = @studentID

go

--6(e)(1) procedure
create proc viewCoursePaymentsInstall
@studentID int 
as 
select C.code, 
P.amount as 'Total Amount', 
P.no_installments as 'No. of Installments', I.date as ' Date of installment', I.amount as 'Installment amount',
        case 
            when done = 0 then 'pending'
            when done = 1 then 'paid'
        end
as 'Status' 

 
from NonGucianStudentPayForCourse NGC inner join Payment P on NGC.paymentNo = P.id 
                                    inner join Installment I on P.id = I.paymentId
                                    inner join Course C on NGC.cid = c.id
where NGC.sid = @studentID

go

--6(e)(2) procedure
create proc ViewThesisPaymentsInstall
@studentID int 
as 
IF(EXISTS (SELECT GUC.id FROM GucianStudent GUC WHERE @studentID = GUC.id) )
select TH.type as ' Thesis Type' , TH.title as ' Thesis Title' , P.amount as 'Total Amount', 
P.no_installments as 'No. of Installments', I.date as ' Date of installment', I.amount as 'Installment amount',
        case 
            when done = 0 then 'pending'
            when done = 1 then 'paid'
        end
as 'Status' 

from GUCianStudentRegisterThesis GUCTH inner join Thesis TH on GUCTH.serial_no = TH.serialNumber  
                                       inner join Payment P on TH.payment_id = P.id 
                                       inner join Installment I on P.id = I.paymentId

where GUCTH.sid = @studentID

else 
IF(EXISTS (SELECT NON.id FROM NonGucianStudent NON WHERE @studentID = NON.id) )
select TH.type as ' Thesis Type' , TH.title as ' Thesis Title' , P.amount as 'Total Amount', 
P.no_installments as 'No. of Installments', I.date as ' Date of installment', I.amount as 'Installment amount',
        case 
            when done = 0 then 'pending'
            when done = 1 then 'paid'
        end
as 'Status' 

from NonGUCianStudentRegisterThesis NONTH inner join Thesis TH on NONTH.serial_no = TH.serialNumber  
                                       inner join Payment P on TH.payment_id = P.id 
                                       inner join Installment I on P.id = I.paymentId

where NONTH.sid = @studentID

go 


--6(e)(3)  procedure
create proc ViewUpcomingInstallments 
@studentID int

as


IF(EXISTS (SELECT GUC.id FROM GucianStudent GUC WHERE @studentID = GUC.id) )
select TH.type as ' Thesis Type' , TH.title as ' Thesis Title' , 
P.no_installments as 'No. of Installments', I.date as ' Date of installment', I.amount as 'Installment amount'

from GUCianStudentRegisterThesis GUCTH inner join Thesis TH on GUCTH.serial_no = TH.serialNumber  
                                       inner join Payment P on TH.payment_id = P.id 
                                       inner join Installment I on P.id = I.paymentId

where GUCTH.sid = @studentID and I.date > CURRENT_TIMESTAMP and I.done = 0

else 

select I.date as ' Date of installment', I.amount as 'Installment amount'
 
from NonGucianStudentPayForCourse NGC inner join Payment P on NGC.paymentNo = P.id 
                                    inner join Installment I on P.id = I.paymentId
                                    inner join Course C on NGC.cid = c.id
where NGC.sid = @studentID and I.date > CURRENT_TIMESTAMP

Union

select I.date as ' Date of installment', I.amount as 'Installment amount'
from GUCianStudentRegisterThesis GUCTH inner join Thesis TH on GUCTH.serial_no = TH.serialNumber  
                                       inner join Payment P on TH.payment_id = P.id 
                                       inner join Installment I on P.id = I.paymentId

where GUCTH.sid = @studentID and I.date > CURRENT_TIMESTAMP

go

--6(e)(4)  procedure
create proc ViewMissedInstallments  

@studentID int

as


IF(EXISTS (SELECT GUC.id FROM GucianStudent GUC WHERE @studentID = GUC.id) )
select I.date as ' Date of installment', I.amount as 'Installment amount'

from GUCianStudentRegisterThesis GUCTH inner join Thesis TH on GUCTH.serial_no = TH.serialNumber  
                                       inner join Payment P on TH.payment_id = P.id 
                                       inner join Installment I on P.id = I.paymentId

where GUCTH.sid = @studentID and I.date < CURRENT_TIMESTAMP and I.done = 0

else 
IF(EXISTS (SELECT NON.id FROM NONGucianStudent NON WHERE @studentID = NON.id) )
select I.date as ' Date of installment', I.amount as 'Installment amount'
 
from NonGucianStudentPayForCourse NGC inner join Payment P on NGC.paymentNo = P.id 
                                    inner join Installment I on P.id = I.paymentId
                                    inner join Course C on NGC.cid = c.id
where NGC.sid = @studentID and I.date < CURRENT_TIMESTAMP and I.done = 0

Union

select I.date as ' Date of installment', I.amount as 'Installment amount'
from GUCianStudentRegisterThesis GUCTH inner join Thesis TH on GUCTH.serial_no = TH.serialNumber  
                                       inner join Payment P on TH.payment_id = P.id 
                                       inner join Installment I on P.id = I.paymentId

where GUCTH.sid = @studentID and I.date < CURRENT_TIMESTAMP and I.done = 0

go


-- 6(f)(1) procedure
create proc AddProgressReport
@thesisSerialNo int,
@ProgressReportDate date
as
declare @sid int
declare @no int
declare @which bit
declare @supid int
IF(EXISTS (SELECT GUC.serial_no FROM GUCianStudentRegisterThesis GUC WHERE @thesisSerialNo = GUC.serial_no) )
SELECT @sid = GUC.sid, @which = 1, @supid = supid 
FROM GUCianStudentRegisterThesis GUC 
WHERE @thesisSerialNo = GUC.serial_no

else 

IF(EXISTS (SELECT NON.serial_no FROM NonGUCianStudentRegisterThesis NON WHERE @thesisSerialNo = NON.serial_no) )

SELECT @sid = NON.sid, @which = 0, @supid = supid
FROM NONGUCianStudentRegisterThesis NON 
WHERE @thesisSerialNo = NON.serial_no

if (@which = 1)
select @no = max(GUC.no) + 1
from GUCianProgressReport GUC
else
if (@which = 0)
select @no = max(NON.no) + 1
from NonGUCianProgressReport NON

if (@which = 1)
insert into GUCianProgressReport (sid,no,thesisSerialNumber, supid, date)
values (@sid,@no,@thesisSerialNo, @supid, @ProgressReportDate)
else 
if (@which = 0)
insert into NonGUCianProgressReport (sid,no,thesisSerialNumber, supid, date)
values (@sid,@no,@thesisSerialNo, @supid, @ProgressReportDate)

go

--6(f)(2)  procedure 
create proc FillProgressReport
@thesisSerialNo int,
@ProgressReportNo int,
@state int,
@description varchar(200)
as

IF(EXISTS (SELECT GUC.thesisSerialNumber FROM GUCianProgressReport GUC WHERE @thesisSerialNo = GUC.thesisSerialNumber) )
UPDATE GUCianProgressReport 
set state = @state, description = @description
where thesisSerialNumber = @thesisSerialNo AND no = @ProgressReportNo

else 

IF(EXISTS (SELECT NON.thesisSerialNumber FROM NonGUCianProgressReport NON WHERE @thesisSerialNo = NON.thesisSerialNumber) )
UPDATE NonGUCianProgressReport 
set state = @state, description = @description
where thesisSerialNumber = @thesisSerialNo AND no = @ProgressReportNo

go

--6(g) procedure
create proc ViewEvalProgress
@thesisSerialNo int,
@ProgressReportNo int
as 

IF(EXISTS (SELECT GUC.thesisSerialNumber FROM GUCianProgressReport GUC WHERE @thesisSerialNo = GUC.thesisSerialNumber) )

select no as 'Progress Report No.' , date, eval as 'Progress Evaluation', state as 'State'
from GUCianProgressReport
where thesisSerialNumber = @thesisSerialNo AND no = @ProgressReportNo
else

IF(EXISTS (SELECT NON.thesisSerialNumber FROM NonGUCianProgressReport NON WHERE @thesisSerialNo = NON.thesisSerialNumber) )
select no as 'Progress Report No.' , date, eval as 'Progress Evaluation', state as 'State'
from NONGUCianProgressReport
where thesisSerialNumber = @thesisSerialNo AND no = @ProgressReportNo

go

--6(h)  procedure
create proc addPublication 
@title varchar(50),
@pubDate datetime, 
@host varchar(50),
@place varchar(50),
@accepted bit
as

insert into Publication(title,date,place,host,accepted) values (@title,@pubDate,@place,@host,@accepted)

go

-- 6(i)  procedure
create proc LinkPubThesis
@PubID int,
@thesisSerialNo int
as
insert into ThesisHasPublication(pubid,serialNo) values(@PubID,@thesisSerialNo)

go

create proc tabletype
@id int,
@type varchar(30) output
as
select @id from PostGradUser where PostGradUser.id=@id
if(exists(select * from GucianStudent where @id=GucianStudent.id))
set @type='gucianstudent'
else if(exists(select * from NonGucianStudent where @id=NonGucianStudent.id))
set @type='nongucianstudent'
else if(exists(select * from Supervisor where @id=Supervisor.id))
set @type='supervisor'
else if(exists(select * from Examiner where @id=Examiner.id))
set @type='examiner'
else if(exists(select * from Admin where @id=Admin.id))
set @type='admin'

go

create proc UpdateExaminerProfile
@ExaminerID int, @name varchar(20), @fieldOfWork varchar(20)
as
update Examiner
set name = @name, fieldOfWork = @fieldOfWork
where id = @ExaminerID

go

CREATE PROC ExaminerSearchForThesis
@keyword VARCHAR(20)
AS
SELECT *
FROM Thesis t
WHERE t.title LIKE '%'+@keyword+'%';

go

CREATE PROC ListThesis
@examinerId int 
AS
SELECT t.*
FROM Examiner e inner join ExaminerEvaluateDefense eed on e.id=eed.examinerId
    inner join Defense d on eed.date=d.date and eed.serialNo=d.serialNumber
    inner join Thesis t on d.serialNumber=t.serialNumber
where e.id=@examinerId

go


create proc GetName
@studentID int
as 
if(exists(
select * from GucianStudent where id = @studentId
))
begin
select G.firstName
from GucianStudent G
where G.id = @studentID
end
else
begin
select N.firstName
from NonGucianStudent N
where N.id = @studentID
end

go

create proc GetThesis
@studentID int
as 
if(exists(
select * from GucianStudent where id = @studentID
))
begin
select T.serialNumber ,T.title, T.type, T.field, T.startDate, T.endDate, T.defenseDate, T.years, T.grade
from Thesis T inner join GUCianStudentRegisterThesis G on T.serialNumber = G.serial_no
where G.sid = @studentID
end
else
begin
select T.serialNumber , T.title, T.type, T.field, T.startDate, T.endDate, T.defenseDate, T.years, T.grade
from Thesis T inner join NonGUCianStudentRegisterThesis N on T.serialNumber = N.serial_no
where N.sid = @studentID
end

go


