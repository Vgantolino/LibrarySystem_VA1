(function ($) {
    var _bookService = abp.services.app.book,
        l = abp.localization.getSource('LibrarySystem_VA')
    _$form = $('form[name=searchBookForm]');


    //Edit
    $(document).on('click', '.edit-book', function () {
        var bookId = $(this).attr("data-book-id");
        window.location.href = "/Books/CreateOrEdit/" + bookId;

    });

    //Delete
    $(document).on('click', '.delete-book', function () {
        var bookId = $(this).attr("data-book-id");
        var bookTitle = $(this).attr("data-book-title");

        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                bookTitle),
            '',
            function (isConfirmed) {
                if (isConfirmed) {
                    _bookService.delete({ id: bookId }).done(function () {
                        window.location.href = "/Books";
                    })
                }
            }
        );
    });

    //Search
    _$form.find('.search-button').on('click', (e) => {
        window.location.href = "/Books/Index";
    });

})(jQuery);
