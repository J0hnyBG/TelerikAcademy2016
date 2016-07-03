function solve(params) {
    'use strict';
    var s = +params[0],
        numberOfLines = +params[s + 1],
        variables = {},
        jump,
    // sectionInnerHTML = '',
        sections = {},
        result = [];

    //Get key-value pairs
    for (var i = 0; i < s; i++) {
        var keyvalue = params[i + 1].split(':');
        variables[keyvalue[0]] = keyvalue[1];
    }
    // console.log(variables['marks']);
    for (var i = s + 2; i < params.length; i++) {
        var atIndex = params[i].indexOf('@');
        if(atIndex >= 0) {
            if(params[i].substr(atIndex).startsWith('@@')) {
                params[i] = params[i].replace('@@', '@');
                result.push(params[i]);
            }
            else if(params[i].substr(atIndex).startsWith('@section')) {
                var sectionName = params[i].substr(atIndex + 9).split(' ')[0];
                var sectionInnerHTML = "";
                while(true) {
                    i++;
                    if(params[i].indexOf('}') >= 0) {
                        sections[sectionName] = sectionInnerHTML;
                        break;
                    }
                    sectionInnerHTML += params[i] + "\n";
                }
            }
            else if(params[i].substr(atIndex).startsWith('@renderSection')) {
                var sectionName = params[i].substr(atIndex + 14).split(' ')[0].replace("\'", "").replace("\"", "").replace("(", "").replace(")", "").replace("\'", "").replace("\"", "");
                // console.log(sectionName);
                params[i] = sections[sectionName];
                result.push(params[i]);
            }
            else if(params[i].substr(atIndex).startsWith('@if')) {
                var variableName = params[i].substr(atIndex + 3).split(' ')[1].replace(')', "").replace('(', "");
                var condition = variables[variableName];
                if(condition === "true") {
                    while (true) {
                        var innerHTML = "";
                        i++;
                        atIndex = params[i].indexOf('@');
                        if(params[i].indexOf('}') >= 0) {
                            //dostuff
                            break;
                        }
                        if(params[i].substr(atIndex).startsWith('@@')) {
                            params[i] = params[i].replace('@@', '@');
                            innerHTML += params[i];
                        }
                        else {
                            result.push(innerHTML);
                        }

                    }
                }

                // result.push(params[i]);
            }
        }
        else if (params[i].indexOf('}') < 0){
            result.push(params[i])
        }

    }
    console.log(result.join('\n'));

}


var input = [
    '6',
    'title:Telerik Academy',
    'showSubtitle:true',
    'subTitle:Free training',
    'showMarks:false',
    'marks:3,4,5,6',
    'students:Pesho,Gosho,Ivan',
    '42',
    '@section menu {',
    '<ul id="menu">',
    '    <li>Home</li>',
    '    <li>About us</li>',
    '</ul>',
    '}',
    '@section footer {',
    '<footer>',
    '    Copyright Telerik Academy 2014',
    '</footer>',
    '}',
    '<!DOCTYPE html>',
    '<html>',
    '<head>',
    '    <title>Telerik Academy</title>',
    '</head>',
    '<body>',
    '    @renderSection("menu")',
    '',
    '    <h1>@title</h1>',
    '    @if (showSubtitle) {',
    '        <h2>@subTitle</h2>',
    '        <div>@@JustNormalTextWithDoubleKliomba ;)</div>',
    '    }',
    '',
    '    <ul>',
    '        @foreach (var student in students) {',
    '            <li>',
    '                @student ',
    '            </li>',
    '            <li>Multiline @title</li>',
    '        }',
    '    </ul>',
    '    @if (showMarks) {',
    '        <div>',
    '            @marks',
    '        </div>',
    '    }',
    '',
    '    @renderSection("footer")',
    '</body>',
    '</html>'
];
solve(input);