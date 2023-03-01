const baseUrl = "https://localhost:7294/api/";

$(document).ready(function () {
    if (sessionStorage.getItem("token") != null) {
        $('#hello').show();
        if (window.location == 'https://localhost:7051/Home/Index') {
            $('#hello').html('<a class="nav-link text-dark">Welcome' + sessionStorage.getItem("role") + '</a>');
        }

        $("#logoutButton").show();
        $("#studentsButton").show();
        $("#registerButton").hide();
        $("#loginButton").hide();

    }
    else {

        $("#logoutButton").hide();
        $("#studentsButton").hide();
        $("#registerButton").show();
        $("#loginButton").show();
    }

    if (window.location == 'https://localhost:7075/Student') {
        GetStudentsList();
    }

});

function GetStudentsList() {
    var myUrl = baseUrl + "Students";
    $.ajax({
        url: myUrl,
        type: "GET",
        headers: {
            "Authorization": 'Bearer ' + sessionStorage.getItem("token")
        },
        success: function (response) {
            GetStudentListPartial(response);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(xhr.responseText);
        }
    });
}

function CreateStudent() {
    let formdata = new FormData();
    let input = document.getElementById("Photo");
    let files = input.files;
    formdata.append('photo', files[0]);
    formdata.append('firstName', $("#FirstName").val());
    formdata.append('lastName', $("#LastName").val());
    formdata.append('schoolId', $("#SchoolId").val());

    var myUrl = baseUrl + "Students";
    if ($('#createStudentForm').valid()) {
        $.ajax({
            url: myUrl,
            type: "POST",
            data: formData,
            processData: false,
            contentType: false,
            success: function (data, textStatus, xhr) {
                if (xhr.status == 201) {
                    GetStudentList()
                }
                else {
                    $("#fail").append('<div class="alert alert-danger" role="alert">Error! Student addition failed.</div>');
                }
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(xhr.status);
                alert(xhr.responseText);
            }
        });

    }
}

function GetStudentListPartial(students) {
    var myUrl = "/Students/GetStudentList";
    $.ajax({
        url: myUrl,
        type: "POST",
        data: students,
        success: function (response) {
            $("#letMeSee").html(response);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(xhr.responseText);
        }
    });
}

function GetSchoolsList() {
    var myUrl = baseUrl + "Schools";
    $.ajax({
        url: myUrl,
        type: "GET",
        headers: {
            "Authorization": 'Bearer ' + sessionStorage.getItem("token")
        },
        success: function (response) {
            GetStudentCreatePartial(response);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(xhr.responseText);
        }
    });
}

function GetStudentCreatePartial(schools) {
    var myUrl = "/Students/GetStudentCreatePartial";
    $.ajax({
        url: myUrl,
        type: "POST",
        data: schools,
        success: function (response) {
            $("#letMeSee").html(response);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(xhr.status);
            alert(xhr.responseText);
        }
    });
}


function Register() {
    let formData = new FormData();
    formData.append('userName', $('#userName').val());
    formData.append('firstName', $('#firstName').val());
    formData.append('lastName', $('#lastName').val());
    formData.append('email', $('#email').val());
    formData.append('password', $('#password').val());
    formData.append('passwordConfirm', $('#passwordConfirm').val());
    formData.append('applicationUserRole', $('#applicationUserRole').val());

    var myUrl = baseUrl + "ApplicationUsers";
    if ($('#registerForm').valid()) {
        $.ajax({
            url: myUrl,
            type: "POST",
            data: formData,
            processData: false,
            contentType: false,
            success: function (response) {
                alert("Registration successful. Please login");
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(xhr.status);
                alert(xhr.responseText);
            }
        });
    }

}


function GotoHomeIndex() {
    window.location.href = "/Home/Index";
}
 
    function Login() {
        let formData = new FormData();
        formData.append('email', $('#email').val());
        formData.append('password', $('#password').val());

        var myUrl = baseUrl + "ApplicationUsers/Login";
        if ($('#loginForm').valid()) {
            $.ajax({
                url: myUrl,
                type: "POST",
                data: formData,
                processData: false,
                contentType: false,
                success: function (response) {
                    sessionStorage.setItem("token", response);
                    alert("Welcome");
                    GetLoggedInUserRole();
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    alert(xhr.status);
                    alert(xhr.responseText);
                }
            });

        }
    }

    function GetLoggedInUserRole() {
        var myUrl = baseUrl + "ApplicationUsers";
        $.ajax({
            url: myUrl,
            type: "GET",
            headers: {
                "Authorization": 'Bearer ' + sessionStorage.getItem("token")
            },
            success: function (response) {
                sessionStorage.setItem("role", response);
                GotoHomeIndex();
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert(xhr.status);
                alert(xhr.responseText);
            }
        });
    }