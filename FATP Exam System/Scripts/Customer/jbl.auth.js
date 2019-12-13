var jblpersonalinfokey = 'jblpersonalinfo';
var DevAddr = `http://10.137.128.74:3030`;
var DevAppAddr = `http://cnctug0app01:3030`;
var passDevAddr = `http://open.app-dev.corp.jabil.org/pis/auth`;
var passProductionAddr = `http://open.acloud.corp.jabil.org/pis/auth`;

var jabilauthenticate = function () {
    var addr = passProductionAddr;
    var tokenUri = addr + '/api/v1/user/authorize';
    var checkTokenUri = addr + '/api/v1/user/token';
    var getSiteUrl = addr + '/api/v1/site/getSite';

    //get parameter value from URL.-
    getParameterByName = function (name) {
        name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
        var regexS = "[\\?&]" + name + "=([^&]*)";
        var regex = new RegExp(regexS);
        var decodedUrl = decodeURIComponent(document.location.toString()).replace(/amp;/g, '');
        var results = regex.exec(decodedUrl);
        if (results == null)
            return "";
        else
            return decodeURIComponent(results[1].replace(/\+/g, " "));
    },

        //show loging icon
        showprogress = function (show) {
            if (show) {
                // $("#okta-sign-in").css("display", "none");
                // $("#loadingdiv").css("display", "block");
                //$('.okta-sign-in-beacon-border').addClass('auth-beacon-border');
                $('#sso-spinner').css('display', 'block');
                $('#sso-login').css('display', 'none');
            } else {
                // $("#okta-sign-in").css("display", "block");
                // $("#loadingdiv").css("display", "none");
                $('#sso-spinner').css('display', 'none');
                $('#sso-login').css('display', 'block');
            }
        }

    //verify if user token is valid
    verifyusertokenexp = function (token) {
        var deferred = $.Deferred();
        $.ajax({
            method: "GET",
            url: checkTokenUri,
            headers: {
                'x-access-token': token
            }
        })
            .done(function (data) {
                deferred.resolve(data);
            })
        return deferred.promise();
    }

    saveUserInfo = function () {
        var username = $("#ntid").val();
        //var siteValue = $('#site').val();
        var userInfoStr = JSON.stringify({
            NTID: username,
            //site: siteValue
        })
        var isChecked = ($("#rmbUser").prop("checked") == true) || ($("#rmbUser").prop("checked") == "checked");
        if (isChecked) {
            var rmbUserStr = $.cookie("rmbUser");
            if (rmbUserStr && rmbUserStr != '') {
                var userInfo = JSON.parse(rmbUserStr);
                if (username != userInfo.NTID || siteValue != userInfo.site) {
                    $.cookie("rmbUser", userInfoStr, { expires: 7 });
                }
            } else {
                $.cookie("rmbUser", userInfoStr, { expires: 7 });
            }
        }
    }

    //setSite = function () {
    //    $.ajax(
    //        {
    //            type: 'GET',
    //            url: getSiteUrl,
    //            success: function (result) {
    //                if (result) {
    //                    var op = `<option value=''>Please select your site</option>`;
    //                    for (var i = 0; i < result.length; i++) {
    //                        op += `<option value='${result[i]}'>${result[i]}</option>`;
    //                    }
    //                    $("#site").html(op);
    //                }
    //                var rmbUserStr = $.cookie("rmbUser");
    //                if (rmbUserStr && rmbUserStr != '') {
    //                    var userInfo = JSON.parse(rmbUserStr);
    //                    $("#ntid").val(userInfo.NTID);
    //                    $(`#site option[value='${userInfo.site}']`).attr("selected", true);
    //                };
    //                $(".ui-select").selectWidget({
    //                    change: function (changes) {
    //                        var siteValue = $('#site').val();
    //                        if (siteValue != '') {
    //                            $('#site-error').css('display', 'none');
    //                        } else {
    //                            $('#site-error').css('display', 'block');
    //                        }
    //                        return changes;
    //                    },
    //                    effect: "slide",
    //                    keyControl: true,
    //                    speed: 200,
    //                    scrollHeight: 120
    //                });
    //            },
    //            error: function () {
    //                $('#hint').html('Get site info error.')
    //                $("#hint").css("display", "block");
    //                setTimeout(function () {
    //                    $("#hint").css("display", "none");
    //                }, 3000);
    //            }
    //        });
    //}

    initPage = function () {
        setSite();
        var sourceUrl = getParameterByName('sourceurl');
        var lType = getParameterByName('ltype');
        var path = getParameterByName('path');
        var sysName = getParameterByName('sysname');
        if (sysName && sysName != '') {
            $('#sys-head').html(sysName);
        }
        var redirectUrl = sourceUrl;
        $("#formLogin").validate({
            rules: {
                username: "required",
                password: "required",
                site: "required"
            },
            messages: {
                username: "Please enter your ntid",
                password: "Please enter your password",
                site: "Please select your site"
            },
            submitHandler: function (form) {
                var siteValue = $('#site').val();
                if (siteValue == '') {
                    $('#site-error').css('display', 'block');
                    return;
                }
                showprogress(true);
                setTimeout(function () {
                    var $form = $(form);
                    $.post(tokenUri, $form.serialize(), function (da) { })
                        .done(function (res) {
                            console.log(res);
                            if (res && (!res.error)) {
                                saveUserInfo();
                                if (sourceUrl && lType) {
                                    if (lType === 'angular') {
                                        if (path) {
                                            sourceUrl = sourceUrl + '/#/' + path;
                                        } else {
                                            window.location = '/';
                                        }
                                    }
                                    window.location = sourceUrl + '?token=' + res.result.token;
                                } else {
                                    window.location = '/';
                                }
                            } else {
                                // $('#hint').html('Failed to loging the system.');
                                $('#hint').html(res.result);
                                $("#hint").css("display", "block");
                                setTimeout(function () {
                                    $("#hint").css("display", "none");
                                }, 3000);
                            }
                            showprogress(false);
                        })
                }, 500);
            }
        })
    }

    return {
        getParameterByName: getParameterByName,
        verifyusertokenexp: verifyusertokenexp,
        initPage: initPage,
        saveUserInfo: saveUserInfo
    }

}();

var jabilhome = function () {

    //log out
    logout = function () {
        if (confirm('Do you really want to sign out application?')) {
            // $.cookie('sso_token', null);
            window.location = "/logout";
        }
    }

    //welcome page
    initPage = function () {
        var usertoken = $.cookie('sso_token');
        if (usertoken) {
            jabilauthenticate.verifyusertokenexp(usertoken).then(function (res) {
                if (res) {
                    var data = res.data;
                    if (data && data.error) {
                        $.cookie('sso_token', null);
                        window.location = "/login";
                    } else {
                        $('#ntid').html(data.result.name);
                        $('#tokeninfo').html(data.result.token);
                        $('#uid-value').html(data.result._id);
                        $('#name-value').html(data.result.name);
                        $('#mail-value').html(data.result.mail);
                        $('#department-value').html(data.result.department);
                        $('#title-value').html(data.result.title);
                        //$('#site-name').html(data.result.st);
                    }
                } else {
                    window.location = "/login";
                }
            })
        } else {
            window.location = "/login";
        }
    }
    return {
        logout: logout,
        initPage: initPage
    }
}();