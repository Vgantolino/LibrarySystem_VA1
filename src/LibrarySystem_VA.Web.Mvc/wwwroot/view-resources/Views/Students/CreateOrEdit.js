(function ($) {

    var _studentService = abp.services.app.student,
        l = abp.localization.getSource('LibrarySystem_VA'),
        _$form = $('form[name=StudentForm]');


    //Save
    _$form.find('.save-button').on('click', (e) => {
        e.preventDefault();
        studentSave();
    });

    //Cancel
    _$form.find('.cancel-button').on('click', (e) => {
        e.preventDefault();
        redirectToIndex();
    });

    function studentSave() {
        if (!_$form.valid()) {
            return;
        }
        
        var student = _$form.serializeFormToObject();
        abp.ui.setBusy(_$form);

        if (student.Id != 0) { //update or edit
            _studentService.update(student).done(function () {
                redirectToIndex();
            }).always(function () {
                abp.ui.clearBusy(_$form);
            });

        }
        else { //create
            _studentService.create(student).done(function () {
                redirectToIndex();
            })
        }
    }

    function redirectToIndex() {
        window.location.href = "/Students";
    }


})(jQuery);