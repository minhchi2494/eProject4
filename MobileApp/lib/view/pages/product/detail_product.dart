import 'package:flutter/material.dart';
import 'package:sale_man_app/view/pages/component/appbar.dart';
import 'package:sale_man_app/view/pages/product/update_product.dart';

class DetailProduct extends StatefulWidget {
  @override
  State<DetailProduct> createState() => _DetailProductState();
}

class _DetailProductState extends State<DetailProduct> {
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
                  "Products",
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
          // [Name]
          Row(
            children: const [
              Text('Name Product'),
            ],
          ),
          // spacer
          const SizedBox(height: 12.0),
          // [Password]
          Row(
            children: const [
              Text('Product Price'),
            ],
          ),
          const SizedBox(height: 12.0),

        ]),
        ElevatedButton(
          child: const Text('Update'),
          onPressed: () => Navigator.push(context, MaterialPageRoute(builder: (context) => UpdateProduct())),
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
