import 'package:flutter/material.dart';

import 'package:sale_man_app/models/Store.dart';
import 'package:sale_man_app/view/pages/component/appbar.dart';
import 'package:sale_man_app/view/pages/store/create_store.dart';
import 'package:sale_man_app/view/pages/store/update_store.dart';

class DetailStore extends StatelessWidget {
  const DetailStore({Key? key, required this.store}) : super(key: key);

  final Store store;
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: GetAppBar(),
      body: Column(
        children: [
          Stack(
            children: [
              Row(
                mainAxisAlignment: MainAxisAlignment.start,
                children: [

                  const Text(
                    "Store",
                    style:
                    TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
                  ),
                ],
              ),
            ],
          ),
          Column(children: [
            Container(
              alignment: Alignment.center,
              width: double.infinity,
              height: 70,
              // color: Colors.grey[300],
              child: Image.asset(
                  'assets/images/shopss.png'),
            ),
            const SizedBox(height: 12.0),
            // [Name]
            Column(
              mainAxisAlignment: MainAxisAlignment.start,
              children: [
                Row(
                  children: [
                    Text("Store Name: ${store.name}"),
                  ],
                ),
                const SizedBox(height: 12.0),
                Row(
                  children: [
                    Text("Address: ${store.address}"),
                  ],
                ),
                const SizedBox(height: 12.0),
                Row(
                  children: [
                    Text("Phone: ${store.phone}"),
                  ],
                ),
                const SizedBox(height: 12.0),
                Row(
                  children: [
                    Text("Email: ${store.email}"),
                  ],
                ),
              ],
            ),
            // spacer

            const SizedBox(height: 12.0),
          ]),
          Row(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              Expanded(
                child: ElevatedButton(
                  child: const Text('Update'),
                  onPressed: () {
                    Navigator.push(
                        context,
                        MaterialPageRoute(
                            builder: (context) => UpdateStore(store: store,)));
                  },
                ),
              ),
            ],
          ),
          Row(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              Expanded(
                child: ElevatedButton(
                  child: const Text('Daily Order'),
                  onPressed: () {
                    Navigator.push(
                        context,
                        MaterialPageRoute(
                            builder: (context) => CreateStore()));
                  },
                ),
              ),
            ],
          ),
        ],
      ),
    );
  }
}
