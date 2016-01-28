var map;
var earthquakeResults;

//Intialization of the google map API is done here
function initialize() {
    //here we are getting the Element ID of the mapwindow of mymap.html to render google map there.
    map = new google.maps.Map(document.getElementById('mapwindow'), {
        zoom: 3,
        center: new google.maps.LatLng(40, -187.3),
        mapTypeId: google.maps.MapTypeId.TERRAIN
    });

    addMarkers();
}

//this function is extracting data from week.js for the use in the Map
eqfeed_callback = function (results) {
    earthquakeResults = results;
}

//below function is used to add pins to the specific location on the google map.
var marker;
popUps = new Array();
positions = new Array();
function addMarkers() {
    for (var i = 0; i < earthquakeResults.features.length; i++) {

        var earthquake = earthquakeResults.features[i];
        var coordinates = earthquake.geometry.coordinates;
        var latiLong = new google.maps.LatLng(coordinates[1], coordinates[0]);
        var place = earthquake.properties.place;
        marker = new google.maps.Marker({
            position: latiLong,
            map: map,
        });

        ///**************************************************************************************////
        ///This part is done to show the information popup when users click on the particular pin
        ///if not needed commenting this code will not affect the map
        ///**************************************************************************************////
        positions[i] = marker;
        popUps[i] = '<div id = "content">' +
        '<div>' +
        '</div>' +
        '<p>' + place + '</h1>' +
        '</div>';
        //Here the addListener is being invoked which is in turn invoking particular info window.
        addListener(i);
        ///**************************************************************************************////
        ///**************************************************************************************////
    }
}

var infowindows;
var addListener = function (i) {
    google.maps.event.addListener(marker, 'click', function () {
        if (infowindows) infowindows.close();
        infowindows = new google.maps.InfoWindow({
            content: popUps[i]
        });
        infowindows.open(map, positions[i]);
    });
}
google.maps.event.addDomListener(window, 'load', initialize);