(function ($) {

    var _authorService = abp.services.app.author,
        l = abp.localization.getSource('LibrarySystem_VA'),
    _$form = $('form[name=searchAuthorsForm]');

    //Edit
    $(document).on('click', '.edit-author', function () {
        var authorId = $(this).attr("data-author-id");
        window.location.href = "/Authors/CreateOrEdit/" + authorId;
    });

    //Delete
    $(document).on('click', '.delete-author', function () {
        var authorId = $(this).attr("data-author-id");
        var authorName = $(this).attr("data-author-name");

        abp.message.confirm(
            abp.utils.formatString(
                l("AreYouSureWantToDelete"),
                authorName),
            '',
            function (isConfirmed) {
                if (isConfirmed) {
                    _authorService.delete({ id: authorId }).done(function () {
                        window.location.href = "/Authors";
                    })
                }
            }
        );
    });

    //Search
    _$form.find('.search-button').on('click', (e) => {
        window.location.href = "/Authors/Index";
    })

})(jQuery);