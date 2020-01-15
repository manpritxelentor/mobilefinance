function financeSaveSuccess(data) {
    if (data.Status == true) {
        window.location = financeListPageUrl;
        return;
    }
    showError('Failed to save finance. Please try again');
}

function financeSaveError() {
    showError('Failed to save finance. Please try again');
}

function setCustomerMetaData() {
    var customerSelect = $("#CustomerId").data("kendoDropDownList");
    var customerModel = customerSelect.dataItem()

    var customerNameElement = $("#CustomerName");
    var customerMobileElement = $("#CustomerMobile");
    var customerAddressElement = $("#CustomerAddress");

    if (customerModel.Id != "") {
        customerNameElement.val(customerModel.FullName);
        customerMobileElement.val(customerModel.Mobile1);
        customerAddressElement.val(customerModel.Address);
    } else {
        customerNameElement.val("");
        customerMobileElement.val("");
        customerAddressElement.val("");
    }
}

function calculateEMI() {
    var emiElement = $("#EMI").data("kendoNumericTextBox");
    var loanAmountElement = $("#LoanAmount").data("kendoNumericTextBox");
    var loanAmount = loanAmountElement.value();
    var durationElement = $("#Duration").data("kendoNumericTextBox");
    var durationValue = durationElement.value();
    var emiValue = loanAmount / durationValue;
    if (emiValue > 0) {
        emiValue = Math.ceil(emiValue);
    } else {
        emiValue = 0;
    }
    emiElement.value(emiValue)
}

function recalculateLoanAmount() {
    var loanAmountElement = $("#LoanAmount").data("kendoNumericTextBox");
    var mobilePriceElement = $("#MobilePrice").data("kendoNumericTextBox");
    var mobilePrice = mobilePriceElement.value();
    var downPaymentElement = $("#DownPayment").data("kendoNumericTextBox");
    var downPayment = downPaymentElement.value();
    var loanAmount = mobilePrice - downPayment;
    loanAmountElement.value(loanAmount > 0 ? loanAmount : 0);
    calculateEMI();
}

function getBrandAddButton() {
    return "<button class='btn btn-block btn-link' onclick='openBrandPopup()'>Add Brand</button>"
}

function openBrandPopup() {
    openModal('Add New Brand', brandAddUrl);
}

function brandSaveSuccess(data) {
    if (data.Status == true) {
        closeModal();
        $('#FinanceBrandId').data("kendoDropDownList").dataSource.read()
        showSuccess('Brand saved successfully');
        return;
    }
    showError('Failed to save brand. Please try again');
}

function brandSaveError(data) {
    showError('Failed to save brand. Please try again');
}

function getModelAddButton() {
    return "<button class='btn btn-block btn-link' onclick='openModelPopup()'>Add Model</button>"
}

function openModelPopup() {
    openModal('Add New Model', modelAddUrl);
}

function modelSaveSuccess(data) {
    if (data.Status == true) {
        closeModal();
        $('#ModelId').data("kendoDropDownList").dataSource.read()
        showSuccess('Model saved successfully');
        return;
    }
    showError('Failed to save model. Please try again');
}

function modelSaveError(data) {
    showError('Failed to save model. Please try again');
}

function getGuarantorAddButton() {
    return "<button class='btn btn-block btn-link' onclick='openGuarantorPopup()'>Add Guarantor</button>"
}

function openGuarantorPopup() {
    openModal('Add New Guarantor', guarantorAddUrl);
}

function guarantorSaveSuccess(data) {
    if (data.Status == true) {
        closeModal();
        $('#Guarantor1').data("kendoDropDownList").dataSource.read()
        $('#Guarantor2').data("kendoDropDownList").dataSource.read()
        showSuccess('Guarantor saved successfully');
        return;
    }
    showError('Failed to save Guarantor. Please try again');
}

function guarantorSaveError(data) {
    showError('Failed to save guarantor. Please try again');
}