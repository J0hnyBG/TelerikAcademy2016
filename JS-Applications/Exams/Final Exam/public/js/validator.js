let validator = {
    stringLength: function(str, min, max) {
        if(str.length < min || str.length > max) {
            return false;
        }
        return true;
    },
    username: function(username) {
        return this.stringLength(username, 6, 30) && /^[A-Za-z0-9_.]+$/.test(username);
    },
    password: function(pass) {
        return this.stringLength(pass, 6, 30) && /^[A-Za-z0-9]+$/.test(pass);
    }
}