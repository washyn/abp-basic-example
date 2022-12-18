﻿(function ($) {

    abp.dom = abp.dom || {};

    abp.dom.initializers = abp.dom.initializers || {};
    
    abp.dom.initializers.initializeAutocompleteSelects = function ($autocompleteSelects) {
        if ($autocompleteSelects.length) {
            $autocompleteSelects.each(function () {
                var $select = $(this);
                var url = $(this).data("autocompleteApiUrl");
                var displayName = $(this).data("autocompleteDisplayProperty");
                var displayValue = $(this).data("autocompleteValueProperty");
                var itemsPropertyName = $(this).data("autocompleteItemsProperty");
                var filterParamName = $(this).data("autocompleteFilterParamName");
                var selectedText = $(this).data("autocompleteSelectedItemName");
                var name = $(this).attr("name");
                var selectedTextInputName = name.substring(0, name.length - 1) + "_Text]";
                var selectedTextInput = $('<input>', {
                    type: 'hidden',
                    id: selectedTextInputName,
                    name: selectedTextInputName,
                });
                if (selectedText != "") {
                    selectedTextInput.val(selectedText);
                }
                selectedTextInput.insertAfter($select);
                $select.select2({
                    ajax: {
                        url: url,
                        dataType: "json",
                        data: function (params) {
                            var query = {};
                            query[filterParamName] = params.term;
                            return query;
                        },
                        processResults: function (data) {
                            var retVal = [];
                            var items = data;
                            if (itemsPropertyName) {
                                items = data[itemsPropertyName];
                            }

                            items.forEach(function (item, index) {
                                retVal.push({
                                    id: item[displayValue],
                                    text: item[displayName]
                                })
                            });
                            return {
                                results: retVal
                            };
                        }
                    },
                    width: '100%',
                    theme: 'bootstrap4',
                });
                $select.on('select2:select', function (e) {
                    selectedTextInput.val(e.params.data.text);
                });
            });
        }
    }
    
    $(function () {
        abp.dom.initializers.initializeAutocompleteSelects($('.auto-complete-select'));
    });
})(jQuery);