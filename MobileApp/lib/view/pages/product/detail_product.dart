import 'package:flutter/material.dart';
import 'package:sale_man_app/models/Product.dart';
import 'package:sale_man_app/view/pages/component/appbar.dart';
import 'package:sale_man_app/view/pages/product/update_product.dart';

class DetailProduct extends StatelessWidget {
  const DetailProduct({Key? key, required this.product}) : super(key: key);

  final Product product;
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: GetAppBar(),
      body: Padding(
        padding: const EdgeInsets.symmetric(horizontal: 1.0),
        child: Column(
          children: [
            Stack(
              children: [
                Row(
                  mainAxisAlignment: MainAxisAlignment.start,
                  children: [
                    TextButton(
                        child: const Icon(Icons.arrow_back),
                        onPressed: () => Navigator.pop(context)),
                    SizedBox(
                      width: 10.0,
                    ),
                    const Text(
                      "Products",
                      style:
                          TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
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
                // color: Colors.grey[300],
                child: Image.network(
                    'https://th.bing.com/th/id/OIP.kfYgy8ywVaQsKDZk3YmOogHaHa?pid=ImgDet&w=500&h=500&rs=1'),
              ),
              const SizedBox(height: 12.0),
              // [Name]
              Column(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  Text(product.name),
                  const SizedBox(height: 12.0),
                  Text(product.price.toString()),
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
                              builder: (context) => UpdateProduct(product: product,)));
                    },
                  ),
                ),
              ],
            ),
          ],
        ),
      ),
    );
  }
}
