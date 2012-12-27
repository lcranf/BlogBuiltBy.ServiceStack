(function($) {

    /* Twitter.Bootstrap required for this plugin to work
     *
     * - alertType  - 
     * - fade       - true or false to fade out on close
     * - autoClose  - true to close
     * - message    - alert message (required)
     */
    $.fn.alertMessage = function (options) {

        var settings = $.extend({
            fade: false,
            autoClose: false
        }, options);

        return this.each(function () {
            var alertContainer = $("<div></div>");

            alertContainer.addClass("alert alert-block");

            if (settings.fade) {
                alertContainer.addClass("fade in");
            }

            if (settings.alertType != 'undefined') {
                alertContainer.addClass(settings.alertType);
            }
            
            if (settings.autoClose) {
                alertContainer.append("<button type='button' class='close' data-dismiss='alert'>&times;</button>");
            }

            $("<p></p>").html(settings.message).appendTo(alertContainer);

            $(this).append(alertContainer);
        });
    };

})(jQuery);