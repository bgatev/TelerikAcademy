function changeColors() {
    var areaFontColor = document.getElementById('areaFontColor');
    var areaBackgroundColor = document.getElementById('areaBackgroundColor');
    var myTextArea = document.getElementById('MyText');

    myTextArea.style.color = areaFontColor.value;
    myTextArea.style.backgroundColor = areaBackgroundColor.value;
}