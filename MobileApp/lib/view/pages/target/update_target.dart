import 'package:flutter/material.dart';
import 'package:sale_man_app/view/pages/component/appbar.dart';

class UpdateTarget extends StatefulWidget {
  @override
  State<UpdateTarget> createState() => _UpdateTargetState();
}

class _UpdateTargetState extends State<UpdateTarget> {
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
                        Text('Target ID',
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
              labelText: 'Target',
            ),
          ),
          TextField(
            decoration: InputDecoration(
              filled: true,
              labelText: 'Actual',
            ),
          ),
          TextField(
            decoration: InputDecoration(
              filled: true,
              labelText: 'Date',
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
