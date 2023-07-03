(function ($) {
    var _borrowerService = abp.services.app.borrower;
    var _bookService = abp.services.app.book;
    l = abp.localization.getSource('LibrarySystem_VA')
    _$form = $('form[name=searchBorrowerForm]');
    _$table = $('#BorrowersTable');
    

    //Edit
    $(document).on('click', '.edit-borrower', function () {
        var borrowerId = $(this).attr("data-borrower-id");
        window.location.href = "/Borrowers/CreateOrEdit/" + borrowerId;
    });

    //Delete
    $(document).on('click', '.delete-borrower', function () {
        var borrowerId = $(this).attr("data-borrower-id");
        var borrowerName = $(this).attr("data-borrower-name");
        var bookId = $(this).attr('data-book-id');

        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                borrowerName),
            '',
            function (isConfirmed) {
                if (isConfirmed) {                    
                    _borrowerService.delete({
                        id: borrowerId
                    }).done(function () {
                        _bookService.updateIsBorrowedIfDeletedInBorrowers({ id: bookId });
                        window.location.href = "/Borrowers";
                    })
                    
                }
            }
        );
    });

    //Search
    _$form.find('.search-button').on('click', (e) => {
        window.location.href = "/Borrowers/Index";
    });



})(jQuery);