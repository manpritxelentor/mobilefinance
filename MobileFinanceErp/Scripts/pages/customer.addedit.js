function customerSaveSuccess(data) {
    if (data.Status == true) {
        window.location = customerListPageUrl;
        return;
    }
    showError('Failed to save customer. Please try again');
}

function customerSaveError(data) {
    showError('Failed to save customer. Please try again');
}