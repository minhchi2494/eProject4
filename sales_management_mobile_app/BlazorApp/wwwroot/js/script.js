////var map;

////function initialize() {
////    var latlng = new google.maps.LatLng(10.7862695, 106.6642934);
////    var options = {
////        zoom: 14, center: latlng,
////        mapTypeId: google.maps.MapTypeId.ROADMAP
////    };
////    map = new google.maps.Map(document.getElementById("map"), options);

////    var input = (document.getElementById('pac-input'));

////    var searchBox = new google.maps.places.SearchBox((input));
////    google.maps.event.addListener(searchBox, 'places_changed', function () {
////        var places = searchBox.getPlaces();

////        if (places.length = 0) {
////            return;
////        }



////        markers = [];
////        var bounds = new google.maps.LatLngBound();
////        for (var i = o, place; place = places[i]; i++) {
////            var image = {
////                url: place.icon,
////                size: new google.maps.Size(71, 71),
////                origin: new google.maps.Point(0, 0),
////                anchor: new google.maps.Point(17, 34),
////                scaledSize: new google.maps.Point(25, 25)
////            };


////            var mark = new google.maps.Marker({
////                map: map,
////                icon: image,
////                title: place.name,
////                position: place.geometry.location
////            });

////            markers.push(mark);

////            bounds.extend(place.geometry.location)
////        }

////        map.fitBounds(bounds);

////    });
////}
//////10.7862695,106.6642934