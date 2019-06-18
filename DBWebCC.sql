/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2012                    */
/* Created on:     2017/11/8 20:54:38                           */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Arranger_table') and o.name = 'FK_ARRANGER_ARRANGER__AUTHORIT')
alter table Arranger_table
   drop constraint FK_ARRANGER_ARRANGER__AUTHORIT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Classroom_table') and o.name = 'FK_CLASSROO_CLASSROOM_BUILDING')
alter table Classroom_table
   drop constraint FK_CLASSROO_CLASSROOM_BUILDING
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('LiveDorm_table') and o.name = 'FK_LIVEDORM_REFERENCE_STUDENT_')
alter table LiveDorm_table
   drop constraint FK_LIVEDORM_REFERENCE_STUDENT_
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('LiveDorm_table') and o.name = 'FK_LIVEDORM_REFERENCE_DORM_TAB')
alter table LiveDorm_table
   drop constraint FK_LIVEDORM_REFERENCE_DORM_TAB
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('NewCourse_table') and o.name = 'FK_NEWCOURS_NEWCOURSE_TEACHER_')
alter table NewCourse_table
   drop constraint FK_NEWCOURS_NEWCOURSE_TEACHER_
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('NewCourse_table') and o.name = 'FK_NEWCOURS_REFERENCE_CLASSROO')
alter table NewCourse_table
   drop constraint FK_NEWCOURS_REFERENCE_CLASSROO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('NewCourse_table') and o.name = 'FK_NEWCOURS_REFERENCE_SCHOOLHO')
alter table NewCourse_table
   drop constraint FK_NEWCOURS_REFERENCE_SCHOOLHO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('NewCourse_table') and o.name = 'FK_NEWCOURS_REFERENCE_COURSE_T')
alter table NewCourse_table
   drop constraint FK_NEWCOURS_REFERENCE_COURSE_T
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Student_table') and o.name = 'FK_STUDENT__AUTHORITY_AUTHORIT')
alter table Student_table
   drop constraint FK_STUDENT__AUTHORITY_AUTHORIT
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('StudyCourse_table') and o.name = 'FK_STUDYCOU_REFERENCE_NEWCOURS')
alter table StudyCourse_table
   drop constraint FK_STUDYCOU_REFERENCE_NEWCOURS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('StudyCourse_table') and o.name = 'FK_STUDYCOU_STUDYCOUR_STUDENT_')
alter table StudyCourse_table
   drop constraint FK_STUDYCOU_STUDYCOUR_STUDENT_
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Teacher_table') and o.name = 'FK_TEACHER__AUTHORITY_AUTHORIT')
alter table Teacher_table
   drop constraint FK_TEACHER__AUTHORITY_AUTHORIT
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TeacherDetail_View')
            and   type = 'V')
   drop view TeacherDetail_View
go

if exists (select 1
            from  sysobjects
           where  id = object_id('StudentDetail_View')
            and   type = 'V')
   drop view StudentDetail_View
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Restudy_View2')
            and   type = 'V')
   drop view Restudy_View2
go

if exists (select 1
            from  sysobjects
           where  id = object_id('NewCourseAndChoose_View')
            and   type = 'V')
   drop view NewCourseAndChoose_View
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ManagerDetail_View')
            and   type = 'V')
   drop view ManagerDetail_View
go

if exists (select 1
            from  sysobjects
           where  id = object_id('FinishedGetGrade_View')
            and   type = 'V')
   drop view FinishedGetGrade_View
go

if exists (select 1
            from  sysobjects
           where  id = object_id('FinishedChooseCourse_View')
            and   type = 'V')
   drop view FinishedChooseCourse_View
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Arranger_table')
            and   type = 'U')
   drop table Arranger_table
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Authority_table')
            and   type = 'U')
   drop table Authority_table
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Building_table')
            and   type = 'U')
   drop table Building_table
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Classroom_table')
            and   type = 'U')
   drop table Classroom_table
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Course_table')
            and   type = 'U')
   drop table Course_table
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Dorm_table')
            and   type = 'U')
   drop table Dorm_table
go

if exists (select 1
            from  sysobjects
           where  id = object_id('LiveDorm_table')
            and   type = 'U')
   drop table LiveDorm_table
go

if exists (select 1
            from  sysobjects
           where  id = object_id('NewCourse_table')
            and   type = 'U')
   drop table NewCourse_table
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Schoolhour_table')
            and   type = 'U')
   drop table Schoolhour_table
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Student_table')
            and   type = 'U')
   drop table Student_table
go

if exists (select 1
            from  sysobjects
           where  id = object_id('StudyCourse_table')
            and   type = 'U')
   drop table StudyCourse_table
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Teacher_table')
            and   type = 'U')
   drop table Teacher_table
go

if exists(select 1 from systypes where name='Age')
   execute sp_unbindrule Age
go

if exists(select 1 from systypes where name='Age')
   drop type Age
go

if exists(select 1 from systypes where name='DateT')
   drop type DateT
go

if exists(select 1 from systypes where name='Email')
   drop type Email
go

if exists(select 1 from systypes where name='Name')
   drop type Name
go

if exists(select 1 from systypes where name='NatureCourse')
   drop type NatureCourse
go

if exists(select 1 from systypes where name='Number')
   drop type Number
go

if exists(select 1 from systypes where name='PassCode')
   drop type PassCode
go

if exists(select 1 from systypes where name='PhoneNum')
   drop type PhoneNum
go

if exists(select 1 from systypes where name='Profile')
   drop type Profile
go

if exists(select 1 from systypes where name='Score')
   drop type Score
go

if exists(select 1 from systypes where name='Sex')
   execute sp_unbindrule Sex
go

if exists(select 1 from systypes where name='Sex')
   drop type Sex
go

if exists(select 1 from systypes where name='State')
   execute sp_unbindrule State
go

if exists(select 1 from systypes where name='State')
   drop type State
go

if exists(select 1 from systypes where name='StudentNum')
   drop type StudentNum
go

if exists(select 1 from systypes where name='TimesectionSchoolhour')
   execute sp_unbindrule TimesectionSchoolhour
go

if exists(select 1 from systypes where name='TimesectionSchoolhour')
   drop type TimesectionSchoolhour
go

if exists(select 1 from systypes where name='UserImage')
   drop type UserImage
go

if exists(select 1 from systypes where name='id')
   drop type id
go

if exists (select 1 from sysobjects where id=object_id('R_Age') and type='R')
   drop rule  R_Age
go

if exists (select 1 from sysobjects where id=object_id('R_Sex') and type='R')
   drop rule  R_Sex
go

if exists (select 1 from sysobjects where id=object_id('R_State') and type='R')
   drop rule  R_State
go

if exists (select 1 from sysobjects where id=object_id('R_TimesectionSchoolhour') and type='R')
   drop rule  R_TimesectionSchoolhour
go

create rule R_Age as
      @column between 0 and 110
go

create rule R_Sex as
      @column in ('男','女','未填写')
go

create rule R_State as
      @column in (1,2,3,4)
go

create rule R_TimesectionSchoolhour as
      @column between 0 and 3
go

/*==============================================================*/
/* Domain: Age                                                  */
/*==============================================================*/
create type Age
   from int
go

execute sp_bindrule R_Age, Age
go

/*==============================================================*/
/* Domain: DateT                                                */
/*==============================================================*/
create type DateT
   from datetime
go

/*==============================================================*/
/* Domain: Email                                                */
/*==============================================================*/
create type Email
   from varchar(100)
go

/*==============================================================*/
/* Domain: Name                                                 */
/*==============================================================*/
create type Name
   from varchar(50)
go

/*==============================================================*/
/* Domain: NatureCourse                                         */
/*==============================================================*/
create type NatureCourse
   from int
go

/*==============================================================*/
/* Domain: Number                                               */
/*==============================================================*/
create type Number
   from varchar(50)
go

/*==============================================================*/
/* Domain: PassCode                                             */
/*==============================================================*/
create type PassCode
   from varchar(400)
go

/*==============================================================*/
/* Domain: PhoneNum                                             */
/*==============================================================*/
create type PhoneNum
   from varchar(50)
go

/*==============================================================*/
/* Domain: Profile                                              */
/*==============================================================*/
create type Profile
   from varchar(400)
go

/*==============================================================*/
/* Domain: Score                                                */
/*==============================================================*/
create type Score
   from int
go

/*==============================================================*/
/* Domain: Sex                                                  */
/*==============================================================*/
create type Sex
   from varchar(10)
go

execute sp_bindrule R_Sex, Sex
go

/*==============================================================*/
/* Domain: State                                                */
/*==============================================================*/
create type State
   from int
go

execute sp_bindrule R_State, State
go

/*==============================================================*/
/* Domain: StudentNum                                           */
/*==============================================================*/
create type StudentNum
   from varchar(50)
go

/*==============================================================*/
/* Domain: TimesectionSchoolhour                                */
/*==============================================================*/
create type TimesectionSchoolhour
   from int
go

execute sp_bindrule R_TimesectionSchoolhour, TimesectionSchoolhour
go

/*==============================================================*/
/* Domain: UserImage                                            */
/*==============================================================*/
create type UserImage
   from varchar(200)
go

/*==============================================================*/
/* Domain: id                                                   */
/*==============================================================*/
create type id
   from int
go

/*==============================================================*/
/* Table: Arranger_table                                        */
/*==============================================================*/
create table Arranger_table (
   IDArranger           id                   identity(4000000,1) not for replication,
   IDAuthority          int                  null,
   NumberArranger       Number               not null,
   NameArranger         Name                 not null,
   EmailArranger        Email                null,
   AgeArranger          Age                  null,
   SexArranger          Sex                  null default '未填写',
   PhoneNumArranger     PhoneNum             null,
   PasscodeArranger     PassCode             not null,
   ImageArranger        UserImage            null,
   constraint PK_ARRANGER_TABLE primary key (IDArranger),
   constraint AK_KEY_2_ARRANGER unique (NumberArranger)
)
go

/*==============================================================*/
/* Table: Authority_table                                       */
/*==============================================================*/
create table Authority_table (
   IDAuthority          id                   identity(10000,1) not for replication,
   LevelAuthority       int                  not null,
   constraint PK_AUTHORITY_TABLE primary key (IDAuthority)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('Authority_table') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'Authority_table' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '用于给用户权限', 
   'user', @CurrentUser, 'table', 'Authority_table'
go

/*==============================================================*/
/* Table: Building_table                                        */
/*==============================================================*/
create table Building_table (
   IDBuilding           id                   identity(70000,1) not for replication,
   NameBuilding         Name                 not null,
   NumBuilding          id                   not null,
   CountBuilding        id                   null,
   constraint PK_BUILDING_TABLE primary key (IDBuilding),
   constraint AK_KEY_2_BUILDING unique (NameBuilding, NumBuilding)
)
go

/*==============================================================*/
/* Table: Classroom_table                                       */
/*==============================================================*/
create table Classroom_table (
   IDClassroom          id                   identity(60000,1) not for replication,
   IDBuilding           int                  null,
   NumClassroom         id                   not null,
   PeopleNumClassroom   id                   null,
   constraint PK_CLASSROOM_TABLE primary key (IDClassroom),
   constraint AK_KEY_2_CLASSROO unique (NumClassroom)
)
go

/*==============================================================*/
/* Table: Course_table                                          */
/*==============================================================*/
create table Course_table (
   IDCourse             id                   identity(500000,1) not for replication,
   NumberCourse         Number               not null,
   NameCourse           Name                 not null,
   ProfileCourse        Profile              null,
   ScoreCourse          Score                null,
   StudyTimeCourse      int                  null,
   constraint PK_COURSE_TABLE primary key (IDCourse),
   constraint AK_KEY_2_COURSE_T unique (NumberCourse)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('Course_table') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'Course_table' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '课程实体   对课程的描述  ', 
   'user', @CurrentUser, 'table', 'Course_table'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Course_table')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'StudyTimeCourse')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Course_table', 'column', 'StudyTimeCourse'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '学习的总课时',
   'user', @CurrentUser, 'table', 'Course_table', 'column', 'StudyTimeCourse'
go

/*==============================================================*/
/* Table: Dorm_table                                            */
/*==============================================================*/
create table Dorm_table (
   IDDorm               id                   identity(10000000,1) not for replication,
   NumDorm              id                   not null,
   CountDorm            int                  not null,
   constraint PK_DORM_TABLE primary key (IDDorm),
   constraint AK_KEY_2_DORM_TAB unique (NumDorm)
)
go

/*==============================================================*/
/* Table: LiveDorm_table                                        */
/*==============================================================*/
create table LiveDorm_table (
   IDLiveDorm           id                   identity(1100000,1) not for replication,
   IDStudent            int                  not null,
   IDDorm               int                  not null,
   OtherLiveDorm        varchar(200)         null,
   constraint PK_LIVEDORM_TABLE primary key (IDLiveDorm),
   constraint AK_KEY_2_LIVEDORM unique (IDStudent, IDDorm)
)
go

/*==============================================================*/
/* Table: NewCourse_table                                       */
/*==============================================================*/
create table NewCourse_table (
   IDNewCourse          id                   identity(8000000,1) not for replication,
   IDTeacher            int                  null,
   IDCourse             int                  null,
   IDClassroom          int                  null,
   IDSchoolhour         int                  null,
   SetTimeNewCourse     DateT                not null,
   BeginTimeNewCourse   DateT                not null,
   StateNewCourse       State                null default 0,
   AccommodateNewCourse int                  null,
   NatureNewCourse      NatureCourse         not null,
   constraint PK_NEWCOURSE_TABLE primary key (IDNewCourse)
)
go

/*==============================================================*/
/* Table: Schoolhour_table                                      */
/*==============================================================*/
create table Schoolhour_table (
   IDSchoolhour         id                   identity,
   TimesectionSchoolhour TimesectionSchoolhour not null default 0,
   TimesectionSchoolhourDetail TimesectionSchoolhour not null default 0,
   constraint PK_SCHOOLHOUR_TABLE primary key (IDSchoolhour)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('Schoolhour_table') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'Schoolhour_table' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '上课时间区间    
   上午分为 12  34节 
   下午分为 56  78节
   晚上分为 9  10  11节', 
   'user', @CurrentUser, 'table', 'Schoolhour_table'
go

/*==============================================================*/
/* Table: Student_table                                         */
/*==============================================================*/
create table Student_table (
   IDStudent            id                   identity(2000000,1) not for replication,
   IDAuthority          int                  null,
   NumberStudent        Number               not null,
   NameStudent          Name                 not null,
   AgeStudent           Age                  null,
   PasscodeStudent      PassCode             not null,
   GradeStudent         int                  not null,
   YearsStudent         int                  null,
   ImageStudent         UserImage            null,
   constraint PK_STUDENT_TABLE primary key (IDStudent),
   constraint AK_KEY_2_STUDENT_ unique (NumberStudent)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('Student_table') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'Student_table' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '学生表 用于存储学生基本信息', 
   'user', @CurrentUser, 'table', 'Student_table'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Student_table')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'YearsStudent')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Student_table', 'column', 'YearsStudent'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '区别本科专科 3 4年',
   'user', @CurrentUser, 'table', 'Student_table', 'column', 'YearsStudent'
go

/*==============================================================*/
/* Table: StudyCourse_table                                     */
/*==============================================================*/
create table StudyCourse_table (
   IDStudyCourse        id                   identity(9000000,1) not for replication,
   IDStudent            int                  null,
   IDNewCourse          int                  null,
   GradeStudyCourse     Score                not null,
   constraint PK_STUDYCOURSE_TABLE primary key (IDStudyCourse),
   constraint AK_KEY_2_STUDYCOU unique (IDStudent, IDNewCourse)
)
go

/*==============================================================*/
/* Table: Teacher_table                                         */
/*==============================================================*/
create table Teacher_table (
   IDTeacher            id                   identity(300000,1) not for replication,
   IDAuthority          int                  null,
   NumberTeacher        Number               not null,
   NameTeacher          Name                 not null,
   AgeTeacher           Age                  null,
   SexTeacher           Sex                  null default '未填写',
   GradeTeacher         int                  null,
   PhoneNumTeacher      PhoneNum             null,
   EmailTeacher         Email                null,
   PasscodeTeacher      PassCode             not null,
   ImageTeacher         UserImage            null,
   constraint PK_TEACHER_TABLE primary key (IDTeacher),
   constraint AK_KEY_2_TEACHER_ unique (NumberTeacher)
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('Teacher_table') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'Teacher_table' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '关于教师信息', 
   'user', @CurrentUser, 'table', 'Teacher_table'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Teacher_table')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'GradeTeacher')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Teacher_table', 'column', 'GradeTeacher'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   ' 3 专科 4 本科  7研究生   9博士生    11博士后     13副教授   15教授',
   'user', @CurrentUser, 'table', 'Teacher_table', 'column', 'GradeTeacher'
go

/*==============================================================*/
/* View: FinishedChooseCourse_View                              */
/*==============================================================*/
create view FinishedChooseCourse_View as
select
   Student_table.IDStudent Student_table_IDStudent,
   Student_table.NameStudent,
   Student_table.NumberStudent,
   Student_table.AgeStudent,
   Student_table.GradeStudent,
   Student_table.YearsStudent,
   Teacher_table.NameTeacher,
   Teacher_table.EmailTeacher,
   NewCourse_table.SetTimeNewCourse,
   NewCourse_table.BeginTimeNewCourse,
   NewCourse_table.StateNewCourse,
   NewCourse_table.AccommodateNewCourse,
   Course_table.NameCourse,
   Course_table.ScoreCourse,
   Course_table.StudyTimeCourse,  
   Classroom_table.NumClassroom,
   Schoolhour_table.TimesectionSchoolhour,
   Schoolhour_table.TimesectionSchoolhourDetail,
      StudyCourse_table.GradeStudyCourse
from
   Student_table,
   NewCourse_table,
   StudyCourse_table,
   Classroom_table,
   Course_table,
   Teacher_table,
   Schoolhour_table
where
    Student_table.IDStudent=StudyCourse_table.IDStudent
    And 
    StudyCourse_table.IDNewCourse=NewCourse_table.IDNewCourse
    and
    NewCourse_table.IDClassroom=Classroom_table.IDClassroom
    and
    Course_table.IDCourse=NewCourse_table.IDCourse
    and
    Teacher_table.IDTeacher=NewCourse_table.IDTeacher
    and
    Schoolhour_table.IDSchoolhour=NewCourse_table.IDSchoolhour;
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('FinishedChooseCourse_View') and minor_id = 0)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'view', 'FinishedChooseCourse_View'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '学生已选课程View   学生已经选择的课程表单   其中有学生信息  课程信息',
   'user', @CurrentUser, 'view', 'FinishedChooseCourse_View'
go

/*==============================================================*/
/* View: FinishedGetGrade_View                                  */
/*==============================================================*/
create view FinishedGetGrade_View as
select
   Student_table.NameStudent,
   Student_table.NumberStudent,
   Student_table.GradeStudent,
   Teacher_table.NameTeacher,
   NewCourse_table.BeginTimeNewCourse,
   Course_table.NameCourse,
   Course_table.ScoreCourse,
   Course_table.StudyTimeCourse,  
   Classroom_table.NumClassroom,
   Schoolhour_table.TimesectionSchoolhour,
   Schoolhour_table.TimesectionSchoolhourDetail,
   StudyCourse_table.GradeStudyCourse
from
   Student_table,
   NewCourse_table,
   StudyCourse_table,
   Classroom_table,
   Course_table,
   Teacher_table,
   Schoolhour_table
where
    Student_table.IDStudent=StudyCourse_table.IDStudent
    And 
    StudyCourse_table.IDNewCourse=NewCourse_table.IDNewCourse
    and
    NewCourse_table.IDClassroom=Classroom_table.IDClassroom
    and
    Course_table.IDCourse=NewCourse_table.IDCourse
    and
    Teacher_table.IDTeacher=NewCourse_table.IDTeacher
    and
    Schoolhour_table.IDSchoolhour=NewCourse_table.IDSchoolhour
    and
    NewCourse_table.AccommodateNewCourse =3;
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('FinishedGetGrade_View') and minor_id = 0)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'view', 'FinishedGetGrade_View'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '学生已选课程View   学生已经选择的课程表单   其中有学生信息  课程信息',
   'user', @CurrentUser, 'view', 'FinishedGetGrade_View'
go

/*==============================================================*/
/* View: ManagerDetail_View                                     */
/*==============================================================*/
create view ManagerDetail_View as
select
   Arranger_table.IDArranger,
   Authority_table.LevelAuthority,
   Arranger_table.NameArranger,
   Arranger_table.NumberArranger,
   Arranger_table.EmailArranger,
   Arranger_table.AgeArranger,
   Arranger_table.SexArranger,
   Arranger_table.PhoneNumArranger
from
   Authority_table,
   Arranger_table
where
    Authority_table.IDAuthority=Arranger_table.IDAuthority;
go

/*==============================================================*/
/* View: NewCourseAndChoose_View                                */
/*==============================================================*/
create view NewCourseAndChoose_View as
select
   Teacher_table.IDTeacher Teacher_table_IDTeacher,
   Teacher_table.NameTeacher,
   Teacher_table.AgeTeacher,
   Teacher_table.SexTeacher,
   Teacher_table.GradeTeacher,
   Teacher_table.PhoneNumTeacher,
   Teacher_table.EmailTeacher,
   NewCourse_table.IDNewCourse,
   NewCourse_table.SetTimeNewCourse,
   NewCourse_table.BeginTimeNewCourse,
   NewCourse_table.StateNewCourse,
   NewCourse_table.AccommodateNewCourse,
   Course_table.NameCourse,
   Course_table.ProfileCourse,
   Course_table.ScoreCourse,
   Course_table.StudyTimeCourse,
   Classroom_table.NumClassroom,
      Schoolhour_table.TimesectionSchoolhour,
   Schoolhour_table.TimesectionSchoolhourDetail
from
   Teacher_table,
   NewCourse_table,
   Course_table,
   Classroom_table,
   Schoolhour_table
where
    Teacher_table.IDTeacher=NewCourse_table.IDTeacher
    and
    Course_table.IDCourse=NewCourse_table.IDCourse
    and
    Classroom_table.IDClassroom=NewCourse_table.IDClassroom
    and
    Schoolhour_table.IDSchoolhour=NewCourse_table.IDSchoolhour;
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('NewCourseAndChoose_View') and minor_id = 0)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'view', 'NewCourseAndChoose_View'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '教师已开设的课程',
   'user', @CurrentUser, 'view', 'NewCourseAndChoose_View'
go

/*==============================================================*/
/* View: Restudy_View2                                          */
/*==============================================================*/
create view Restudy_View2 as
select
   Student_table.NameStudent,
   Student_table.NumberStudent,
   Student_table.GradeStudent,
   Teacher_table.NameTeacher,
   NewCourse_table.BeginTimeNewCourse,
   Course_table.NameCourse,
   Course_table.ScoreCourse,
   Course_table.StudyTimeCourse,  
   Classroom_table.NumClassroom,
   Schoolhour_table.TimesectionSchoolhour,
   Schoolhour_table.TimesectionSchoolhourDetail,
   StudyCourse_table.GradeStudyCourse
from
   Student_table,
   NewCourse_table,
   StudyCourse_table,
   Classroom_table,
   Course_table,
   Teacher_table,
   Schoolhour_table
where
    Student_table.IDStudent=StudyCourse_table.IDStudent
    And 
    StudyCourse_table.IDNewCourse=NewCourse_table.IDNewCourse
    and
    NewCourse_table.IDClassroom=Classroom_table.IDClassroom
    and
    Course_table.IDCourse=NewCourse_table.IDCourse
    and
    Teacher_table.IDTeacher=NewCourse_table.IDTeacher
    and
    Schoolhour_table.IDSchoolhour=NewCourse_table.IDSchoolhour
    and
    StudyCourse_table.GradeStudyCourse<60;
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('Restudy_View2') and minor_id = 0)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'view', 'Restudy_View2'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '重修信息   学生已经选择的课程表单   其中有学生信息  课程信息
   显示挂科后的科目 与 信息',
   'user', @CurrentUser, 'view', 'Restudy_View2'
go

/*==============================================================*/
/* View: StudentDetail_View                                     */
/*==============================================================*/
create view StudentDetail_View as
select 
   Student_table.IDStudent,
   Student_table.NumberStudent,
   Authority_table.LevelAuthority,
   Student_table.NameStudent,
   Student_table.AgeStudent,
   Student_table.GradeStudent,
   Student_table.YearsStudent,
   LiveDorm_table.IDLiveDorm,
   LiveDorm_table.IDDorm,
   LiveDorm_table.OtherLiveDorm
   
from
   Authority_table,
   Student_table,
   LiveDorm_table
where
    Student_table.IDAuthority=Authority_table.IDAuthority AND
    Student_table.IDStudent=LiveDorm_table.IDStudent;
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('StudentDetail_View') and minor_id = 0)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'view', 'StudentDetail_View'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '此表只是为了查询  不可修改更新',
   'user', @CurrentUser, 'view', 'StudentDetail_View'
go

/*==============================================================*/
/* View: TeacherDetail_View                                     */
/*==============================================================*/
create view TeacherDetail_View as
select
   Teacher_table.IDTeacher,
   Teacher_table.Authority_table.LevelAuthority,
   NumberTeacher,
   Teacher_table.NameTeacher,
   Teacher_table.AgeTeacher,
   Teacher_table.SexTeacher,
   Teacher_table.GradeTeacher,
   Teacher_table.PhoneNumTeacher,
   Teacher_table.EmailTeacher,
   Teacher_table.PasscodeTeacher
from
   Authority_table,
   Teacher_table
Where
    Authority_table.IDAuthority=Teacher_table.IDAuthority;
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TeacherDetail_View') and minor_id = 0)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'view', 'TeacherDetail_View'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '不可更新   只可以查询',
   'user', @CurrentUser, 'view', 'TeacherDetail_View'
go

alter table Arranger_table
   add constraint FK_ARRANGER_ARRANGER__AUTHORIT foreign key (IDAuthority)
      references Authority_table (IDAuthority)
go

alter table Classroom_table
   add constraint FK_CLASSROO_CLASSROOM_BUILDING foreign key (IDBuilding)
      references Building_table (IDBuilding)
go

alter table LiveDorm_table
   add constraint FK_LIVEDORM_REFERENCE_STUDENT_ foreign key (IDStudent)
      references Student_table (IDStudent)
go

alter table LiveDorm_table
   add constraint FK_LIVEDORM_REFERENCE_DORM_TAB foreign key (IDDorm)
      references Dorm_table (IDDorm)
go

alter table NewCourse_table
   add constraint FK_NEWCOURS_NEWCOURSE_TEACHER_ foreign key (IDTeacher)
      references Teacher_table (IDTeacher)
go

alter table NewCourse_table
   add constraint FK_NEWCOURS_REFERENCE_CLASSROO foreign key (IDClassroom)
      references Classroom_table (IDClassroom)
go

alter table NewCourse_table
   add constraint FK_NEWCOURS_REFERENCE_SCHOOLHO foreign key (IDSchoolhour)
      references Schoolhour_table (IDSchoolhour)
go

alter table NewCourse_table
   add constraint FK_NEWCOURS_REFERENCE_COURSE_T foreign key (IDCourse)
      references Course_table (IDCourse)
go

alter table Student_table
   add constraint FK_STUDENT__AUTHORITY_AUTHORIT foreign key (IDAuthority)
      references Authority_table (IDAuthority)
go

alter table StudyCourse_table
   add constraint FK_STUDYCOU_REFERENCE_NEWCOURS foreign key (IDNewCourse)
      references NewCourse_table (IDNewCourse)
go

alter table StudyCourse_table
   add constraint FK_STUDYCOU_STUDYCOUR_STUDENT_ foreign key (IDStudent)
      references Student_table (IDStudent)
go

alter table Teacher_table
   add constraint FK_TEACHER__AUTHORITY_AUTHORIT foreign key (IDAuthority)
      references Authority_table (IDAuthority)
go

