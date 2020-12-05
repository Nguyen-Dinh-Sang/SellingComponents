USE SellingComponentsDB
GO

---Quyền
INSERT INTO Role(Role)
VALUES(N'Khách hàng')

INSERT INTO Role(Role)
VALUES(N'Nhân Viên')

INSERT INTO Role(Role)
VALUES(N'Quản Lý')
Go

---Người dùng
INSERT INTO UserInformation(UserName, Password, FullName, Sex, PhoneNumber, Email, Brithday, Address, IdRole)
VALUES('phuongthanh', '12345', N'Phạm Phương Thành', N'Nam', '01234567890', 'phuongthanh@gmail.com', '2020-01-01', N'Gò Vấp', 1)

INSERT INTO UserInformation(UserName, Password, FullName, Sex, PhoneNumber, Email, Brithday, Address, IdRole)
VALUES('thanhphuong', '12345', N'Lê Thanh Phương', N'Nam', '01234567890', 'thanhphuong@gmail.com', '2020-01-01', N'Gò Vấp', 1)

INSERT INTO UserInformation(UserName, Password, FullName, Sex, PhoneNumber, Email, Brithday, Address, IdRole)
VALUES('sangdeptrai', '12345', N'Nguyễn Đình Sang', N'Nam', '01234567890', 'dinhsang@gmail.com', '2020-01-01', N'Quận 8', 2)

INSERT INTO UserInformation(UserName, Password, FullName, Sex, PhoneNumber, Email, Brithday, Address, IdRole)
VALUES('thanhhai', '12345', N'Trần Viết Thanh Hải', N'Nam', '01234567890', 'thanhhai@gmail.com', '2020-01-01', N'Quận 8', 2)

INSERT INTO UserInformation(UserName, Password, FullName, Sex, PhoneNumber, Email, Brithday, Address, IdRole)
VALUES('xuanlinh', '12345', N'Nguyễn Thị Xuân Linh', N'Nữ', '01234567890', 'xuanlinh@gmail.com', '2020-01-01', N'Quận Hóc Môn', 3)

INSERT INTO UserInformation(UserName, Password, FullName, Sex, PhoneNumber, Email, Brithday, Address, IdRole)
VALUES('phongle', '12345', N'Trần Thanh Phong', N'Nam', '01234567890', 'phongle@gmail.com', '2020-01-01', N'Long An', 3)
GO

---Đơn hàng
INSERT INTO Orders(IdUser, TotalCost, DeliveryAddress, DeliveryDate)
VALUES(1, 200000, N'Gò Vấp', '2020-01-01')

INSERT INTO Orders(IdUser, TotalCost, DeliveryAddress, DeliveryDate)
VALUES(1, 200000, N'Gò Vấp', '2020-01-01')
GO

--Loại linh kiện
INSERT INTO Classify(ClassifyName, ClassifyDetail)
VALUES(N'Laptop', N'Laptop phục vụ cho nhu cầu gaming, văn phòng, doanh nhân của các hàng sản xuất Dell, HP, Lenovo, Acer, Asus, MSI, LG')

INSERT INTO Classify(ClassifyName, ClassifyDetail)
VALUES(N'Mainboard', N'Bo mạch chủ')

INSERT INTO Classify(ClassifyName, ClassifyDetail)
VALUES(N'CPU', N'Bộ vi xử lý')

INSERT INTO Classify(ClassifyName, ClassifyDetail)
VALUES(N'Ram', N'Bộ nhớ trong')

INSERT INTO Classify(ClassifyName, ClassifyDetail)
VALUES(N'VGA', N'Card màn hình')
GO

INSERT INTO Classify(ClassifyName, ClassifyDetail)
VALUES(N'SSD', N'Ổ cứng thể rắn')

INSERT INTO Classify(ClassifyName, ClassifyDetail)
VALUES(N'HDD', N'Ổ cứng PC')

INSERT INTO Classify(ClassifyName, ClassifyDetail)
VALUES(N'PSU', N'Nguồn máy tính')

INSERT INTO Classify(ClassifyName, ClassifyDetail)
VALUES(N'Case', N'Vở máy tính')

INSERT INTO Classify(ClassifyName, ClassifyDetail)
VALUES(N'Tản nhiệt', N'Tản nhiệt khí, tản nhiệt nước, fan RGB')

INSERT INTO Classify(ClassifyName, ClassifyDetail)
VALUES(N'Màn hình', N'Các loại màn hình phù hợp mọi nhu cầu')

INSERT INTO Classify(ClassifyName, ClassifyDetail)
VALUES(N'Bàn phím', N'Các loại bàn phím')

INSERT INTO Classify(ClassifyName, ClassifyDetail)
VALUES(N'Chuột', N'Chuột và lót chuột')

INSERT INTO Classify(ClassifyName, ClassifyDetail)
VALUES(N'Ghế', N'Bàn ghế các loại')

INSERT INTO Classify(ClassifyName, ClassifyDetail)
VALUES(N'Audio', N'Loa, tai nghe...')
GO

---Linh kiện
INSERT INTO Product(ProductName, Amount, Price, Detail, IdClassify)
VALUES(N'MSI H410M-A PRO', 10, 100000, N'MSI H410M-A PRO là main máy tính được sử dụng chipset H410 của Intel, hỗ trợ vi xử lý Intel® Core™ / Pentium® Celeron® thế hệ 10 socket LGA 1200. Là một bo mạch chủ với giá cả phải chăng, MSI H410M-A Pro vẫn sở hữu đầy đủ tính năng để đáp ứng cho nhu cầu làm việc cũng như gaming.', 2)

INSERT INTO Product(ProductName, Amount, Price, Detail, IdClassify)
VALUES(N'Intel Pentium G6400', 10, 100000, N'Intel Pentium G6400 / 4MB / 4.0GHz / 2 Nhân 4 Luồng / LGA 1200', 3)

INSERT INTO Product(ProductName, Amount, Price, Detail, IdClassify)
VALUES(N'G.SKILL Ripjaws V 8GB', 10, 100000, N'8G DDR4 1x8G 2800', 4)

INSERT INTO Product(ProductName, Amount, Price, Detail, IdClassify)
VALUES(N'HDD Western Digital Blue 1TB', 10, 100000, N'HDD Western Digital Blue 1TB 2.5" SATA 3', 7)

INSERT INTO Product(ProductName, Amount, Price, Detail, IdClassify)
VALUES(N'PNY SSD CS900', 10, 100000, N'PNY SSD CS900 120G 2.5" Sata 3" SATA 3', 6)

INSERT INTO Product(ProductName, Amount, Price, Detail, IdClassify)
VALUES(N'Case XIGMATEK NYX 3F RGB', 10, 100000, N'Nhà sản xuất: Xigmatek', 9)

INSERT INTO Product(ProductName, Amount, Price, Detail, IdClassify)
VALUES(N'Deepcool DN450 80 Plus', 10, 100000, N'( 450W ) Nguồn Máy Tính Deepcool DN450 80 Plus', 8)

INSERT INTO Product(ProductName, Amount, Price, Detail, IdClassify)
VALUES(N'MSI GTX 1650 VENTUS XS', 10, 100000, N'MSI GTX 1650 VENTUS XS 4GB OC V1 GDDR6', 5)
GO

---Nhập hàng
INSERT INTO Warehouse(IdProduct, Amount)
VALUES(1, 10)

INSERT INTO Warehouse(IdProduct, Amount)
VALUES(2, 10)

INSERT INTO Warehouse(IdProduct, Amount)
VALUES(3, 10)

INSERT INTO Warehouse(IdProduct, Amount)
VALUES(4, 10)

INSERT INTO Warehouse(IdProduct, Amount)
VALUES(5, 10)

INSERT INTO Warehouse(IdProduct, Amount)
VALUES(6, 10)

INSERT INTO Warehouse(IdProduct, Amount)
VALUES(7, 10)
GO

---Catalog
INSERT INTO Catalog(CatalogName, CatalogDetails)
VALUES(N'PC Gaming', N'Máy tính chuyên chơi game')

INSERT INTO Catalog(CatalogName, CatalogDetails)
VALUES(N'PC Văn phòng', N'Máy tính làm việc văn phòng')

INSERT INTO Catalog(CatalogName, CatalogDetails)
VALUES(N'PC Workstation', N'Máy tính danh cho đồ họa, thiết kế')

INSERT INTO Catalog(CatalogName, CatalogDetails)
VALUES(N'Phụ kiện máy tính', N'Màn hình, chuột, bàn phím, bàn ghế')
GO

---Combo
INSERT INTO Combo(ComboName, ComboDetails, TotalCost, Price, IdCatalog)
VALUES(N'Titan 10 M', N'Với kinh phí dưới 10 triệu đồng nhưng lại cần build một chiếc pc chất lượng nhằm hỗ trợ công việc. Đặc biệt, đáp ứng được nhu cầu giải trí với các tựa game đình đám. GVN Titan 10 M  sẽ là một trong những sự lựa chọn tốt nhất trong phân khúc dưới 10 triệu đồng bạn không nên bỏ qua.', 800000, 750000, 1)
GO

---Chi tiết combo
INSERT INTO ComboDetails(IdCombo, IdProduct)
VALUES(1, 2)

INSERT INTO ComboDetails(IdCombo, IdProduct)
VALUES(1, 3)

INSERT INTO ComboDetails(IdCombo, IdProduct)
VALUES(1, 4)

INSERT INTO ComboDetails(IdCombo, IdProduct)
VALUES(1, 5)

INSERT INTO ComboDetails(IdCombo, IdProduct)
VALUES(1, 6)

INSERT INTO ComboDetails(IdCombo, IdProduct)
VALUES(1, 1)

INSERT INTO ComboDetails(IdCombo, IdProduct)
VALUES(1, 7)

INSERT INTO ComboDetails(IdCombo, IdProduct)
VALUES(1, 8)
GO

---Chi tiết đơn hàng
INSERT INTO OrdersDetails(IdOrders, IdProduct, Amount, Price)
VALUES(1, 1, 2, 100000)

INSERT INTO OrdersDetails(IdOrders, IdProduct, Amount, Price)
VALUES(2, 3, 1, 100000)

INSERT INTO OrdersDetails(IdOrders, IdProduct, Amount, Price)
VALUES(2, 4, 1, 100000)
GO
---
SELECT *
FROM Role

SELECT*
FROM UserInformation

SELECT *
FROM Orders

SELECT *
FROM Classify

SELECT *
FROM Product

SELECT *
FROM Warehouse

SELECT *
FROM Catalog

SELECT *
FROM Combo

SELECT *
FROM ComboDetails

SELECT *
FROM OrdersDetails