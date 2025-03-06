
function ShowAllReservation() {
    $("table tbody").html("");
    $.ajax({
        url: apiURL,
        type: "get",
        contentType: "application/json",
        success: function (result, status, xhr) {
            $.each(result, function (index, value) {
                $("tbody").append($("<tr>"));
                let appendElement = $("tbody tr").last();
                appendElement.append($("<td>").html(value["id"]));
                appendElement.append($("<td>").html(value["name"]));
                appendElement.append($("<td>").html(value["startLocation"]));
                appendElement.append($("<td>").html(value["endLocation"]));
                appendElement.append($("<td>").html(`<a href="reservation/update?id=${value["id"]}"><img src="icon/edit.png" /></a>`));
                appendElement.append($("<td>").html(`<img class="delete" src="icon/close.png" />`));
            });
        },
        error: function (xhr, status, error) {
            console.log(xhr);
        }
    });
}
function DeleteReservation() {
    $("table").on("click", "img.delete", function () {
        var reservationId = $(this).parents("tr").find("td:nth-child(1)").text();
        $.ajax({
            url: `${apiURL}/${reservationId}`,
            type: "delete",
            contentType: "application/json",
            success: function (result, status, xhr) {
                ShowAllReservation();
            },
            error: function (xhr, status, error) {
                console.log(xhr)
            }
        });
    });
}

function getReservationById() {
    $("#GetButton").click(function (e) {
        $("table tbody").html("");
        $.ajax({
            url: apiURL + `/${$("#Id").val()}`,
            type: "get",
            contentType: "application/json",
            success: function (result, status, xhr) {
                $("#resultDiv").show();
                if (typeof result !== 'undefined') {
                    var str = "<tr><td>" + result["id"] + "</td><td>" + result["name"] + "</td><td>" + result["startLocation"] + "</td><td>" + result["endLocation"] + "</td></tr>";
                    $("table tbody").append(str);
                }
                else
                    $("table tbody").append("<td colspan=\"4\">No Reservation</td>");
            },
            error: function (xhr, status, error) {
                console.log(xhr)
            }
        });
    });
}
function GetReservation() {
    let params = (new URL(document.location)).searchParams;
    let id = params.get("id");
    $.ajax({
        url: apiURL + `/${id}`,
        type: "get",
        contentType: "application/json",
        success: function (result, status, xhr) {
            $("#Id").val(result["id"]);
            $("#Name").val(result["name"]);
            $("#StartLocation").val(result["startLocation"]);
            $("#EndLocation").val(result["endLocation"]);
        },
        error: function (xhr, status, error) {
            console.log(xhr)
        }
    });
}
function UpdateReservation() {
    $("#UpdateButton").click(function (e) {
        e.preventDefault();

        let params = new URLSearchParams(window.location.search);
        let id = params.get("id");

        let data = JSON.stringify({
            Id: $("#Id").val(),
            Name: $("#Name").val(),
            StartLocation: $("#StartLocation").val(),
            EndLocation: $("#EndLocation").val()
        });

        $.ajax({
            url: apiURL,
            type: "PUT",
            data: data,
            contentType: "application/json", 
            processData: false,
            success: function (result, status, xhr) {
                var str = "<tr><td>" + result["id"] + "</td><td>" + result["name"] + "</td><td>" + result["startLocation"] + "</td><td>" + result["endLocation"] + "</td></tr>";
                $("table tbody").append(str);
                $("#resultDiv").show();
            },
            error: function (xhr, status, error) {
                console.log(xhr);
            }
        });
    });

}
function AddReservation() {
    $("#AddButton").click(function (e) {
        $.ajax({
            url: apiURL,
            headers: {
                Key: "Secret@123"
            },
            type: "post",
            contentType: "application/json",
            data: JSON.stringify({
                Id: 0,
                Name: $("#Name").val(),
                StartLocation: $("#StartLocation").val(),
                EndLocation: $("#EndLocation").val()
            }),
            success: function (result, status, xhr) {
                var str = "<tr><td>" + result["id"] + "</td><td>" + result["name"] + "</td><td>" + result["startLocation"] + "</td><td>" + result["endLocation"] + "</td></tr>";
                $("table tbody").append(str);
                $("#resultDiv").show();
            },
            error: function (xhr, status, error) {
                console.log(xhr)
            }
        });
    });
}

