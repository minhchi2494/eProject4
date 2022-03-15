import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:sale_man_app/models/Product.dart';
import 'package:sale_man_app/models/SaleDetail.dart';
import 'package:sale_man_app/models/Store.dart';
import 'package:sale_man_app/models/StoreSalesDetail.dart';
import 'package:sale_man_app/service/store_sales_detail_service.dart';
import 'package:sale_man_app/view/pages/component/appbar.dart';

class CreateStore extends StatefulWidget {
  const CreateStore({Key? key, required this.store}) : super(key: key);

  final Store store;

  @override
  State<CreateStore> createState() => _CreateStoreState();
}

class _CreateStoreState extends State<CreateStore> {
  late DateTime _dateTime = DateTime.now();

  late bool _isFieldQuantityValid;
  late bool _isFieldProductValid;
  TextEditingController _controllerQuantity = TextEditingController();
  TextEditingController _controllerProduct = TextEditingController();

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
          Column(children: [
            SizedBox(height: 12.0),
            // [Name]
            // Text(),
            RaisedButton(
              child: Text(_dateTime == null
                  ? 'Nothing has been order yet'
                  : DateFormat("yyyy-MM-dd").format(_dateTime)),
              onPressed: () {
                showDatePicker(
                  context: context,
                  initialDate: _dateTime == null ? DateTime.now() : _dateTime,
                  firstDate: DateTime(2001),
                  lastDate: DateTime(2222),
                ).then((date) {
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
              controller: _controllerQuantity,
              keyboardType: TextInputType.number,
              decoration: InputDecoration(
                filled: true,
                labelText: 'Quantity',
              ),
            ),
            TextField(
              controller: _controllerProduct,
              keyboardType: TextInputType.number,
              decoration: InputDecoration(
                filled: true,
                labelText: 'Product ID:',
              ),
            ),
          ]),
          Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              ElevatedButton(
                child: const Text('Create Order'),
                onPressed: () {
                  // late List<StoreSalesDetail> storeDetail = [];
                  // String date = _dateTime.toString();
                  // int quantity =
                  //     int.parse(_controllerQuantity.text.toString().trim());
                  // String product = _controllerQuantity.text.toString().trim();
                  //
                  // if (date == null) {
                  //   showSnackbarMessage("date is required");
                  // } else if (quantity == 0) {
                  //   showSnackbarMessage("Quantity is required");
                  // } else if (product.isEmpty) {
                  //   showSnackbarMessage("product ID is required");
                  // } else {
                  //   setState(() {
                  //     StoreSalesDetail storeSalesDetail = StoreSalesDetail(
                  //         id: quantity,
                  //         quantityCommit: quantity,
                  //         salesDetailId: quantity,
                  //         productId: product,
                  //         price: double.parse(quantity.toString()),
                  //         date: DateTime.parse(date),
                  //         storeId: widget.store.id,
                  //         storeActualQuantity:
                  //             quantity,
                  //         product: quantity as Product,
                  //         salesDetail: quantity as SalesDetail,
                  //         store: widget.store);
                  //     StoreSalesDetailService.createStoreSalesDetail(storeSalesDetail).then((response) {
                  //       if (response.statusCode == 200) {
                  //         Navigator.pop(context,true);
                  //       } else {
                  //         print("error: " + response.statusCode.toString());
                  //         showSnackbarMessage("Create data failed");
                  //       }
                  //     });
                  //   });
                  // }
                },
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

  void showSnackbarMessage(String message) {
    ScaffoldMessenger.of(context)
        .showSnackBar(SnackBar(content: Text(message)));
  }
}
