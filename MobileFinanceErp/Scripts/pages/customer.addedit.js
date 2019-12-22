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