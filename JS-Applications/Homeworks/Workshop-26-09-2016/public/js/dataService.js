/* globals requester */
var dataService = {
    cookies: () => {
        
        return requester.getJSON('api/cookies')
    }
}