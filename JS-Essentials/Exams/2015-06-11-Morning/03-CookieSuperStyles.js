function solve(args) {
    Array.prototype.clean = function (deleteValue) {
        for (var i = 0; i < this.length; i++) {
            if (this[i] == deleteValue) {
                this.splice(i, 1);
                i--;
            }
        }
        return this;
    };

    var lines = args.map(function (s) {
            return s.trim()
        }),
        selectors = {},
        props = [],
        selectorName = '',
        i;

    for (i = 0; i < lines.length; i++) {
        var line = lines[i];

        if (line[line.length - 1] === '{') {
            line = line.split('{');
            selectorName = minifySelector(line[0]);
        }
        else if (line[0] === '}') {
            if (selectors[selectorName]) {
                mergeSelectors(selectors[selectorName], props);
            }
            else {
                selectors[selectorName] = props.slice();
            }
            props = [];
        }
        else {
            props.push(parseProperty(line));
        }
    }
    var result = '';
    for (var sel in selectors) {
        if (selectors.hasOwnProperty(sel)) {
            selectors[sel] = removeRedundantProperties(selectors[sel]);
            result = result + sel + selectors[sel].join(';') + '}';
        }
    }
    console.log(result);
    
    function parseProperty(str) {
        return str.replace(/\s|;/g, '');
    }

    function mergeSelectors(sel, props) {
        for (var j = 0; j < props.length; j++) {
            if (sel.indexOf(props[j]) < 0) {
                sel.push(props[j]);
            }
        }
    }

    function removeRedundantProperties(propertiesArr) {
        for (var i = 0; i < propertiesArr.length; i++) {
            var propertyName = propertiesArr[i].split(':')[0];
            if(propertyName == '') {
                propertiesArr.splice(i, 1);
                continue;
            }
            for (var k = i+1; k < propertiesArr.length; k++) {
                var targetName = propertiesArr[k].split(':')[0];
                if (targetName === propertyName) {
                    propertiesArr.splice(i, 1);
                }
            }
        }
        return propertiesArr;
    }

    function minifySelector(str) {
        var between = '';
        str = str.split(' ');
        str.clean('');
        for (var i = 1; i < str.length; i++) {
            if (isLetter(str[i][0]) || isLetter(str[i - 1][str[i - 1].length - 1])) {
                between = ' ';
            }
            if (isSelectorCharOrLetter(str[i - 1][str[i - 1].length - 1]) || isSelectorCharOrLetter(str[i][0])) {
                between = ' ';
            }
            if(isSpecialChar(str[i][0]) || isSpecialChar(str[i - 1][str[i - 1].length - 1])) {
                between = '';
            }

            str[i] = between + str[i];
            between = '';
        }
        return str.join('') + '{';
    }
    function isLetter(str) {
        return str.length === 1 && str.match(/[a-z]/i);
    }
    function isSelectorCharOrLetter(str) {
        return str.length === 1 && str.match(/#|\./i) || isLetter(str);
    }
    function isSpecialChar(str) {
        return str.length === 1 && str.match(/\+|~|>/i);
    }
}

solve([
    '#the-big-b{',
    'color: yellow;',
    'size: big;',
    '}',
    '.muppet{',
    '    powers: all;',
    '    skin: fluffy;',
    '}',
    '.water-spirit         {',
    '    powers: water;',
    '    alignment    : not-good;',
    '}',
    'all{',
    '    meant-for: nerdy-children;',
    '}',
    '.muppet      {',
    '    powers: everything;',
    '}',
    'all            .muppet {',
    '    alignment             :             good                             ;',
    '}',
    '.muppet+             .water-spirit{',
    '    power: everything-a-muppet-can-do-and-water;',
    '}',
    'all            muppet   +      plus      sdasds{',
    '    alignment             :             good                             ;',
    '    alignment             :             terrible                             ;',
    '    why             :             not                             ;',
    '    ok             :             yes                             ;',

    '}',
    'all            muppet   +      plus >     sdasds   {',
    '    alignment             :             good                             ;',
    '    alignment             :             terrible                             ;',
    '    ok             :             not                             ;',
    '}'
]);

solve([
    'body  + #asd all {',
    '   padding-left:         11em          ;        ',
    'font-family: Georgia, "Times New Roman",   Times, serif;',
    'color: purple;',
    'background-color: #d8da3d ',
    '}',
    'ul.navbar {',
    '   position: absolute;',
    '  top: 2em;',
    'left: 1em;',
    'width: 9em ',
    '}',

    'ul.navbar {',
    '   position: relative;',
    '  top: 15em;',
    'left: 100000em;',
    '       width          :     9em           ' ,
    '           }',
    'h1 {',
    '   font-family: Helvetica, Geneva, Arial,          SunSans-Regular,      sans-serif ;    ',
    '  ',
    '}'
]);