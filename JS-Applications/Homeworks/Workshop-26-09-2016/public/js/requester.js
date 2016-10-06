/* globals $*/

var requester = {
    getJSON: (url) => {
        return new Promise((resolve, reject) =>
            $.ajax({
                url: url,
                method: 'GET',
                contentType: 'application/json',
                success: (response) => {
                    resolve(response);
                },
            })
        );
    }
}