alter table zipcode_info
alter column zip_code varchar(5);

alter table zipcode_info
alter column city varchar(25);

alter table zipcode_info
alter column state varchar(2);


alter table instructor_info
alter column instructor_id int;

alter table instructor_info
alter column instructor_first_name varchar(25);

alter table instructor_info
alter column instructor_last_name varchar(25);

alter table instructor_info
alter column street_address varchar(50);

alter table instructor_info
alter column zip_code varchar(5);


alter table course_info
alter column course_no int;

alter table course_info
alter column course_name varchar(50);

alter table course_info
alter column course_prerequisite int;

alter table course_info
alter column cost decimal(9,2);


alter table student_info
alter column student_id int;

alter table student_info
alter column student_first_name varchar(25);

alter table student_info
alter column student_last_name varchar(25);

alter table student_info
alter column street_address varchar(50);

alter table student_info
alter column zip_code varchar(5);


alter table section_info
alter column section_id int;

alter table section_info
alter column course_no int;

alter table section_info
alter column section_no int;

alter table section_info
alter column instructor_id int;

alter table section_info
alter column location varchar(50);

alter table section_info
alter column capacity int;


alter table enrollment_info
alter column student_id int;

alter table enrollment_info
alter column section_id int;

alter table enrollment_info
alter column enrollment_date date;


alter table grade_info
alter column student_id int;

alter table grade_info
alter column section_id int;

alter table grade_info
alter column grade_type_code char(2);

alter table grade_info
alter column grade_code_occurance bigint;

alter table grade_info
alter column numeric_grade int;
