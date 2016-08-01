function solve(params) {
    var selectors = {},
        selector = {priority: 0, properties: []},
        property = {priority: 0, value: "12px"},
        priority = 0,
        currentSelector = {priority: 0, properties: []},
        selectorName = '',
        inSelector = false,
        selectorPriority = 0;

    for (var i = 0; i < params.length; i++) {
        var line = params[i];
        line = line.replace(/\s\s+/gim, ' ');

        if (hasPriority(line) && inSelector) {
            currentPriority = +line.split('@')[1];
        }
        if (hasPriority(line) && !inSelector) {
            priority = +line.split('@')[1];
        }
        // console.log("Selector: " + priority + " Current: " + currentPriority);

        if (isSelector(line)) {
            selectorName = line.split('{')[0];
            inSelector = true;
            currentSelector = {priority: priority, properties: []};
        }
        if (isClosing(line)) {
            inSelector = false;

            if (!selectors[selectorName]) {
                selectors[selectorName] = currentSelector;
            }
            else {
                // selectors[selectorName] = mergeSelectors(selectors[selectorName], currentSelector);
            }
            currentSelector = {priority: priority, properties: []};

        }
        if (isPriority(line)) {
            selectorPriority = +line.split('@')[1];
        }
        if (isProperty(line) && inSelector) {
            var currentPriority;
            if (hasPriority(line)) {
                currentPriority = +line.split('@')[1];
            }
            var prop = line.split(':');
            var propertyName = prop[0].replace(/\s/g, '');
            var propertyValue = prop[1].split(';')[0].replace(/\s/g, '');

            if (currentSelector.properties.indexOf(propertyName) < 0) {
                // currentSelector[propertyName] = [];
                if (typeof (currentPriority) == 'undefined') {
                    currentPriority = 0;
                }
                currentSelector.properties.push( {priority: currentPriority, value: propertyValue, name:propertyName});
            }
            else {
                var indexOfProperty = currentSelector.properties.indexOf(propertyName);

                if (currentSelector.properties[indexOfProperty].priority < currentPriority) {
                    currentSelector.properties.splice(indexOfProperty, 1);

                    currentSelector.properties.push({priority: currentPriority, value: propertyValue});

                    // console.log(currentSelector[propertyName]);
                }
            }

            currentPriority = selectorPriority;


        }
    }
    console.log(selectors);


    function mergeSelectors(first, second) {
        if (first.priority != second.priority) {
            return first.priority > second.priority ? first : second;
        }
        else {
            return first;
        }
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

    function isSelector(line) {
        return line.indexOf('{') > -1;
    }

    function isClosing(line) {
        return line.indexOf('}') > -1;
    }

    function findPriority(line) {
        var indexOf = line.indexOf('@');
        if (indexOf > -1) {
            return +line.split('@')[1];

        }
    }
}
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