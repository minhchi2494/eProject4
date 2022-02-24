import 'package:flutter/material.dart';
import 'package:sale_man_app/view/pages/component/appbar.dart';

class CreateProduct extends StatefulWidget {
  @override
  State<CreateProduct> createState() => _CreateProductState();
}

class _CreateProductState extends State<CreateProduct> {
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
                        Text('Create New Products',
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
          Center(
            child: ElevatedButton(
              child: const Text('Select An Image'),
              // onPressed: _openImagePicker,
              onPressed: () {},
            ),
          ),
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
