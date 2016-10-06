/* globals dataService templates console Handlebars*/
let controllers = {
    home: () => {
        var cookies = {};
        dataService.cookies()
            .then((cookiesResponse) => {
                cookies = cookiesResponse;
                
                console.log(cookiesResponse);
                return templates.get('home');
            })
            .then(templateHtml => {
                var templateFunc = Handlebars.compile(templateHtml);
                var result = templateFunc(cookies);
                $('#container').html(result);
            })
    },
    myCookie: () => {
        console.log('myCookie');
    }
}