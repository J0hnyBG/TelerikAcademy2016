function solve(args) {
    "use strict";
    var selectors = [];
    var current = {};
    var parentPriority = 0;
    var currPriority = 0;

    for (var i = 0; i < args.length; i++) {
        var line = args[i];
        if (isPriority(line)) {
            parentPriority = findPriority(line);
        }
        else if (hasPriority(line)) {
            currPriority = findPriority(line);
        }
        if (isSelector(line)) {
            line = line.trim();
            var selector = line.replace(/\s\s+/, " ").substr(0, line.length - 1).trim();
            // if (current) {

            selector = line.split('{')[0];
            // }
            selectors.push({
                "selector": selector,
                "priority": currPriority,
                "properties": []
            });

            current = selectors[selectors.length - 1];

        } else if (isProperty(line)) {
            var currentPriority;
            if (hasPriority(line)) {
                currentPriority = findPriority(line);

            }
            line = line.trim();
            line = line.substr(0, line.length - 1)
                .trim();

            var propertyValueArray = line.split(":").map(function (x) {
                return x.trim()
            });

            current.properties.push({
                "property": propertyValueArray[0],
                "value": propertyValueArray[1].split(';')[0],
                "priority": currentPriority ? currentPriority : parentPriority
            });
        }
        else {
            current = current.priority;
        }
    }
    selectors.every(function(sel) {

    });

    for (var selector in selectors) {
        for (var propertyValuePair in selectors[selector].properties) {
            console.log(selectors[selector].selector + '{' + selectors[selector].properties[propertyValuePair].property + ": " + selectors[selector].properties[propertyValuePair].value + ' }');

        }
    }
    // console.log(selectors);

    function isSelector(line) {
        return 0 <= line.indexOf("{");
    }

    function isPriority(line) {
        return line.indexOf('@') == 0;
    }

    function hasPriority(line) {
        return line.indexOf('@') > -1;
    }

    function isProperty(line) {
        return line.indexOf(':') > -1;

    }

    function isPropertyValue(line) {
        return 0 <= line.indexOf(":");
    }
}
//
//     function isSelector(line) {
//         return line.indexOf('{') > -1;
//     }
//
//     function isClosing(line) {
//         return line.indexOf('}') > -1;
//     }
//
function findPriority(line) {
    var indexOf = line.indexOf('@');
    if (indexOf > -1) {
        return +line.split('@')[1];
    }
}
// }

solve([
    'li {',
    '    font-size: 2px;',
    '    font-weight: bold;',
    '}',
    'div {',
    '    font-size: 20px; @5',
    '}',
    'div { @4',
    '    font-size: 17px;',
    '}',
    '@19',
    'li {',
    '    font-size: 42px;',
    '    color: red; @9',
    '}'
]);
// solve([
//     'enthusiasm { @5',
//     '  ap-percept-ion:buying;',
//     '  @2',
//     '  houston:pZ!X;',
//     '  chute-s:accelerometers;',
//     '}',
//     '@9',
//     'molar { @6',
//     '  @15',
//     '  houston:E!NVDt; @7',
//     '  houston:u#It#;',
//     '  ap-percept-ion:Dog; @15',
//     '  chute-s:advises;',
//     '}',
//     'oodles {',
//     '  @13',
//     '  chute-s:perish;',
//     '}',
//     'molar {',
//     '  r-ega-rding:4lXPE;',
//     '  r-ega-rding:digesting;',
//     '  houston:xZAEIh#S;',
//     '  chute-s:benched;',
//     '  @3',
//     '  ap-percept-ion:gssO%FDd;',
//     '}',
//     'enthusiasm { @15',
//     '  houston:NkR99XZ;',
//     '  ap-percept-ion:aPQG;',
//     '}'
// ]);