import 'dart:developer';

import 'package:flutter/material.dart';
import 'package:google_maps_flutter/google_maps_flutter.dart';
import 'package:sale_man_app/models/Store.dart';
import 'package:sale_man_app/service/store_service.dart';
import 'package:sale_man_app/view/pages/store/create_store.dart';
import 'package:sale_man_app/view/pages/store/detail_store.dart';

class StoreScreen extends StatefulWidget {
  const StoreScreen({Key? key}) : super(key: key);

  @override
  State<StoreScreen> createState() => _StoreScreenState();
}

class _StoreScreenState extends State<StoreScreen> {
  final Map<String, Marker> _markers = {};
  // final List<Store> store = [];
  Future<void> _onMapCreated(GoogleMapController controller) async {
    List<Store> googleOffices = await StoreService.getStores();
    setState(() {
      _markers.clear();
      for (final office in googleOffices) {
        final marker = Marker(
          markerId: MarkerId(office.name),
          position: LatLng(office.latitude,office.longitude),
          infoWindow: InfoWindow(
            title: office.name,
            snippet: office.address,
          ),

          onTap: (){
            Navigator.push(context, MaterialPageRoute(builder: (context) => DetailStore(store: office)));
          },
        );
        _markers[office.name] = marker;
      }
      // for(Store item in googleOffices){
      //   log('${item.latitude} - ${item.longitude}');
      // }
    });
  }
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.white,
      body: getBody(),
    );
  }

  getBody() {
    late GoogleMapController mapController;

    final LatLng _center = const LatLng(10.7863, 106.6665);

    // void _onMapCreated(GoogleMapController controller) {
    //   mapController = controller;
    // }

    return ListView(
      // padding: const EdgeInsets.symmetric(horizontal: 24.0),

      children: [
        // Stack(
        //   children: [
        //     // Row(
        //     //   children: const [
        //     //     Text(
        //     //       "Store",
        //     //       style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
        //     //     ),
        //     //   ],
        //     // ),
        //     // Padding(
        //     //   padding: const EdgeInsets.only(top: 20, right: 10),
        //     //   child: Column(
        //     //     children: [
        //     //       Row(
        //     //         children: [
        //     //           Row(
        //     //             // mainAxisAlignment: MainAxisAlignment.end,
        //     //             children: [
        //     //               ElevatedButton(
        //     //                 child: const Text('Detail'),
        //     //                 onPressed: () {
        //     //                   Navigator.push(
        //     //                     context,
        //     //                     MaterialPageRoute(
        //     //                         builder: (context) => DetailStore()),
        //     //                   );
        //     //                 },
        //     //               ),
        //     //             ],
        //     //           ),
        //     //         ],
        //     //       ),
        //     //     ],
        //     //   ),
        //     // ),
        //   ],
        // ),
        // const SizedBox(
        //   height: 10.0,
        // ),
        SizedBox(
          height: MediaQuery.of(context).size.height,
          width: MediaQuery.of(context).size.width,
          child: GoogleMap(
            onMapCreated: _onMapCreated,
            initialCameraPosition: CameraPosition(
              target: _center,
              zoom: 18.0,
            ),
            markers: _markers.values.toSet(),
          ),
        ),
      ],
    );
  }
}
