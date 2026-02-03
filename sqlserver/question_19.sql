
select zip_code,city,state as state_name from zipcode_info;

select distinct state from zipcode_info;

select student_id,concat(student_first_name,' ',student_last_name) as name from student_info;

select concat(zip_code,', ',city,', ',state) as address from zipcode_info;

select course_name from course_info;

select course_name,cost from course_info;

select * from course_info;

select instructor_last_name,zip_code from instructor_info;

select distinct zip_code from student_info;

select student_first_name,student_last_name from student_info;

select city,state,zip_code from zipcode_info;

select student_id,section_id,numeric_grade from grade_info where grade_type_code='fi';

select zip_code,city from zipcode_info where state='mi';

select s.student_id,concat(s.student_first_name,' ',s.student_last_name) as name from student_info s join enrollment_info e on s.student_id=e.student_id where month(e.enrollment_date)=1 and year(e.enrollment_date)=1999 order by name;

select section_id,instructor_id from section_info where course_no in(10,20) order by instructor_id;

select student_id,section_id,numeric_grade from grade_info order by section_id asc,numeric_grade desc;

select course_no,course_name,cost from course_info where course_name like '%intro%';

select * from course_info where substring(course_name,len(course_name)-2,1)='a';

select * from student_info where student_id between 300 and 350;

select * from course_info where cost between 4000 and 7000;

select instructor_first_name from instructor_info where instructor_last_name='schumer';

select instructor_first_name from instructor_info where instructor_last_name<>'schumer';

select course_name,cost from course_info where cost>4000;

select course_name,cost from course_info where cost between 3000 and 7000;

select course_name,cost from course_info where cost in(4000,4500);

select student_first_name,street_address from student_info where student_last_name like 's%';

select student_first_name,street_address from student_info where student_last_name like '_o%';

select instructor_first_name from instructor_info where instructor_last_name not like 's%';

select course_name,cost from course_info where cost between 4000 and 4500 and course_name like 'i%';

select course_name,cost,course_prerequisite from course_info where (cost=2000 and course_prerequisite=20) or course_prerequisite=25;

select course_name,cost,course_prerequisite from course_info where cost=2000 or course_prerequisite in(20,25);

select * from course_info where course_prerequisite is null;

select student_last_name from student_info where zip_code in('10048','11102','11209');

select instructor_first_name,instructor_last_name from instructor_info where lower(instructor_last_name) like '%i%' and zip_code='10025';

select course_name from course_info where course_prerequisite is not null and cost<1100;

select distinct cost from course_info where course_prerequisite is null;

select course_no,course_name from course_info where course_prerequisite is null order by course_name;

select course_no,course_name from course_info where course_prerequisite is null order by course_name desc;

select city,state,zip_code from zipcode_info where state in('ny','ct') order by zip_code;

select zip_code,student_first_name,student_last_name from student_info where student_last_name='graham' order by zip_code desc,student_first_name asc;

select concat(city,' ',state) as city_state from zipcode_info;

select upper(left(student_first_name,1))+lower(substring(student_first_name,2,len(student_first_name))) as firstname from student_info;

select concat(instructor_first_name,', ',instructor_last_name) as instructor_name from instructor_info;

select cost,cost+10 as add_cost,cost-20 as sub_cost,cost*30 as mul_cost,cost/5 as div_cost from course_info;

select distinct numeric_grade,floor(numeric_grade/2) as half_grade from grade_info;

select format(cost,'#,###') from course_info where course_no<25;

select format(cost,'$#,##0.00') from course_info;

select course_name,isnull(cast(course_prerequisite as varchar),'not applicable') as prerequisite from course_info;

select city,case when state='ny' then 'new york' when state='nj' then 'new jersey' else 'others' end as state from zipcode_info;
