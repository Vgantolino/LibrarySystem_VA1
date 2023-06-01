(function ($) {

    var _departmentService = abp.services.app.department,
    l = abp.localization.getSource('LibrarySystem_VA');
    
    $(document).on('click', '.edit-dept', function () {
        var deptId = $(this).attr("data-dept-id");
        window.location.href = "/Departments/CreateOrEdit/" + deptId;

    });

    $(document).on('click', '.delete-dept', function () {
        var deptId = $(this).attr("data-dept-id");
        var deptName = $(this).attr("data-dept-name");

            abp.message.confirm(
                abp.utils.formatString(
                    l('AreYouSureWantToDelete'),
                    deptName),
                    '',
            function (isConfirmed) {
                if (isConfirmed) {
                    _departmentService.delete({ id: deptId }).done(function () {
                        window.location.href = "/Departments";
                    })
                }
            }
        );

    });

})(jQuery);