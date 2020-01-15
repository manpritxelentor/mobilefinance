function modelSaveSuccess(data) {
    if (data.Status == true) {
        window.location = brandListPageUrl;
        return;
    }
    showError('Failed to save model. Please try again');
}

function modelSaveError(data) {
    showError('Failed to save model. Please try again');
}