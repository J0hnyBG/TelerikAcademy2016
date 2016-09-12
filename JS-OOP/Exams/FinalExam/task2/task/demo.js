'use strict';

const result = require('./solution'),
    // helpers
    // toStringArmyUnit = t => `${t.alignment} ${t.name}(id: ${t.id}) - dmg: ${t.damage}, health: ${t.health}, speed: ${t.speed}, count: ${t.count}`,
    // toStringSpell = s => `${s.name} - cost: ${s.manaCost}`,
    MANAGER = result();

const mengsk = MANAGER.getCommander('Arcturus Mengsk', 'evil', 20),
    kerrigan = MANAGER.getCommander('Sarah Kerrigan', 'neutral', 50);


const spells = {
    psionicStorm: MANAGER.getSpell('Psionic Storm', 15, target => target.count -= ((target.health * target.count) - 400) / target.health),
    transfuse: MANAGER.getSpell('Transfuse', 10, target => target.health += 5)
}

MANAGER
    .addCommanders(mengsk, kerrigan)
    .addSpellsTo('Sarah Kerrigan', spells.psionicStorm, spells.transfuse)

expect(kerrigan.spellbook.length).to.equal(2)
expect(kerrigan.spellbook.some(s => s === spells.psionicStorm))
expect(kerrigan.spellbook.some(s => s === spells.transfuse))
expect(mengsk.spellbook.length).to.equal(0)
