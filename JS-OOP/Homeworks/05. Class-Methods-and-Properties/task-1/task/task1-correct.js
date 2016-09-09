'use strict';
var listNode = (function () {

    class listNode {
        constructor(value) {
            this.data = value;
            this.nextNode = null;
        }

        get data() {
            return this._data;
        }

        set data(val) {
            this._data = val;
        }

        get nextNode() {
            return this._next;
        }

        set nextNode(val) {
            this._next = val;
        }
    }

    return listNode;
} ());

var LinkedList = (function (listNode) {

    function getNodeAtIndex(ind) {
        let currNode;

        if (ind < 0 || this._length - 1 < ind) {
            currNode = null;
        }
        else {
            let i = 0;

            currNode = this._firstNode;

            while (i < ind) {
                currNode = currNode.nextNode;
                i += 1;
            }
        }

        return currNode;
    }

    class LinkedList {
        constructor() {
            this._length = 0;
            this._firstNode = null;
        }

        get first() {
            if (this._firstNode !== null) {
                return this._firstNode.data;
            }
            else {
                return null;
            }
        }

        get last() {
            let lastInd = this._length - 1;
            if (this._firstNode !== null) {
                return getNodeAtIndex.call(this, lastInd).data;
            }
            else {
                return null;
            }
        }

        get length() {
            return this._length;
        }

        append(...args) {
            let itemsToAdd = args;
            itemsToAdd = itemsToAdd.map(el => {
                return new listNode(el);
            });

            let last;
            let lastInd = this._length - 1;
            if (this._firstNode === null) {
                this._firstNode = itemsToAdd[0];
                last = this._firstNode;
            }
            else {
                last = getNodeAtIndex.call(this, lastInd);
                last.nextNode = itemsToAdd[0];
                last = last.nextNode;
            }

            this._length += 1;

            for (let i = 1, len = itemsToAdd.length; i < len; i += 1) {
                let currentItem = itemsToAdd[i];
                last.nextNode = currentItem;
                last = last.nextNode;
                this._length += 1;
            }

            return this;
        }

        prepend(...args) {
            let itemsToAdd = args.map(node => { return new listNode(node); });

            let next = this._firstNode;
            this._firstNode = itemsToAdd[0];
            this._length += 1;

            let curr = this._firstNode;
            for (let i = 1, len = itemsToAdd.length; i < len; i += 1) {
                curr.nextNode = itemsToAdd[i];
                curr = curr.nextNode;
                this._length += 1;
            }

            curr.nextNode = next;
            return this;
        }

        insert(ind, ...args) {
            if (ind === 0) {
                this.prepend(...args);
            }
            else {
                let itemsToAdd = args.map(el => { return new listNode(el); });

                let prev = getNodeAtIndex.call(this, ind - 1);
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

        at(ind, param) {
            if (param === undefined) {
                return getNodeAtIndex.call(this, ind).data;
            }
            else {
                if (ind === 0) {
                    this._firstNode.data = param;
                }
                else {
                    getNodeAtIndex.call(this, ind).data = param;
                }

                return this;
            }
        }

        removeAt(ind) {
            let prev, removed;
            if (ind === 0) {
                removed = this._firstNode.data;
                this._firstNode = this._firstNode.nextNode;
            }
            else if (ind === this._length - 1) {
                prev = getNodeAtIndex.call(this, ind - 1);
                removed = prev.nextNode.data;
                prev.nextNode = null;
            }
            else {
                prev = getNodeAtIndex.call(this, ind - 1);
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
                        return { done: true };
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
})(listNode);

module.exports = LinkedList;