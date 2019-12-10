'use strict';

var config = (function () {
    var DEFAULT_PAGE = 'index';
    var DEFAULT_ROOT = 'main';
    return {
// personnal settings
        SITE_NAME: 'Inner Stories',
        SITE_DESCRIPTION: '... les scories d\'une vie de développeur',
        SITE_TITLE: 'Inner Stories: ',
        AUTHORS: 'Bernard Tatin',
        COPYRIGHT: '(c) 2019',
        TOC_TITLE: 'voir aussi...',
        // be carefull with that assignment, Eugene!
        SITE_BASE: "gitio/pages",
// don't touch that!
        DEFAULT_PAGE: DEFAULT_PAGE,
        DEFAULT_ROOT: DEFAULT_ROOT,
        UNDEFINED: undefined,
        current_root: DEFAULT_ROOT,
        current_page: DEFAULT_PAGE
    };
})();
