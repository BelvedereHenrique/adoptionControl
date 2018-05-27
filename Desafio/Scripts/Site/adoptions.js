GetAdoptions();
GetFreeAnimals(function (result) {
    CleanTable($("#animals-table-tr"));
    PopulateAnimalTable(result);
});

function RemoveAdoption(tr)
{
    var id = tr.parentElement.parentElement.id;
    $.ajax(
        {
            type: "POST",
            url: "/Adoptions/RemoveAdoption",
            data: {adoptionId:id},
            success: function (result) {
                if (result.Success) {
                    CleanTable($("#adoptions-table-tr"));
                    GetFreeAnimals(function (result) {
                        CleanTable($("#animals-table-tr"));
                        PopulateAnimalTable(result);
                    });
                } else {
                    alert("Fail to revert adoption: " + result.Message);
                }
            },
            error: function () {
                alert("Fail on request.");
            }
        });
}

function GetAdoptions() {
    $.ajax(
        {
            type: "GET",
            url: "/Adoptions/GetAll",
            success: function (result) {
                if (result.Success) {
                    CleanTable($("#adoptions-table-tr"));
                    PopulateAdoptionsTable(result.Result);
                } else {
                    alert("Fail to collect adoptions: " + result.Message);
                }
            },
            error: function () {
                alert("Fail on request.");
            }
        });
}

function GetFreeAnimals(callback) {
    $.ajax(
        {
            type: "GET",
            url: "/Adoptions/GetFreeAnimals",
            success: function (result) {
                if (result.Success) {
                    callback(result.Result);
                } else {
                    alert("Fail to collect free animals: " + result.Message);
                }
            },
            error: function () {
                alert("Server error.");
            }
        });
}

function GetAdopters(callback) {
    $.ajax(
        {
            type: "GET",
            url: "/Adopters/GetAll",
            success: function (result) {
                callback(result.Result);
            },
            error: function () {
                alert("Fail on request.");
            }
        });
}
function AdoptClick() {
    var adopterId = $('#adopterSelect option:selected').val();
    var animalId = $('#animalSelect option:selected').val();

    Adopt(function (result) {
        GetAdoptions();
        GetFreeAnimals(function (result) {
            $(result).each(function () {
                animalSelect.append("<option value=" + this.ID + ">" + this.Name + "</option>");
            })
        });
        $('#addModal').modal('toggle');
        GetAdoptions();
        GetFreeAnimals(function (result) {
            CleanTable($("#animals-table-tr"));
            PopulateAnimalTable(result);
        });
    }, adopterId, animalId);

}

function Adopt(callback, adopterId, animalId) {
    $.ajax(
        {
            type: "POST",
            url: "/Adoptions/Adopt",
            data: { adopterId: adopterId, animalId: animalId },
            success: function (result) {
                if (result.Success) {
                    callback(result)
                } else {
                    alert("Fail to adopt: " + result.Message);
                }
            },
            error: function () {
                alert("Server error.");
            }
        });
}

function CleanTable(table) {
    table.find("tr").remove();
}

function PopulateAdoptionsTable(result) {
    $(result).each(function () {
        $("#adoptions-table-tr").append("<tr id=" + this.Animal.ID + "><td>" + this.Adopter.Name + "</td><td>" + this.Animal.Name + "</td><td class='buttonsColumn'><span class='glyphicon glyphicon-trash clickable' style='color:red;'onclick='RemoveAdoption(this)'/> </td></tr>");
    });
}

function PopulateAnimalTable(result) {
    $(result).each(function () {
        $("#animals-table-tr").append("<tr id=" + this.ID + "><td>" + this.Name + "</td><td>" + this.AnimalType + "</td><td>" + this.Weight + "</td><td>" + this.Age + "</td></tr>");
    });
}

function PopulateSelects() {
    var animalSelect = $("#animalSelect");
    var adopterSelect = $("#adopterSelect");

    animalSelect.find("option").remove();
    adopterSelect.find("option").remove();
    GetFreeAnimals(function (result) {
        $(result).each(function () {
            animalSelect.append("<option value=" + this.ID + ">" + this.Name + "</option>");
        })
    });
    GetAdopters(function (result) {
        $(result).each(function () {
            adopterSelect.append("<option value=" + this.ID + ">" + this.Name + "</option>");
        })
    });

}
