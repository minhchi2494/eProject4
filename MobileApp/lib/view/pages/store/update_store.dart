import 'package:flutter/material.dart';
import 'package:sale_man_app/models/Store.dart';
import 'package:sale_man_app/view/pages/component/appbar.dart';

class UpdateStore extends StatefulWidget {
  const UpdateStore({Key? key, required this.store}) : super(key: key);

  final Store store;

  @override
  State<UpdateStore> createState() => _UpdateStoreState();
}

class _UpdateStoreState extends State<UpdateStore> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: GetAppBar(),
      body: getBody(),
    );
  }

  getBody() {
    return ListView(
      padding: const EdgeInsets.symmetric(horizontal: 24.0),
      children: [
        Stack(
          children: [
            Row(
              children: const [
                Text(
                  "Store",
                  style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
                ),
              ],
            ),
            Padding(
                padding: const EdgeInsets.only(top: 35, right: 10),
                child: Row(
                  // mainAxisAlignment: MainAxisAlignment.spaceBetween,
                  children: [
                    Row(
                      // mainAxisAlignment: MainAxisAlignment.end,
                      children: const [
                        Text('Name Store',
                            style: TextStyle(
                                fontSize: 12,
                                fontWeight: FontWeight.bold,
                                color: Colors.grey)),
                      ],
                    ),
                  ],
                )),
          ],
        ),
        const SizedBox(
          height: 12.0,
        ),
        Column(children: const [
          SizedBox(height: 12.0),
          // [Name]
          TextField(
            decoration: InputDecoration(
              filled: true,
              labelText: 'Store Name',
            ),
          ),
          // spacer
          // const SizedBox(height: 12.0),
          // [Password]
          TextField(
            decoration: InputDecoration(
              filled: true,
              labelText: 'Address',
            ),
          ),
          TextField(
            decoration: InputDecoration(
              filled: true,
              labelText: 'Phone',
            ),
          ),
          TextField(
            decoration: InputDecoration(
              filled: true,
              labelText: 'Email',
            ),
          ),
          TextField(
            decoration: InputDecoration(
              filled: true,
              labelText: 'Location',
            ),
          ),
        ]),
        Row(
          mainAxisAlignment: MainAxisAlignment.end,
          children: [
            ElevatedButton(
              child: const Text('Update'),
              onPressed: () {},
            ),
            // TODO: Add an elevation to NEXT (103)
            // TODO: Add a beveled rectangular border to NEXT (103)
            const SizedBox(width: 5.0,),
            ElevatedButton(
              child: const Text('Back'),
              onPressed: () {
                Navigator.pop(context);
              },
            ),
          ],
        )
      ],
    );
  }
}
