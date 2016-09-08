'use strict';

function _toConsumableArray(arr) { if (Array.isArray(arr)) { for (var i = 0, arr2 = Array(arr.length); i < arr.length; i++) { arr2[i] = arr[i]; } return arr2; } else { return Array.from(arr); } }

var chai = require('chai'),
    expect = chai.expect,
    LinkedList = require('../task/task-1');

describe('Linked list: ', function () {
    it('should have append and toString correctly', function () {

        var list = new LinkedList(),
            values = [1, 2, false, 3, 4];

        list.append.apply(list, values);

        expect(list.first).to.equal(values[0]);
        expect(list.last).to.equal(values[values.length - 1]);
        expect(list.length).to.equal(values.length);
        expect(list.toString()).to.equal(values.join(' -> '));
    });

    it('append should implement chaining and toString should work correctly', function () {
        var values = [1, 2, 3, 4, 5, 6],
            list = new LinkedList().append(1, 2).append(3, 4).append(5).append(6);

        expect(list.first).to.equal(values[0]);
        expect(list.last).to.equal(values[values.length - 1]);
        expect(list.length).to.equal(values.length);
        expect(list.toString()).to.equal(values.join(' -> '));
    });

    it('should implement prepend correctly, enable chaining and toString should work correctly', function () {

        var values = [0, 1, 2, 3, 4, 5],
            list = new LinkedList().append(3, 4).prepend(1, 2).prepend(0).append(5);

        expect(list.first).to.equal(values[0]);
        expect(list.last).to.equal(values[values.length - 1]);
        expect(list.length).to.equal(values.length);
        expect(list.toString()).to.equal(values.join(' -> '));
    });

    it('should insert correctly', function () {
        var _ref;

        var values = [1, 2, 6, 7, 8],
            list = (_ref = new LinkedList()).append.apply(_ref, values).insert(2, 3, 4).insert(4, 5);

        expect(list.first).to.equal(1);
        expect(list.length).to.equal(8);
        expect(list.toString()).to.equal([1, 2, 3, 4, 5, 6, 7, 8].join(' -> '));
    });

    it('should insert correctly', function () {
        var list = new LinkedList().append(1, 2).insert(0, 3, 4);

        list.insert(list.length - 1, 'kremikovci');

        expect(list.first).to.equal(3);
        expect(list.last).to.equal(2);
        expect(list.length).to.equal(5);
        expect(list.toString()).to.equal([3, 4, 1, 'kremikovci', 2].join(' -> '));
    });

    it('should have correct for-of', function () {
        var _ref2;

        var values = [5, 6, 38],
            list = (_ref2 = new LinkedList()).append.apply(_ref2, values);

        var _iteratorNormalCompletion = true;
        var _didIteratorError = false;
        var _iteratorError = undefined;

        try {
            for (var _iterator = list[Symbol.iterator](), _step; !(_iteratorNormalCompletion = (_step = _iterator.next()).done); _iteratorNormalCompletion = true) {
                var val = _step.value;

                expect(values.indexOf(val)).to.not.equal(-1);
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
    });

    it('should have correct for-of', function () {
        var _append, _ref3;

        var values = [5, 6, 3, 'gosho', true, null, 'ivan', { message: 'Hello' }],
            list = (_append = (_ref3 = new LinkedList()).append.apply(_ref3, _toConsumableArray(values.slice(4)))).prepend.apply(_append, _toConsumableArray(values.slice(0, 4)));

        var _iteratorNormalCompletion2 = true;
        var _didIteratorError2 = false;
        var _iteratorError2 = undefined;

        try {
            for (var _iterator2 = list[Symbol.iterator](), _step2; !(_iteratorNormalCompletion2 = (_step2 = _iterator2.next()).done); _iteratorNormalCompletion2 = true) {
                var val = _step2.value;

                expect(val).to.equal(values.shift());
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
    });

    it('should have correct removeAt', function () {
        var _ref4;

        var theObj = { value: 'val', message: 'hello' };
        var values = ['test', true, null, 1, 2, 'testtest', theObj, 'gg'],
            list = (_ref4 = new LinkedList()).append.apply(_ref4, values),
            removed1 = list.removeAt(1),
            removed2 = list.removeAt(1),
            removed3 = list.removeAt(0),
            removed4 = list.removeAt(list.length - 1);

        expect(list.first).to.equal(1);
        expect(list.last).to.equal(theObj);
        expect(list.length).to.equal(values.length - 4);
        expect([removed1, removed2, removed3, removed4].join()).to.equal([true, null, 'test', 'gg'].join());
    });

    it('should have correct indexing with at(index)', function () {
        var _ref5;

        var values = 'babel src --presets es2015 --out-dir ./build -s -w'.split(' '),
            list = (_ref5 = new LinkedList()).append.apply(_ref5, _toConsumableArray(values)),
            listLength = list.length;

        for (var i = 0, length = values.length; i < length; i += 1) {
            expect(list.at(i)).to.equal(values[i]);
        }

        expect(list.first).to.equal(values[0]);
        expect(list.last).to.equal(values[values.length - 1]);
        expect(list.length).to.equal(listLength);
    });

    it('at(0) should return the same as .first', function () {
        var list = new LinkedList().append(1, 2, 3, 5);

        expect(list.at(0)).to.equal(list.first);
    });

    it('at(list.length - 1) should return the same as .last', function () {
        var list = new LinkedList().append(1, 2, 3, 5);

        expect(list.at(list.length - 1)).to.equal(list.last);
    });

    it('should have correct indexing with at(index, value)', function () {
        var _ref6;

        var values = 'babel src --presets es2015 --out-dir ./build -s -w'.split(' '),
            list = (_ref6 = new LinkedList()).append.apply(_ref6, _toConsumableArray(values)),
            listLength = list.length;

        for (var i = 0, length = values.length; i < length; i += 1) {
            list.at(i, i);
            expect(list.at(i)).to.equal(i);
        }

        expect(list.first).to.equal(0);
        expect(list.last).to.equal(values.length - 1);
        expect(list.length).to.equal(listLength);
    });

    it('should have correct toArray', function () {
        var _ref7;

        var values = ['test', true, null, 1, 2, 'testtest', { value: 'val', message: 'hello' }],
            array = (_ref7 = new LinkedList()).append.apply(_ref7, values).toArray();

        expect(array instanceof Array).to.be.true;
        expect(array.length).to.equal(values.length);
        expect(JSON.stringify(array)).to.equal(JSON.stringify(values));
    });
});

//# sourceMappingURL=tests-compiled.js.map