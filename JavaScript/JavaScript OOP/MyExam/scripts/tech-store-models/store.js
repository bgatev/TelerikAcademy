//PLEASE TEST with Firefox !!!
define(['tech-store-models/item'], function (Item) {
    'use strict';
    var Store;
    Store = (function () {

        function Store(name) {
            if (name.length < 6 || name.length > 30) throw Error("Invalid Store Name");
            else this._name = name;

            this._itemsList = [];
        }

        function dynamicSort(property) {
            var sortOrder = 1;

            if (property[0] === "-") {
                sortOrder = -1;
                property = property.substr(1);
            }

            return function (a, b) {
                var result = (a[property] < b[property]) ? -1 : (a[property] > b[property]) ? 1 : 0;
                return result * sortOrder;
            }
        }

        Store.prototype = {
            addItem: function (item) {
                if (item instanceof Item) this._itemsList.push(item);
                else throw Error("Invalid Item");

                return this;
            },
            getAll: function () {
                var tempList = this._itemsList.slice(0);

                tempList.sort(dynamicSort("_name"));

                return tempList;
            },
            getSmartPhones: function () {
                var tempList = this.getAll();
                var result = [];

                for (var i = 0, len = tempList.length; i < len; i++) {
                    if (tempList[i]._type == "smart-phone") result.push(tempList[i]);
                }

                return result;
            },
            getMobiles: function () {
                var tempList = this.getAll();
                var result = [];

                for (var i = 0, len = tempList.length; i < len; i++) {
                    if (tempList[i]._type == "smart-phone" || tempList[i]._type == "tablet") result.push(tempList[i]);
                }

                return result;
            },
            getComputers: function () {
                var tempList = this.getAll();
                var result = [];

                for (var i = 0, len = tempList.length; i < len; i++) {
                    if (tempList[i]._type == "pc" || tempList[i]._type == "notebook") result.push(tempList[i]);
                }

                return result;
            },
            filterItemsByType: function (filterType) {
                var tempList = this.getAll();
                var result = [];

                for (var i = 0, len = tempList.length; i < len; i++) {
                    if (tempList[i]._type === filterType) result.push(tempList[i]);
                }

                return result;
            },
            filterItemsByPrice: function (options) {
                var min, max;

                if (options != undefined) {
                    min = options.min || 0;
                    max = options.max || Number.MAX_VALUE;
                }
                else {
                    min = 0;
                    max = Number.MAX_VALUE;
                }

                var tempList = this._itemsList.slice(0);
                var result = [];

                tempList.sort(dynamicSort("_price"));
                for (var i = 0, len = tempList.length; i < len; i++) {
                    var currentItemPrice = tempList[i]._price;

                    if (currentItemPrice > min && currentItemPrice < max) result.push(tempList[i]);
                }

                return result;
            },
            countItemsByType: function () {
                var tempList = this._itemsList.slice(0);
                var result = [];

                tempList.sort(dynamicSort("_type"));
                for (var i = 0, len = tempList.length; i < len; i++) {
                    var currentItemType = tempList[i]._type;

                    if (result[currentItemType] == undefined) result[currentItemType] = 1;
                    else result[currentItemType]++;
                }

                return result;
            },
            filterItemsByName: function (partOfName) {
                var tempList = this.getAll();
                var result = [];

                for (var i = 0, len = tempList.length; i < len; i++) {
                    var index = tempList[i]._name.toLowerCase().indexOf(partOfName.toLowerCase());

                    if (index > -1) result.push(tempList[i]);
                }

                return result;
            }   
        };

        return Store;
    })();
    return Store;
});