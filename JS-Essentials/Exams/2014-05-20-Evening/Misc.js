function solve(args) {
    var n = +args[0],
        result = [],
        model = [];

    for (var i = 0; i < n; i++) {
        var keyValuePair = args[i + 1].split('-');
        var key = keyValuePair[0];
        var value = keyValuePair[1];

        if (value == 'true') {
            value = true;
        }
        else if (value == 'false') {
            value = false;
        }
        else if (value.indexOf(';') > -1) {
            value = value.split(';');
        }
        model[key] = value;
    }

    var inModel = false;
    var currentModel = '';
    var modelOpenTag = '<nk-model>';
    var modelCloseTag = '</nk-model>';

    var escaped = false;
    var escapeOpen = '{{';
    var escapeClose = '}}';

    var inTemplate = false;
    var templateOpenTag = '<nk-template name="';
    var templateCloseTag = '</nk-template';
    var currentTemplateName = '';
    var currentTemplateContent = [];
    var allTemplates = {};

    var templateRenderingOpenTag = '<nk-template render="';
    var m = parseInt(args[n + 1]);
    var render = true;
    var skipnewLine = false;
    var ifOpenTag = '<nk-if condition="';
    var ifClosedTag = '</nk-if>';

    for (var j = n + 2; j < n + m + 2; j++) {
        var currentLine = args[j];
        if (currentLine == undefined) {
            currentLine = '';
        }

        if (inTemplate) {
            currentTemplateContent.push('\n');
        }
        for (var k = 0; k < currentLine.length; k++) {
            var currentSymbol = currentLine[k];

            //
            if (checkForCommand(currentLine, escapeOpen)) {
                escaped = true;
                k += escapeOpen.length - 1;
                continue;
            }
            //escape ends
            if (escaped && checkForCommand(currentLine, escapeClose)) {
                escaped = false;
                k += escapeClose.length - 1;
                continue;
            }
            // push escaped content to result
            if (escaped) {
                if (render) {
                    result.push(currentSymbol);

                }
                continue;
            }

            if(checkForCommand(currentLine, ifOpenTag)) {
                var condition = currentLine.split('"')[1];
                if(!model[condition]) {
                    render = false;
                }
                else {
                    skipnewLine = true;
                }

                break;
            }

            if(checkForCommand(currentLine, ifClosedTag)) {
                render = true;
                var lastIndexOfNewline = result.lastIndexOf('\n');
                if(lastIndexOfNewline > -1) {
                    result.splice(lastIndexOfNewline, 1);
                }
                skipnewLine = true;
                break;
            }

            if (checkForCommand(currentLine, templateRenderingOpenTag)) {
                var templateToRender = currentLine.split('"')[1];
                var templateContentToRender = allTemplates[templateToRender];
                if (render) {
                    result.push(templateContentToRender);
                }
                break;
            }
            //check if section is template
            if (checkForCommand(currentLine, templateOpenTag)) {
                inTemplate = true;
                currentTemplateName = currentLine.split('"')[1];
                break; //TODO: check for whitespaces
            }

            if (inTemplate && checkForCommand(currentLine, templateCloseTag)) {
                inTemplate = false;
                allTemplates[currentTemplateName] = currentTemplateContent.join('').trim();
                currentTemplateContent = [];
                currentTemplateName = '';
                break;
            }
            if (inTemplate) {
                if (render) {
                    currentTemplateContent.push(currentSymbol);
                }
                continue;
            }
            //check if model tag is opened
            if (checkForCommand(currentLine, modelOpenTag)) {
                inModel = true;
                k += modelOpenTag.length - 1;
                continue;
            }

            if (inModel && checkForCommand(currentLine, modelCloseTag)) {
                inModel = false;
                if (model[currentModel] && render) {
                    result.push(model[currentModel]);
                }
                currentModel = '';
                k += modelCloseTag.length - 1;
                continue;
            }
            if (inModel) {
                currentModel += currentSymbol;
                continue;
            }
            if (render) {
                result.push(currentSymbol)
            }
        }
        if(render && !skipnewLine) {
            skipnewLine = false;
            result.push('\n');
        }

        if(skipnewLine) {
            skipnewLine = false;
        }
    }
    console.log(result.join('').trim());

    function checkForCommand(currentLine, tag) {
        return currentLine.substr(k, tag.length) == tag;
    }
}


solve(['6',
    'title-Telerik Academy',
    'showSubtitle-true',
    'subTitle-Free training',
    'showMarks-false',
    'marks-3;4;5;6',
    'students-Ivan;Gosho;Pesho',
    '42',
    '<nk-template name="menu">',
    '    <ul id="menu">',
    '    <li>Home</li>',
    '    <li>About us</li>',
    '</ul>',
    '</nk-template>',
    '<nk-template name="footer">',
    '    <footer>',
    '    Copyright Telerik Academy 2014',
    '</footer>',
    '</nk-template>',
    '<!DOCTYPE html>',
    '<html>',
    '<head>',
    '<title>Telerik Academy</title>',
    '</head>',
    '<body>',
    '<nk-template render="menu" />',
    '',
    '    <h1><nk-model>title</nk-model></h1>',
    '    <nk-if condition="showSubtitle">',
    '    <h2><nk-model>subTitle</nk-model></h2>',
    '    <div>{{<nk-model>subTitle</nk-model>}} ;)</div>',
    '</nk-if>',
    '',
    '<ul>',
    '<nk-repeat for="student in students">',
    '    <li>',
    '    <nk-model>student</nk-model>',
    '    </li>',
    '    <li>Multiline <nk-model>title</nk-model></li>',
    '    </nk-repeat>',
    '    </ul>',
    '    <nk-if condition="showMarks">',
    '    <div>',
    '    <nk-model>marks</nk-model>',
    '    </div>',
    '    </nk-if>',
    '',
    '<nk-template render="footer" />',
    '    </body>',
    '    </html>'
]);