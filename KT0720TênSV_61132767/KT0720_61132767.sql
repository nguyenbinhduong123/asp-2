create database KT0720_61132767
go

use KT0720_61132767
go

create table LOP(
	Malop varchar(10) primary key,
	Tenlop nvarchar(30) not null
)

create table SINHVIEN(
	MaSV varchar(10) primary key,
	HoSV nvarchar(10) not null,
	TenSV nvarchar(10) not null,
	Ngaysinh date not null,
	Gioitinh bit not null,
	AnhSV nvarchar(50) not null,
	Diachi nvarchar(50) not null,
	Malop varchar(10) foreign key references LOP(Malop) not null
)

insert into LOP
values('61CNTT2' , N'61 Công Nghệ Thông Tin 2'),
		('61CNTT3' , N'61 Công Nghệ Thông Tin 3'),
		('61CNTT1' , N'61 Công Nghệ Thông Tin 1')

INSERT INTO SINHVIEN
VALUES('61131111', N'Nguyễn Văn', N'A', CAST(N'2001-01-01' AS Date), 1, N'employee11.png', N'Nha Trang, Khánh Hòa', '61CNTT1'),
	('61131112', N'Nguyễn Thị', N'B', CAST(N'2001-01-02' AS Date), 0, N'employee12.png', N'Nha Trang, Khánh Hòa', '61CNTT1'),
	('61131113', N'Nguyễn Văn', N'C', CAST(N'2001-01-03' AS Date), 1, N'employee13.png', N'Nha Trang, Khánh Hòa', '61CNTT1'),
	('61131121', N'Trần Văn', N'C', CAST(N'2001-02-01' AS Date), 1, N'employee21.png', N'Nha Trang, Khánh Hòa', '61CNTT2'),
	('61131122', N'Trần Thị', N'C', CAST(N'2001-07-11' AS Date), 0, N'employee22.png', N'Nha Trang, Khánh Hòa', '61CNTT2'),
	('61131123', N'Trần Văn', N'C', CAST(N'2001-02-03' AS Date), 1, N'employee23.png', N'Nha Trang, Khánh Hòa', '61CNTT2'),
	('61131131', N'Lê Văn', N'C', CAST(N'2001-03-01' AS Date), 1, N'employee31.png', N'Nha Trang, Khánh Hòa', '61CNTT3'),
	('61131132', N'Lê Thị', N'C', CAST(N'2001-04-05' AS Date), 0, N'employee32.png', N'Nha Trang, Khánh Hòa', '61CNTT3'),
	('61131133', N'Lê Văn', N'C', CAST(N'2001-03-03' AS Date), 1, N'employee33.png', N'Nha Trang, Khánh Hòa', '61CNTT3')