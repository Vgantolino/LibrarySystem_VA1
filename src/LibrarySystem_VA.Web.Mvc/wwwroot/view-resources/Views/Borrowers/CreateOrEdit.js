(function ($) {

    var _borrowerService = abp.services.app.borrower,
        l = abp.localization.getSource('LibrarySystem_VA'),
        _$form = $('form[name=BorrowerForm]');

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

})(jQuery);