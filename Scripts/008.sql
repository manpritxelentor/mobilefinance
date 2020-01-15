insert into tbl_GroupCode(Code,Name,DisplayName,TenantId) 
values('MORBI','City','Morbi',2)

insert into tbl_GroupCode(Code,Name,DisplayName,TenantId) 
values('WANKANER','City','Wankaner',2)

insert into tbl_GroupCode(Code,Name,DisplayName,TenantId) 
values('RAJKOT','City','Rajkot',2)

update tbl_CodeMaintain set Prefix=NULL,Separator=NULL where id=1

delete from tbl_GroupCode where id in (501,567)

ALTER TABLE tbl_Guarantor
ADD CityId int null;