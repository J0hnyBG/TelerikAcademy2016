function solve(params) {
    var Selector = function(name, content) {
        this.name = name;
        this.content = content;
    };

    Selector.create = function(name, content) {
        return new Selector(name, content);
    };

    // Selector.prototype = {};

    var sel = Selector.create("asd", "content");
    console.log(sel.name);
    console.log(sel.content);

    // for (var i = 0; i < 10000; i++) {
    //     console.log(Math.floor(Math.random() * 100));
    // }
}
solve([
'#the-big-b{',
'    color: big-yellow;',
'.little-bs {',
'        color: little-yellow;',
'        $.male            {',
'            color: middle-yellow;',
'        }',
'    }',
'}',
'.muppet           {',
'    skin        :        fluffy;',
'    $.water-spirit    {',
'        powers    :     water;',
'    }',
'    $>thread{',
'        color: depends;',
'    }',
'    powers    :      all-muppet-powers;',
'}'
]);
console.log('==================');
