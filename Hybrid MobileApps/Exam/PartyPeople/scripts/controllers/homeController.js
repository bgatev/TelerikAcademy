
var app = app || {};

(function (scope) {
    
    scope.login = kendo.observable({
        name: '',
        musicType: $("#userMusicType").val(),
        geoPosition: '',
        phone: '',
        login: function (ev) {

            if (this.name == '' || this.name == null || this.name == undefined) {
                navigator.notification.alert("You must enter your username!");
            }
            else if (this.musicType == undefined) {
                navigator.notification.alert("You must enter your music genre preference!");
            }
            else if (this.phone == '' || this.phone == null || this.phone == undefined) {
                navigator.notification.alert("You must enter your phone number!");
            }
            else {
                var self = this;
                navigator.geolocation.getCurrentPosition(onGetPositionSuccess, onGetPositionError);

                function onGetPositionSuccess(position) {

                    self.geoPosition = {
                        longitude: position.coords.longitude,
                        latitude: position.coords.latitude
                    };

                    var data = window.everlife.data('PartyUsers');

                    data.create({
                        Name: self.name,
                        MusicType: self.musicType,
                        Phone: self.phone,
                        Geolocation: self.geoPosition
                    }, function () {

                        window.navigator.vibrate(200);
                        $("#userMusicType").hide();
                        $("#userData").hide();
                        navigator.notification.alert('You are in the Party People Network!');

                    },
                        function (error) {
                            console.log(error);
                        }
                    );

                }

                function onGetPositionError(error) {
                    console.log(error);
                }
            }
        }
    });
}(app))

