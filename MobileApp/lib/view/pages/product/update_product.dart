import 'package:flutter/material.dart';
import 'package:sale_man_app/view/pages/component/appbar.dart';

class UpdateProduct extends StatefulWidget {
  @override
  State<UpdateProduct> createState() => _UpdateProductState();
}

class _UpdateProductState extends State<UpdateProduct> {
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
                  "Products",
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
                        Text('Name Product',
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
          // [Name]
          const TextField(
            decoration: InputDecoration(
              filled: true,
              labelText: 'Product Name',
            ),
          ),
          // spacer
          const SizedBox(height: 12.0),
          // [Password]
          const TextField(
            decoration: InputDecoration(
              filled: true,
              labelText: 'Product Price',
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
