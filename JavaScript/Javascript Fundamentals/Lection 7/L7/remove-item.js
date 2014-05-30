if (!Array.prototype.remove) {
    Array.prototype.remove = function (value) {
        var arrayLength = this.length;
            tempArray = [];
        for (var i = 0; i < arrayLength; i++) {
            if (this[i] !== value) {
                tempArray.push(this[i]);
            }
        }
        
        var tempLength = tempArray.length;

        for (var i = 0; i < tempLength; i++) this[i] = tempArray[i];
        for (var i = tempLength; i < arrayLength; i++) this.pop();

        return this;
    }
}

var arr = [1, 2, 1, 4, 1, 3, 4, 1, 111, 3, 2, 1, "1"];

console.log(arr);
arr.remove(1);
console.log(arr);