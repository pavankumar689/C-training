select
    r.session_id as blocked_session,
    r.blocking_session_id as blocking_session,
    s.login_name,
    s.host_name,
    t.text as blocked_sql_text
from sys.dm_exec_requests r
join sys.dm_exec_sessions s
    on r.session_id = s.session_id
cross apply sys.dm_exec_sql_text(r.sql_handle) t
where r.blocking_session_id <> 0;
