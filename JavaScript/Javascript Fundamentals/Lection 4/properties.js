function FindProperties(object) {
    var allProperties = "";

    for (var property in object) {
        allProperties += property + " ";
    }

    var propertiesArray = allProperties.split(" ");

    propertiesArray.sort();
    console.log("Min: " + propertiesArray[1]);
    console.log("Max: " + propertiesArray[propertiesArray.length - 1]);
}

FindProperties(document);
FindProperties(window);
FindProperties(navigator);