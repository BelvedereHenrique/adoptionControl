GetAnimalsAjax();

//Form manipulation
function AddNew() {
    var form = GetAddNewForm();
    if (ValidateForm(form)) {
        AddNewAnimalAjax(form);
        $('#addModal').modal('toggle');
    } else {
        $("#addFulfill").show();
    }
}
function Edit() {
    var form = GetEditForm();
    if (ValidateForm(form)) {
        EditAnimalAjax(form);
        $('#editModal').modal('toggle');
    } else {
        $("#editFulfill").show();
    }
}
function ValidateForm(form) {
    return form.Name !== "" && form.AnimalType !== "";
}
function GetAddNewForm() {
    var obj = {
        Name: $("#newName").val(),
        AnimalType: $("#newType").val(),
        Weight: $("#newWeight").val(),
        Age: $("#newAge").val()
    };
    return obj;
}
function GetEditForm() {
    var obj = {
        ID: $("#hiddenID").val(),
        Name: $("#editName").val(),
        AnimalType: $("#editType").val(),
        Weight: $("#editWeight").val(),
        Age: $("#editAge").val()
    };
    return obj;
}
function CleanTable() {
    $("#animals-table-tr").find("tr").remove();
}
function PopulateTable(result) {
    $(result).each(function () {
        $("#animals-table-tr").append("<tr id=" + this.ID + "><td>" + this.Name + "</td><td>" + this.AnimalType + "</td><td>" + this.Weight + "</td><td>" + this.Age + "</td><td class='buttonsColumn'><span class='glyphicon glyphicon-trash clickable' style='color:red;'onclick='RemoveAnimalAjax(this)'/><span class='glyphicon glyphicon-pencil clickable' style='color:#00cec9;'onclick='EditAnimalModal(this)' data-toggle='modal' data-target='#editModal' /></td></tr>");
    });
}
function EditAnimalModal(animal)
{
    $("#hiddenID").val(animal.parentElement.parentElement.id);
    $("#editName").val(animal.parentElement.parentElement.children[0].innerText);
    $("#editType").val(animal.parentElement.parentElement.children[1].innerText);
    $("#editWeight").val(animal.parentElement.parentElement.children[2].innerText);
    $("#editAge").val(animal.parentElement.parentElement.children[3].innerText);
}

//Ajax
function GetAnimalsAjax() {
    $.ajax({
        type: "GET",
        url: "/Animals/GetAll",
        success: function (result) {
            if (result.Success) {
                CleanTable();
                PopulateTable(result.Result);
            } else {
                alert("Failt to get animals: " + result.Message);
            }
        },
        error: function () {
            alert("Fail on request.");
        }
    });
}
function AddNewAnimalAjax(form) {
    $.ajax({
        type: "POST",
        url: "/Animals/Add",
        data: {
            animal: form
        },
        success: function () {
            GetAnimalsAjax();
        },
        error: function () {
            alert("Fail on request.");
        }
    });
}
function RemoveAnimalAjax(tr) {
    var animalID = tr.parentElement.parentElement.id;
    $.ajax({
        type: "POST",
        url: "Animals/Remove",
        data: { animalID: animalID },
        success: function () {
            GetAnimalsAjax();
        },
        error: function () {
            alert("Fail on request.");
        }
    });
}
function EditAnimalAjax(animal) {

    $.ajax({
        type: "POST",
        url: "Animals/Edit",
        data: { animal: animal},
        success: function () {
            GetAnimalsAjax();
        },
        error: function () {
            alert("Fail on request.");
        }
    });
}

