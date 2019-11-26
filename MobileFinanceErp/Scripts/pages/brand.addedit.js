function brandSaveSuccess(data) {
    if (data.Status == true) {
        window.location = brandListPageUrl;
        return;
    }
    showError('Failed to save brand. Please try again');
}

function brandSaveError(data) {
    showError('Failed to save brand. Please try again');
}