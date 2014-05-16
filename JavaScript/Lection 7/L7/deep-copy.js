function objToString(obj) {
    var str = '';

    for (var p in obj) if (obj.hasOwnProperty(p)) str += obj[p];

    return str;
}

function DeepCopy(obj) {
    var result = {};

    if ((typeof (obj) === 'string') || (typeof (obj) === 'number') || (typeof (obj) === 'boolean')) return obj;

    for (var prop in obj) result[prop] = obj[prop];
     
    return result;
}

var obj1 = { url: "abv.bg" };
    obj2 = DeepCopy(obj1);

    obj2.url = "google.com";
    a = 123;
    b = DeepCopy(a);

console.log(obj1.url);
console.log(obj2.url);
console.log(obj1.url);
console.log(a);
if (typeof (a) === 'string') console.log(objToString(b));
else console.log(b);
console.log(a);