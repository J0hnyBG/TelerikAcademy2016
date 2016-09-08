"use strict";
function solve() {
    var idGenerator = (function () {
        var currentId = 0;

        function getNextId() {
            currentId += 1;
            return currentId;
        }

        function current() {
            return currentId;
        }

        return {
            getNext: getNextId,
            current: current
        }

    })();

    class Playlist {
        constructor(name) {
            this.name = name;
            this._playList = [];
            this.id = idGenerator.getNext();
        }

        addPlayable(playable) {
            this._playList.push(playable);
            return this;
        }

        getPlayableById(id) {
            let playable = this._playList.filter(x => x.id === id);

            return playable.length === 1 ? playable[0] : null;
        }

        removePlayable(args) {
            let playableId;
            if (typeof args === 'number') {
                playableId = args;
            }
            else {
                playableId = args.id;
            }

            if (playableId < 0) {
                throw new Error("Id is less than zero!")
            }
            let playable = this._playList.filter(x => x.id === playableId);

            if (playable.length != 1) {
                throw new Error("No Playable with this id!")
            }

            this._playList = this._playList.filter(x => x.id != playableId);

            return this;
        }

        listPlayables(page, size) {
            if (this._playList.length < size) {
                return this._playList.length;
            }

            if (page * size > this._playList.length
                || page < 0
                || size <= 0) {
                throw new Error("Cannot list playables!")
            }

            var sortedArray = this._playList.sort(function (a, b) {
                let aTitle = a.title;
                let bTitle = b.title;
                let aId = a.id;
                let bId = b.id;

                if (aTitle == bTitle) {
                    return (aId < bId) ? -1 : (aId > bId) ? 1 : 0;
                }
                else {
                    return (aTitle < bTitle) ? -1 : 1;
                }
            });

            if (this._playList.length <= size) {
                return this._playList.length;
            }

            var startIndex = page * size;
            var endIndex = (page + 1) * size - 1;

            return sortedArray.slice(startIndex, endIndex + 1);
        }

        contains(playable) {
            return this._playList.indexOf(playable) >= 0;
        }

        containsSong(pattern) {
            var songs = this._playList.filter(x => x.title === pattern);

            return songs.length != 0;
        }

    }

    class Player {
        constructor(name) {
            this.name = name;
            this._playLists = [];
            this.id = idGenerator.getNext();
        }

        addPlaylist(playlistToAdd) {
            if (playlistToAdd instanceof Playlist) {
                this._playLists.push(playlistToAdd);
            }
            else {
                throw new Error("Instance is not a Playlist!")
            }

            return this;
        }

        getPlaylistById(id) {
            var playlist = this._playLists.filter(x => x.id === id);

            return playlist.length === 1 ? playlist[0] : null;
        }

        removePlaylist(args) {
            let playlistId;
            if (typeof args === 'number') {
                playlistId = args;
            }
            else {
                playlistId = args.id;
            }

            if (!this._playLists.some(x => x.id === playlistId)) {
                throw new Error("No Playable with this id!")
            }

            this._playLists = this._playLists.filter(x => x.id != playlistId);

            return this;
        }

        listPlayables(page, size) {
            if (this._playLists.length < size) {
                return this._playLists.length;
            }

            if (page * size > this._playLists.length
                || page < 0
                || size <= 0) {
                throw new Error("Cannot list playables!")
            }

            var sortedArray = this._playLists.sort(function (a, b) {
                let aTitle = a.name;
                let bTitle = b.name;
                let aId = a.id;
                let bId = b.id;

                if (aTitle == bTitle) {
                    return (aId < bId) ? -1 : (aId > bId) ? 1 : 0;
                }
                else {
                    return (aTitle < bTitle) ? -1 : 1;
                }
            });

            if (this._playLists.length <= size) {
                return this._playLists.length;
            }

            var startIndex = page * size;
            var endIndex = (page + 1) * size - 1;

            return sortedArray.slice(startIndex, endIndex + 1);
        }

        contains(playable, playlist) {
            return playlist.contains(playable);
        }

        search(pattern) {
            var result = [];
            for (var playlist of this._playLists) {
                if (playlist.containsSong(pattern)) {
                    result.push(
                        {
                            id: playlist.id,
                            title: playlist.name
                        })
                }
            }
            return result;
        }
    }
    class Playable {
        constructor(title, author) {
            this.id = idGenerator.getNextId();
            this.title = title;
            this.author = author;
        }

        play() {
            return `${this.id}. ${this.title} - ${this.author}`
        }
    }

    class Audio extends Playable {
        constructor(title, author, length) {
            super(title, author);
            if (length > 0) {
                this.length = length;
            }
            else {
                throw new Error("Length cannot be less than zero!")
            }
        }

        play() {
            return super.play() + ' - ' + this.length;
        }
    }

    class Video extends Playable {
        constructor(title, author, imdbRating) {
            super(title, author);
            if (imdbRating < 1 || 5 < imdbRating) {
                throw new Error("Invalid IMDB rating!")
            }
            this.imdbRating = imdbRating;
        }

        play() {
            return super.play() + ' - ' + this.imdbRating;
        }
    }

    return {
        getPlayer: function (name) {
            return new Player(name);
        },
        getPlaylist: function (name) {
            return new Playlist(name);
        },
        getAudio: function (title, author, length) {
            return new Audio(title, author, length);
        },
        getVideo: function (title, author, imdbRating) {
            return new Video(title, author, imdbRating);
        }
    };
}

module.exports = solve;