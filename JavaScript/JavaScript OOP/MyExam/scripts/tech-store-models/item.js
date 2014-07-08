//PLEASE TEST with Firefox !!!
define([], function () {
    'use strict';
    var Item;
    Item = (function () {
        var typeValues = ['accessory', 'smart-phone', 'notebook', 'pc', 'tablet'];

        function Item(type, name, price) {
            var index = typeValues.indexOf(type);

            if (index > -1) this._type = type;
            else throw Error("Invalid Item type");

            if (name.length < 6 || name.length > 40) throw Error("Invalid Item Name");
            this._name = name;
            
            if (price < 0) throw Error("Invalid Price");
            else this._price = price;
        }
        return Item;
    })();
    return Item;
});