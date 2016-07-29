function solve() {
    $.fn.datepicker = function () {
        var MONTH_NAMES = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
        var WEEK_DAY_NAMES = ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'];

        Date.prototype.getMonthName = function () {
            return MONTH_NAMES[this.getMonth()];
        };

        Date.prototype.getDayName = function () {
            return WEEK_DAY_NAMES[this.getDay()];
        };
		var $dateInput = $('#date');

        $dateInput.parent().append("<div class='datepicker-wrapper'><input type='text' id='date' class='datepicker'/></div>");
        $dateInput.remove();

        $dateInput = $('#date');
        var $datepickerWrapper = $('.datepicker-wrapper');
        $dateInput.on('click', showDatePicker);
        var $datepickerContent = $('<div></div>');
        $datepickerContent.addClass('datepicker-content');
        $datepickerContent.appendTo($datepickerWrapper);


        // you are welcome :)
		var date = new Date();
		console.log(date.getDayName());
		console.log(date.getMonthName());

        return $(this);

        function showDatePicker() {
            $datepickerContent.addClass('datepicker-content-visible');
        }
    };
};
