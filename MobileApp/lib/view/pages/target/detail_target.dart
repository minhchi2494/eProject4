import 'package:flutter/material.dart';
import 'package:sale_man_app/view/pages/component/appbar.dart';
import 'package:sale_man_app/view/pages/store/update_store.dart';
import 'package:sale_man_app/view/pages/target/update_target.dart';

class DetailTarget extends StatefulWidget {
  @override
  State<DetailTarget> createState() => _DetailTargetState();
}

class _DetailTargetState extends State<DetailTarget> {
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
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                TextButton(
                    child: const Icon(Icons.arrow_back),
                    onPressed: () => Navigator.pop(context)),
                const Text(
                  "Target",
                  style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
                ),
              ],
            ),
          ],
        ),
        const SizedBox(
          height: 12.0,
        ),
        Column(children: [
          const SizedBox(height: 12.0),
          Container(
            alignment: Alignment.center,
            width: double.infinity,
            height: 150,
            color: Colors.grey[300],
            child: Row(
              children: const [
                // _image != null
                //     ? Image.file(_image!, fit: BoxFit.cover)
                //     : const Text('Please select an image'),
              ],
            ),
          ),
          const SizedBox(height: 12.0),
          Row(
            children: const [
              Text('Target ID'),
            ],
          ),
          // spacer
          const SizedBox(height: 12.0),
          Row(
            children: const [
              Text('Period'),
            ],
          ),
          const SizedBox(height: 12.0),
          Row(
            children: const [
              Text('Store'),
            ],
          ),
          // spacer
          const SizedBox(height: 12.0),
          Row(
            children: const [
              Text('Address'),
            ],
          ),
          const SizedBox(height: 12.0),
          Row(
            children: const [
              Text('Phone'),
            ],
          ),
          const SizedBox(height: 12.0),
          Row(
            children: const [
              Text('Email'),
            ],
          ),
          // spacer
          const SizedBox(height: 12.0),
          Row(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [
              Row(
                children: const [
                  Text('Target'),
                ],
              ),
              Row(
                children: const [
                  Text('Name Store'),
                ],
              ),
            ],
          ),
          const SizedBox(height: 12.0),
        ]),
        ElevatedButton(
          child: const Text('Update'),
          onPressed: () => Navigator.push(context, MaterialPageRoute(builder: (context) => UpdateTarget())),
        ),
        // TODO: Add an elevation to NEXT (103)
        // TODO: Add a beveled rectangular border to NEXT (103)
        ElevatedButton(
          child: const Text('Delete'),
          onPressed: () {},
        ),
      ],
    );
  }
}
