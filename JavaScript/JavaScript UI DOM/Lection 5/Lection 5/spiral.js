(function drawSpiral() {
    var frame = 1;
    var r = 1;
    var startX = paper.width / 2;
    var startY = paper.height / 2;
    var circlesNum = 200;
    var outsideR = paper.width * 0.45;

    function drawCircle(framesNumber) {
        var dAngle = (2 + (framesNumber) / 12.0) * Math.PI / 180;

        paper.clear();

        for (var i = 1; i <= circlesNum; i++) {
            var angle = i * dAngle;
            var spiralR = (i / circlesNum) * outsideR;

            var x = startX + Math.cos(angle) * spiralR;
            var y = startY + Math.sin(angle) * spiralR;

            paper.circle(x, y, r);
        }
    }

    function animate() {
        drawCircle(frame);
        setTimeout(animate, 10);
        frame++;
    }

    animate();
})();