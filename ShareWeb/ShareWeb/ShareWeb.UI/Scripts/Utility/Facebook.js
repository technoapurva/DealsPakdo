function InitialiseFacebook(appId) {

    window.fbAsyncInit = function () {
        FB.init({
            appId: appId,
            status: true,
            cookie: true,
            xfbml: true
        });

        FB.Event.subscribe('auth.login', function (response) {
            var credentials = { uid: response.authResponse.userID, accessToken: response.authResponse.accessToken };
            SubmitLogin(credentials);
        });

        FB.getLoginStatus(function (response) {
            if (response.status === 'connected') {
                var credentials = { uid: response.authResponse.userID, accessToken: response.authResponse.accessToken };
                $.ajax({
                    url: "/account/facebooklogin",
                    type: "POST",
                    data: credentials,
                    error: function () {
                        alert("error logging in to your facebook account.");
                    },
                    success: function () {
                        // window.location.reload();
                        $.ajax({
                            url: "/account/userdetails",
                            type: "GET",
                            error: function (e) {
                                debugger;
                            },
                            success: function (result) {
                                // window.location.reload();
                                $('#fb-login').remove();
                                $('#right-nav')[0].innerHTML = result;
                            }
                        });
                    }
                });
            }
            else if (response.status === 'not_authorized') { alert("user is not authorised"); }
            else {
                //alert("user is not conntected to facebook");
            }

        });

        function SubmitLogin(credentials) {
            $.ajax({
                url: "/account/facebooklogin",
                type: "POST",
                data: credentials,
                error: function () {
                    alert("error logging in to your facebook account.");
                },
                success: function () {
                    // window.location.reload();
                    $.ajax({
                        url: "/account/userdetails",
                        type: "GET",
                        error: function (e) {
                            debugger;
                        },
                        success: function (result) {
                            // window.location.reload();
                            $('#fb-login').remove();
                            $('#right-nav')[0].innerHTML = result;
                        }
                    });
                    //$('#fb-login').remove();
                    //$('#right-nav').load('/Home/GetNavbar', function () {
                    //    });
                }
            });
        }

    };

    (function (d) {
        var js, id = 'facebook-jssdk', ref = d.getElementsByTagName('script')[0];
        if (d.getElementById(id)) {
            return;
        }
        js = d.createElement('script');
        js.id = id;
        js.async = true;
        js.src = "//connect.facebook.net/en_US/all.js";
        ref.parentNode.insertBefore(js, ref);
    }(document));

}
var Facebook = {};
Facebook.fblogout = function () {
    FB.logout();
    $('#right-nav').empty();
    $('#right-nav').append($('<div id="fb-login" class="nav navbar-top-links navbar-right"><a autologoutlink="true" perms="read_friendlists, create_event, email, publish_stream" class="btn btn-block btn-social btn-facebook" style="width: 110px; margin: 10px 30px 5px" onclick="FB.login()"><i class="fa fa-facebook"></i> Sign in</a></div>'));

}