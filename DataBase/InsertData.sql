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
/*1*/ INSERT INTO Classify(ClassifyName, ClassifyDetail)
VALUES(N'Laptop', N'Laptop phục vụ cho nhu cầu gaming, văn phòng, doanh nhân của các hàng sản xuất Dell, HP, Lenovo, Acer, Asus, MSI, LG')

/*2*/ INSERT INTO Classify(ClassifyName, ClassifyDetail)
VALUES(N'Mainboard', N'Bo mạch chủ')

/*3*/ INSERT INTO Classify(ClassifyName, ClassifyDetail)
VALUES(N'CPU', N'Bộ vi xử lý')

/*4*/ INSERT INTO Classify(ClassifyName, ClassifyDetail)
VALUES(N'Ram', N'Bộ nhớ trong')

/*5*/ INSERT INTO Classify(ClassifyName, ClassifyDetail)
VALUES(N'VGA', N'Card màn hình')
GO

/*6*/INSERT INTO Classify(ClassifyName, ClassifyDetail)
VALUES(N'SSD', N'Ổ cứng thể rắn')

/*7*/ INSERT INTO Classify(ClassifyName, ClassifyDetail)
VALUES(N'HDD', N'Ổ cứng PC')

/*8*/INSERT INTO Classify(ClassifyName, ClassifyDetail)
VALUES(N'PSU', N'Nguồn máy tính')

/*9*/INSERT INTO Classify(ClassifyName, ClassifyDetail)
VALUES(N'Case', N'Vở máy tính')

/*10*/INSERT INTO Classify(ClassifyName, ClassifyDetail)
VALUES(N'Tản nhiệt', N'Tản nhiệt khí, tản nhiệt nước, fan RGB')

/*11*/INSERT INTO Classify(ClassifyName, ClassifyDetail)
VALUES(N'Màn hình', N'Các loại màn hình phù hợp mọi nhu cầu')

/*12*/INSERT INTO Classify(ClassifyName, ClassifyDetail)
VALUES(N'Bàn phím', N'Các loại bàn phím')

/*13*/INSERT INTO Classify(ClassifyName, ClassifyDetail)
VALUES(N'Chuột', N'Chuột và lót chuột')

/*14*/INSERT INTO Classify(ClassifyName, ClassifyDetail)
VALUES(N'Ghế', N'Bàn ghế các loại')

/*15*/INSERT INTO Classify(ClassifyName, ClassifyDetail)
VALUES(N'Audio', N'Loa, tai nghe...')
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

---Linh kiện
/*1*/ INSERT INTO Product(ProductName, Amount, Price, Detail, IdClassify)
VALUES(N'MSI H410M-A PRO', 10, 100000, N'MSI H410M-A PRO là main máy tính được sử dụng chipset H410 của Intel, hỗ trợ vi xử lý Intel® Core™ / Pentium® Celeron® thế hệ 10 socket LGA 1200. Là một bo mạch chủ với giá cả phải chăng, MSI H410M-A Pro vẫn sở hữu đầy đủ tính năng để đáp ứng cho nhu cầu làm việc cũng như gaming.', 2)
/*14*/ INSERT INTO Product(ProductName, Amount, Price, Detail, IdClassify)
VALUES(N'MSI B450M Mortar MAX (AMD Socket AM4)', 10, 100000, N'MSI B450M Mortar MAX (AMD Socket AM4) MSI B450M Mortar Max có tích hợp sẵn một 2 khe cắm M.2, 2 cổng PCI-E x16 và 1 công PCI-E x1  hỗ trợ tất cả các dòng M.2 SSD NVME cao cấp', 2)

/*2*/ INSERT INTO Product(ProductName, Amount, Price, Detail, IdClassify)
VALUES(N'Intel Pentium G6400', 10, 100000, N'Intel Pentium G6400 / 4MB / 4.0GHz / 2 Nhân 4 Luồng / LGA 1200', 3)
/*9*/ INSERT INTO Product(ProductName, Amount, Price, Detail, IdClassify)
VALUES(N'Intel Core i3 10100', 10, 100000, N'Intel Core i3 10100 / 6MB / 3.6GHz / 4 Nhân 8 Luồng / LGA 1200', 3)
/*15*/ INSERT INTO Product(ProductName, Amount, Price, Detail, IdClassify)
VALUES(N'AMD Ryzen 7 3700x', 10, 100000, N'AMD Ryzen 7 3700x /36MB /3.6GHz /8 nhân 16 luồng', 3)

/*3*/ INSERT INTO Product(ProductName, Amount, Price, Detail, IdClassify)
VALUES(N'G.SKILL Ripjaws V 8GB', 10, 100000, N'8G DDR4 1x8G 2800', 4)
/*12*/ INSERT INTO Product(ProductName, Amount, Price, Detail, IdClassify)
VALUES(N'RAM Kingston HyperX Fury Black', 10, 100000, N'8GB DDR4 1x8G 2666', 4)
/*16*/ INSERT INTO Product(ProductName, Amount, Price, Detail, IdClassify)
VALUES(N'G.SKILL Trident Z RGB', 10, 100000, N'16G DDR4 2x8G 3000 cas 16', 4)


/*8*/ INSERT INTO Product(ProductName, Amount, Price, Detail, IdClassify)
VALUES(N'MSI GTX 1650 VENTUS XS', 10, 100000, N'MSI GTX 1650 VENTUS XS 4GB OC V1 GDDR6', 5)
/*11*/ INSERT INTO Product(ProductName, Amount, Price, Detail, IdClassify)
VALUES(N'GIGABYTE GeForce GT710D5', 10, 100000, N'GIGABYTE GeForce GT710D5 1GL', 5)
/*17*/ INSERT INTO Product(ProductName, Amount, Price, Detail, IdClassify)
VALUES(N'MSI GeForce', 10, 100000, N'MSI GeForce® GTX 1660 SUPER GAMINGX 6GB GDDR6', 5)

/*5*/ INSERT INTO Product(ProductName, Amount, Price, Detail, IdClassify)
VALUES(N'PNY SSD CS900', 10, 100000, N'PNY SSD CS900 120G 2.5" Sata 3" SATA 3', 6)
/*10*/ INSERT INTO Product(ProductName, Amount, Price, Detail, IdClassify)
VALUES(N'SSD Patriot Burst 2.5', 10, 100000, N'SSD Patriot Burst 2.5 Sata III 120Gb', 6)

/*4*/ INSERT INTO Product(ProductName, Amount, Price, Detail, IdClassify)
VALUES(N'HDD Western Digital Blue 1TB', 10, 100000, N'HDD Western Digital Blue 1TB 2.5" SATA 3', 7)
/*18*/ INSERT INTO Product(ProductName, Amount, Price, Detail, IdClassify)
VALUES(N'HDD Seagate Barracuda 1TB', 10, 100000, N'HDD Seagate Barracuda 1TB 7200rpm', 7)

/*7*/ INSERT INTO Product(ProductName, Amount, Price, Detail, IdClassify)
VALUES(N'Deepcool DN450 80 Plus', 10, 100000, N'( 450W ) Nguồn Máy Tính Deepcool DN450 80 Plus', 8)
/*19*/ INSERT INTO Product(ProductName, Amount, Price, Detail, IdClassify)
VALUES(N'Corsair CV550 80 Plus', 10, 100000, N'( 550W ) Nguồn máy tính Corsair CV550 80 Plus Bronze', 8)

/*6*/ INSERT INTO Product(ProductName, Amount, Price, Detail, IdClassify)
VALUES(N'Case XIGMATEK NYX 3F RGB', 10, 100000, N'Nhà sản xuất: Xigmatek', 9)
/*13*/ INSERT INTO Product(ProductName, Amount, Price, Detail, IdClassify)
VALUES(N'Case XIGMATEK XA-20', 10, 100000, N'Nhà sản xuất: Xigmatek', 9)
/*20*/ INSERT INTO Product(ProductName, Amount, Price, Detail, IdClassify)
VALUES(N'Case XIGMATEK GEMINI', 10, 100000, N'Nhà sản xuất: Xigmatek', 9)


GO


---Combo
-- combo của catalog 1
INSERT INTO Combo(ComboName, ComboDetails, TotalCost, Price, IdCatalog)
VALUES(N'Titan 10 M', N'Với kinh phí dưới 10 triệu đồng nhưng lại cần build một chiếc pc chất lượng nhằm hỗ trợ công việc. Đặc biệt, đáp ứng được nhu cầu giải trí với các tựa game đình đám. GVN Titan 10 M  sẽ là một trong những sự lựa chọn tốt nhất trong phân khúc dưới 10 triệu đồng bạn không nên bỏ qua.', 800000, 750000, 1)

--Combo của catalog 2
INSERT INTO Combo(ComboName, ComboDetails, TotalCost, Price, IdCatalog)
VALUES(N'Atom', N'Với kinh phí dưới 10 triệu đồng nhưng lại cần build một chiếc pc chất lượng nhằm hỗ trợ công việc. Đặc biệt, đáp ứng được nhu cầu giải trí với các tựa game đình đám. GVN Atom sẽ là một trong những sự lựa chọn tốt nhất trong phân khúc dưới 10 triệu đồng bạn không nên bỏ qua.', 8410000, 6990000, 2)
INSERT INTO Combo(ComboName, ComboDetails, TotalCost, Price, IdCatalog)
VALUES(N'AXE', N'Với kinh phí dưới 10 triệu đồng nhưng lại cần build một chiếc pc chất lượng nhằm hỗ trợ công việc. Đặc biệt, đáp ứng được nhu cầu giải trí với các tựa game đình đám. GVN Axe sẽ là một trong những sự lựa chọn tốt nhất trong phân khúc dưới 10 triệu đồng bạn không nên bỏ qua.', 8230000, 6990000, 2)

-- Combo của catalog 3
INSERT INTO Combo(ComboName, ComboDetails, TotalCost, Price, IdCatalog)
VALUES(N'GVN G-Creator C501', N'Main B450M, CPU R7 3700X, Ram 2x8Gb, VGA 1660S, HDD 1Tb, PSU 550W', 27130000, 23790000, 3)

-- Combo của catalog 4
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

/* chi tiết combo1 catalog 2*/
INSERT INTO ComboDetails(IdCombo, IdProduct)
VALUES(2,1 )
INSERT INTO ComboDetails(IdCombo, IdProduct)
VALUES(2,9 )
INSERT INTO ComboDetails(IdCombo, IdProduct)
VALUES(2,4 )
INSERT INTO ComboDetails(IdCombo, IdProduct)
VALUES(2,10 )
INSERT INTO ComboDetails(IdCombo, IdProduct)
VALUES(2,7 )
INSERT INTO ComboDetails(IdCombo, IdProduct)
VALUES(2,6 )
/* chi tiết combo2 catalog 2*/
INSERT INTO ComboDetails(IdCombo, IdProduct)
VALUES(3,1 )
INSERT INTO ComboDetails(IdCombo, IdProduct)
VALUES(3,11 )
INSERT INTO ComboDetails(IdCombo, IdProduct)
VALUES(3,12 )
INSERT INTO ComboDetails(IdCombo, IdProduct)
VALUES(3,10 )
INSERT INTO ComboDetails(IdCombo, IdProduct)
VALUES(3,13 )
INSERT INTO ComboDetails(IdCombo, IdProduct)
VALUES(3,6 )

/* chi tiết combo1 catalog 3*/

INSERT INTO ComboDetails(IdCombo, IdProduct)
VALUES(4,14 )
INSERT INTO ComboDetails(IdCombo, IdProduct)
VALUES(4, 15 )
INSERT INTO ComboDetails(IdCombo, IdProduct)
VALUES(4, 16 )
INSERT INTO ComboDetails(IdCombo, IdProduct)
VALUES(4,17 )
INSERT INTO ComboDetails(IdCombo, IdProduct)
VALUES(4,18 )
INSERT INTO ComboDetails(IdCombo, IdProduct)
VALUES(4, 10)
INSERT INTO ComboDetails(IdCombo, IdProduct)
VALUES(4, 19)
INSERT INTO ComboDetails(IdCombo, IdProduct)
VALUES(4, 20)
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