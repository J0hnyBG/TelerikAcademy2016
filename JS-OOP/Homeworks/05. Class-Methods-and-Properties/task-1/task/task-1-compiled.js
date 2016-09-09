'use strict';

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

var listNode = function () {
    function listNode(value) {
        _classCallCheck(this, listNode);

        this._data = value;
        this._nextNode = null;
    }

    _createClass(listNode, [{
        key: 'data',
        get: function get() {
            return this._data;
        },
        set: function set(value) {
            this._data = value;
        }
    }, {
        key: 'nextNode',
        get: function get() {
            return this._nextNode;
        },
        set: function set(val) {
            this._nextNode = val;
        }
    }]);

    return listNode;
}();

var LinkedList = function () {

    function getNodeAt(nodeIndex) {
        var currNode = void 0;

        if (nodeIndex < 0 || this._length - 1 < nodeIndex) {
            currNode = null;
        } else {
            currNode = this._firstNode;

            for (var i = 0; i < nodeIndex; i++) {
                currNode = currNode.nextNode;
            }
        }

        return currNode;
    }

    function getNodeArray(args) {
        return args.map(function (value) {
            return new listNode(value);
        });
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

                var nodesToAppend = getNodeArray(args);

                var last = void 0;

                if (this._firstNode === null) {
                    this._firstNode = nodesToAppend[0];
                    last = this._firstNode;
                } else {
                    last = getNodeAt.call(this, this._length - 1);
                    last.nextNode = nodesToAppend[0];
                    last = last.nextNode;
                }

                this._length += 1;

                for (var i = 1, len = nodesToAppend.length; i < len; i += 1) {
                    last.nextNode = nodesToAppend[i];
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

                var nodesToPrepend = getNodeArray(args);

                var next = this._firstNode;
                this._firstNode = nodesToPrepend[0];
                this._length += 1;

                var curr = this._firstNode;
                for (var i = 1, len = nodesToPrepend.length; i < len; i += 1) {
                    curr.nextNode = nodesToPrepend[i];
                    curr = curr.nextNode;
                    this._length += 1;
                }

                curr.nextNode = next;
                return this;
            }
        }, {
            key: 'insert',
            value: function insert(index) {
                for (var _len3 = arguments.length, args = Array(_len3 > 1 ? _len3 - 1 : 0), _key3 = 1; _key3 < _len3; _key3++) {
                    args[_key3 - 1] = arguments[_key3];
                }

                if (index === 0) {
                    this.prepend.apply(this, args);
                } else {
                    var itemsToAdd = getNodeArray(args);

                    var prev = getNodeAt.call(this, index - 1);
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
            value: function at(index, value) {
                if (value === undefined) {
                    return getNodeAt.call(this, index).data;
                } else {
                    if (index === 0) {
                        this._firstNode.data = value;
                    } else {
                        getNodeAt.call(this, index).data = value;
                    }

                    return this;
                }
            }
        }, {
            key: 'removeAt',
            value: function removeAt(index) {
                var prev = void 0,
                    removed = void 0;
                if (index === 0) {
                    removed = this._firstNode.data;
                    this._firstNode = this._firstNode.nextNode;
                } else if (index === this._length - 1) {
                    prev = getNodeAt.call(this, index - 1);
                    removed = prev.nextNode.data;
                    prev.nextNode = null;
                } else {
                    prev = getNodeAt.call(this, index - 1);
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
                return this._firstNode ? this._firstNode.data : null;
            }
        }, {
            key: 'last',
            get: function get() {
                if (this._firstNode !== null) {
                    return getNodeAt.call(this, this._length - 1).data;
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
}();

module.exports = LinkedList;

//# sourceMappingURL=task-1-compiled.js.map