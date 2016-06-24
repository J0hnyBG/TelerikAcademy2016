function solve(args) {
    Array.prototype.remove = function(element) {
        var index = this.indexOf(element);
        while(this.indexOf(element) >= 0) {

            this.splice(index,1);
            index = this.indexOf(element);
        }
    };

    args.remove(args[0]);

    console.log(args.join('\n'));
}

solve( [ '1', '2', '3', '2', '1', '2', '3', '2' ]);
solve( [
    '_h/_',
    '^54F#',
    'V',
    '^54F#',
    'Z285',
    'kv?tc`',
    '^54F#',
    '_h/_',
    'Z285',
    '_h/_',
    'kv?tc`',
    'Z285',
    '^54F#',
    'Z285',
    'Z285',
    '_h/_',
    '^54F#',
    'kv?tc`',
    'kv?tc`',
    'Z285'
]);