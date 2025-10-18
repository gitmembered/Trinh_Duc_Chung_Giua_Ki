
CREATE DATABASE QuanLySV;
GO


USE QuanLySV;
GO


Drop table Lop
CREATE TABLE Lop (
    MaLop char(3) PRIMARY KEY,
    TenLop nvarchar(30) NOT NULL 
);
GO


drop table Sinhvien
CREATE TABLE Sinhvien (
    MaSV char(6) PRIMARY KEY, 
    HotenSV nvarchar(40),
    NgaySinh Date,
    MaLop char(3), 
    
  
    CONSTRAINT FK_Sinhvien_Lop 
    FOREIGN KEY (MaLop) 
    REFERENCES Lop(MaLop)
       
);
GO
-- Nhập 2 dòng dữ liệu cho Table Lop
INSERT INTO Lop (MaLop, TenLop) VALUES ('KTT', N'Kế toán khóa 1');
INSERT INTO Lop (MaLop, TenLop) VALUES ('IT', N'Công nghệ thông tin');


INSERT INTO Sinhvien (MaSV, HotenSV, MaLop, NgaySinh) 
VALUES 
('SV0001', N'Trần Văn Năm', 'IT', '1965-08-20'),
('SV0002', N'Nguyễn Thị Tuyết', 'KTT', '1965-08-25'),
('SV0003', N'Nguyễn Kim Tuyến', 'IT', '1984-03-21'),
('SV0004', N'Lê Minh Anh', 'KTT', '1985-01-01');

SELECT * FROM Lop;

SELECT * FROM Sinhvien;     
