import 'package:flutter/material.dart';
import 'package:sale_man_app/view/pages/component/appbar.dart';

class CreateTarget extends StatefulWidget {
  @override
  State<CreateTarget> createState() => _CreateTargetState();
}

class _CreateTargetState extends State<CreateTarget> {
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
                  "Target",
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
                        Text('Create New Target',
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
              labelText: 'Store',
            ),
          ),
          // spacer
          SizedBox(height: 12.0),
          // [Password]
          TextField(
            decoration: InputDecoration(
              filled: true,
              labelText: 'Target',
            ),
            obscureText: true,
          ),
          TextField(
            decoration: InputDecoration(
              filled: true,
              labelText: 'Period',
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
