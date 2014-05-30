function hasProperty(obj,propertyToCheck){
    var result = false;
    
    for (var prop in obj) if (prop == propertyToCheck) return true;

    return result;
}

var human = { fName:"Pesho", lName:"Petrov", url: "abv.bg", };
    hasProp = hasProperty(human, "url");
console.log(hasProp);
