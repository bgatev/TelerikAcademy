function inputImage() {
    var svgNS1 = 'http://www.w3.org/2000/svg';

    var win8 = createImage(svgNS1, 0, 0, 1280, 720, 'win8.jpg');
    document.getElementById('my-svg1').appendChild(win8);
};

function createImage(svg, x, y, width, height, imageFile) {
    var imageElement = document.createElementNS(svg, 'image');

    imageElement.setAttributeNS(svg, 'x', x);
    imageElement.setAttributeNS(svg, 'y', y);
    imageElement.setAttributeNS(svg, 'width', width);
    imageElement.setAttributeNS(svg, 'height', height);
    imageElement.setAttributeNS(svg, 'xlink:href', imageFile);
    imageElement.setAttributeNS(svg, 'visibility', 'visible');

    return imageElement;
}
