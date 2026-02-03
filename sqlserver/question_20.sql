create table zipcode_info(zip_code varchar(5),city varchar(10));

create table instructor_info(instructor_id int,instructor_first_name varchar(15),instructor_last_name varchar(15));

create table course_info(course_no int,cost decimal(5,2));

create table student_info(student_id int,student_first_name varchar(15),student_last_name varchar(15));

create table section_info(section_id int,course_no int,section_no int,instructor_id int);

create table enrollment_info(student_id int,section_id int);

create table grade_info(student_id int,section_id int,grade_type_code char(2),grade_code_occurance int);
