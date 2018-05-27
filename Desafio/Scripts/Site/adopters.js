GetAnimalsAjax();

//Form manipulation
function AddNew() {
    var form = GetAddNewForm();
    if (ValidateForm(form)) {
        AddNewAdopterAjax(form);
        $('#addModal').modal('toggle');
    } else {
        $("#addFulfill").show();
    }
}
function Edit() {
    var form = GetEditForm();
    if (ValidateForm(form)) {
        EditAdopterAjax(form);
        $('#editModal').modal('toggle');
    } else {
        $("#editFulfill").show();
    }
}
function ValidateForm(form) {
    return form.Name !== "" && form.Email !== "" && form.Address !== "" && form.State !== "" && form.Phone !== "";
}
function GetAddNewForm() {
    var obj = {
        Name: $("#newName").val(),
        Email: $("#newEmail").val(),
        AddressLine: $("#newAddress").val(),
        State: $("#newState").val(),
        Phone: $("#newPhone").val()
    };
    return obj;
}
function GetEditForm() {
    var obj = {
        ID: $("#hiddenID").val(),
        Name: $("#editName").val(),
        Email: $("#editEmail").val(),
        AddressLine: $("#editAddress").val(),
        State: $("#editState").val(),
        Phone: $("#editPhone").val()
    };
    return obj;
}
function CleanTable() {
    $("#table-tr").find("tr").remove();
}
function PopulateTable(result) {
    $(result).each(function () {
        $("#table-tr").append("<tr id=" + this.ID + "><td>" + this.Name + "</td><td>" + this.Email + "</td><td>" + this.AddressLine + "</td><td>" + this.State + "</td><td>" + this.Phone + "</td><td class='buttonsColumn'><span class='glyphicon glyphicon-trash clickable' style='color:red;'onclick='RemoveAdopterAjax(this)'/><span class='glyphicon glyphicon-pencil clickable' style='color:#00cec9;'onclick='EditAdopterModal(this)' data-toggle='modal' data-target='#editModal' /></td></tr>");
    });
}
function EditAdopterModal(adopter) {
    $("#hiddenID").val(adopter.parentElement.parentElement.id);
    $("#editName").val(adopter.parentElement.parentElement.children[0].innerText);
    $("#editEmail").val(adopter.parentElement.parentElement.children[1].innerText);
    $("#editAddress").val(adopter.parentElement.parentElement.children[2].innerText);
    $("#editState").val(adopter.parentElement.parentElement.children[3].innerText);
    $("#editPhone").val(adopter.parentElement.parentElement.children[4].innerText);
}

//Ajax
function GetAnimalsAjax() {
    $.ajax({
        type: "GET",
        url: "Adopters/GetAll",
        success: function (result) {
            if (result.Success) {
                CleanTable();
                PopulateTable(result.Result);
            } else {
                alert("Fail to collect adopters: " + result.Message);
            }
        },
        error: function (error) {
            alert("Fail on request.");
        }
    });
}
function AddNewAdopterAjax(form) {
    $.ajax({
        type: "POST",
        url: "Adopters/Add",
        data: {
            adopter: form
        },
        success: function () {
            GetAnimalsAjax();
        },
        error: function () {
            alert("Fail on request.");
        }
    });
}
function RemoveAdopterAjax(tr) {
    var adopterID = tr.parentElement.parentElement.id;
    $.ajax({
        type: "POST",
        url: "Adopters/Remove",
        data: { adopterID: adopterID },
        success: function () {
            GetAnimalsAjax();
        },
        error: function () {
            alert("Fail on request.");
        }
    });
}
function EditAdopterAjax(adopter) {

    $.ajax({
        type: "POST",
        url: "Adopters/Edit",
        data: { adopter: adopter },
        success: function () {
            GetAnimalsAjax();
        },
        error: function () {
            alert("Fail on request.");
        }
    });
}

