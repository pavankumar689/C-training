delete from students
where not exists(
    select 1
    from marks m
    where m.studentid = students.studentid
);
