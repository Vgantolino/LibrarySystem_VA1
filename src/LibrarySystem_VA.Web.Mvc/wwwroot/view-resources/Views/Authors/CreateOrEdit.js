(function ($) {

    var _authorService = abp.services.app.author,
        l = abp.localization.getSource('LibrarySystem_VA'),
        _$form = $('form[name=AuthorForm]');

    //Save
    _$form.find('.save-button').on('click', (e) => {
        e.preventDefault();
        SaveAuthor();
    });

    function SaveAuthor() {
        if (!_$form.valid()) {
            return;
        }

        var author = _$form.serializeFormToObject();
        abp.ui.setBusy(_$form);

        if (author.Id != 0) {
            _authorService.update(author).done(function () {
                RedirectToIndex();
            }).always(function () {
                abp.ui.clearBusy(_$form);
            });
        }
        else {
            _authorService.create(author).done(function () {
                RedirectToIndex();
            })
        }
    }

    //Cancel
    _$form.find('.cancel-button').on('click', (e) => {
        RedirectToIndex();
    });

    function RedirectToIndex() {
        window.location.href = "/Authors";
    }

})(jQuery);
