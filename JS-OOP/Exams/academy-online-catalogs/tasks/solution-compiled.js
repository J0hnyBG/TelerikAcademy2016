"use strict";

var _get = function get(object, property, receiver) { if (object === null) object = Function.prototype; var desc = Object.getOwnPropertyDescriptor(object, property); if (desc === undefined) { var parent = Object.getPrototypeOf(object); if (parent === null) { return undefined; } else { return get(parent, property, receiver); } } else if ("value" in desc) { return desc.value; } else { var getter = desc.get; if (getter === undefined) { return undefined; } return getter.call(receiver); } };

var _typeof = typeof Symbol === "function" && typeof Symbol.iterator === "symbol" ? function (obj) { return typeof obj; } : function (obj) { return obj && typeof Symbol === "function" && obj.constructor === Symbol ? "symbol" : typeof obj; };

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

function _toConsumableArray(arr) { if (Array.isArray(arr)) { for (var i = 0, arr2 = Array(arr.length); i < arr.length; i++) { arr2[i] = arr[i]; } return arr2; } else { return Array.from(arr); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function solve() {
    "use strict";

    var idGenerator = function () {
        var currentId = 0;

        function getNext() {
            currentId += 1;
            return currentId;
        }

        return {
            getNext: getNext
        };
    }();

    var Validator = function () {
        function validateStringLength(string, min, max) {
            if (string === null || typeof string === 'undefined') {
                throw new Error("No string provided!");
            }
            if (typeof min === 'undefined' && typeof max === 'undefined') {
                if (string.length >= max) {
                    throw new Error("String length must be less than " + max + " characters long!");
                }
            } else if (typeof max === 'undefined' || max === null) {
                if (string.length <= min) {
                    throw new Error("String length must be more than " + min + " characters long!");
                }
            } else {
                if (string.length <= min || max <= string.length) {
                    throw new Error("String length must be between " + min + " and " + max + " characters long!");
                }
            }
        }

        function validateISBN(isbn) {
            if (isNaN(isbn) || isbn.length != 10 && isbn.length != 13) {
                throw new Error("Invalid ISBN!");
            }
        }

        function validateNumberRange(number, minValue, maxValue) {
            if (typeof number === 'undefined' || number === null) {
                throw new Error('You must specify a number!');
            }
            if (typeof maxValue === 'undefined' || maxValue === null) {
                if (number < minValue) {
                    throw new Error("Number must be more than " + minValue + "!");
                }
            } else {
                if (number < minValue || maxValue < number) {
                    throw new Error("Number must be between " + minValue + " and " + maxValue + "!");
                }
            }
        }

        return {
            validateStringLength: validateStringLength,
            validateISBN: validateISBN,
            validateNumberRange: validateNumberRange
        };
    }();

    var Item = function () {
        function Item(name, description) {
            _classCallCheck(this, Item);

            this._id = idGenerator.getNext();
            this.description = description;
            this.name = name;
        }

        _createClass(Item, [{
            key: "id",
            get: function get() {
                return this._id;
            }
        }, {
            key: "name",
            set: function set(value) {
                Validator.validateStringLength(value, 1, 41);
                this._name = value;
            },
            get: function get() {
                return this._name;
            }
        }, {
            key: "description",
            set: function set(value) {
                Validator.validateStringLength(value, 1);
                this._description = value;
            },
            get: function get() {
                return this._description;
            }
        }]);

        return Item;
    }();

    var Book = function (_Item) {
        _inherits(Book, _Item);

        function Book(name, isbn, genre, description) {
            _classCallCheck(this, Book);

            var _this = _possibleConstructorReturn(this, (Book.__proto__ || Object.getPrototypeOf(Book)).call(this, name, description));

            _this.isbn = isbn;
            _this.genre = genre;
            return _this;
        }

        _createClass(Book, [{
            key: "isbn",
            set: function set(isbn) {
                Validator.validateISBN(isbn);
                this._isbn = isbn;
            },
            get: function get() {
                return this._isbn;
            }
        }, {
            key: "genre",
            set: function set(genre) {
                Validator.validateStringLength(genre, 1, 21);
                this._genre = genre;
            },
            get: function get() {
                return this._genre;
            }
        }]);

        return Book;
    }(Item);

    var Media = function (_Item2) {
        _inherits(Media, _Item2);

        function Media(name, rating, duration, description) {
            _classCallCheck(this, Media);

            var _this2 = _possibleConstructorReturn(this, (Media.__proto__ || Object.getPrototypeOf(Media)).call(this, name, description));

            _this2.rating = rating;
            _this2.duration = duration;
            return _this2;
        }

        _createClass(Media, [{
            key: "rating",
            set: function set(rating) {
                Validator.validateNumberRange(rating, 1, 5);
                this._rating = rating;
            },
            get: function get() {
                return this._rating;
            }
        }, {
            key: "duration",
            set: function set(duration) {
                Validator.validateNumberRange(duration, 1);
                this._duration = duration;
            },
            get: function get() {
                return this._duration;
            }
        }]);

        return Media;
    }(Item);

    var Catalog = function () {
        function Catalog(name) {
            _classCallCheck(this, Catalog);

            this.name = name;
            this._id = idGenerator.getNext();
            this.items = [];
        }

        _createClass(Catalog, [{
            key: "add",
            value: function add() {
                var _items;

                for (var _len = arguments.length, items = Array(_len), _key = 0; _key < _len; _key++) {
                    items[_key] = arguments[_key];
                }

                if (Array.isArray(items[0])) {
                    items = items[0];
                }

                if (items.length === 0) {
                    throw new Error('No items are added');
                }

                (_items = this.items).push.apply(_items, _toConsumableArray(items));

                return this;
            }
        }, {
            key: "find",
            value: function find(x) {
                if (typeof x === 'number') {
                    var _iteratorNormalCompletion = true;
                    var _didIteratorError = false;
                    var _iteratorError = undefined;

                    try {
                        for (var _iterator = this.items[Symbol.iterator](), _step; !(_iteratorNormalCompletion = (_step = _iterator.next()).done); _iteratorNormalCompletion = true) {
                            var item = _step.value;

                            if (item.id === x) {
                                return item;
                            }
                        }
                    } catch (err) {
                        _didIteratorError = true;
                        _iteratorError = err;
                    } finally {
                        try {
                            if (!_iteratorNormalCompletion && _iterator.return) {
                                _iterator.return();
                            }
                        } finally {
                            if (_didIteratorError) {
                                throw _iteratorError;
                            }
                        }
                    }

                    return null;
                }

                if (x !== null && (typeof x === "undefined" ? "undefined" : _typeof(x)) === 'object') {
                    var result = this.items.filter(function (item) {
                        return Object.keys(x).every(function (prop) {
                            return x[prop] === item[prop];
                        });
                    });

                    return result;
                }

                throw new Error('Invalid options or id');
            }
        }, {
            key: "search",
            value: function search(pattern) {
                if (typeof pattern != 'string' || pattern.length < 1) {
                    throw new Error("Invalid pattern length!");
                }

                return this.items.filter(function (x) {
                    return x.name.indexOf(pattern) >= 0 || x.description.indexOf(pattern) >= 0;
                });
            }
        }, {
            key: "id",
            get: function get() {
                return this._id;
            }
        }, {
            key: "name",
            set: function set(name) {
                Validator.validateStringLength(name, 1, 41);
                this._name = name;
            },
            get: function get() {
                return this._name;
            }
        }]);

        return Catalog;
    }();

    var BookCatalog = function (_Catalog) {
        _inherits(BookCatalog, _Catalog);

        function BookCatalog(name) {
            _classCallCheck(this, BookCatalog);

            return _possibleConstructorReturn(this, (BookCatalog.__proto__ || Object.getPrototypeOf(BookCatalog)).call(this, name));
        }

        _createClass(BookCatalog, [{
            key: "add",
            value: function add() {
                var _get2;

                for (var _len2 = arguments.length, books = Array(_len2), _key2 = 0; _key2 < _len2; _key2++) {
                    books[_key2] = arguments[_key2];
                }

                if (Array.isArray(books[0])) {
                    books = books[0];
                }

                books.forEach(function (x) {
                    if (!(x instanceof Book)) {
                        throw new Error('Must add only books');
                    }
                });

                return (_get2 = _get(BookCatalog.prototype.__proto__ || Object.getPrototypeOf(BookCatalog.prototype), "add", this)).call.apply(_get2, [this].concat(_toConsumableArray(books)));
            }
        }, {
            key: "getGenres",
            value: function getGenres() {
                var genres = [];
                var _iteratorNormalCompletion2 = true;
                var _didIteratorError2 = false;
                var _iteratorError2 = undefined;

                try {
                    for (var _iterator2 = this.items[Symbol.iterator](), _step2; !(_iteratorNormalCompletion2 = (_step2 = _iterator2.next()).done); _iteratorNormalCompletion2 = true) {
                        var book = _step2.value;

                        if (genres.indexOf(book.genre) < 0) {
                            genres.push(book.genre);
                        }
                    }
                } catch (err) {
                    _didIteratorError2 = true;
                    _iteratorError2 = err;
                } finally {
                    try {
                        if (!_iteratorNormalCompletion2 && _iterator2.return) {
                            _iterator2.return();
                        }
                    } finally {
                        if (_didIteratorError2) {
                            throw _iteratorError2;
                        }
                    }
                }

                return genres;
            }
        }]);

        return BookCatalog;
    }(Catalog);

    var MediaCatalog = function (_Catalog2) {
        _inherits(MediaCatalog, _Catalog2);

        function MediaCatalog(name) {
            _classCallCheck(this, MediaCatalog);

            return _possibleConstructorReturn(this, (MediaCatalog.__proto__ || Object.getPrototypeOf(MediaCatalog)).call(this, name));
        }

        _createClass(MediaCatalog, [{
            key: "add",
            value: function add() {
                var _get3;

                for (var _len3 = arguments.length, medias = Array(_len3), _key3 = 0; _key3 < _len3; _key3++) {
                    medias[_key3] = arguments[_key3];
                }

                if (Array.isArray(medias[0])) {
                    medias = medias[0];
                }

                medias.forEach(function (x) {
                    if (!(x instanceof Media)) {
                        throw new Error('Must add only medias');
                    }
                });

                return (_get3 = _get(MediaCatalog.prototype.__proto__ || Object.getPrototypeOf(MediaCatalog.prototype), "add", this)).call.apply(_get3, [this].concat(_toConsumableArray(medias)));
            }
        }, {
            key: "getTop",
            value: function getTop(count) {
                if (count === null || typeof count != 'number' || count < 1) {
                    throw new Error("Invalid count!");
                }

                this.items = this.items.sort(function (a, b) {
                    return a.rating < b.rating;
                });

                var result;
                if (this.items.length < count) {
                    result = this.items;
                } else {
                    result = this.items.slice(0, count);
                }

                return result.map(function (x) {
                    return {
                        id: x.id,
                        name: x.name
                    };
                });
            }
        }, {
            key: "getSortedByDuration",
            value: function getSortedByDuration() {}
        }]);

        return MediaCatalog;
    }(Catalog);

    return {
        getBook: function getBook(name, isbn, genre, description) {
            return new Book(name, isbn, genre, description);
        },
        getMedia: function getMedia(name, rating, duration, description) {
            return new Media(name, rating, duration, description);
        },
        getBookCatalog: function getBookCatalog(name) {
            return new BookCatalog(name);
        },
        getMediaCatalog: function getMediaCatalog(name) {
            return new MediaCatalog(name);
        }
    };
}

module.exports = solve;

//# sourceMappingURL=solution-compiled.js.map