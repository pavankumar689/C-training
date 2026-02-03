select empid,[jan],[feb],[mar],[apr]
from
(
    select empid,month,totalpresent
    from attendance
) src
pivot
(
    sum(totalpresent)
    for month in ([jan],[feb],[mar],[apr])
) p;
