--question 1
create table trainer_master(trainer_id int primary key,trainername varchar(100));

create table courses_master(courseid int primary key,coursename varchar(100),
coursefee int,trainerid int foreign key references trainer_master(trainer_id));

create table student_master(studentid int primary key,
studentname varchar(100));

create table exam_details(examid int primary key,studentid int foreign key references 
student_master(studentid),courseid int foreign key references courses_master(courseid)
,joiningdate date,exammonth int,examyear int,marks int);

--question 2
alter table student_master add reward_points int default 0;

--question 3
alter table student_master add constraint 
checking_rewards_points check(reward_points between 0 and 100);

--question 4
select sm.studentname,cm.coursename,tm.trainername,ed.exammonth,
ed.examyear,ed.marks from exam_details ed inner join student_master 
sm on ed.studentid=sm.studentid inner join courses_master cm on 
ed.courseid=cm.courseid inner join trainer_master tm on tm.trainer_id=cm.trainerid;

--question 5
select studentid,sum(marks) as totalmarks from exam_details
where examyear=year(getdate()) group by studentid;

--question 6
select sm.studentname,left(sm.studentname,3)+left(cm.coursename,2)+
cast(sm.studentid as varchar(10)) as loginid from student_master sm 
inner join exam_details ed on sm.studentid=ed.studentid inner join 
courses_master cm on ed.courseid=cm.courseid;

--question 7
select sm.studentname from student_master sm where sm.studentid 
in(select studentid from exam_details group by studentid having 
sum(marks)>(select avg(totalmarks) from(select sum(marks) as totalmarks 
from exam_details group by studentid)a));

--question 8
select sm.studentname,ed.marks,'high' as category from student_master 
sm join exam_details ed on sm.studentid=ed.studentid where ed.marks>80
union select sm.studentname,ed.marks,'low' as category from student_master 
sm join exam_details ed on sm.studentid=ed.studentid where ed.marks<40;

--question 9
alter trigger trg_updaterewardpoints126 on exam_details after insert as begin 
set nocount on; update sm set reward_points=isnull(sm.reward_points,101)+
case when i.marks>=80 then 10 when i.marks>=60 then 5 else 2 end from
student_master sm inner join inserted i on sm.studentid=i.studentid; end;

--question 10
select sm.studentname,ed.joiningdate,
datediff(year,ed.joiningdate,getdate())
-case when dateadd(year,datediff(year,ed.joiningdate,getdate()),ed.joiningdate)>getdate()
then 1 else 0 end as yearsofstudy,case when datediff(year,ed.joiningdate,getdate())
-case when dateadd(year,datediff(year,ed.joiningdate,getdate()),ed.joiningdate)>getdate()
then 1 else 0 end>=3 then 10000 else 0 end as scholarshipamount,coalesce(sm.reward_points,0)
as rewardpoints from student_master sm left join exam_details ed on sm.studentid=ed.studentid;

insert into student_master values('deman1',null)
insert into Exam_Details values(15,2,'2026-11-10',3,2026,89)


