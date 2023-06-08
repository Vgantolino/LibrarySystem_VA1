(function ($) {
    var _borrowerService = abp.services.app.borrower,
        l = abp.localization.getSource('LibrarySystem_VA'),
        _$form = $('form[name=BorrowerForm]');

    //public
    var date = new Date();
    var day = date.getDate();
    var month = date.getMonth() + 1;
    var year = date.getFullYear();

    if (month.length < 2) month = "0" + month;
    if (day.length < 2) day = "0" + day;

    //Call on-load
    SetCurrentDate();
    SetExpectedReturnDate();

    //Set Current Date
    function SetCurrentDate() {    
        var today = year + "-" + month + "-" + day;
        return document.getElementById('DateBorrow').value = today;
    }    

    //Set Expected Return Date
    function SetExpectedReturnDate() {
        var borrowDate = new Date(document.getElementById('DateBorrow').value).getDate()+7;
        /*var addDays = 7;*/
        //var newBorrowDate = new Date(AddDaysToDate(GetFormattedString(borrowDate), addDays));
        //var newBorrowDate = new Date(borrowDate).setDate(new Date().getDate()+7);
        var expectedDate = year + "-" + month + "-" + borrowDate;

        return document.getElementById('ExpectedDate').value = expectedDate;
    }

    ////format date
    //function GetFormattedString(date) {
    //    return ('0' + date.getDate()).toString().slice(-2) + "/" + ('0' + (date.getMonth() + 1)).toString().slice(-2) + "/" + date.getFullYear();
    //}

    ////Add days to date
    //function AddDaysToDate(currentDate, daysToAdd) {
    //    var currentDate = new Date(currentDate);
    //    if (daysToAdd != 0) {
    //        currentDate.setDate(currentDate.getDate() + parseInt(daysToAdd));
    //    }
    //    return currentDate;
    //}

    //Save
    function SaveBorrowers() {

        if (!_$form.valid()) {
            return;
        }

        var borrower = _$form.serializeFormToObject();
        abp.ui.setBusy(_$form);

        if (borrower.Id != 0) {
            _borrowerService.update(borrower).done(function () {
                RedirectToIndex();
            }).always(function () {
                abp.ui.clearBusy(_$form);
            });
        }
        else {
            _borrowerService.create(borrower).done(function () {
                RedirectToIndex();
            }).always(function () {
                abp.ui.clearBusy(_$form);
            })
        }
    }

    //Return to Index Page
    function RedirectToIndex() {
        window.location.href = "/Borrowers";
    }

    //BorrowDate On-Click
    $('input').on('change', function () {
        SetExpectedReturnDate();
    });    

    //SAVE
    _$form.find('.save-button').on('click', (e) => {
        e.preventDefault();
        SaveBorrowers();
    });

    //CANCEL
    _$form.find('.cancel-button').on('click', (e) => {
        e.preventDefault();
        RedirectToIndex();
    });

})(jQuery);