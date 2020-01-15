function guarantorSaveSuccess(data) {
    if (data.Status == true) {
        window.location = guarantorListPageUrl;
        return;
    }
    showError('Failed to save Guarantor. Please try again');
}

function guarantorSaveError(data) {
    showError('Failed to save Guarantor. Please try again');
}

function addUpdateCity() {
    return "<button class='btn btn-block btn-link' onclick='openCityPopup()'>Add / Edit City</button>"
}

function openCityPopup() {
    openModal('Add / Update City', addCityUrl);
}

function groupCodeSavedHandler(groupCode) {
    switch (groupCode) {
        case 'City':
            $("#CityId").data("kendoDropDownList").dataSource.read();
            break;
    }
}