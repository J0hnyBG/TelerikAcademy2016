/* globals require module Promise */
"use strict";
module.exports = function (models) {
    let { Superhero } = models;

    return {
        insertHero(name, secretIdentity, alignment, story, image, powers) {
            if (!Array.isArray(powers)) {
                return Promise.reject("Powers must be an array!");
            }

            let superHeroPowers = powers.map((power) => {
                return { name: power };
            });

            let hero = new Superhero({
                name,
                secretIdentity,
                alignment,
                story,
                image,
                superHeroPowers
            });

            return new Promise((resolve, reject) => {
                hero.save((err) => {
                    if (err) {
                        return reject(err);
                    }

                    return resolve(hero);
                });
            });
        },
        findSuperheroBySecretIdentity(secretIdentity) {
            return new Promise((resolve, reject) => {
                Superhero.findOne()
                    .bySecretIdentity(secretIdentity)
                    .exec((err, user) => {
                        if (err) {
                            return reject(err);
                        }

                        return resolve(user);
                    });
            });
        },
        findSuperheroById(id) {
            return new Promise((resolve, reject) => {
                Superhero.findById(id).exec((err, hero) => {
                    if (err) {
                        return reject(err);
                    }

                    return resolve(hero);
                });
            });
        },
        getAllSuperheroes() {
            return new Promise((resolve, reject) => {
                Superhero.find((err, heroes) => {
                    if (err) {
                        return reject(err);
                    }

                    return resolve(heroes);
                });
            });
        }
    };
};
