--所有的欄位
select *
from (
select *
from LiveFellowship ) a1

--部份欄位
select sn,DeptID,StudentsSN,LiveType,LiveHours,AmountMoney
from (
select sn,DeptID,StudentsSN,LiveType,LiveHours,AmountMoney
from LiveFellowship) a1