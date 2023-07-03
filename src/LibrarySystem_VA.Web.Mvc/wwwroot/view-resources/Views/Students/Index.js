(function ($) {

    var _studentService = abp.services.app.student,
        l = abp.localization.getSource('LibrarySystem_VA');

    //Edit
    $(document).on('click', '.edit-student', function () {
        var studentId = $(this).attr("data-student-id");
        window.location.href = "/Students/CreateOrEdit/" + studentId;
    });

    //Delete
    $(document).on('click', '.delete-student', function () {
        var StudentId = $(this).attr("data-student-id");
        var StudentName = $(this).attr("data-student-name");

        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                StudentName),
                '',
            function (isConfirmed) {
                if (isConfirmed) {
                    _studentService.delete({ id: StudentId }).done(function () {
                        window.location.href = "/Students";
                    })
                }
            }
        );
    });

})(jQuery);