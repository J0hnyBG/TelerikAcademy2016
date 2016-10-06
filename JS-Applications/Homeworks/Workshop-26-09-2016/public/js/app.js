/* globals Navigo controllers*/

let router = new Navigo(null, true);

router.on('home', controllers.home)
    .on('my-cookie', controllers.myCookie)
    .on(() => {
            router.navigate('home');
        }
    )
    .resolve();