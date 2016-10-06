mocha.setup('bdd');

const {expect, assert} = chai;

const AUTH_KEY = "SOME_AUTH_KEY";
const user = {
    username: 'SOME_USERNAME',
    password: 'SOME_PASSHASH'
};
const cookie = {
    img: 'SOME COOKIE IMG',
    text: 'SOME COOKIE TEXT',
    likes: 0,
    dislikes: 0,
    id: 42
};
const HTTP_HEADER_KEY = "x-auth-key",
    KEY_STORAGE_USERNAME = "goodmats-username",
    KEY_STORAGE_AUTH_KEY = "goodmats-authKey";

const typeOfPromise = 'Promise',
    typeOfFunction = 'function';
const requesterInstance = requester.getInstance($);
const dataServiceInstance = dataService.getInstance(requesterInstance);

describe('dataService.js tests', function () {
    describe('login tests', function () {
        const result = {
            result: []
        };

        beforeEach(function () {
            sinon.stub(requesterInstance, 'putJSON')
                .returns(new Promise((resolve, reject) => {
                    resolve({
                        result: {
                            username: user.username,
                            authKey: AUTH_KEY
                        }
                    });
                }));
            localStorage.clear();
        });
        afterEach(function () {
            requesterInstance.putJSON.restore();
            localStorage.clear();
        });

        it('Expect login to exist and be a function', function () {
            expect(dataServiceInstance.login).to.exist;
            expect(dataServiceInstance.login).to.be.a(typeOfFunction);
        });

        it('Expect login to make exactly one putJSON call', function (done) {
            dataServiceInstance.login(user)
                .then(() => {
                    expect(requesterInstance.putJSON.calledOnce).to.be.true;
                })
                .then(done, done);
        });

        it('Expect login to call putJSON with correct parameters.', function (done) {
            dataServiceInstance.login(user)
                .then(obj => {
                    const actualUrl = requesterInstance.putJSON
                        .firstCall
                        .args[0];

                    const actualUser = requesterInstance.putJSON
                        .firstCall
                        .args[1];

                    expect(actualUrl).to.equal('./api/users/auth/');
                    expect(actualUser).to.equal(user);
                })
                .then(done, done);
        });
        it('Expect login to set localStorage keys correctly', function (done) {
            dataServiceInstance.login(user)
                .then(res => {
                    expect(localStorage.getItem(KEY_STORAGE_USERNAME)).to.equal(user.username);
                    expect(localStorage.getItem(KEY_STORAGE_AUTH_KEY)).to.equal(AUTH_KEY);
                }).then(done, done);
        })
    });


    describe('register tests', function () {
        beforeEach(function () {
            sinon.stub(requesterInstance, 'postJSON')
                .returns(new Promise((resolve, reject) => {
                    resolve(user);
                }));
        });
        afterEach(function () {
            requesterInstance.postJSON.restore();
        });

        it('Expect register to exist and be a function', function () {
            expect(dataServiceInstance.register).to.exist;
            expect(dataServiceInstance.register).to.be.a(typeOfFunction);
        });

        it('Expect register to call requester.postJSON exactly once', function (done) {
            dataServiceInstance.register(user)
                .then(() => {
                    expect(requesterInstance.postJSON.calledOnce).to.be.true;
                })
                .then(done, done);
        });

        it('Expect register to call requester.postJSON with correct parameters', function (done) {
            dataServiceInstance.register(user)
                .then(() => {
                    const actualUrl = requesterInstance.postJSON
                        .firstCall
                        .args[0];

                    const actualBody = requesterInstance.postJSON
                        .firstCall
                        .args[1];

                    expect(actualUrl).to.equal('./api/users');
                    expect(actualBody).to.equal(user);
                })
                .then(done, done);
        });
    });

    describe('isLoggedIn tests', function () {
        it('Expect isLoggedIn to exist and be a function', function () {
            expect(dataServiceInstance.isLoggedIn).to.exist;
            expect(dataServiceInstance.isLoggedIn).to.be.a(typeOfFunction);
        });

        it('Expect isLoggedIn to return a promise', function () {
            let actual = dataServiceInstance.isLoggedIn();
            expect(actual).to.be.a(typeOfPromise);
        });

        it('Expect isLoggedIn to return true when localStorage has auth key', function (done) {
            localStorage.setItem(KEY_STORAGE_AUTH_KEY, "LoggedIn");

            dataServiceInstance.isLoggedIn()
                .then(actual => {
                    expect(actual).to.be.true;
                })
                .then(done, done);
        });

        it('Expect isLoggedIn to return false when localStorage doesnt have auth key', function (done) {
            localStorage.removeItem(KEY_STORAGE_AUTH_KEY);

            dataServiceInstance.isLoggedIn()
                .then(actual => {
                    expect(actual).to.be.false;
                })
                .then(done, done);
        });
    });

    describe('logout tests', function () {
        it('Expect logout to exist and be a function', function () {
            expect(dataServiceInstance.logout).to.exist;
            expect(dataServiceInstance.logout).to.be.a(typeOfFunction);
        });

        it('Expect logout to return a promise', function () {
            let actual = dataServiceInstance.logout();
            expect(actual).to.be.a(typeOfPromise);
        });

        it('Expect logout to remove localStorage keys', function (done) {
            localStorage.setItem(KEY_STORAGE_AUTH_KEY, AUTH_KEY);
            localStorage.setItem(KEY_STORAGE_USERNAME, user.username);

            dataServiceInstance.logout().then(res => {
                expect(localStorage.getItem(KEY_STORAGE_AUTH_KEY)).to.be.null;
                expect(localStorage.getItem(KEY_STORAGE_USERNAME)).to.be.null;
            })
                .then(done, done);
        });
    });

    describe('getAllMaterials tests', function () {
        const result = {
            result: []
        };

        beforeEach(function () {
            sinon.stub(requesterInstance, 'get')
                .returns(new Promise((resolve, reject) => {
                    resolve(result);
                }));
        });
        afterEach(function () {
            requesterInstance.get.restore();
        });

        it('Expect getAllMaterials to exist and be a function', function () {
            expect(dataServiceInstance.getAllMaterials).to.exist;
            expect(dataServiceInstance.getAllMaterials).to.be.a(typeOfFunction);
        });

        it('Expect getAllMaterials to return a promise', function () {
            let actual = dataServiceInstance.getAllMaterials();
            expect(actual).to.be.a(typeOfPromise);
        });

        it('Expect getAllMaterials to return correct result', function (done) {
            dataServiceInstance.getAllMaterials()
                .then(obj => {
                    expect(obj).to.eql(result.result);
                })
                .then(done, done);
        });

        it('Expect getAllMaterials to call requester.get with correct parameters', function (done) {
            dataServiceInstance.getAllMaterials(user)
                .then(() => {
                    const actualUrl = requesterInstance.get
                        .firstCall
                        .args[0];

                    expect(actualUrl).to.equal('./api/materials');
                })
                .then(done, done);
        });
    });

    describe('materialById tests', function () {
        const result = {
            result: []
        };

        beforeEach(function () {
            sinon.stub(requesterInstance, 'get')
                .returns(new Promise((resolve, reject) => {
                    resolve(result);
                }));
        });
        afterEach(function () {
            requesterInstance.get.restore();
        });

        it('Expect materialById to exist and be a function', function () {
            expect(dataServiceInstance.materialById).to.exist;
            expect(dataServiceInstance.materialById).to.be.a(typeOfFunction);
        });

        it('Expect materialById to return a promise', function () {
            let actual = dataServiceInstance.materialById("id");
            expect(actual).to.be.a(typeOfPromise);
        });

        it('Expect materialById to return correct result', function (done) {
            dataServiceInstance.materialById("id")
                .then(obj => {
                    expect(obj).to.eql(result.result);
                })
                .then(done, done);
        });

        it('Expect materialById to call requester.get with correct parameters', function (done) {
            const id = "564654das56dsa65d4as5d6sa4s";

            dataServiceInstance.materialById(id)
                .then(() => {
                    const actualUrl = requesterInstance.get
                        .firstCall
                        .args[0];

                    expect(actualUrl).to.equal('./api/materials/' + id);
                })
                .then(done, done);
        });
    });

    describe('search tests', function () {
        const result = {
            result: []
        };

        beforeEach(function () {
            sinon.stub(requesterInstance, 'get')
                .returns(new Promise((resolve, reject) => {
                    resolve(result);
                }));
        });
        afterEach(function () {
            requesterInstance.get.restore();
        });

        it('Expect search to exist and be a function', function () {
            expect(dataServiceInstance.search).to.exist;
            expect(dataServiceInstance.search).to.be.a(typeOfFunction);
        });

        it('Expect search to return a promise', function () {
            let actual = dataServiceInstance.search("id");
            expect(actual).to.be.a(typeOfPromise);
        });

        it('Expect search to return correct result', function (done) {
            dataServiceInstance.search("id")
                .then(obj => {
                    expect(obj).to.eql(result.result);
                })
                .then(done, done);
        });

        it('Expect search to call requester.get with correct parameters', function (done) {
            const phrase = "564654das56dsa65d4as5d6sa4s";

            dataServiceInstance.search(phrase)
                .then(() => {
                    const actualUrl = requesterInstance.get
                        .firstCall
                        .args[0];

                    expect(actualUrl).to.equal('./api/materials?filter=' + phrase);
                })
                .then(done, done);
        });
    });

    describe('user tests', function () {
        const result = {
            result: []
        };

        beforeEach(function () {
            sinon.stub(requesterInstance, 'get')
                .returns(new Promise((resolve, reject) => {
                    resolve(result);
                }));
        });
        afterEach(function () {
            requesterInstance.get.restore();
        });

        it('Expect user to exist and be a function', function () {
            expect(dataServiceInstance.user).to.exist;
            expect(dataServiceInstance.user).to.be.a(typeOfFunction);
        });

        it('Expect user to return a promise', function () {
            let actual = dataServiceInstance.user(user.username);
            expect(actual).to.be.a(typeOfPromise);
        });

        it('Expect user to return correct result', function (done) {
            dataServiceInstance.user(user.username)
                .then(obj => {
                    expect(obj).to.eql(result.result);
                })
                .then(done, done);
        });

        it('Expect user to call requester.get with correct parameters', function (done) {
            const userName = "pesho123";

            dataServiceInstance.user(userName)
                .then(() => {
                    const actualUrl = requesterInstance.get
                        .firstCall
                        .args[0];

                    expect(actualUrl).to.equal('./api/profiles/' + userName);
                })
                .then(done, done);
        });
    });
    describe('addMaterial tests', function () {
        const result = {
            result: []
        };

        beforeEach(function () {
            localStorage.setItem(KEY_STORAGE_AUTH_KEY, AUTH_KEY);
            localStorage.setItem(KEY_STORAGE_USERNAME, user.username);

            sinon.stub(requesterInstance, 'postJSON')
                .returns(new Promise((resolve, reject) => {
                    resolve(result);
                }));
        });
        afterEach(function () {
            localStorage.removeItem(KEY_STORAGE_AUTH_KEY);
            localStorage.removeItem(KEY_STORAGE_USERNAME);
            requesterInstance.postJSON.restore();
        });

        it('Expect addMaterial to exist and be a function', function () {
            expect(dataServiceInstance.addMaterial).to.exist;
            expect(dataServiceInstance.addMaterial).to.be.a(typeOfFunction);
        });

        it('Expect addMaterial to return a promise', function () {
            let actual = dataServiceInstance.addMaterial(result);
            expect(actual).to.be.a(typeOfPromise);
        });

        it('Expect addMaterial to return correct result', function (done) {
            dataServiceInstance.addMaterial(result)
                .then(obj => {
                    expect(obj).to.eql(result);
                })
                .then(done, done);
        });

        it('Expect addMaterial to call requester.postJSON with correct parameters', function (done) {
            const expectedHeaders = {
                [HTTP_HEADER_KEY]: AUTH_KEY
            };

            dataServiceInstance.addMaterial(result)
                .then(() => {
                    const actualUrl = requesterInstance.postJSON
                        .firstCall
                        .args[0];

                    const actualBody = requesterInstance.postJSON
                        .firstCall
                        .args[1];
                    const actualHeaders = requesterInstance.postJSON
                        .firstCall
                        .args[2];

                    expect(actualUrl).to.equal('./api/materials/');
                    expect(actualBody).to.equal(result);
                    expect(actualHeaders.toString()).to.equal(expectedHeaders.toString());
                })
                .then(done, done);
        });
    });

    describe('addComment tests', function () {
        const result = {
            result: {
                id: "3",
                text: "COMMENT"
            }
        };

        beforeEach(function () {
            localStorage.setItem(KEY_STORAGE_AUTH_KEY, AUTH_KEY);
            localStorage.setItem(KEY_STORAGE_USERNAME, user.username);

            sinon.stub(requesterInstance, 'putJSON')
                .returns(new Promise((resolve, reject) => {
                    resolve(result);
                }));
        });
        afterEach(function () {
            localStorage.removeItem(KEY_STORAGE_AUTH_KEY);
            localStorage.removeItem(KEY_STORAGE_USERNAME);
            requesterInstance.putJSON.restore();
        });

        it('Expect addComment exist and be a function', function () {
            expect(dataServiceInstance.addComment).to.exist;
            expect(dataServiceInstance.addComment).to.be.a(typeOfFunction);
        });

        it('Expect addComment to return a promise', function () {
            let actual = dataServiceInstance.addComment(result.result.id, result.result.text);
            expect(actual).to.be.a(typeOfPromise);
        });

        it('Expect addComment to return correct result', function (done) {
            dataServiceInstance.addComment(result.result.id, result.result.text)
                .then(obj => {
                    expect(obj).to.eql(result.result);
                })
                .then(done, done);
        });

        it('Expect addComment to call requester.postJSON with correct parameters', function (done) {
            const expectedHeaders = {
                [HTTP_HEADER_KEY]: AUTH_KEY
            };
            const expectedBody = {'commentText': result.result.text};

            dataServiceInstance.addComment(result.result.id, result.result.text)
                .then(() => {
                    const actualUrl = requesterInstance.putJSON
                        .firstCall
                        .args[0];

                    const actualBody = requesterInstance.putJSON
                        .firstCall
                        .args[1];
                    const actualHeaders = requesterInstance.putJSON
                        .firstCall
                        .args[2];

                    expect(actualUrl).to.equal(`./api/materials/${result.result.id}/comments`);
                    expect(JSON.stringify(actualBody)).to.equal(JSON.stringify(expectedBody));
                    expect(actualHeaders.toString()).to.equal(expectedHeaders.toString());
                })
                .then(done, done);
        });
    });

    describe('setMaterialStatus tests', function () {
        const result = {
            result: {
                id: "3",
                category: "CATEGORY"
            }
        };

        beforeEach(function () {
            localStorage.setItem(KEY_STORAGE_AUTH_KEY, AUTH_KEY);
            localStorage.setItem(KEY_STORAGE_USERNAME, user.username);

            sinon.stub(requesterInstance, 'putJSON')
                .returns(new Promise((resolve, reject) => {
                    resolve(result);
                }));
        });
        afterEach(function () {
            localStorage.removeItem(KEY_STORAGE_AUTH_KEY);
            localStorage.removeItem(KEY_STORAGE_USERNAME);
            requesterInstance.putJSON.restore();
        });

        it('Expect setMaterialStatus exist and be a function', function () {
            expect(dataServiceInstance.setMaterialStatus).to.exist;
            expect(dataServiceInstance.setMaterialStatus).to.be.a(typeOfFunction);
        });

        it('Expect setMaterialStatus to return a promise', function () {
            let actual = dataServiceInstance.setMaterialStatus(result.result.category, result.result.id);
            expect(actual).to.be.a(typeOfPromise);
        });

        it('Expect setMaterialStatus to return correct result', function (done) {
            dataServiceInstance.setMaterialStatus(result.result.category, result.result.id)
                .then(obj => {
                    expect(obj).to.eql(result.result);
                })
                .then(done, done);
        });

        it('Expect setMaterialStatus to call requester.postJSON with correct parameters', function (done) {
            const expectedHeaders = {
                [HTTP_HEADER_KEY]: AUTH_KEY
            };

            const expectedBody = {
                "id": "3",
                "category": "CATEGORY"
            };

            dataServiceInstance.setMaterialStatus(result.result.category, result.result.id)
                .then(() => {
                    const actualUrl = requesterInstance.putJSON
                        .firstCall
                        .args[0];

                    const actualBody = requesterInstance.putJSON
                        .firstCall
                        .args[1];
                    const actualHeaders = requesterInstance.putJSON
                        .firstCall
                        .args[2];

                    expect(actualUrl).to.equal(`./api/user-materials`);
                    expect(JSON.stringify(actualBody)).to.equal(JSON.stringify(expectedBody));
                    expect(actualHeaders.toString()).to.equal(expectedHeaders.toString());
                })
                .then(done, done);
        });
    });

});

mocha.run();