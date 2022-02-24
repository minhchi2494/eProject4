import 'package:flutter/material.dart';
import 'package:sale_man_app/view/pages/component/appbar.dart';

class CreateStore extends StatefulWidget {
  @override
  State<CreateStore> createState() => _CreateStoreState();
}

class _CreateStoreState extends State<CreateStore> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.white,
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
                        Text('Create New Store',
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
          SizedBox(height: 12.0),
          // [Password]
          TextField(
            decoration: InputDecoration(
              filled: true,
              labelText: 'Address',
            ),
            obscureText: true,
          ),
          TextField(
            decoration: InputDecoration(
              filled: true,
              labelText: 'Phone',
            ),
            obscureText: true,
          ),
          TextField(
            decoration: InputDecoration(
              filled: true,
              labelText: 'Email',
            ),
            obscureText: true,
          ),
          TextField(
            decoration: InputDecoration(
              filled: true,
              labelText: 'Location',
            ),
            obscureText: true,
          ),
        ]),
        Row(
          mainAxisAlignment: MainAxisAlignment.end,
          children: [
            ElevatedButton(
              child: const Text('Create New'),
              onPressed: () {},
            ),
            // TODO: Add an elevation to NEXT (103)
            // TODO: Add a beveled rectangular border to NEXT (103)
            TextButton(
              child: const Text('Back'),
              onPressed: () {
                Navigator.pop(context);
              },
            ),
          ],
        ),
      ],
    );
  }
}
