function createCalendar(selector, data) {

    const DaysOfWeek = {0: "Sun", 1:"Mon", 2: "Tue", 3: "Wed", 4: "Thu", 5: "Fri", 6: "Sat"};

    var rootElement = document.querySelector(selector),
        calendarDayElements = [];

    if(!rootElement) {
        throw new Error("No element matches with provided selector!");
    }

    data.sort(compareCalendarData);

    var calendarWrapper = document.createElement('div');
    calendarWrapper.className = 'calendar-wrapper';

    for(let i = 0; i < 30; i++) {
        var calendarDay = document.createElement('div');
        calendarDay.className = 'calendar-item';
        var dayOfWeek = i % 7;

        var itemHeader = document.createElement('span');
        itemHeader.className = 'calendar-item-header';
        itemHeader.innerHTML = DaysOfWeek[dayOfWeek] + ' ' + (i + 1) + ' June 2014';

        var itemBody = document.createElement('div');

        var dayTasks = data.filter(function(obj) {
            return +obj.date == (i + 1);
        });

        for (let j = 0; j < dayTasks.length; j++) {
            itemBody.innerHTML+= '<span title="duration: ' + dayTasks[j].duration +'">' + dayTasks[j].hour + ' ' + dayTasks[j].title + '</span><br>';
        }

        calendarDay.appendChild(itemHeader);
        calendarDay.appendChild(itemBody);
        calendarWrapper.appendChild(calendarDay);
        calendarDayElements.push(calendarDay);
    }

    var styles = document.createElement('style');
    styles.innerHTML =  '.calendar-wrapper { width: 90%; margin: 0 auto;}' +
                        '.calendar-item { border: 1px solid #000; display: inline-table; width: 14%; height: 150px;}' +
                        '.calendar-item-header {text-align: center; background-color: #c3c3c3; display: inline-block; width: 100%}' +
                        '.calendar-item:hover > .calendar-item-header {color:#fff; background-color: #333;}' +
                        '.calendar-item.active { background-color: #e3e3e3;}';

    document.body.appendChild(styles);
    rootElement.appendChild(calendarWrapper);

    calendarWrapper.addEventListener('click', function (ev) {
        if(ev.target.className.indexOf('calendar-item') >= 0 ) {
            for(let i = 0; i < calendarDayElements.length; i++) {
                calendarDayElements[i].className = 'calendar-item';
            }
            ev.target.className += ' active';
        }
    })
}

function compareCalendarData(a, b) {
    if (+a.date < +b.date)
    {
        return -1;
    }
    if (+a.date > +b.date)
    {
        return 1;
    }
    if(+a.date == +b.date) {
        if(a.hour < b.hour) {
            return -1;
        }
        if(a.hour > b.hour) {
            return 1
        }
    }
    return 0;
}

