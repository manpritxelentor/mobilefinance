function guarantorSaveSuccess(data) {
    if (data.Status == true) {
        window.location = guarantorListPageUrl;
        return;
    }
    showError('Failed to save Guarantor. Please try again');
}

function brandSaveError(data) {
    showError('Failed to save Guarantor. Please try again');
}