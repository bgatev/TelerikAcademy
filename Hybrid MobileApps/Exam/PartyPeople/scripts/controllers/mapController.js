var app = app || {};

function generateOutput(data) {

    var template = kendo.template($("#partypeople-list-template").html());

    var result = template(data);

    $("#party-list-output").html(result);
}


(function (scope) {
    scope.map = function (e) {
        
        var currentUserMusicType = $("#userMusicType").val();
       // if (currentUserMusicType == null || currentUserMusicType == undefined) {

            //navigator.notification.alert("You must log in to view other party animals!");
       // }
        //else {

            navigator.geolocation.getCurrentPosition(onGetPositionSuccess, onGetPositionError);

            function onGetPositionSuccess(position) {
                
                var map = new GMaps({
                    div: '#map',
                    lat: position.coords.longitude,
                    lng: position.coords.latitude,
                    width: '500px',
                    height: '500px',
                });

                var query = new Everlive.Query();
                query
                    .where()
                        .nearSphere('Geolocation', [position.coords.longitude, position.coords.latitude], 1, 'km')
                        .eq('MusicType', currentUserMusicType);

                var data = window.everlife.data('PartyUsers');
                data.get(query)
                .then(function (data) {
                    //add markers
                    
                    for (var i = 0; i < data.result.length; i++) {
                        console.log(data.result[i]);
                        map.addMarker({
                            lat: data.result[i].Geolocation.longitude,
                            lng: data.result[i].Geolocation.latitude,
                            title: data.result[i].Name,
                        });
                    }
                    
                },
                function (error) {
                    console.log(error);
                });
            }
            function onGetPositionError(error) {
                console.log(error);
            }
        //}
       
    }
}(app))