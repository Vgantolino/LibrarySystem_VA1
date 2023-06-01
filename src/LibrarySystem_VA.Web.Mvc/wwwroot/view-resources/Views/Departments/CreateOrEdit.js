(function ($) {

    var _departmentService = abp.services.app.department,
        l = abp.localization.getSource('LibrarySystem_VA'),
        _$form = $('form[name=DepartmentForm]');

    _$form.find('.save-button').on('click', (e) => {
        e.preventDefault();
        save();
    });

    function save() {
        if (!_$form.valid()) {
            return;
        }

        var department = _$form.serializeFormToObject();
        abp.ui.setBusy(_$form);

        if (department.Id != 0) { //update or edit
            _departmentService.update(department).done(function () {
                redirectToIndex();
            }).always(function () {
                abp.ui.clearBusy(_$form);
            });
            
        }
        else { //create
            _departmentService.create(department).done(function () {
                redirectToIndex();
            })

        }
    }

    _$form.find('.cancel-button').on('click', (e) => {
        redirectToIndex();

    });

    function redirectToIndex() {
        window.location.href = "/Departments";
    }

})(jQuery);