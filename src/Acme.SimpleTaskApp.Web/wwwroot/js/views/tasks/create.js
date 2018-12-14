(function($) {
    $(function () {
        $("#obSelect").append("<option value='2'>No</option>");
        $("#obSelect").append("<option value='Yes'>Yes</option>");
        $("#obSelect").val("0");
        var options = [{ text: "Yes", value: 1 }, { text: "No", value: 2 }];
        var $select = $("#exSelect").selectize({
            onChange: selectOnChange,
            create: true,
            options: options,
            createFilter: function (text) {
                var result = true;
                options.every(option => {
                    if (option.text == text) {
                        result = false;
                        return false;
                    }
                })
                return result;
            }
        });
        var selectize = $select[0].selectize;
        function selectOnChange() {
            var value = selectize.getValue();
            if (value.toString().indexOf("1") >= 0 || value.toString().indexOf("2") >= 0) {
                selectize.clearOptions();
                selectize.refreshOptions();
            } else {
                selectize.addOption(options);
            }
        };

        var _$form = $('#TaskCreationForm');

        _$form.find('input:first').focus();

        _$form.validate();

        _$form.find('button[type=submit]')
            .click(function (e) {
                e.preventDefault();

                if (!_$form.valid()) {
                    return;
                }

                var input = _$form.serializeFormToObject();
                abp.services.app.task.create(input)
                    .done(function () {
                        location.href = '/Tasks';
                    });
            });

    });
})(jQuery);