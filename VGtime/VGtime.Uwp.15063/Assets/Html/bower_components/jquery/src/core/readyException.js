define([
    "../core"
], function (jQuery) {
    "use strict";
    jQuery.readyException = function (error) {
        window.setTimeout(function () {
            throw error;
        });
    };
});
//# sourceMappingURL=readyException.js.map 
//# sourceMappingURL=readyException.js.map