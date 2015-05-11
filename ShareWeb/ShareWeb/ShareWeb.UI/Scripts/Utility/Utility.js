var Utility = {};
Utility.getUserProfile = function () {
    $.ajax({
        url: "/account/getuserprofile",
        type: "GET",
        error: function (e) {
            debugger;
        },
        success: function (result) {
            // window.location.reload();
            $('#main-view').empty();
            $('#title-content')[0].innerHTML = 'Update profile';
            $('#main-view')[0].innerHTML = result;
        }
    });
}