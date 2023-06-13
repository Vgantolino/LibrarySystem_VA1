(function ($) {

    var _bookCategoryService = abp.services.app.bookCategory,
        l = abp.localization.getSource('LibrarySystem_VA'),
        _$form = $('form[name=BookCategoryForm]');

    //Save
    _$form.find('.save-button').on('click', (e) => {
        e.preventDefault();
        BookCategorySave();
    });

    function BookCategorySave() {
        if (!_$form.valid()) {
            return;
        }

        var bookCategory = _$form.serializeFormToObject();
        bookCategory.DepartmentId = parseInt(bookCategory.DepartmentId);
        abp.ui.setBusy(_$form);

        if (bookCategory.Id != 0) { //update
            _bookCategoryService.update(bookCategory).done(function () {
                RedirectToIndex();
            }).always(function () {
                abp.ui.clearBusy(_$form);
            });

        }
        else { //create
            _bookCategoryService.create(bookCategory).done(function () {
                RedirectToIndex();
            }).always(function () {
                abp.ui.clearBusy(_$form);
            });
        }
    }

    //CANCEL
    _$form.find('.cancel-button').on('click', (e) => {
        e.preventDefault();
        RedirectToIndex();
    });

    function RedirectToIndex() {
        window.location.href = "/BookCategory";
    }

})(jQuery);