function solve() {
    $.fn.datepicker = function () {
        var MONTH_NAMES = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
        var WEEK_DAY_NAMES = ['Su', 'Mo', 'Tu', 'We', 'Th', 'Fr', 'Sa'];
        var date = new Date();

        Date.prototype.getMonthName = function () {
            return MONTH_NAMES[this.getMonth()];
        };

        Date.prototype.getDayName = function () {
            return WEEK_DAY_NAMES[this.getDay()];
        };

        Date.prototype.getNextDay = function () {
            if (this.getDate() < daysInMonth(this.getFullYear(), this.getMonth() + 1)) {
                return new Date(this.getFullYear(), this.getMonth(), this.getDate() + 1);
            } else if (this.getDate() === daysInMonth(this.getFullYear(), this.getUTCMonth() + 1)) {
                return this.getNextMonth();
            }
        };

        Date.prototype.getPreviousDay = function () {
            if (this.getDate() > 1) {
                return new Date(this.getFullYear(), this.getMonth(), this.getDate() - 1);
            } else {
                return this.getPreviousMonth();
            }
        };

        Date.prototype.getNextMonth = function () {
            if (this.getMonth() < 11) {
                return new Date(this.getFullYear(), this.getMonth() + 1, 1);
            } else {
                return this.getNextYear();
            }
        };

        Date.prototype.getPreviousMonth = function () {
            if (this.getMonth() > 0) {
                return new Date(this.getFullYear(), this.getMonth() - 1, daysInMonth(this.getFullYear(), this.getMonth()));
            } else {
                return this.getPreviousYear();
            }
        };

        Date.prototype.getNextYear = function () {
            return new Date(this.getFullYear() + 1, 0, 1);
        };

        Date.prototype.getPreviousYear = function () {
            return new Date(this.getFullYear() - 1, 11, 31);
        };

        //Month is 1 based
        function daysInMonth(year, month) {
            return new Date(year, month, 0).getDate();
        }

        var $input = $('#date');
        var year = new Date();
        $input.parent().append("<div class='datepicker-wrapper'><input type='text' id='date' class='datepicker'/></div>");
        $input.remove();

        $input = $('#date');
        var datepickerWrapper = $('.datepicker-wrapper');
        $input.on('click', showDatePicker);
        //Main container
        var datepickerContent = $('<div class="datepicker-content"></div>');
        datepickerContent.appendTo(datepickerWrapper);
        //ControlsUp
        var controlUp = $('<div class="controls"></div>');
        //Current Date
        var currentDate = $('<div class="current-date current-date-link"></div>');
        //controlsUp Current month
        var currentMonth = $('<div class="current-month"></div>');
        currentMonth.text(date.getMonthName() + ' ' + date.getFullYear());
        //Button left
        var navigationButtonLeft = $('<button class="btn btnLeft"></button>');
        navigationButtonLeft.text('<');

        //Button right
        var navigationButtonRight = $('<button class="btn btnRight"></button>');
        navigationButtonRight.text('>');

        //Append buttons and date
        navigationButtonLeft.appendTo(controlUp);
        currentMonth.appendTo(controlUp);
        navigationButtonRight.appendTo(controlUp);

        //Calendar
        var calendar = $('<div class="calendar"></div>');

        //Table
        var table = $('<table></table>');
        table.appendTo(calendar);

        controlUp.appendTo(datepickerContent);
        calendar.appendTo(datepickerContent);
        currentDate.appendTo(datepickerContent);
        //events
        $(".datepicker").on("click", function () {
            datepickerContent.addClass('datepicker-content-visible');
        });

        $(".btnRight").on("click", function () {
            year = year.getNextMonth();
            createTable(year.getFullYear(), year.getMonth());
            currentMonth.text(year.getMonthName() + ' ' + year.getFullYear());
        });


        $(".btnLeft").on("click", function () {
            year = year.getPreviousMonth();
            createTable(year.getFullYear(), year.getMonth());
            currentMonth.text(year.getMonthName() + ' ' + year.getFullYear());
        });

        $(".current-date").on("click", function (ev) {
            datepickerContent.removeClass('datepicker-content-visible');
            $input.val(new Date().getDate() + '/' + (new Date().getMonth() +1) + '/' + new Date().getFullYear());
        });

        createTable(year.getFullYear(), year.getMonth());
        currentDate.text(new Date().getDate() + ' ' + MONTH_NAMES[new Date().getMonth()] + ' ' + new Date().getFullYear());

        function createTable(yyear, month) {
            //add day names
            table.html('');
            var trDayNames = $('<tr></tr>');
            for (var i = 0; i < 7; i += 1) {
                $('<td></td>').text(WEEK_DAY_NAMES[i]).appendTo(trDayNames);
            }
            trDayNames.appendTo(table);
            var day = 1;
            var dateNow = new Date(yyear, month, day);

            do {
                dateNow = dateNow.getPreviousDay();
            } while (dateNow.getDayName() !== WEEK_DAY_NAMES[0]);

            for (var row = 0; row < 6; row += 1) {
                var trNow = $('<tr></tr>');
                for (var j = 0; j < 7; j += 1) {
                    var tdNow = $('<td></td>');
                    tdNow.text(dateNow.getDate());
                    if (dateNow.getMonth() === month) {
                        tdNow.addClass('current-month');
                    } else {
                        tdNow.addClass('another-month');
                    }
                    tdNow.appendTo(trNow);
                    dateNow = dateNow.getNextDay();
                }
                trNow.appendTo(table);
            }

            $("td.current-month").on("click", function (ev) {
                datepickerContent.removeClass('datepicker-content-visible');
                $input.val(ev.target.innerHTML + '/' + (year.getMonth()+1) + '/' + year.getFullYear());
            });
        }

        return $(this);

        function showDatePicker() {
            datepickerContent.addClass('datepicker-content-visible');
        }
    };
};
