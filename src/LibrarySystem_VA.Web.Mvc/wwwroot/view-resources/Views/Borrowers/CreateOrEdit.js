(function ($) {

    var _borrowerService = abp.services.app.borrower,
        l = abp.localization.getSource('LibrarySystem_VA'),
        _$form = $('form[name=BorrowerForm]');
    var borrower = _$form.serializeFormToObject();

    //Set Borrow and Expected Date In Create
    if (borrower.Id == 0) {
        SetCurrentDate();
        SetExpectedDate();
    }

    //Display return date in edit mode
    if (borrower.Id != 0) {
        document.getElementById('hidden-panel').style.display = 'block'
    }
    else {
        document.getElementById('hidden-panel').style.display = 'none'
    }

    //Save
    _$form.find('.save-button').on('click', (e) => {
        e.preventDefault();
        BorrowerSave();
    });

    //CANCEL
    _$form.find('.cancel-button').on('click', (e) => {
        e.preventDefault();
        RedirectToIndex();
    });

    function BorrowerSave() {
        if (!_$form.valid()) {
            return;
        }

        var borrower = _$form.serializeFormToObject();
        abp.ui.setBusy(_$form);

        if (borrower.Id != 0) { //update
            _borrowerService.update(borrower).done(function () {
                RedirectToIndex();
            }).always(function () {
                abp.ui.clearBusy(_$form);
            });
        }
        else { //create
            _borrowerService.create(borrower).done(function () {
                RedirectToIndex();
            }).always(function () {
                abp.ui.clearBusy(_$form);
            });
        }
    }

    function RedirectToIndex() {
        window.location.href = "/Borrowers";
    }

    function SetCurrentDate() {
        var now = new Date();
        var day = ("0" + now.getDate()).slice(-2);
        var month = ("0" + (now.getMonth() + 1)).slice(-2);
        var today = now.getFullYear() + "-" + (month) + "-" + (day);

        document.getElementById('BorrowDate').value = today;
    }

    function SetExpectedDate(date, days) {
        var borrowDate = new Date(document.getElementById('BorrowDate').value).getDate() + 7;
        var borrowYear = new Date(document.getElementById('BorrowDate').value).getFullYear();
        var borrowMonth = new Date(document.getElementById('BorrowDate').value).getMonth();
        if (borrowMonth < 10) borrowMonth = "0" + borrowMonth;

        return document.getElementById('ExpectedReturnDate').value = borrowYear + "-" + borrowMonth + "-" + borrowDate;
    }

})(jQuery);