import 'package:flutter/material.dart';
import 'package:sale_man_app/models/Product.dart';
import 'package:sale_man_app/models/SaleDetail.dart';
import 'package:sale_man_app/service/product_service.dart';
import 'package:sale_man_app/view/pages/component/appbar.dart';

final GlobalKey<ScaffoldState> _scaffoldState = GlobalKey<ScaffoldState>();

class UpdateProduct extends StatefulWidget {
  late Product product;

  UpdateProduct({Key? key, required this.product}) : super(key: key);

  @override
  State<UpdateProduct> createState() => _UpdateProductState();
}

class _UpdateProductState extends State<UpdateProduct> {
  bool _isLoading = false;
  // ProductService productService = ProductService();
  late bool _isFieldNameValid;
  late bool _isFieldPriceValid;
  TextEditingController _controllerName = TextEditingController();
  TextEditingController _controllerPrice = TextEditingController();

  @override
  void initState() {
    if (widget.product != null) {
      _isFieldNameValid = true;
      _controllerName.text = widget.product.name;
      _isFieldPriceValid = true;
      _controllerPrice.text = widget.product.price.toString();
    }
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: GetAppBar(),
      body: getBody(),
    );
  }

  getBody() {
    return Padding(
      padding: const EdgeInsets.symmetric(horizontal: 12.0),
      child: Container(
        height: 1000,
        child: Column(
          children: [
            Stack(
              children: [
                Row(
                  children: const [
                    Text(
                      "Product",
                      style:
                          TextStyle(fontSize: 18, fontWeight: FontWeight.bold),
                    ),
                  ],
                ),
              ],
            ),
            Column(children: [
              Container(
                alignment: Alignment.center,
                width: double.infinity,
                height: 100,
                // color: Colors.grey[300],
                child: Row(
                  mainAxisAlignment: MainAxisAlignment.center,
                  children: [
                    Image.asset(
                        'assets/images/${widget.product.images}'),
                  ],
                ),
              ),
              // [Name]
              _buildTextFieldName(),
              _buildTextFieldPrice(),
            ]),
            Row(
              mainAxisAlignment: MainAxisAlignment.end,
              children: [
                ElevatedButton(
                    child: const Text('Update'),
                    onPressed: () {
                      String name = _controllerName.text.toString().trim();
                      double price = _controllerPrice.text.toString().isEmpty
                          ? 0
                          : double.parse(_controllerPrice.text.toString());
                      if (name.isEmpty) {
                        showSnackbarMessage("Name is required");
                      } else if (price == 0) {
                        showSnackbarMessage("Price is required");
                      } else {
                        setState(() {
                          Product product = Product(
                              name: name,
                              id: widget.product.id,
                              price: price,
                              unit: widget.product.unit,
                              images: widget.product.images,
                              isActive: widget.product.isActive,
                              imagesNavigation: widget.product.imagesNavigation,
                              salesDetails: widget.product.salesDetails,
                              storeSalesDetails: widget.product.storeSalesDetails);
                          ProductService.updateProduct(product).then((response){
                            if(response.statusCode == 200){
                              Navigator.pop(context);
                            } else {
                              print("error: " + response.statusCode.toString());
                              showSnackbarMessage("Update data failed");
                            }
                          });
                        });
                      }
                    }

                    // String name = _controllerName.text.toString();
                    // String id = _controllerId.text.toString();
                    // String unit = _controllerUnit.text.toString();
                    // String images = _controllerImages.text.toString();
                    // bool active = true;
                    // late List<dynamic> image = [];
                    // late List<dynamic> sales = [];
                    // late List<dynamic> store = [];
                    // double price = double.parse(_controllerPrice.text.toString());
                    // Product product = Product(
                    //     name: name,
                    //     id: id,
                    //     price: price,
                    //     unit: unit,
                    //     images: images,
                    //     isActive: active,
                    //     imagesNavigation: image,
                    //     salesDetails: sales,
                    //     storeSalesDetails: store);
                    // if (widget.product != null) {
                    //   product.id = widget.product.id;
                    //   ProductService.updateProduct(product).then((isSuccess) {
                    //     setState(() => _isLoading = false);
                    //     if (isSuccess) {
                    //       Navigator.pop(
                    //           _scaffoldState.currentState!.context, true);
                    //     } else {
                    //       const ScaffoldMessenger(
                    //         child: SnackBar(
                    //           content: Text("Submit data failed"),
                    //         ),
                    //       );
                    //     }
                    //   });
                    // }
                    // },
                    ),
                const SizedBox(
                  width: 5.0,
                ),
                ElevatedButton(
                  child: const Text('Back'),
                  onPressed: () {
                    Navigator.pop(context);
                  },
                ),
              ],
            ),
            if (_isLoading)
              Container(
                height: 50,
                child: Stack(
                  children: const <Widget>[
                    Opacity(
                      opacity: 1.0,
                      child: ModalBarrier(
                        dismissible: false,
                        color: Colors.grey,
                      ),
                    ),
                    Center(
                      child: CircularProgressIndicator(),
                    ),
                  ],
                ),
              )
            else
              Container(),
          ],
        ),
      ),
    );
  }

  Widget _buildTextFieldName() {
    return TextField(
      controller: _controllerName,
      keyboardType: TextInputType.text,
      decoration: const InputDecoration(
        labelText: "Product name",
        // errorText: _isFieldNameValid == null || _isFieldNameValid
        //     ? null
        //     : "Product name is required",
      ),
      // onChanged: (value) {
      //   bool isFieldValid = value.trim().isNotEmpty;
      //   if (isFieldValid != _isFieldNameValid) {
      //     setState(() => _isFieldNameValid = isFieldValid);
      //   }
      // },
    );
  }

  Widget _buildTextFieldPrice() {
    return TextField(
      controller: _controllerPrice,
      keyboardType: TextInputType.number,
      decoration: const InputDecoration(
        labelText: "Price",
        // errorText: _isFieldPriceValid == null || _isFieldPriceValid
        //     ? null
        //     : "Price is required",
      ),
      // onChanged: (value) {
      //   bool isFieldValid = value.trim().isNotEmpty;
      //   if (isFieldValid != _isFieldPriceValid) {
      //     setState(() => _isFieldPriceValid = isFieldValid);
      //   }
      // },
    );
  }

  void showSnackbarMessage(String message) {
    ScaffoldMessenger.of(context)
        .showSnackBar(SnackBar(content: Text(message)));
  }
}
