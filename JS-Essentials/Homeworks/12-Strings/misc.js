function solve(args) {

    var match = args[0].match(/<a href=([^<]+)[^>]+>([^<]+)<\/a>/);

    while (match != null) {
        match[1] = match[1].replace('\"', '');
        args[0] = args[0].replace(match[0], '[' + match[2] + ']' + '(' + match[1] + ')');
        match = args[0].match(/<a href=([^<]+)[^>]+>([^<]+)<\/a>/);
    }
    console.log(args[0]);
}

solve(['<p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course. Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>']);