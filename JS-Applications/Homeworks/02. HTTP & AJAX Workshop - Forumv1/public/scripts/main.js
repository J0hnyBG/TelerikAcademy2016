/*globals Navigo console, controllers*/
$(() => { // on document ready
    const GLYPH_UP = 'glyphicon-chevron-up',
        GLYPH_DOWN = 'glyphicon-chevron-down',
        root = $('#root'),
        navbar = root.find('nav.navbar'),
        contentContainer = root.find('#content');

    var router = new Navigo(null, true);

    router.on('gallery', controllers.gallery)
        .on('threads', controllers.threads)
        .on('threads/:id', controllers.threadById)
        .resolve();

    navbar.on('click', 'li', (ev) => {
        let $target = $(ev.target);
        $target.parents('nav').find('li').removeClass('active');
        $target.parents('li').addClass('active');
    });

    contentContainer.on('click', '#btn-add-thread', (ev) => {
        let $target = $(ev.target);
        let title = $target.parents('form').find('input#input-add-thread').val() || null;

        controllers.addThread(title);
    });

    contentContainer.on('click', '.btn-add-message', (ev) => {
        let $target = $(ev.target),
            $container = $target.parents('.container-messages'),
            thId = $container.attr('data-thread-id'),
            msg = $container.find('.input-add-message').val();

        controllers.addMessage(thId, msg);
    });

    contentContainer.on('click', '.btn-close-msg', (ev) => {
        $(ev.target).parents('.container-messages').remove();
    });

    contentContainer.on('click', '.btn-collapse-msg', (ev) => {
        let $target = $(ev.target);
        if ($target.hasClass(GLYPH_UP)) {
            $target.removeClass(GLYPH_UP).addClass(GLYPH_DOWN);
        } else {
            $target.removeClass(GLYPH_DOWN).addClass(GLYPH_UP);
        }

        $target.parents('.container-messages').find('.messages').toggle();
    });

    // start login/logout
    navbar.on('click', '#btn-login', (ev) => {
        controllers.login();
    });
    navbar.on('click', '#btn-logout', (ev) => {
        controllers.logout();
    });
    // end login/logout
});

