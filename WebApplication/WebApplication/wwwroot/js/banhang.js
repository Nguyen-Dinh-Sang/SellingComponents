function ThemSP_GioHang(data) {
    alert(data);
    var id = data;
    //alert(id);
    $.ajax({
        type: 'GET',
        dataType: 'json',
        headers: {
            "XSRF-TOKEN": $('input:hidden[name="__RequestVerificationToken"]').val()
        },
        contentType: 'application/json; charset=utf-8',
        url: '/GiaTourHienTais/Jquery',
        data: {
            id: id
        },

        success: function (result) {
            var html = '<select asp-for="GiaId" name="GiaId" class="form-control">';
            $.each(result, function () {
                var item = this;
                var spl = item.giaTuNgay.split('T');
                var date = new Date(spl[0]);
                html += '<option value="' + item.giaId + '"> ' + parseInt(date.getMonth() + 1) + '/' + date.getDate() + '/' + date.getFullYear() + ' </option>';
            })
            html += '</select>';
            $("#result").html(html);
        }
    });
}
function SanPham_MuaNgay(data) {
    alert(data);
}
function ThemCombo_GioHang(data) {
    alert(data);
}
function Combo_MuaNgay(data) {
    alert(data);
}