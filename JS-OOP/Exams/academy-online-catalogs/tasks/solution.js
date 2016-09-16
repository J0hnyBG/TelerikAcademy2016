function solve() {
    "use strict";
    var idGenerator = (function () {
        let currentId = 0;

        function getNext() {
            currentId += 1;
            return currentId;
        }

        return {
            getNext: getNext
        }
    })();

    var Validator = (function () {
        function validateStringLength(string, min, max) {
            if (string === null || typeof string === 'undefined') {
                throw new Error("No string provided!")
            }
            if (typeof min === 'undefined' && typeof max === 'undefined') {
                if (string.length >= max) {
                    throw new Error(`String length must be less than ${max} characters long!`)
                }
            }
            else if (typeof max === 'undefined' || max === null) {
                if (string.length <= min) {
                    throw new Error(`String length must be more than ${min} characters long!`)
                }
            }
            else {
                if (string.length <= min || max <= string.length) {
                    throw new Error(`String length must be between ${min} and ${max} characters long!`)
                }
            }
        }

        function validateISBN(isbn) {
            if (isNaN(isbn) || (isbn.length != 10 && isbn.length != 13)) {
                throw new Error("Invalid ISBN!")
            }
        }

        function validateNumberRange(number, minValue, maxValue) {
            if (typeof number === 'undefined' || number === null) {
                throw new Error('You must specify a number!')
            }
            if (typeof maxValue === 'undefined' || maxValue === null) {
                if (number < minValue) {
                    throw new Error(`Number must be more than ${minValue}!`)
                }
            }
            else {
                if (number < minValue || maxValue < number) {
                    throw new Error(`Number must be between ${minValue} and ${maxValue}!`)
                }
            }

        }

        return {
            validateStringLength,
            validateISBN,
            validateNumberRange
        }

    })();

    class Item {
        constructor(name, description) {
            this._id = idGenerator.getNext();
            this.description = description;
            this.name = name;
        }

        get id() {
            return this._id;
        }

        set name(value) {
            Validator.validateStringLength(value, 1, 41);
            this._name = value;
        }

        get name() {
            return this._name;
        }

        set description(value) {
            Validator.validateStringLength(value, 1);
            this._description = value;
        }

        get description() {
            return this._description;
        }
    }

    class Book extends Item {
        constructor(name, isbn, genre, description) {
            super(name, description);
            this.isbn = isbn;
            this.genre = genre;
        }

        set isbn(isbn) {
            Validator.validateISBN(isbn);
            this._isbn = isbn;
        }

        get isbn() {
            return this._isbn;
        }

        set genre(genre) {
            Validator.validateStringLength(genre, 1, 21);
            this._genre = genre;
        }

        get genre() {
            return this._genre;
        }
    }

    class Media extends Item {
        constructor(name, rating, duration, description) {
            super(name, description);
            this.rating = rating;
            this.duration = duration;
        }

        set rating(rating) {
            Validator.validateNumberRange(rating, 1, 5);
            this._rating = rating;
        }

        get rating() {
            return this._rating;
        }

        set duration(duration) {
            Validator.validateNumberRange(duration, 1);
            this._duration = duration;
        }

        get duration() {
            return this._duration;
        }
    }

    class Catalog {
        constructor(name) {
            this.name = name;
            this._id = idGenerator.getNext();
            this.items = [];
        }

        get id() {
            return this._id;
        }

        set name(name) {
            Validator.validateStringLength(name, 1, 41);
            this._name = name;
        }

        get name() {
            return this._name;
        }

        add(...items) {
            if (Array.isArray(items[0])) {
                items = items[0];
            }

            if (items.length === 0) {
                throw new Error('No items are added');
            }

            this.items.push(...items);

            return this;
        }

        find(x) {
            if (typeof x === 'number') {
                for (let item of this.items) {
                    if (item.id === x) {
                        return item;
                    }
                }

                return null;
            }

            if (x !== null && typeof x === 'object') {
                let result = this.items.filter(function (item) {
                    return Object.keys(x).every(function (prop) {
                        return x[prop] === item[prop];
                    });
                });

                return result;
            }

            throw new Error('Invalid options or id');
        }

        search(pattern) {
            if (typeof pattern != 'string' || pattern.length < 1) {
                throw new Error("Invalid pattern length!");
            }

            return this.items.filter(x => x.name.indexOf(pattern) >= 0
                                       || x.description.indexOf(pattern) >= 0);
        }
    }

    class BookCatalog extends Catalog {
        constructor(name) {
            super(name);
        }

        add(...books) {
            if (Array.isArray(books[0])) {
                books = books[0];
            }

            books.forEach(function (x) {
                if (!(x instanceof Book)) {
                    throw new Error('Must add only books');
                }
            });

            return super.add(...books);
        }

        getGenres() {
            let genres = [];
            for (let book of this.items) {
                if (genres.indexOf(book.genre) < 0) {
                    genres.push(book.genre);
                }
            }
            return genres;
        }
    }

    class MediaCatalog extends Catalog {
        constructor(name) {
            super(name);
        }

        add(...medias) {
            if(Array.isArray(medias[0])) {
                medias = medias[0];
            }

            medias.forEach(function(x) {
                if(!(x instanceof Media)) {
                    throw new Error('Must add only medias');
                }
            });

            return super.add(...medias);
        }

        getTop(count) {
            if (count === null || typeof count != 'number' || count < 1) {
                throw new Error("Invalid count!")
            }

            this.items = this.items.sort((a, b) => a.rating < b.rating);

            var result;
            if (this.items.length < count) {
                result = this.items;
            }
            else {
                result = this.items.slice(0, count);
            }

            return result.map(x => {
                return {
                    id: x.id,
                    name: x.name
                }
            });
        }

        getSortedByDuration() {

        }
    }

    return {
        getBook: function (name, isbn, genre, description) {
            return new Book(name, isbn, genre, description);
        },
        getMedia: function (name, rating, duration, description) {
            return new Media(name, rating, duration, description);
        },
        getBookCatalog: function (name) {
            return new BookCatalog(name);
        },
        getMediaCatalog: function (name) {
            return new MediaCatalog(name);
        }
    };
}

module.exports = solve;