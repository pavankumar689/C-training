create table zipcode_info(zip_code varchar(5),city
varchar(25) not null,state varchar(2) not null,
constraint zip_pk primary key(zip_code),constraint
zip_len_chk check(len(zip_code)=5),constraint 
zip_num_chk check(zip_code not like '%[^0-9]%'));


create table instructor_info(instructor_id int,instructor_first_name varchar(25)
not null,instructor_last_name varchar(25) not null,street_address varchar(50)
,zip_code varchar(5),constraint instructor_id_pk primary key(instructor_id),
constraint zip_instructor_fk foreign key(zip_code) references zipcode_info(zip_code));

create table course_info(course_no int,course_name varchar(50)
not null,course_prerequisite int,cost decimal(9,2) not null,
constraint course_no_pk primary key(course_no),constraint
cost_nn check(cost is not null));

create table student_info(student_id int,
student_first_name varchar(25) not null,student_last_name
varchar(25) not null,street_address varchar(50),zip_code varchar(5),
constraint student_id_pk primary key(student_id),constraint 
zip_student_fk foreign key(zip_code) references zipcode_info(zip_code));

create table section_info(section_id int,course_no int,
section_no int not null,instructor_id int,location varchar(50)
,capacity int,constraint section_id_pk primary key(section_id)
,constraint section_no_nn check(section_no is not null),constraint
course_section_fk foreign key(course_no) references course_info(course_no),
constraint instructor_section_fk foreign key(instructor_id) 
references instructor_info(instructor_id));

create table enrollment_info(student_id int,section_id int,
enrollment_date date,constraint enrollment_stud_sect_pk 
primary key(student_id,section_id),constraint enrollment_student_id_fk
foreign key(student_id) references student_info(student_id),
constraint enrollment_section_id_fk foreign key(section_id) 
references section_info(section_id));

create table grade_info(student_id int,section_id
int,grade_type_code char(2),grade_code_occurance bigint
,numeric_grade int default 0 not null,constraint 
grade_stud_sect_type_code_pk primary key(student_id,section_id,grade_type_code,
grade_code_occurance),constraint grade_student_id_fk foreign key(student_id)
references student_info(student_id),constraint
grade_section_id_fk foreign key(section_id) references 
section_info(section_id),constraint chk_grade_type_code 
check(grade_type_code in('fi','hm','mt','pa','pj','qz')),
constraint numeric_grade_nn check(numeric_grade is not null));
