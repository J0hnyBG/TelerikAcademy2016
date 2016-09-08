'use strict';
class listNode {
    constructor(value) {
        this._data = value;
        this._nextNode = null;
    }

    get data() {
        return this._data;
    }

    set data(value) {
        this._data = value;
    }

    get nextNode() {
        return this._nextNode;
    }

    set nextNode(val) {
        this._nextNode = val;
    }
}

var LinkedList = (function () {

    function getNodeAt(nodeIndex) {
        let currNode;

        if (nodeIndex < 0 || this._length - 1 < nodeIndex) {
            currNode = null;
        }
        else {
            currNode = this._firstNode;

            for(let i = 0; i < nodeIndex; i++) {
                currNode = currNode.nextNode;
            }
        }

        return currNode;
    }

    function getNodeArray(args) {
        return args.map(value => new listNode(value));
    }

    class LinkedList {
        constructor() {
            this._length = 0;
            this._firstNode = null;
        }

        get first() {
            return this._firstNode
                ? this._firstNode.data
                : null;
        }

        get last() {
            if (this._firstNode !== null) {
                return getNodeAt.call(this, this._length - 1).data;
            }
            else {
                return null;
            }
        }

        get length() {
            return this._length;
        }

        append(...args) {
            let nodesToAppend = getNodeArray(args);

            let last;

            if (this._firstNode === null) {
                this._firstNode = nodesToAppend[0];
                last = this._firstNode;
            }
            else {
                last = getNodeAt.call(this, this._length - 1);
                last.nextNode = nodesToAppend[0];
                last = last.nextNode;
            }

            this._length += 1;

            for (let i = 1, len = nodesToAppend.length; i < len; i += 1) {
                last.nextNode = nodesToAppend[i];
                last = last.nextNode;
                this._length += 1;
            }

            return this;
        }

        prepend(...args) {
            let nodesToPrepend = getNodeArray(args);

            let next = this._firstNode;
            this._firstNode = nodesToPrepend[0];
            this._length += 1;

            let curr = this._firstNode;
            for (let i = 1, len = nodesToPrepend.length; i < len; i += 1) {
                curr.nextNode = nodesToPrepend[i];
                curr = curr.nextNode;
                this._length += 1;
            }

            curr.nextNode = next;
            return this;
        }

        insert(index, ...args) {
            if (index === 0) {
                this.prepend(...args);
            }
            else {
                let itemsToAdd = getNodeArray(args);

                let prev = getNodeAt.call(this, index - 1);
                let next = prev.nextNode;

                prev.nextNode = itemsToAdd[0];
                this._length += 1;

                let curr = prev.nextNode;
                for (let i = 1, len = itemsToAdd.length; i < len; i += 1) {
                    curr.nextNode = itemsToAdd[i];
                    curr = curr.nextNode;
                    this._length += 1;
                }

                curr.nextNode = next;
            }

            return this;
        }

        at(index, value) {
            if (value === undefined) {
                return getNodeAt.call(this, index).data;
            }
            else {
                if (index === 0) {
                    this._firstNode.data = value;
                }
                else {
                    getNodeAt.call(this, index).data = value;
                }

                return this;
            }
        }

        removeAt(index) {
            let prev, removed;
            if (index === 0) {
                removed = this._firstNode.data;
                this._firstNode = this._firstNode.nextNode;
            }
            else if (index === this._length - 1) {
                prev = getNodeAt.call(this, index - 1);
                removed = prev.nextNode.data;
                prev.nextNode = null;
            }
            else {
                prev = getNodeAt.call(this, index - 1);
                let curr = prev.nextNode;
                removed = curr.data;
                prev.nextNode = curr.nextNode;
            }

            this._length -= 1;
            return removed;
        }

        toString() {
            let curr = this._firstNode;
            let str = '';

            while (curr.nextNode !== null) {
                str += curr.data + ' -> ';
                curr = curr.nextNode;
            }

            str += curr.data;

            return str;
        }

        toArray() {
            let arr = [];
            for (let node of this) {
                arr.push(node);
            }

            return arr;
        }

        [Symbol.iterator]() {
            let curr = this._firstNode;
            return {
                next: function () {
                    if (curr === null) {
                        return {done: true};
                    }
                    else {
                        let data = curr.data;
                        curr = curr.nextNode;
                        return {
                            value: data,
                            done: false
                        };
                    }
                }
            };
        }
    }

    return LinkedList;
})();

module.exports = LinkedList;
