function ThemSP_GioHang(data,id_user) {
    
    var id = data;
    var iduser = id_user;
    var soluong = parseInt( document.getElementById("giohang_soluong").innerHTML)+1;
    //alert(id);
    $.ajax({
        type: 'GET',
        dataType: 'json',
        headers: {
            "XSRF-TOKEN": $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        contentType: 'application/json; charset=utf-8',
        url: '/Products/SanPham_GioHang',
        data: {
            id: id,
            iduser: iduser
        },

        success: function (result) {
            
            window.location.reload(); 
        }
    });
}
function SanPham_MuaNgay(data) {
    alert(data);
}
function ThemCombo_GioHang(data,id_user) {
    
    var id = data;
    var iduser = id_user;
    var soluong = parseInt(document.getElementById("giohang_soluong").innerHTML) + 1;
    //alert(id);
    $.ajax({
        type: 'GET',
        dataType: 'json',
        headers: {
            "XSRF-TOKEN": $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        contentType: 'application/json; charset=utf-8',
        url: '/Products/Combo_GioHang',
        data: {
            id: id,
            iduser: iduser
        },

        success: function (result) {
            
            window.location.reload(); 
        }
    });
}
function Combo_MuaNgay(data) {
    alert(data);
}
function deleteCart(data,id_user) {
    
    var id = data;
    var iduser = id_user;
    
    //alert(id);
    $.ajax({
        type: 'GET',
        dataType: 'json',
        headers: {
            "XSRF-TOKEN": $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        contentType: 'application/json; charset=utf-8',
        url: '/Products/Delete_Cart',
        data: {
            id: id,
            iduser: iduser
        },

        success: function (result) {
            
            window.location.reload(); 
        }
    });
}
function set_soluong_giohang(id,data,max) {
    
    var id = id;
    var soluong = data;
    if (soluong > max) {
        alert("số lượng sản phẩm trong kho không đủ ");
        return 0;
    }
    //alert(id);
    $.ajax({
        type: 'GET',
        dataType: 'json',
        headers: {
            "XSRF-TOKEN": $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        contentType: 'application/json; charset=utf-8',
        url: '/Products/Update_Soluong',
        data: {
            id: id,
            soluong: soluong
        },

        success: function (result) {

            window.location.reload();
        }
    });
}
function dathang() {
    var IdUser = document.getElementById("giohang_iduser").value;
    var TotalCost = document.getElementById("giohang_totalcost").value;
    var DeliveryAddress = document.getElementById("giohang_deliveryaddress").value;
    var DeliveryDate = document.getElementById("giohang_deliverydate").value;
    $.ajax({
        type: 'GET',
        dataType: 'json',
        headers: {
            "XSRF-TOKEN": $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        contentType: 'application/json; charset=utf-8',
        url: '/Products/DatHang',
        data: { 
            IdUser: IdUser,
            TotalCost: TotalCost,
            DeliveryAddress: DeliveryAddress,
            DeliveryDate: DeliveryDate
        },

        success: function (result) {
            alert(result);
            location.replace("/Products/index");
        }
    });
}
function login() {
    var UserName = document.getElementById("login_username").value;
    var Password = document.getElementById("login_password").value;
    $.ajax({
        type: 'GET',
        dataType: 'json',
        headers: {
            "XSRF-TOKEN": $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        contentType: 'application/json; charset=utf-8',
        url: '/Products/Banhang_Login',
        data: {
            UserName: UserName,
            Password: Password
        },

        success: function (result) {
            if (result == "1") {
                alert("Đăng nhập thành công");
                location.replace("/Products/index");
            }
            else {
                alert("Sai tên tài khoản hoặc mật khẩu.");
            }
            
        }
    });
}
function logout() {
    var ok = "ok";
    $.ajax({
        type: 'GET',
        dataType: 'json',
        headers: {
            "XSRF-TOKEN": $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        contentType: 'application/json; charset=utf-8',
        url: '/Products/Banhang_Logout',
        data: {
            ok:ok
        },

        success: function (result) {
            location.replace("/Products");
        

        }
    });
}
function sigup() {
    var FullName = document.getElementById("registration_fullname").value;
    var Password = document.getElementById("registration_password").value;
    var Password1 = document.getElementById("registration_passwordRepeat").value;
    var UserName = document.getElementById("registration_UserName").value;
    if (Password != Password1) {
        alert("Mật khẩu mới và mật khẩu nhập lại không khớp");
        return;
    }
    $.ajax({
        type: 'GET',
        dataType: 'json',
        headers: {
            "XSRF-TOKEN": $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        contentType: 'application/json; charset=utf-8',
        url: '/Products/Banhang_sigup',
        data: {
            UserName: UserName,
            Password: Password,
            FullName: FullName
        },

        success: function (result) {
            if (result == "1") {
                alert("Đăng ký thành công.");
                location.replace("/Products");
            }
            else {
                alert("User đã tồn tại.");
            }
            


        }
    });
}