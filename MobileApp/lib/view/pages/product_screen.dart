import 'package:flutter/material.dart';
import 'package:sale_man_app/view/pages/product/create_product.dart';
import 'package:sale_man_app/view/pages/product/detail_product.dart';

class ProductScreen extends StatefulWidget {
  const ProductScreen({Key? key}) : super(key: key);

  @override
  State<ProductScreen> createState() => _ProductScreenState();
}

class _ProductScreenState extends State<ProductScreen> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.white,
      body: getBody(),
    );
  }

  getBody() {
    var size = MediaQuery.of(context).size;
    return ListView(
      padding: EdgeInsets.zero,
      children: [
        Stack(
          children: [
            Row(
              children: const [
                Text(
                  "Total Products",
                  style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
                ),
              ],
            ),
            Padding(
                padding: const EdgeInsets.only(top: 35, right: 10),
                child: Row(
                  mainAxisAlignment: MainAxisAlignment.spaceBetween,
                  children: [
                    Row(
                      // mainAxisAlignment: MainAxisAlignment.start,
                      children: const [
                        Icon(
                          Icons.favorite,
                          color: Colors.black,
                          size: 28,
                        ),
                        SizedBox(
                          width: 15,
                        ),
                        Icon(
                          Icons.search,
                          color: Colors.black,
                          size: 25,
                        ),
                      ],
                    ),
                    Row(
                      // mainAxisAlignment: MainAxisAlignment.end,
                      children: [
                        ElevatedButton(
                          child: const Text('Create New'),
                          onPressed: () {
                            Navigator.push(
                              context,
                              MaterialPageRoute(
                                  builder: (context) => CreateProduct()),
                            );
                          },
                        ),
                      ],
                    ),
                  ],
                )),
          ],
        ),
        const SizedBox(
          height: 10,
        ),

        // Nội dung (List Product)
        //title top sale
        Row(
          children: [
            const Text(
              "Top Sales",
              style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
            ),
            Row(
              children: const [
                SizedBox(width: 5),
                Icon(
                  Icons.trending_up,
                  color: Colors.green,
                )
              ],
            )
          ],
        ),
        const SizedBox(
          height: 20,
        ),
        // Nội Dung
        Row(
          // nội dung
          children: [
            ElevatedButton(
              onPressed: () => Navigator.push(
                context,
                MaterialPageRoute(builder: (context) => DetailProduct()),
              ),
              child: const Text('Deltail'),
            ),
          ],
        ),
        const SizedBox(
          height: 40,
        ),
      ],
    );
  }
}
