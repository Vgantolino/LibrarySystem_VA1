(function ($) {

    var _authorService = abp.services.app.author,
        l = abp.localization.getSource('LibrarySystem_VA'),
        _$form = $('form[name=searchAuthorsForm]');
        _$table = $('#AuthorsTable');

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

    //Index Page
    var _$authorsTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        listAction: {
            ajaxFunction: _authorService.getAll,
            inputFilter: function () {
                return $('#searchAuthorsForm').serializeFormToObject(true);
            }
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-redo-alt"></i>',
                action: () => _$authorsTable.draw(false)
            }
        ],
        responsive: {
            details: {
                type: 'column'
            }
        },
        columnDefs: [
            {
                targets: 0,
                data: 'id',
                defaultContent: '',
            },
            {
                targets: 1,
                data: 'name',
                sortable: false
            },
            {
                targets: 2,
                data: null,
                sortable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    return [
                        `   <button type="button" class="btn btn-sm bg-secondary edit-author" data-author-id="${row.id}">`,
                        `       <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm bg-danger delete-author" data-author-id="${row.id}" data-author-name="${row.name}">`,
                        `       <i class="fas fa-trash"></i> ${l('Delete')}`,
                        '   </button>'
                    ].join('');
                }
            }
        ]
    });



    
})(jQuery);