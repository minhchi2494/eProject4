function initialize() {
    var latlng = new google.maps.LatLng(10.7862695, 106.6642934);
    var options = {
        zoom: 14, center: latlng,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };
    var map = new google.maps.Map(document.getElementById("map"), options);
}
//10.7862695,106.6642934