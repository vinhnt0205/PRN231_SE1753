function ShowAllReservation() {
    var xhttp = new XMLHttpRequest();
    xhttp.open("GET", apiURL, true);
    xhttp.send();
    xhttp.onreadystatechange = function () {
        var tbody = document.getElementById("apiTable").querySelector("tbody");
        tbody.innerHTML = "";
        if (this.readyState == 4 && this.status == 200) {
            JSON.parse(this.responseText).forEach(function (data, index) {
                tbody.innerHTML += "<tr><td>" + data.id + "</td>" +
                    "<td>" + data.name + "</td>" +
                    "<td>" + data.startLocation + "</td>" +
                    "<td>" + data.endLocation + "</td>" +
                    "<td><a href=\"reservation/update?id=" + data.id +
                    "\"><img src=\"icon/edit.png\" /></a></td>" +
                    "<td><img class=\"delete \" src=\"icon/close.png\" /></td></tr>";
            });
            CreateClickEvent();
        }
    };
}
function CreateClickEvent() {
    var dimg = document.getElementsByClassName("delete");
    for (let i = 0; i < dimg.length; i++) {
        dimg[i].addEventListener("click", function (e) {
            var xhttp = new XMLHttpRequest();
            xhttp.onreadystatechange = function () {
                ShowAllReservation();
            };
            var resId = e.target.closest("tr").childNodes[0].innerHTML;
            xhttp.open("DELETE", apiURL + "/" + resId, true);
            xhttp.send();
        })
    }
}
function getReservationById() {
    document.getElementById("GetButton").onclick = function () {
        var xhttp = new XMLHttpRequest();
        xhttp.onreadystatechange = function () {
            if (this.readyState == 4 && this.status == 200) {
                var response = JSON.parse(this.responseText);
                var tbody = document.getElementById("resultDiv").querySelector("tbody");
                tbody.innerHTML = "<tr><td>" + response.id + "</td><td>" + response.name + "</td><td>" +
                    response.startLocation + "</td><td>" + response.endLocation + "</td></tr>";
                document.getElementById("resultDiv").style.display = "block";
            }
        };
        xhttp.open("GET", apiURL + "/" + document.getElementById("Id").value, true);
        xhttp.send();
    };
}
function GetReservation() {
    let params = (new URL(document.location)).searchParams;
    let id = params.get("id");
    var xhttp = new XMLHttpRequest
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            var response = JSON.parse(this.responseText);
            document.getElementById("Id").value = response.id;
            document.getElementById("Name").value = response.name;
            document.getElementById("StartLocation").value = response.startLocation;
            document.getElementById("EndLocation").value = response.endLocation;
        }
    };
    xhttp.open("GET", apiURL + "/" + id, true);
    xhttp.send();
}
function UpdateReservation() {
    document.getElementById("UpdateButton").onclick = function () {
        var xhttp = new XMLHttpRequest();
        xhttp.onreadystatechange = function () {
            if (this.readyState == 4 && this.status == 200) {
                var response = JSON.parse(this.responseText);
                var tbody = document.getElementById("resultDiv").querySelector("tbody");
                tbody.innerHTML = "<tr><td>" + response.id + "</td><td>" + response.name + "</td><td>" +
                    response.startLocation + "</td><td>" + response.endLocation + "</td></tr>";
                document.getElementById("resultDiv").style.display = "block";
            }
        };

        xhttp.open("PUT", apiURL, true);
        xhttp.setRequestHeader("Content-Type", "application/json");

        // Convert form data to JSON
        var data = JSON.stringify({
            Id: document.getElementById("Id").value,
            Name: document.getElementById("Name").value,
            StartLocation: document.getElementById("StartLocation").value,
            EndLocation: document.getElementById("EndLocation").value
        });

        xhttp.send(data);
    };

}
function AddReservation() {
    document.getElementById("AddButton").onclick = function () {
        var xhttp = new XMLHttpRequest();
        xhttp.onreadystatechange = function () {
            if (this.readyState == 4 && this.status == 200) {
                var response = JSON.parse(this.responseText);
                var tbody = document.getElementById("resultDiv").querySelector("tbody");
                tbody.innerHTML = "<tr><td>" + response.id + "</td><td>" + response.name +
                    "</td><td>" + response.startLocation + "</td><td>" + response.endLocation + "</td></tr>";
                document.getElementById("resultDiv").style.display = "block";
            }
        };
        xhttp.open("POST", apiURL, true);
        xhttp.setRequestHeader("Content-type", "application/json");
        xhttp.setRequestHeader("Key", "Secret@123");
        var obj = {
            Id: 0, Name: document.getElementById("Name").value,
            StartLocation: document.getElementById("StartLocation").value,
            EndLocation: document.getElementById("EndLocation").value
        };
        xhttp.send(JSON.stringify(obj));
    };
}