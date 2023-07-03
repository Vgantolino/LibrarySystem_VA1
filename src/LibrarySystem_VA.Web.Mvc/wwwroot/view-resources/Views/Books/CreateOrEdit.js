(function ($) {
    var _bookService = abp.services.app.book,
        l = abp.localization.getSource('LibrarySystem_VA'),
        _$form = $('form[name=BookForm]');

    //Save
    _$form.find('.save-button').on('click', (e) => {
        e.preventDefault();
        BookSave();
    });

    //Cancel
    _$form.find('.cancel-button').on('click', (e) => {
        e.preventDefault();
        RedirectToIndex();
    });

    function BookSave() {
        if (!_$form.valid()) {
            return;
        }

        var book = _$form.serializeFormToObject();
        abp.ui.setBusy(_$form);

        if (book.Id != 0) { //update or edit
            _bookService.update(book).done(function () {
                RedirectToIndex();
            }).always(function () {
                abp.ui.clearBusy(_$form);
            });
        }
        else {
            _bookService.create(book).done(function () {
                RedirectToIndex();
            }).always(function () {
                abp.ui.clearBusy(_$form);
            })
        }
    }    

    //Return to Index Page
    function RedirectToIndex() {
        window.location.href = "/Books";
    }

})(jQuery);