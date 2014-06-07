﻿window.onload = function () {
    var svgNS = 'http://www.w3.org/2000/svg';

    var M = createText(svgNS, 50, 100, 40, "bold", "Arial", "M", "darkgrey");
    var E = createText(svgNS, 50, 155, 40, "bold", "Arial", "E","grey");
    var A = createText(svgNS, 50, 210, 40, "bold", "Arial", "A", "red");
    var N = createText(svgNS, 50, 265, 40, "bold", "Arial", "N", "green");
    var express = createText(svgNS, 172, 150, 16, "normal", "Arial", "express", "white");

    document.getElementById('my-svg').appendChild(M);
    document.getElementById('my-svg').appendChild(E);
    document.getElementById('my-svg').appendChild(A);
    document.getElementById('my-svg').appendChild(N);

    var circle1 = createCircle(svgNS, 200, 100, 50, "darkgrey");
    var circle2 = createCircle(svgNS, 200, 150, 50, "grey");
    var circle3 = createCircle(svgNS, 200, 200, 50, "red");
    var circle4 = createCircle(svgNS, 200, 250, 50, "green");

    var transformPathLeaf = "translate(155, 150) scale(0.1,-0.1)";
    var leafPath = "M396 853 c16 -61 9 -80 -44 -131 -52 -48 -52 -49 -52 -109 0 -79 -19 -94 -111 -87 -74 5 -135 20 -144 34 -3 6 -12 10 -18 10 -7 -1 7 -18 29 -38 44 -39 95 -142 98 -195 1 -21 12 -37 40 -58 22 -16 47 -29 56 -29 21 0 40 -20 40 -42 0 -11 11 -23 26 -28 37 -14 116 -15 141 -1 16 8 23 8 26 -2 3 -6 6 -1 6 12 1 20 4 22 13 13 21 -21 71 -13 133 21 50 27 61 37 63 62 3 20 23 50 64 93 50 52 59 66 53 85 -5 12 -8 44 -8 70 0 38 7 58 31 93 33 47 30 56 -9 25 -13 -10 -49 -24 -79 -30 -30 -7 -70 -17 -88 -22 -42 -13 -71 -3 -77 27 -3 13 -8 36 -11 52 -6 29 -31 62 -46 62 -20 0 -102 77 -115 107 -16 40 -26 43 -17 6z";
    var leaf = createPath(svgNS, transformPathLeaf, leafPath, "green");
    
    var transformPathFerrari = "translate(165,260) scale(0.08,-0.08)"
    var ferrariPath = "M0 590 l0 -590 450 0 450 0 0 590 0 590 -450 0 -450 0 0 -590z m524 519 c-5 -9 90 -20 112 -13 14 4 15 3 6 -4 -17 -12 67 -25 106 -16 19 4 23 3 13 -4 -10 -7 1 -12 38 -17 46 -6 70 -19 59 -30 -2 -3 -96 11 -208 31 l-204 36 -181 -32 c-99 -18 -190 -34 -203 -37 -15 -4 -22 -1 -22 10 0 11 15 17 56 23 39 4 52 9 43 16 -10 6 -7 7 8 3 25 -7 173 15 173 26 0 3 12 4 28 2 16 -3 22 -1 15 4 -6 4 28 8 77 8 48 0 86 -3 84 -6z m144 -114 c38 -7 90 -22 118 -32 l49 -19 3 -139 c4 -213 -33 -356 -130 -507 -74 -114 -234 -259 -271 -245 -36 14 -145 108 -192 166 -139 173 -195 346 -195 607 l0 114 36 15 c146 61 400 79 582 40z";
    var ferrariPath1 = "M404 965 c-14 -11 -16 -15 -4 -15 12 -1 12 -3 -2 -14 -10 -7 -16 -15 -13 -18 3 -2 -5 -4 -17 -4 -16 1 -23 -5 -23 -19 0 -16 8 -21 38 -23 20 -2 37 -9 37 -15 0 -21 -37 -74 -68 -95 -30 -22 -30 -22 -55 -2 -28 23 -56 26 -59 8 -2 -24 -5 -33 -15 -58 -18 -45 -23 -79 -13 -85 5 -3 10 -2 10 3 0 5 6 9 13 9 8 0 12 -9 10 -21 -4 -23 31 -75 42 -64 4 4 -2 27 -14 51 -21 44 -26 67 -15 67 4 0 23 -10 43 -22 35 -21 53 -36 134 -112 22 -20 42 -34 46 -32 4 3 8 -5 8 -16 2 -17 -5 -13 -32 18 -19 21 -37 35 -40 32 -4 -4 3 -28 14 -54 12 -26 19 -49 16 -52 -3 -3 -28 0 -56 6 -71 17 -85 16 -69 -3 7 -8 27 -15 44 -15 17 -1 48 -7 68 -14 25 -9 40 -10 47 -3 7 7 12 5 17 -6 4 -12 -7 -32 -35 -62 -22 -24 -41 -49 -41 -55 0 -17 19 -11 38 11 9 12 23 27 30 34 15 17 16 29 0 19 -7 -4 -8 -3 -4 4 4 6 13 9 20 6 21 -8 39 21 27 44 -9 16 -4 26 24 55 19 20 35 44 36 54 0 11 4 6 9 -10 5 -16 6 -36 3 -45 -4 -13 -1 -12 10 3 9 11 17 29 17 40 l1 20 10 -20 c8 -17 9 -16 5 8 -2 17 2 31 10 34 18 7 32 53 27 89 -3 18 1 42 7 55 13 24 13 24 -8 6 -20 -18 -20 -18 -15 2 3 12 9 24 14 27 5 3 9 10 9 16 0 5 -9 0 -20 -13 -21 -26 -27 -11 -10 22 6 10 8 19 6 19 -3 0 -12 -12 -20 -27 -11 -23 -12 -39 -3 -81 12 -55 6 -76 -24 -95 -10 -6 -28 5 -67 43 -29 28 -57 48 -61 45 -10 -5 -25 11 -34 38 -10 28 3 20 14 -9 5 -15 12 -24 15 -21 3 3 0 15 -6 27 -15 28 -5 38 22 21 11 -7 17 -8 14 -2 -4 5 -1 13 5 17 9 5 7 11 -6 21 -15 10 -15 13 -4 13 29 0 40 22 22 42 -15 17 -15 18 -1 13 17 -7 19 9 4 34 -5 8 -3 16 5 22 12 7 12 9 0 9 -11 0 -10 4 4 14 18 13 18 14 -3 25 -13 7 -21 15 -18 19 2 4 -16 17 -40 28 -27 14 -44 18 -44 10 0 -7 -3 -7 -8 1 -6 10 -12 10 -28 -2z"
    var ferrari = createPath(svgNS, transformPathFerrari, ferrariPath, "yellow");
    var ferrari1 = createPath(svgNS, transformPathFerrari, ferrariPath1, "yellow");
    
    var transfromPathNodeJS = "translate(157,265) scale(0.1,-0.1)";
    var transfromPathNodeJS3 = "translate(180,260) scale(0.1,-0.1)";
    var nodejsPath = "M590 280 c0 -47 -3 -58 -14 -54 -8 3 -33 -4 -56 -16 -41 -21 -41 -21 -38 -71 3 -48 6 -52 43 -74 l40 -24 43 26 42 25 0 108 c0 101 -2 110 -22 124 -12 9 -26 16 -30 16 -5 0 -8 -27 -8 -60z"
    var nodejsPath1 = "M73 211 c-43 -26 -43 -26 -43 -83 0 -60 6 -66 41 -48 13 7 19 21 19 44 0 22 6 36 16 40 24 9 46 -13 40 -40 -4 -16 0 -27 16 -38 35 -25 39 -20 36 44 -3 59 -4 61 -43 84 l-40 23 -42 -26z"
    var nodejsPath2 = "M738 209 c-36 -18 -38 -22 -38 -68 0 -46 3 -51 36 -70 41 -25 54 -26 79 -7 19 13 18 15 -18 36 -35 21 -49 52 -28 64 14 9 41 -4 41 -20 0 -17 2 -17 35 -2 37 17 31 44 -15 68 -47 24 -46 24 -92 -1z"
    var nodejsPath3 = "M0 105 l0 -105 110 0 110 0 0 105 0 105 -110 0 -110 0 0 -105z m155 72 c37 -21 40 -26 43 -69 3 -46 2 -48 -39 -74 l-42 -26 -44 21 c-43 21 -43 21 -43 73 0 51 2 54 38 75 46 27 39 27 87 0z"
    var nodejs = createPath(svgNS, transfromPathNodeJS, nodejsPath, "black");
    var nodejs1 = createPath(svgNS, transfromPathNodeJS, nodejsPath1, "black");
    var nodejs2 = createPath(svgNS, transfromPathNodeJS, nodejsPath2, "black");
    var nodejs3 = createPath(svgNS, transfromPathNodeJS3, nodejsPath3, "white");

    document.getElementById('my-svg').appendChild(circle1);
    document.getElementById('my-svg').appendChild(leaf);
    document.getElementById('my-svg').appendChild(circle2);
    document.getElementById('my-svg').appendChild(express);
    document.getElementById('my-svg').appendChild(circle3);
    document.getElementById('my-svg').appendChild(ferrari);
    document.getElementById('my-svg').appendChild(ferrari1);
    document.getElementById('my-svg').appendChild(circle4);
    document.getElementById('my-svg').appendChild(nodejs);
    document.getElementById('my-svg').appendChild(nodejs1);
    document.getElementById('my-svg').appendChild(nodejs2);
    document.getElementById('my-svg').appendChild(nodejs3);
};

function createPath(svg, transform, points, fillcolor) {
    var pathElement = document.createElementNS(svg, 'path');

    pathElement.setAttribute('transform', transform);
    pathElement.setAttribute('d', points);
    pathElement.setAttribute('fill', fillcolor);

    return pathElement;
}

function createCircle(svg, cx, cy, r, fillcolor) {
    var circleElement = document.createElementNS(svg, 'circle');

    circleElement.setAttribute('cx', cx);
    circleElement.setAttribute('cy', cy);
    circleElement.setAttribute('r', r);
    circleElement.setAttribute('fill', fillcolor);

    return circleElement;
}

function createText(svg, x, y, fontSize, fontWeight, fontFamily, text, fillcolor) {
    var textElement = document.createElementNS(svg, 'text');

    textElement.setAttribute('x', x);
    textElement.setAttribute('y', y);
    textElement.setAttribute('font-size', fontSize);
    textElement.setAttribute('font-weight', fontWeight);
    textElement.setAttribute('font-family', fontFamily);
    textElement.textContent = text;
    textElement.setAttribute('fill',fillcolor);

    return textElement;
}