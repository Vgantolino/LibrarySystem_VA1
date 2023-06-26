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

    function SetExpectedDate() {
        var currentDate = new Date();
        currentDate.setDate(currentDate.getDate() + 7);

        var newExpectedDate = currentDate.getFullYear() + "-" +
                              ('0' + (currentDate.getMonth() + 1)).slice(-2) + "-" +
                              ('0' + currentDate.getDate()).slice(-2);

        //var newExpectedDate = ('0' + newDate).slice(-2) + '/' +
        //                      ('0' + (currentDate.getMonth() + 1)).slice(-2) + '/' +
        //                      currentDate.getFullYear();

        document.getElementById('ExpectedReturnDate').value = newExpectedDate;
    }

})(jQuery);