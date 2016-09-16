function solve() {
    'use strict';

    const ERROR_MESSAGES = {
        INVALID_NAME_TYPE: 'Name must be string!',
        INVALID_NAME_LENGTH: 'Name must be between between 2 and 20 symbols long!',
        INVALID_NAME_SYMBOLS: 'Name can contain only latin symbols and whitespaces!',
        INVALID_MANA: 'Mana must be a positive integer number!',
        INVALID_EFFECT: 'Effect must be a function with 1 parameter!',
        INVALID_DAMAGE: 'Damage must be a positive number that is at most 100!',
        INVALID_HEALTH: 'Health must be a positive number that is at most 200!',
        INVALID_SPEED: 'Speed must be a positive number that is at most 1`00!',
        INVALID_COUNT: 'Count must be a positive integer number!',
        INVALID_SPELL_OBJECT: 'Passed objects must be Spell-like objects!',
        NOT_ENOUGH_MANA: 'Not enough mana!',
        TARGET_NOT_FOUND: 'Target not found!',
        INVALID_BATTLE_PARTICIPANT: 'Battle participants must be ArmyUnit-like!',
        INVALID_ALIGNMENT: 'Alignment must be good, neutral or evil!'
    };

    // your implementation goes here
    const battlemanager = (function () {
        let idGenerator = (function () {
            let currentId = 0;

            function getNext() {
                currentId++;
                return currentId;
            }

            return {
                getNext
            }
        })();
        let IsValid = (function () {
            function isInRange(value, min, max) {
                return min < value && value < max;
            }

            function Name(name) {
                if (typeof name !== 'string') {
                    throw new Error(ERROR_MESSAGES.INVALID_NAME_TYPE);
                }

                if (name.length < 2 || 20 < name.length) {
                    throw new Error(ERROR_MESSAGES.INVALID_NAME_LENGTH);
                }

                if (!name.match(/^[a-zA-Z ]+$/)) {
                    throw new Error(ERROR_MESSAGES.INVALID_NAME_SYMBOLS);
                }
            }

            function Alignment(alignment) {
                if (alignment == null || alignment !== 'good' && alignment !== 'neutral' && alignment !== 'evil') {
                    throw new Error(ERROR_MESSAGES.INVALID_ALIGNMENT);
                }
            }

            function Damage(damage) {
                if (isNaN(damage) || !isInRange(damage, 0, 100)) {
                    throw new Error(ERROR_MESSAGES.INVALID_DAMAGE);
                }
            }

            function Health(health) {
                if (isNaN(health) || !isInRange(health, 0, 200)) {
                    throw new Error(ERROR_MESSAGES.INVALID_DAMAGE);
                }
            }

            function Count(count) {
                if (!isInRange(count, -1, Infinity)) {
                    throw new Error(ERROR_MESSAGES.INVALID_COUNT);
                }
            }

            function Speed(speed) {
                if (!isInRange(speed, 0, 100)) {
                    throw new Error(ERROR_MESSAGES.INVALID_SPEED);
                }
            }

            function Mana(mana) {
                if (isNaN(mana) || mana < 0) {
                    throw new Error(ERROR_MESSAGES.INVALID_MANA);
                }
            }

            function SpellEffect(effect) {
                if (!(effect instanceof Function) || effect.length != 1) {
                    throw new Error(ERROR_MESSAGES.INVALID_EFFECT);
                }
            }

            function Unit(unit) {
                IsValid.Health(unit.health);
                IsValid.Damage(unit.damage);
                IsValid.Count(unit.count);
            }

            return {
                Name,
                Alignment,
                Damage,
                Health,
                Speed,
                Mana,
                SpellEffect,
                Count,
                Unit
            }
        })();

        class Spell {
            constructor(name, manaCost, effect) {
                this.name = name;
                this.manaCost = manaCost;
                this.effect = effect;
            }

            set name(value) {
                IsValid.Name(value);
                this._name = value;
            }

            get name() {
                return this._name;
            }

            set manaCost(value) {
                IsValid.Mana(value);
                this._manaCost = value;
            }

            get manaCost() {
                return this._manaCost;
            }

            set effect(value) {
                IsValid.SpellEffect(value);
                this._effect = value;
            }

            get effect() {
                return this._effect;
            }
        }

        class Unit {
            constructor(name, alignment) {
                this.name = name;
                this.alignment = alignment;
            }

            set name(value) {
                IsValid.Name(value);
                this._name = value;
            }

            get name() {
                return this._name;
            }

            set alignment(value) {
                IsValid.Alignment(value);
                this._alignment = value;
            }

            get alignment() {
                return this._alignment;
            }
        }

        class ArmyUnit extends Unit {
            constructor(name, alignment, damage, health, count, speed) {
                super(name, alignment);
                this._id = idGenerator.getNext();
                this.damage = damage;
                this.health = health;
                this.count = count;
                this.speed = speed;
            }

            get id() {
                return this._id;
            }

            set damage(value) {
                IsValid.Damage(value);
                this._damage = value;
            }

            get damage() {
                return this._damage;
            }

            set health(value) {
                IsValid.Health(value);
                this._health = value;
            }

            get health() {
                return this._health;
            }

            set count(value) {
                IsValid.Count(value);
                this._count = value;
            }

            get count() {
                return this._count;
            }

            set speed(value) {
                IsValid.Speed(value);
                this._speed = value;
            }

            get speed() {
                return this._speed;
            }
        }

        class Commander extends Unit {
            constructor(name, alignment, mana) {
                super(name, alignment);
                this.mana = mana;
                this.spellbook = [];
                this.army = [];
            }

            set mana(value) {
                IsValid.Mana(value);
                this._mana = value;
            }

            get mana() {
                return this._mana;
            }

            set spellbook(value) {
                value.forEach((x) => {
                    if (!(x instanceof Spell)) {
                        throw new Error(ERROR_MESSAGES.INVALID_SPELL_OBJECT);
                    }
                });

                this._spellbook = value;
            }

            get spellbook() {
                return this._spellbook;
            }

            set army(value) {
                value.forEach((x) => {
                    if (!(x instanceof Unit)) {
                        throw new Error(ERROR_MESSAGES.INVALID_BATTLE_PARTICIPANT);
                    }
                });

                this._army = value;
            }

            get army() {
                return this._army;
            }
        }

        class BattleManager {
            constructor() {
                this.commanders = [];
            }

            set commanders(value) {
                this._commanders = value;
            }

            get commanders() {
                return this._commanders;
            }

            getCommander(name, alignment, mana) {
                return new Commander(name, alignment, mana);
            }

            getArmyUnit(options) {
                return new ArmyUnit(options.name, options.alignment, options.damage, options.health, options.count, options.speed);
            }

            getSpell(name, manaCost, effect) {
                return new Spell(name, manaCost, effect);
            }

            addCommanders(...commanders) {
                commanders.forEach(x => this.commanders.push(x));
                return this;
            }

            addArmyUnitTo(commanderName, armyUnit) {
                let commander = this.commanders.filter(x => x.name === commanderName);
                commander[0].army.push(armyUnit);
                return this;
            }

            addSpellsTo(commanderName, ...spells) {
                spells.forEach(x => {
                    try {
                        IsValid.Mana(x.manaCost);
                        IsValid.Name(x.name);
                        IsValid.SpellEffect(x.effect);
                    }
                    catch (ex) {
                        throw new Error(ERROR_MESSAGES.INVALID_SPELL_OBJECT);

                    }

                    if (!(x instanceof Spell)) {
                        throw new Error(ERROR_MESSAGES.INVALID_SPELL_OBJECT);
                    }
                });

                let commander = this.commanders.filter(x => x.name === commanderName);
                commander[0].spellbook.push(...spells);
                return this;
            }

            findCommanders(options) {
                let result = this.commanders.filter(function (item) {
                    return Object.keys(options).every(function (prop) {
                        return options[prop] === item[prop];
                    });
                });

                return result.sort((a, b) => a > b);
            }

            findArmyUnitById(id) {
                let result = [];
                this.commanders.forEach(commander => {
                    commander.army.forEach(unit => {
                        if (unit.id === id) {
                            result.push(unit);
                        }
                    });
                });

                if (result.length === 0) {
                    return undefined;
                }
                return result[0];
            }

            findArmyUnits(query) {
                let result = [];
                this.commanders.forEach(x => {
                    let soldiers = x.army.filter(y => {
                        return Object.keys(query).every(function (prop) {
                            return query[prop] === y[prop];
                        })
                    });

                    soldiers.forEach(x => result.push(x));
                });

                return result.sort(sortBySpeedAndName);
            }

            spellcast(casterName, spellName, targetUnitId) {
                let caster = this.commanders.filter(x => x.name === casterName);
                if (caster.length === 0) {
                    throw new Error("Can\'t cast with non-existant commander " + casterName + "!")
                }

                caster = caster[0];

                let spell = caster.spellbook.filter(x => x.name === spellName);
                if (spell.length === 0) {
                    throw new Error(casterName + " doesn\'t know " + spellName)
                }

                spell = spell[0];
                if (spell.manaCost > caster.mana) {
                    throw new Error(ERROR_MESSAGES.NOT_ENOUGH_MANA)
                }

                let unit = this.findArmyUnitById(targetUnitId);
                if (!unit) {
                    throw new Error(ERROR_MESSAGES.TARGET_NOT_FOUND)
                }

                spell.effect(unit);
                caster.mana -= spell.manaCost;
            }

            battle(attacker, defender) {
                try {
                    IsValid.Unit(attacker);
                    IsValid.Unit(defender);
                }
                catch (ex) {
                    throw new Error(ERROR_MESSAGES.INVALID_BATTLE_PARTICIPANT);
                }

                let attackerTotalDamage = attacker.count * attacker.damage;
                let defenderTotalHealth = defender.health * defender.count;

                defenderTotalHealth -= attackerTotalDamage;
                if (defenderTotalHealth <= 0) {
                    defender.count = 0;
                    return this;
                }

                defender.count = Math.ceil(defenderTotalHealth / defender.health);
                return this;
            }
        }
        function sortBySpeedAndName(a, b) {
            var aSpeed = a.speed;
            var bSpeed = b.speed;
            var aName = a.name;
            var bName = b.name;
            if (aSpeed == bSpeed) {
                return (aName < bName) ? -1 : (aName > bName) ? 1 : 0;
            }
            else {
                return (aSpeed > bSpeed) ? -1 : 1;
            }
        }

        return new BattleManager();
    })();

    return battlemanager;
}

module.exports = solve;