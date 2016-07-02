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
        inSelector = false,
        selectors = {},
        props = [],
        selectorName = '',
        i;


    for (i = 0; i < lines.length; i++) {
        var line = lines[i];

        if (line[line.length - 1] === '{') {
            inSelector = true;
            line = line.split('{');
            selectorName = minifySelector(line[0]);
        }
        else if (line[0] === '}') {
            inSelector = false;
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
            result = result + sel + selectors[sel].join(';') + '}';
        }
    }
    console.log(result);


    function parseProperty(str) {
        return removeAllWhitespaceAndSemicolon(str);
    }

    function mergeSelectors(sel, props) {
        for (var j = 0; j < props.length; j++) {
            if (sel.indexOf(props[j]) < 0) {
                sel.push(props[j]);
            }
        }
    }

    function minifySelector(str) {
        str = str.split(' ');
        str.clean('');
        for (var i = 1; i < str.length; i++) {
            if (isLetter(str[i][0])) {
                str[i] = ' ' + str[i];
            }
        }
        return str.join('') + '{';
    }

    function isLetter(str) {
        return str.length === 1 && str.match(/[a-z]/i);
    }


    function removeAllWhitespaceAndSemicolon(str) {
        return str.replace(/ |;/g, '');
    }
}