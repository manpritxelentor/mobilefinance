﻿function financeSaveSuccess(data) {
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
        customerNameElement.val(customerModel.FirstName);
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
