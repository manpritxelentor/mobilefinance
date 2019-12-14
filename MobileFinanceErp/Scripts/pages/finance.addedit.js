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
    var loanAmountElement = $("#LoanAmount").data("kendoNumericTextBox");
    var loanAmount = loanAmountElement.value();
    var downPaymentElement = $("#DownPayment").data("kendoNumericTextBox");
    var downPayment = downPaymentElement.value();
    var durationSelect = $("#DurationId").data("kendoDropDownList");
    var durationModel = durationSelect.dataItem()
    var interestSelect = $("#InterestRateId").data("kendoDropDownList");
    var interestModel = interestSelect.dataItem()

    var data = {
        loanAmount: loanAmount,
        downPayment: downPayment,
        duration: durationModel.Id != "" ? durationModel.Code : "",
        interest: interestModel.Id != "" ? interestModel.Code : "",
    }
    postAjaxData(calculateEmiUrl, data, function (response) {
        $("#EMI").val(response.EMI)
    }, function () {
        showError("Failed to calculate EMI. Please try again");
    });
}

function onDurationChange() {
    setEndDate();
}

function onStartDateChange() {
    setEndDate();
}

function setEndDate() {
    var durationSelect = $("#DurationId").data("kendoDropDownList");
    var durationModel = durationSelect.dataItem()
    var startDate = $("#StartDate").data("kendoDatePicker");
    var endDate = $("#EndDate").data("kendoDatePicker");
    if (durationModel.Id != "" && startDate.value() != null) {
        var date = new Date(startDate.value());
        date.setMonth(date.getMonth() + parseInt(durationModel.Code));
        endDate.value(date);
    } else {
        endDate.value(null);
    }
}