//todo: only zero test
function solve(args) {

    for (var i = 0; i < args.length; i++) {
        args[i] = args[i].replace(/<(?:.|\n)*?>/gm, '').replace(/\s\s/g, '');;

    }

    console.log(args.join(''));
}

solve([
    '<html>',
    '  <head>',
    '    <title>Sample site</title>',
    '  </head>',
    '  <body>',
    '    <div>text',
    '      <div>more text</div>',
    '      and more...',
    '    </div>',
    '    in body',
    '  </body>',
    '</html>'
]);