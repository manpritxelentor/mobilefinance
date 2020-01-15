function customerSaveSuccess(data) {
    if (data.Status == true) {
        if (data.IsSaveContinue == true) {
            window.location = financePageUrl + "?customerId=" + data.Id;
            return;
        } else {
            window.location = customerListPageUrl;
            return;
        }
    }
    showError('Failed to save customer. Please try again');
}

function customerSaveError(data) {
    showError('Failed to save customer. Please try again');
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