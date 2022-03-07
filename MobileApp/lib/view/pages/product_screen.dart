import 'dart:developer';
import 'dart:ffi';

import 'package:flutter/material.dart';
import 'package:sale_man_app/models/Product.dart';
import 'package:sale_man_app/service/product_service.dart';
import 'package:sale_man_app/view/pages/product/create_product.dart';
import 'package:sale_man_app/view/pages/product/detail_product.dart';
import '';

class ProductScreen extends StatefulWidget {
  const ProductScreen({Key? key}) : super(key: key);

  @override
  State<ProductScreen> createState() => _ProductScreenState();
}

class _ProductScreenState extends State<ProductScreen> {
  List<Product> _products = [];

  ScrollController controller = ScrollController();
  bool closeTopContainer = false;

  List<Card> _buildGridCards(BuildContext context) {
    if (_products.isEmpty) {
      return const <Card>[];
    }
    List<Product> listProduct = [];
    for (var item in _products) {
      listProduct.add(item);
    }
    return listProduct.map((product) {
      return Card(
        clipBehavior: Clip.antiAlias,
        elevation: 2.0, // loại bỏ cái hàng shadow bên dưới mỗi mặt hàng
        child: GestureDetector(
          onTap: () {
            Navigator.of(context).push(MaterialPageRoute(
              builder: (context) => DetailProduct(product: product),
            ));
          },
          child: Row(
            crossAxisAlignment: CrossAxisAlignment.center,
            children: <Widget>[
              // AspectRatio(
              //   aspectRatio: 18.0 / 11.0,
              //   child: Image.network(
              //     product.imageUrl,
              //     fit: BoxFit.cover,
              //     // package: product.assetPackage,
              //   ),
              // ),
              Expanded(
                child: Padding(
                  padding: const EdgeInsets.all(10.0),
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.center,
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: <Widget>[
                      Row(
                        mainAxisAlignment: MainAxisAlignment.spaceBetween,
                        children: [
                          Text(
                            product.name,
                            style: Theme.of(context)
                                .textTheme
                                .headline6!
                                .copyWith(
                                    fontSize: 15, fontWeight: FontWeight.bold),
                            softWrap: false,
                            overflow: TextOverflow.ellipsis,
                            maxLines: 1,
                          ),
                          const SizedBox(height: 4.0),
                          Text(product.price.toString())
                        ],
                      ),
                    ],
                  ),
                ),
              ),
            ],
          ),
        ),
      );
    }).toList();
  }

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    ProductService.getProducts().then((data) {
      setState(() {
        _products = data;
        log('data here: ${_products}');
      });
    });
    controller.addListener(() {
      setState(() {
        closeTopContainer = controller.offset > 50;
      });
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.white,
      body: Center(
        child: getBody(),
      ),
    );
  }

  getBody() {
    return Scaffold(
      body: SafeArea(
        child: Column(
          children: [
            // Row(
            //   mainAxisAlignment: MainAxisAlignment.center,
            //   children: [
            //     ElevatedButton(
            //       child: const Text('Create New'),
            //       onPressed: () {
            //         Navigator.push(
            //           context,
            //           MaterialPageRoute(
            //               builder: (context) => CreateProduct()),
            //         );
            //       },
            //     ),
            //   ],
            // ),
            Expanded(
              child: GridView.count(
                controller: controller,
                crossAxisCount: 2,
                crossAxisSpacing: 1.0,
                mainAxisSpacing: 0.5,
                children: _buildGridCards(context),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
