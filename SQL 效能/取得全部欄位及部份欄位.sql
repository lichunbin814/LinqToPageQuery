--�Ҧ������
select *
from (
select *
from LiveFellowship ) a1

--�������
select sn,DeptID,StudentsSN,LiveType,LiveHours,AmountMoney
from (
select sn,DeptID,StudentsSN,LiveType,LiveHours,AmountMoney
from LiveFellowship) a1