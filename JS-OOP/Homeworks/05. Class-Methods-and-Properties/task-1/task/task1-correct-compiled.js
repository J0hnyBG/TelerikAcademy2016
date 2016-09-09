'use strict';

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var listNode = function () {
    var listNode = function () {
        function listNode(value) {
            _classCallCheck(this, listNode);

            this.data = value;
            this.nextNode = null;
        }

        _createClass(listNode, [{
            key: 'data',
            get: function get() {
                return this._data;
            },
            set: function set(val) {
                this._data = val;
            }
        }, {
            key: 'nextNode',
            get: function get() {
                return this._next;
            },
            set: function set(val) {
                this._next = val;
            }
        }]);

        return listNode;
    }();

    return listNode;
}();

var LinkedList = function (listNode) {

    function getNodeAtIndex(ind) {
        var currNode = void 0;

        if (ind < 0 || this._length - 1 < ind) {
            currNode = null;
        } else {
            var i = 0;

            currNode = this._firstNode;

            while (i < ind) {
                currNode = currNode.nextNode;
                i += 1;
            }
        }

        return currNode;
    }

    var LinkedList = function () {
        function LinkedList() {
            _classCallCheck(this, LinkedList);

            this._length = 0;
            this._firstNode = null;
        }

        _createClass(LinkedList, [{
            key: 'append',
            value: function append() {
                for (var _len = arguments.length, args = Array(_len), _key = 0; _key < _len; _key++) {
                    args[_key] = arguments[_key];
                }

                var itemsToAdd = args;
                itemsToAdd = itemsToAdd.map(function (el) {
                    return new listNode(el);
                });

                var last = void 0;
                var lastInd = this._length - 1;
                if (this._firstNode === null) {
                    this._firstNode = itemsToAdd[0];
                    last = this._firstNode;
                } else {
                    last = getNodeAtIndex.call(this, lastInd);
                    last.nextNode = itemsToAdd[0];
                    last = last.nextNode;
                }

                this._length += 1;

                for (var i = 1, len = itemsToAdd.length; i < len; i += 1) {
                    var currentItem = itemsToAdd[i];
                    last.nextNode = currentItem;
                    last = last.nextNode;
                    this._length += 1;
                }

                return this;
            }
        }, {
            key: 'prepend',
            value: function prepend() {
                for (var _len2 = arguments.length, args = Array(_len2), _key2 = 0; _key2 < _len2; _key2++) {
                    args[_key2] = arguments[_key2];
                }

                var itemsToAdd = args.map(function (node) {
                    return new listNode(node);
                });

                var next = this._firstNode;
                this._firstNode = itemsToAdd[0];
                this._length += 1;

                var curr = this._firstNode;
                for (var i = 1, len = itemsToAdd.length; i < len; i += 1) {
                    curr.nextNode = itemsToAdd[i];
                    curr = curr.nextNode;
                    this._length += 1;
                }

                curr.nextNode = next;
                return this;
            }
        }, {
            key: 'insert',
            value: function insert(ind) {
                for (var _len3 = arguments.length, args = Array(_len3 > 1 ? _len3 - 1 : 0), _key3 = 1; _key3 < _len3; _key3++) {
                    args[_key3 - 1] = arguments[_key3];
                }

                if (ind === 0) {
                    this.prepend.apply(this, args);
                } else {
                    var itemsToAdd = args.map(function (el) {
                        return new listNode(el);
                    });

                    var prev = getNodeAtIndex.call(this, ind - 1);
                    var next = prev.nextNode;

                    prev.nextNode = itemsToAdd[0];
                    this._length += 1;

                    var curr = prev.nextNode;
                    for (var i = 1, len = itemsToAdd.length; i < len; i += 1) {
                        curr.nextNode = itemsToAdd[i];
                        curr = curr.nextNode;
                        this._length += 1;
                    }

                    curr.nextNode = next;
                }

                return this;
            }
        }, {
            key: 'at',
            value: function at(ind, param) {
                if (param === undefined) {
                    return getNodeAtIndex.call(this, ind).data;
                } else {
                    if (ind === 0) {
                        this._firstNode.data = param;
                    } else {
                        getNodeAtIndex.call(this, ind).data = param;
                    }

                    return this;
                }
            }
        }, {
            key: 'removeAt',
            value: function removeAt(ind) {
                var prev = void 0,
                    removed = void 0;
                if (ind === 0) {
                    removed = this._firstNode.data;
                    this._firstNode = this._firstNode.nextNode;
                } else if (ind === this._length - 1) {
                    prev = getNodeAtIndex.call(this, ind - 1);
                    removed = prev.nextNode.data;
                    prev.nextNode = null;
                } else {
                    prev = getNodeAtIndex.call(this, ind - 1);
                    var curr = prev.nextNode;
                    removed = curr.data;
                    prev.nextNode = curr.nextNode;
                }

                this._length -= 1;
                return removed;
            }
        }, {
            key: 'toString',
            value: function toString() {
                var curr = this._firstNode;
                var str = '';

                while (curr.nextNode !== null) {
                    str += curr.data + ' -> ';
                    curr = curr.nextNode;
                }

                str += curr.data;

                return str;
            }
        }, {
            key: 'toArray',
            value: function toArray() {
                var arr = [];
                var _iteratorNormalCompletion = true;
                var _didIteratorError = false;
                var _iteratorError = undefined;

                try {
                    for (var _iterator = this[Symbol.iterator](), _step; !(_iteratorNormalCompletion = (_step = _iterator.next()).done); _iteratorNormalCompletion = true) {
                        var node = _step.value;

                        arr.push(node);
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

                return arr;
            }
        }, {
            key: Symbol.iterator,
            value: function value() {
                var curr = this._firstNode;
                return {
                    next: function next() {
                        if (curr === null) {
                            return { done: true };
                        } else {
                            var data = curr.data;
                            curr = curr.nextNode;
                            return {
                                value: data,
                                done: false
                            };
                        }
                    }
                };
            }
        }, {
            key: 'first',
            get: function get() {
                if (this._firstNode !== null) {
                    return this._firstNode.data;
                } else {
                    return null;
                }
            }
        }, {
            key: 'last',
            get: function get() {
                var lastInd = this._length - 1;
                if (this._firstNode !== null) {
                    return getNodeAtIndex.call(this, lastInd).data;
                } else {
                    return null;
                }
            }
        }, {
            key: 'length',
            get: function get() {
                return this._length;
            }
        }]);

        return LinkedList;
    }();

    return LinkedList;
}(listNode);

module.exports = LinkedList;

//# sourceMappingURL=task1-correct-compiled.js.map