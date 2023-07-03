(function ($) {

    var _bookCategoryService = abp.services.app.bookCategory,
        l = abp.localization.getSource('LibrarySystem_VA'),
        _$form = $('form[name=BookCategoryForm]');

    //Save
    _$form.find('.save-button').on('click', (e) => {
        e.preventDefault();
        BookCategorySave();
    });

    //Cancel
    _$form.find('.cancel-button').on('click', (e) => {
        e.preventDefault();
        RedirectToIndex();
    });

    function BookCategorySave() {
        if (!_$form.valid()) {
            return;
        }

        var bookCategory = _$form.serializeFormToObject();
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

    function RedirectToIndex() {
        window.location.href = "/BookCategories";
    }

})(jQuery);