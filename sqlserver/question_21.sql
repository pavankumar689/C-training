select email,count(*) as duplicate_count
from users
group by email
having count(*)>1;