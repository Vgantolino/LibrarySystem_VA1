(function ($) {
    var _borrowerService = abp.services.app.borrower,
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

        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                borrowerName),
            '',
            function (isConfirmed) {
                if (isConfirmed) {
                    _borrowerService.delete({ id: borrowerId }).done(function () {
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