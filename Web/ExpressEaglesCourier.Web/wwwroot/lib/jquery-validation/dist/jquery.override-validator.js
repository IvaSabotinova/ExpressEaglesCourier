jQuery(function ($) {
    $.validator.AddMethod('number', function (value, element) {
        return this.optional(element) || /^(?:-?\d+)(?:(\.|,)\d+)?$/.test(value);
    })
});
