﻿function query() {
    var querySelectorAllShim = (function () {
        function _toArray(arrayLike) {
            var result = [];

            for (var i = 0, length = arrayLike.length; i < length; i++) result.push(arrayLike[i]);
                
            return result;
        }

        function _isParentOf(self, element) {
            while (element.parentNode) {
                if (element.parentNode === self) return true;
                element = element.parentNode;
            }

            return false
        }

        function _getById(selector, context) {
            var element = document.getElementById(selector.substr(1));

            if (_isParentOf(context, element)) return [element];

            return [];
        }

        function _get(selector, context) {
            if (selector.match(/^#/)) return _getById(selector, context);

            if (selector.match(/^\./)) return _toArray(context.getElementsByClassName(selector.substr(1)));

            return _toArray(context.getElementsByTagName(selector));
        }

        function _querySelectorAllShim(tokens, result) {
            if (tokens.length === 0) return result;

            var token = tokens.shift()
                next = []

            for (var i = 0; i < result.length; i++) Array.prototype.push.apply(next, _get(token, result[i]));

            return _querySelectorAllShim(tokens, next);
        }

        return function (selector) { return _querySelectorAllShim(selector.split(/\s+/), [this]) }
    }())

    document.querySelectorAll = querySelectorAllShim;
    Element.prototype.querySelectorAll = querySelectorAllShim;

    function querySelectorShim(selector) { return document.querySelectorAll(selector)[0] }

    document.querySelector = querySelectorShim;
    Element.prototype.querySelector = querySelectorShim;

    console.log(document.querySelectorAll('body div'));
    console.log(document.body.querySelectorAll('div'));
}