create database quanlydiemsinhvien
go
USE quanlydiemsinhvien
GO


CREATE TABLE KhoaHoc (
    ID INT PRIMARY KEY IDENTITY(1,1),
    TenKhoa NVARCHAR(100) unique
);


CREATE TABLE NganhHoc (
    ID INT PRIMARY KEY IDENTITY(1,1),
    TenNganhHoc NVARCHAR(100) ,
    ID_KhoaHoc INT,
    FOREIGN KEY (ID_KhoaHoc) REFERENCES KhoaHoc(ID)
    
);
CREATE TABLE LopHoc (
    ID INT PRIMARY KEY IDENTITY(1,1),
    TenLop NVARCHAR(100) ,
    ID_NganhHoc INT,
	FOREIGN KEY (ID_NganhHoc) REFERENCES NganhHoc(ID),
   
);

CREATE TABLE MonHoc (
    MaMonHoc NVARCHAR(100) PRIMARY KEY,
    TenMonHoc NVARCHAR(100),
    HocKy INT,
    ID_NganhHoc INT,
	sogiolt int,
	sogioth int,
    FOREIGN KEY (ID_NganhHoc) REFERENCES NganhHoc(ID),
   
);

CREATE TABLE SinhVien (
    MaSinhVien NVARCHAR(100)  PRIMARY KEY,
    TenSinhVien NVARCHAR(100),
    NgaySinh DATE,
    ID_LopHoc INT,
    FOREIGN KEY (ID_LopHoc) REFERENCES LopHoc(ID)
);


CREATE TABLE Thi (
    ID INT PRIMARY KEY IDENTITY(1,1),
    MaMonHoc NVARCHAR(100),
    ID_LopHoc INT ,
    NgayThi DATE NOT NULL,
	HinhThuc nvarchar(100) not null,
	LanThi int not null,
   FOREIGN KEY (MaMonHoc) REFERENCES MonHoc(MaMonHoc),
);

CREATE TABLE KetQua (
    ID INT PRIMARY KEY IDENTITY(1,1),
    MaSinhVien nvarchar(100),
    ID_Thi INT NOT NULL ,
    Diem FLOAT NOT NULL CHECK (Diem >= 0 AND Diem <= 10),
    FOREIGN KEY (MaSinhVien) REFERENCES SinhVien(MaSinhVien) ON DELETE CASCADE,
    FOREIGN KEY (ID_Thi) REFERENCES Thi(ID) ON DELETE CASCADE
);

CREATE TABLE TaiKhoan (
    ID INT PRIMARY KEY IDENTITY(1,1),
    TenDangNhap NVARCHAR(100),
    MatKhau NVARCHAR(100),
    Quyen NVARCHAR(50),
    GhiChu NVARCHAR(255)
);
go
create PROCEDURE USP_InsertThiLan1
    @i_idlop INT, 
    @i_mamonhoc NVARCHAR(100), 
    @i_hinhthuc NVARCHAR(100), 
    @i_ngaythi DATE
AS BEGIN
   -- Khai báo biến
    DECLARE @d_thi_exist INT;
    DECLARE @d_idthi INT;

    -- Kiểm tra tồn tại bản ghi
    SELECT @d_thi_exist = COUNT(*)
    FROM Thi
    WHERE Thi.HinhThuc = @i_hinhthuc 
      AND Thi.ID_LopHoc = @i_idlop 
      AND Thi.MaMonHoc = @i_mamonhoc;

    IF (@d_thi_exist > 0)
    BEGIN
		SELECT 'faild' AS _message;
        RETURN;
    END

    IF (@d_thi_exist = 0)
    BEGIN
        -- Bảng tạm để lưu OUTPUT
        DECLARE @InsertedThi TABLE (ID INT);

        -- Chèn dữ liệu vào bảng Thi và lấy ID mới chèn
        INSERT INTO Thi (MaMonHoc, ID_LopHoc, NgayThi, HinhThuc, LanThi)
        OUTPUT INSERTED.ID INTO @InsertedThi(ID)
        VALUES (@i_mamonhoc, @i_idlop, @i_ngaythi, @i_hinhthuc, 1);

        -- Lấy giá trị ID từ bảng tạm
        SELECT @d_idthi = ID FROM @InsertedThi;

        -- Chèn dữ liệu vào bảng KetQua
        INSERT INTO KetQua (ID_Thi, MaSinhVien, Diem)
        SELECT @d_idthi as ID_Thi , SinhVien.MaSinhVien as MaSinhVien,  0 as diem   FROM SinhVien WHERE SinhVien.ID_LopHoc = @i_idlop;
 
		SELECT 'success' AS _message;
    END
END;	
go



-- repace toàn bộ kết quả thi lần 2 và 
CREATE PROCEDURE USP_InsertThiLan2
    @i_mamonhoc NVARCHAR(100), 
    @i_hinhthuc NVARCHAR(100), 
    @i_ngaythi DATE
AS
BEGIN
    -- Khai báo biến
    DECLARE @d_thi_exist INT;
    DECLARE @d_idthi INT;

    -- Kiểm tra xem thi lần 2 đã tồn tại hay chưa
    SELECT @d_thi_exist = COUNT(*)
    FROM Thi
    WHERE HinhThuc = @i_hinhthuc
      AND MaMonHoc = @i_mamonhoc
      AND LanThi = 2;

    -- Nếu đã tồn tại thi lần 2
    IF (@d_thi_exist > 0)
    BEGIN
        -- Lấy ID của thi lần 2
        SELECT @d_idthi = ID
        FROM Thi
        WHERE MaMonHoc = @i_mamonhoc
          AND HinhThuc = @i_hinhthuc
          AND LanThi = 2;

        -- Chèn thêm sinh viên có điểm dưới 5 (thi lần 1) mà chưa có trong thi lần 2
        INSERT INTO KetQua (ID_Thi, MaSinhVien, Diem)
        SELECT @d_idthi AS ID_Thi, 
               SinhVien.MaSinhVien AS MaSinhVien, 
               0 AS Diem
        FROM SinhVien
        JOIN KetQua ON SinhVien.MaSinhVien = KetQua.MaSinhVien
        JOIN Thi ON Thi.ID = KetQua.ID_Thi
        WHERE KetQua.Diem < 5
          AND Thi.MaMonHoc = @i_mamonhoc
          AND Thi.LanThi = 1
          AND Thi.HinhThuc = @i_hinhthuc
          AND NOT EXISTS (
              SELECT 1 
              FROM KetQua kq 
              WHERE kq.ID_Thi = @d_idthi 
                AND kq.MaSinhVien = SinhVien.MaSinhVien
          );

        -- Trả về thông báo cập nhật thành công
        SELECT 'update success' AS _message;
        RETURN;
    END

    -- Nếu chưa tồn tại thi lần 2
    ELSE
    BEGIN
        -- Bảng tạm để lưu OUTPUT
        DECLARE @InsertedThi TABLE (ID INT);

        -- Thêm mới thi lần 2
        INSERT INTO Thi (MaMonHoc, ID_LopHoc, NgayThi, HinhThuc, LanThi)
        OUTPUT INSERTED.ID INTO @InsertedThi(ID)
        VALUES (@i_mamonhoc, NULL, @i_ngaythi, @i_hinhthuc, 2);

        -- Lấy giá trị ID của lần thi thứ 2
        SELECT @d_idthi = ID FROM @InsertedThi;

        -- Chèn dữ liệu vào bảng KetQua cho thi lần 2
        INSERT INTO KetQua (ID_Thi, MaSinhVien, Diem)
        SELECT @d_idthi AS ID_Thi, 
               SinhVien.MaSinhVien AS MaSinhVien, 
               0 AS Diem
        FROM SinhVien
        JOIN KetQua ON SinhVien.MaSinhVien = KetQua.MaSinhVien
        JOIN Thi ON Thi.ID = KetQua.ID_Thi
        WHERE KetQua.Diem < 5
          AND Thi.MaMonHoc = @i_mamonhoc
          AND Thi.LanThi = 1
          AND Thi.HinhThuc = @i_hinhthuc;

        -- Trả về thông báo thêm mới thành công
        SELECT 'add success' AS _message;
    END
END;
GO






INSERT INTO TaiKhoan (TenDangNhap, MatKhau, Quyen) VALUES ('q', 'q', 'admin'); 
INSERT INTO KhoaHoc (TenKhoa) VALUES (N'K14'), (N'K15'), (N'K16'); 
INSERT INTO NganhHoc(ID_KhoaHoc ,TenNganhHoc) 
  VALUES 
  (1, N'Lập trình máy tính'), 
  (1, N'Thiết kế đồ họa'), 
  (1, N'Công nghệ chế tạo máy'), 
  (1, N'Cơ điện tử'), 
  (1, N'Điện công nghiệp'), 
  (1, N'Điện dân dụng'); 
INSERT INTO LopHoc(ID_NganhHoc , TenLop) VALUES (1,  'ltmt1'), (1,  'ltmt2'), (2,  'tkdh1'), (3,  'cnctm1'), (4,  'cdt1'), (5,  'dtn1'), (6,  'ddd1'); 
INSERT INTO MonHoc (MaMonHoc, TenMonHoc, HocKy, ID_NganhHoc, sogiolt, sogioth) VALUES 
('IT101', N'Nhập môn lập trình', 1, 1, 45, 15),
('IT201', N'Kỹ thuật phần mềm', 1, 1, 65, 20),
('IT301', N'Cấu trúc dữ liệu và giải thuật', 1, 1, 75, 25),
('GD101', N'Cơ bản về Thiết kế đồ họa', 1, 2, 50, 20),
('GD201', N'Thực hành Photoshop', 1, 2, 55, 25),
('GD301', N'Thiết kế giao diện người dùng', 1, 2, 60, 20),
('ME101', N'Nguyên lý chế tạo máy', 1, 3, 65, 30),
('ME201', N'Thiết kế máy', 1, 3, 75, 35),
('ME301', N'Công nghệ CAD/CAM', 1, 3, 85, 30),
('MT101', N'Điện tử căn bản', 1, 4, 55, 25),
('MT201', N'Thực hành PLC', 1, 4, 60, 20),
('MT301', N'Thực hành Robot', 1, 4, 70, 25),
('IE101', N'Hệ thống điện công nghiệp', 1, 5, 45, 15),
('IE201', N'Điều khiển tự động', 1, 5, 55, 25),
('IE301', N'Thực hành điều khiển', 1, 5, 60, 20),
('DE101', N'Kỹ thuật điện dân dụng', 1, 6, 40, 10),
('DE201', N'Thiết kế hệ thống điện', 1, 6, 50, 20),
('DE301', N'Thực hành điện dân dụng', 1, 6, 55, 15);

INSERT INTO SinhVien (MaSinhVien, TenSinhVien, ID_LopHoc, NgaySinh) VALUES
('CD220073', N'Bùi Hoàng Anh', 1, '2000-10-08'),
('CD220088', N'Lê Đức Anh', 1, '1999-08-18'),
('CD220495', N'Nguyễn Việt Anh', 1, '2004-10-08'),
('CD220613', N'Phạm Thế Anh', 1, '2004-08-27'),
('CD220407', N'Trịnh Ngọc Ánh', 1, '2004-11-01'),
('CD220437', N'Hoàng Đức Bảo', 1, '2004-01-29'),
('CD220564', N'Nguyễn Văn Cường', 1, '2003-09-14'),
('CD220674', N'Nguyễn Đình Duy', 1, '2004-03-23'),
('CD220553', N'Ngô Tiến Đạt', 1, '2003-12-26'),
('CD220447', N'Nguyễn Hải Đăng', 1, '2001-12-29'),
('CD220071', N'Đào Tiến Đức', 1, '2003-07-03'),
('CD220599', N'Đỗ Minh Đức', 1, '2004-02-03'),
('CD220222', N'Đặng Thị Nguyệt Hà', 1, '2002-09-16'),
('CD220215', N'Nguyễn Quang Hải', 1, '2004-02-02'),
('CD220256', N'Nguyễn Tiến Hải', 1, '2000-09-15'),
('CD220115', N'Lương Công Hoan', 1, '2003-11-09'),
('CD220145', N'Phan Doãn Hoàng', 1, '2001-02-24');

INSERT INTO SinhVien (MaSinhVien, TenSinhVien, ID_LopHoc, NgaySinh) VALUES
('CD220015', N'Nguyễn Hồng Phong', 2, '2003-03-05'),
('CD220543', N'Nguyễn Đức Phúc', 2, '2001-03-04'),
('CD220403', N'Đào Hoàng Sơn', 2, '2003-11-04'),
('CD220497', N'Phạm Đức Toàn', 2, '2004-12-01'),
('CD220625', N'Dương Quang Tú', 2, '2004-09-18'),
('CD220583', N'Lại Tiến Tuấn', 2, '2004-02-06'),
('CD220021', N'Nguyễn Vũ Tuấn', 2, '2003-04-26'),
('CD220500', N'Trần Bình Thái', 2, '2004-07-06'),
('CD220420', N'Bùi Đức Thắng', 2, '2004-06-15'),
('CD220595', N'Hoàng Đình Thắng', 2, '2004-05-19'),
('CD220125', N'Nguyễn Văn Phú Thuận', 2, '2003-01-11'),
('CD220220', N'Đinh Gia Trung', 2, '2003-06-25'),
('CD220484', N'Nguyễn Hữu Trường', 2, '2002-09-08'),
('CD220066', N'Nguyễn Hoàng Việt', 2, '2000-07-15'),
('CD220136', N'Nguyễn Văn Việt', 2, '2003-11-12'),
('CD220226', N'Tạ Đức Vinh', 2, '2001-01-28'),
('CD220550', N'Đinh Long Vũ', 2, '2004-10-18'),
('CD220287', N'Phi Hồng Vương', 2, '2003-06-16');
INSERT INTO SinhVien (MaSinhVien, TenSinhVien, ID_LopHoc, NgaySinh) VALUES
('CD220839', N'Trịnh Đức An', 3, '2004-01-12'),
('CD220825', N'Vũ Hồng An', 3, '2004-10-24'),
('CD220650', N'Dương Công Tuấn Anh', 3, '2004-12-17'),
('CD220762', N'Đoàn Thế Anh', 3, '2004-09-17'),
('CD221300', N'Nguyễn Hữu Hoàng Anh', 3, '2004-03-22'),
('CD220848', N'Nguyễn Quang Anh', 3, '2004-11-15'),
('CD221550', N'Phạm Quốc Anh', 3, '2004-08-15'),
('CD221038', N'Vũ Đức Anh', 3, '2004-01-14'),
('CD220582', N'Hoàng Cao Bách', 3, '2004-11-20'),
('CD220672', N'Nguyễn Xuân Bắc', 3, '2004-12-22'),
('CD221675', N'Nguyễn Ngọc Bông', 3, '2004-09-30'),
('CD221371', N'Nguyễn Tuấn Cường', 3, '2004-02-13'),
('CD220869', N'Ngô Tiến Chỉnh', 3, '2004-09-30'),
('CD220301', N'Hoàng Văn Diệu', 3, '2004-10-03'),
('CD220673', N'Trần Huyền Diệu', 3, '2004-09-24');

INSERT INTO SinhVien (MaSinhVien, TenSinhVien, ID_LopHoc, NgaySinh) VALUES
('CD220756', N'Trần Văn Doanh', 4, '2004-08-18'),
('CD221100', N'Nguyễn Tuấn Dũng', 4, '2004-11-05'),
('CD221091', N'Phạm Đình Dũng', 4, '2004-07-21'),
('CD221567', N'Trần Văn Dũng', 4, '2003-06-03'),
('CD221201', N'Tô Quốc Duy', 4, '2004-05-08'),
('CD221163', N'Vũ Văn Dương', 4, '2004-10-17'),
('CD221637', N'Ngô Văn Đạt', 4, '2004-10-05'),
('CD221139', N'Phạm Tuấn Đạt', 4, '2004-10-16'),
('CD221140', N'Trịnh Tuấn Điềm', 4, '2004-05-22'),
('CD221676', N'Vũ Phương Đông', 4, '2004-04-03'),
('CD220792', N'Phan Minh Đức', 4, '2004-02-25'),
('CD221198', N'Vũ Duy Đức', 4, '2004-10-22'),
('CD221385', N'Nguyễn Chí Hiếu', 4, '2004-02-13'),
('CD220950', N'Phan Chí Hiếu', 4, '2004-09-01'),
('CD220867', N'Vũ Mạnh Hòa', 4, '2004-05-16'),
('CD220864', N'Nguyễn Mạnh Hùng', 4, '2004-10-26');

INSERT INTO SinhVien (MaSinhVien, TenSinhVien, ID_LopHoc, NgaySinh) VALUES
('CD220992', N'Vũ Văn Hưng', 5, '2004-07-19'),
('CD221432', N'Vũ Trung Kiên', 5, '2004-10-17'),
('CD220979', N'Nguyễn Duy Khánh', 5, '2004-11-07'),
('CD220912', N'Nguyễn Quốc Khánh', 5, '2004-07-19'),
('CD220917', N'Hoàng Long', 5, '2004-03-28'),
('CD220830', N'Đặng Khánh Ly', 5, '2004-01-18'),
('CD221490', N'Châu Ngọc Đức Mạnh', 5, '2004-11-02'),
('CD221414', N'Trần Công Minh', 5, '2004-10-26'),
('CD221420', N'Đào Xuân Nam', 5, '2004-10-22'),
('CD221623', N'Phan Nguyễn Hoài Nam', 5, '2004-07-06'),
('CD220639', N'Nguyễn Bá Ngọc', 5, '2004-09-06'),
('CD220975', N'Nguyễn Duy Phúc', 5, '2004-05-02'),
('CD220817', N'Nguyễn Hoàng Phúc', 5, '2004-10-31'),
('CD221219', N'Bùi Xuân Quý', 5, '2004-11-29'),
('CD221435', N'Hoàng Thị Diễm Quỳnh', 5, '2004-06-26'),
('CD221407', N'Nguyễn Đắc Tâm', 5, '2004-12-20'),
('CD220681', N'Tạ Quang Tiến', 5, '2004-10-23'),
('CD220660', N'Trương Anh Tú', 5, '2004-04-25'),
('CD221664', N'Hoàng Đăng Tuấn', 5, '2004-03-12'),
('CD220955', N'Nguyễn Hoàng Tùng', 5, '2004-12-07');

INSERT INTO SinhVien (MaSinhVien, TenSinhVien, ID_LopHoc, NgaySinh) VALUES
('CD220501', N'Trần Đức Anh', 6, '2002-09-23'),
('CD220592', N'Nguyễn Xuân Diện', 6, '2004-10-01'),
('CD220750', N'Nguyễn Thành Duy', 6, '2004-11-11'),
('CD220609', N'Lưu Đức Dương', 6, '2003-09-16'),
('CD220223', N'Nguyễn Hoàng Dương', 6, '2002-09-30'),
('CD220077', N'Nguyễn Việt Đức', 6, '2003-05-15'),
('CD220031', N'Đỗ Trung Hiếu', 6, '2000-01-10'),
('CD220717', N'Phạm Văn Hiếu', 6, '2004-10-06'),
('CD220156', N'Lưu Đức Hòa', 6, '2000-05-20'),
('CD220392', N'Bùi Thị Tô Hoài', 6, '2003-07-06'),
('CD220610', N'Lê Minh Hoàng', 6, '2004-04-25'),
('CD220541', N'Nguyễn Huy Hoàng', 6, '2001-12-25'),
('CD220318', N'Ngô Hoàng Huy', 6, '2002-11-02'),
('CD220264', N'Trần Quốc Huy', 6, '1999-04-17'),
('CD220067', N'Trương Văn Huy', 6, '2003-08-14'),
('CD220312', N'Lê Thị Kiều', 6, '2004-06-10');

INSERT INTO SinhVien (MaSinhVien, TenSinhVien, ID_LopHoc, NgaySinh) VALUES
('CD220152', N'Nghiêm Công Khang', 7, '2003-10-15'),
('CD220687', N'Triệu Quang Linh', 7, '1999-12-10'),
('CD220053', N'Nguyễn Đức Long', 7, '2000-06-28'),
('CD220368', N'Dương Khánh Nam', 7, '2001-06-04'),
('CD220202', N'Nguyễn Cao Ngà', 7, '2002-12-15'),
('CD220064', N'Hoàng Văn Ngọc', 7, '2003-11-03'),
('CD220342', N'Nguyễn Thế Ngọc', 7, '2004-12-15'),
('CD220080', N'Nguyễn Bá Phát', 7, '2003-11-16'),
('CD220398', N'Phạm Ngọc Phú', 7, '2003-08-13'),
('CD220229', N'Dương Mạnh Quang', 7, '2002-04-14'),
('CD220693', N'Lê Văn Quang', 7, '2000-03-16'),
('CD220188', N'Trương Bảo Quốc', 7, '2003-05-08'),
('CD220464', N'Đỗ Huy Tuấn', 7, '2002-11-17'),
('CD220068', N'Nguyễn Anh Tuấn', 7, '2002-12-10'),
('CD220391', N'Cấn Trọng Tùng', 7, '2003-06-29'),
('CD220405', N'Phạm Ngọc Thạch', 7, '2003-09-08'),
('CD220358', N'Trần Hồng Thái', 7, '2004-08-22'),
('CD220036', N'Thái Quang Thanh', 7, '2003-12-03'),
('CD223732', N'Nguyễn Thế Thành', 7, '2004-08-14');






















select * from MonHoc




EXEC USP_InsertThiLan1 @i_idlop = 1, @i_mamonhoc = N'IT101', @i_hinhthuc = N'Lý thuyết', @i_ngaythi = '2025-01-11';
EXEC USP_InsertThiLan1 @i_idlop = 1, @i_mamonhoc = N'IT201', @i_hinhthuc = N'Lý thuyết', @i_ngaythi = '2025-01-11';
EXEC USP_InsertThiLan1 @i_idlop = 1, @i_mamonhoc = N'IT301', @i_hinhthuc = N'Lý thuyết', @i_ngaythi = '2025-01-11';

EXEC USP_InsertThiLan1 @i_idlop = 1, @i_mamonhoc = N'IT201', @i_hinhthuc = N'Thực hành', @i_ngaythi = '2025-01-11';
EXEC USP_InsertThiLan1 @i_idlop = 1, @i_mamonhoc = N'IT201', @i_hinhthuc = N'Thực hành', @i_ngaythi = '2025-01-11';
EXEC USP_InsertThiLan1 @i_idlop = 1, @i_mamonhoc = N'IT301', @i_hinhthuc = N'Thực hành', @i_ngaythi = '2025-01-11';
















select * from SinhVien join KetQua on KetQua.MaSinhVien = SinhVien.MaSinhVien join Thi on Thi.ID = KetQua.ID_Thi join MonHoc on Thi.MaMonHoc = MonHoc.MaMonHoc
where Thi.MaMonHoc = 'IT101' and Thi.HinhThuc = 'Lý thuyết' and Thi.LanThi = 1 
select * from Thi

select * from KetQua join Thi on KetQua.ID_Thi = Thi.ID
 where Thi.MaMonHoc = 'IT101' and Thi.HinhThuc = N'Lý thuyết' and KetQua.Diem  > 0

--cách test proc thi lần 2: thêm 1 thi trùng với môn học , nếu thi lần 2 thêm =  ok

EXEC USP_InsertThiLan1 @i_idlop = 1, @i_mamonhoc = N'IT101', @i_hinhthuc = N'Lý thuyết', @i_ngaythi = '2025-01-11';
select * from KetQua 


EXEC USP_InsertThiLan1 @i_idlop = 1, @i_mamonhoc = N'IT201', @i_hinhthuc = N'Lý thuyết', @i_ngaythi = '2025-01-11';
 select * from KetQua join Thi on KetQua.ID_Thi = Thi.ID

 exec USP_InsertThiLan2  @i_mamonhoc = N'IT201', @i_ngaythi = '2025-01-11',  @i_hinhthuc = N'Lý thuyết'
 select * from KetQua join Thi on KetQua.ID_Thi = Thi.ID


exec USP_InsertThiLan2  @i_mamonhoc = N'IT101', @i_ngaythi = '2025-01-11',  @i_hinhthuc = N'Lý thuyết'
 select * from KetQua join Thi on KetQua.ID_Thi = Thi.ID

select * from KetQua
select * from Thi where thi.HinhThuc = 'Lý thuyết' and Thi.ID_LopHoc = '1' and Thi.MaMonHoc = 'IT101'

  SELECT Thi.ID FROM Thi WHERE Thi.HinhThuc = 'Lý thuyết'  AND Thi.MaMonHoc = 'IT101' and Thi.LanThi = 2;

  delete from Thi
  delete from KetQua
select * from LopHoc
select * from MonHoc

select * from Thi


EXEC USP_InsertThiLan1 @i_idlop = 2, @i_mamonhoc = N'IT301', @i_hinhthuc = N'Lý thuyết', @i_ngaythi = '2025-01-11';
 select * from KetQua join Thi on KetQua.ID_Thi = Thi.ID

EXEC USP_InsertThiLan1 @i_idlop = 1, @i_mamonhoc = N'IT301', @i_hinhthuc = N'Lý thuyết', @i_ngaythi = '2025-01-11';
 select * from KetQua join Thi on KetQua.ID_Thi = Thi.ID

 exec USP_InsertThiLan2  @i_mamonhoc = N'IT301', @i_ngaythi = '2025-01-11',  @i_hinhthuc = N'Lý thuyết'
 select * from KetQua join Thi on KetQua.ID_Thi = Thi.ID
 

 select Thi.ID as id, LopHoc.TenLop as tenlop, MonHoc.TenMonHoc as tenmonhoc, Thi.LanThi as lanthi, Thi.NgayThi as ngaythi , MonHoc.MaMonHoc as mamonhoc , LopHoc.ID as id_lophoc , Thi.HinhThuc as hinhthuc
 ,NganhHoc.TenNganhHoc as tennganhoc, KhoaHoc.TenKhoa as tenkhoa

 from Thi left join LopHoc on Thi.ID_LopHoc = LopHoc.ID join MonHoc on Thi.MaMonHoc = MonHoc.MaMonHoc join NganhHoc on NganhHoc.ID = MonHoc.ID_NganhHoc join KhoaHoc on KhoaHoc.ID = NganhHoc.ID_KhoaHoc

