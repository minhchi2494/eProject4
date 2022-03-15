import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:sale_man_app/view/pages/component/appbar.dart';

class CreateStore extends StatefulWidget {
  @override
  State<CreateStore> createState() => _CreateStoreState();
}

class _CreateStoreState extends State<CreateStore> {
  late DateTime _dateTime = DateTime.now();
  // late String dateFormat = DateFormat("yyyy-MM-dd").format(_dateTime);

//   _Datetime() {
//     _dateTime ;
// }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.white,
      appBar: GetAppBar(),
      body: getBody(),
    );
  }

  getBody() {
    return Padding(
      padding: const EdgeInsets.all(8.0),
      child: Column(
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
                          Text('Create Daily Sale',
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
          Column(
              children: [
            SizedBox(height: 12.0),
            // [Name]
            // Text(),
            RaisedButton(
              child: Text(_dateTime == null ? 'Nothing has been order yet' : DateFormat("yyyy-MM-dd").format(_dateTime)),
              onPressed: () {
                showDatePicker(
                  context: context,
                  initialDate: _dateTime == null ? DateTime.now() : _dateTime,
                  firstDate: DateTime(2001),
                  lastDate: DateTime(2222),
                ).then((date){
                  setState(() {
                    _dateTime = date!;
                  });
                });
              },
            ),
            // spacer
            SizedBox(height: 12.0),
            // [Password]
            TextField(
              decoration: InputDecoration(
                filled: true,
                labelText: 'Quantity',
              ),
            ),
          ]),
          Column(
            mainAxisAlignment: MainAxisAlignment.center,
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
      ),
    );
  }
}
