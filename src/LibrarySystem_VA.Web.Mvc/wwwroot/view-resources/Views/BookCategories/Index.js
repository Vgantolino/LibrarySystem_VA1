(function ($) {

    var _bookCategoryService = abp.services.app.bookCategory,
        l = abp.localization.getSource('LibrarySystem_VA');

    //Edit
    $(document).on('click', '.edit-bookCategory', function () {
        var bookCategoryId = $(this).attr("data-bookCategory-id");
        window.location.href = "/BookCategories/CreateOrEdit/" + bookCategoryId;

    });

    //Delete
    $(document).on('click', '.delete-bookCategory', function () {
        var bookCategoryId = $(this).attr("data-bookCategory-id");
        var bookCategoryName = $(this).attr("data-bookCategory-name");

        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                bookCategoryName),
            '',
            function (isConfirmed) {
                if (isConfirmed) {
                    _bookCategoryService.delete({ id: bookCategoryId }).done(function () {
                        window.location.href = "/BookCategories";
                    })
                }
            }
        );
    });

})(jQuery);