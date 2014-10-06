var app = app || {};
var my_media = null;
mediaTimer = null;

function setAudioPosition(position) {
    document.getElementById('audio_position').innerHTML = position;
}

function playAudio(src) {
    if (my_media) my_media.stop();

    // Create Media object from src
    my_media = new Media(src, onSuccess, onError);

    // Play audio
    my_media.play();

    // Update my_media position every second
    if (mediaTimer == null) {
        mediaTimer = setInterval(function () {
            // get my_media position
            my_media.getCurrentPosition(
                // success callback
                function (position) {
                    if (position > -1) {
                        setAudioPosition((position) + " sec");
                    }
                },
                // error callback
                function (e) {
                    console.log("Error getting pos=" + e);
                    setAudioPosition("Error: " + e);
                }
            );
        }, 1000);
    }
}

function onSuccess(contacts) {
    var filtered = contacts;

    $("#rock-btn").click(function () {
        //clear the array
        filtered = [];
        console.log(contacts);
        playAudio("music/RockPrettyFly.mp3");

        for (var i = 0; i < contacts.length; i++) {
            

            if (typeof (contacts[i].categories[0].type) == 'string' || (contacts[i].categories[0].type) instanceof String
                && typeof (contacts[i].categories[1].type) == 'string' || (contacts[i].categories[1].type) instanceof String) {

                if (contacts[i].categories[0].type == "Rock" && contacts[i].categories[1].type == "PartyGuy") {

                    filtered.push(contacts[i]);
                }
            }
            else {
                continue;
            }
        }

        var template = kendo.template($("#contacts-list-template").html());

        var result = template(filtered);

        $("#contacts-output").html(result);

    })

    $("#chalga-btn").click(function () {
        //clear the array
        filtered = [];

        playAudio("music/ChalgaPlashtal.mp3");
        for (var i = 0; i < contacts.length; i++) {
            

            if (typeof (contacts[i].categories[0].type) == 'string' || (contacts[i].categories[0].type) instanceof String
                && typeof (contacts[i].categories[1].type) == 'string' || (contacts[i].categories[1].type) instanceof String) {

                if (contacts[i].categories[0].type == "Chalga" && contacts[i].categories[1].type == "PartyGuy") {

                    filtered.push(contacts[i]);
                }
            }
            else {
                continue;
            }
        }

        var template = kendo.template($("#contacts-list-template").html());

        var result = template(filtered);

        $("#contacts-output").html(result);

    })

    $("#retro-btn").click(function () {
        //clear the array
        filtered = [];

        playAudio("music/RetroBrenitsa.mp3");
        for (var i = 0; i < contacts.length; i++) {
            

            if (typeof (contacts[i].categories[0].type) == 'string' || (contacts[i].categories[0].type) instanceof String
                && typeof (contacts[i].categories[1].type) == 'string' || (contacts[i].categories[1].type) instanceof String) {

                if (contacts[i].categories[0].type == "Retro" && contacts[i].categories[1].type == "PartyGuy") {

                    filtered.push(contacts[i]);
                }
            }
            else {
                continue;
            }
        }

        var template = kendo.template($("#contacts-list-template").html());

        var result = template(filtered);

        $("#contacts-output").html(result);

    })

    $("#dance-btn").click(function () {
        //clear the array
        filtered = [];

        playAudio("music/DanceKrisko.mp4");
        for (var i = 0; i < contacts.length; i++) {
           

            if (typeof (contacts[i].categories[0].type) == 'string' || (contacts[i].categories[0].type) instanceof String
                && typeof (contacts[i].categories[1].type) == 'string' || (contacts[i].categories[1].type) instanceof String) {

                if (contacts[i].categories[0].type == "Dance" && contacts[i].categories[1].type == "PartyGuy") {

                    filtered.push(contacts[i]);
                }
            }
            else {
                continue;
            }
        }

        var template = kendo.template($("#contacts-list-template").html());

        var result = template(filtered);

        $("#contacts-output").html(result);

    })

    var template = kendo.template($("#contacts-list-template").html());

    var result = template(filtered);

    $("#contacts-output").html(result);
};

function onError(contactError) {
    navigator.notification.alert('There is an error with your contacts. Please reopen the app!');
};

(function (scope) {

    scope.contacts = function (e) {

        var options = new ContactFindOptions();
        options.multiple = true;

        var fields = [
            navigator.contacts.fieldType.displayName,
            navigator.contacts.fieldType.categories,
            navigator.contacts.fieldType.phoneNumbers
        ];

        var vm = kendo.observable({
            name: 'Contacts',
            contacts: navigator.contacts.find(fields, onSuccess, onError, options)
        });

        kendo.bind(e.view.element, vm);

    }

}(app))