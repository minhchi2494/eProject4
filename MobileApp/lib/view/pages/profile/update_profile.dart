import 'package:flutter/material.dart';
import 'package:sale_man_app/models/User.dart';
import 'package:sale_man_app/service/user_service.dart';
import 'package:sale_man_app/view/pages/component/appbar.dart';

class ProfileUpdate extends StatefulWidget {
  const ProfileUpdate({Key? key, required this.user}) : super(key: key);

  final User user;

  @override
  State<ProfileUpdate> createState() => _ProfileUpdateState();
}

class _ProfileUpdateState extends State<ProfileUpdate> {
  late bool _isFieldNameValid;
  late bool _isFieldAddressValid;
  late bool _isFieldPhoneValid;
  late bool _isFieldEmailValid;
  late bool _isFieldLocationValid;

  TextEditingController _controllerName = TextEditingController();
  TextEditingController _controllerAddress = TextEditingController();
  TextEditingController _controllerPhone = TextEditingController();
  TextEditingController _controllerEmail = TextEditingController();
  TextEditingController _controllerLocation = TextEditingController();

  @override
  void initState() {
    if (widget.user != null) {
      _isFieldNameValid = true;
      _controllerName.text = widget.user.fullname;
      _isFieldAddressValid = true;
      _controllerAddress.text = widget.user.address;
      _isFieldPhoneValid = true;
      _controllerPhone.text = widget.user.phone;
      _isFieldEmailValid = true;
      _controllerEmail.text = widget.user.email;
      _isFieldLocationValid = true;
      _controllerLocation.text = widget.user.locationId.toString();
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
      child: SizedBox(
        height: MediaQuery.of(context).size.height,
        width: MediaQuery.of(context).size.width,
        child: Column(
          children: [
            Column(children: [
              // [Name]
              _buildTextFieldName(),
              _buildTextFieldAddress(),
              _buildTextFieldPhone(),
              _buildTextFieldEmail(),
              // _buildTextFieldLocation(),
            ]),
            Row(
              mainAxisAlignment: MainAxisAlignment.end,
              children: [
                ElevatedButton(
                    child: const Text('Update'),
                    onPressed: () {
                      String name = _controllerName.text.toString().trim();
                      String email = _controllerEmail.text.toString().trim();
                      String address =
                          _controllerAddress.text.toString().trim();
                      String phone = _controllerPhone.text.toString().trim();
                      int location = _controllerLocation.text.toString().isEmpty
                          ? 0
                          : int.parse(_controllerLocation.text.toString());
                      if (name.isEmpty) {
                        showSnackbarMessage("Name is required");
                      } else if (email.isEmpty) {
                        showSnackbarMessage("Email is required");
                      } else if (address.isEmpty) {
                        showSnackbarMessage("Address is required");
                      } else if (phone.isEmpty) {
                        showSnackbarMessage("Phone is required");
                      } else if (location == 0) {
                        showSnackbarMessage("Location is required");
                      } else {
                        setState(() {
                          User user = User(
                              id: widget.user.id,
                              targetId: widget.user.targetId,
                              username: widget.user.username,
                              password: widget.user.password,
                              fullname: name,
                              email: email,
                              phone: phone,
                              address: address,
                              storeId: widget.user.storeId,
                              locationId: widget.user.locationId,
                              roleId: widget.user.roleId,
                              managerId: widget.user.managerId,
                              isActive: widget.user.isActive,
                              location: widget.user.location,
                              manager: widget.user.manager,
                              role: widget.user.role,
                              store: widget.user.store,
                              target: widget.user.target);
                          UserService.updateStore(user).then((response) {
                            if (response.statusCode == 200) {
                              Navigator.pop(context, true);
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
        labelText: "Full Name",
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

  Widget _buildTextFieldAddress() {
    return TextField(
      controller: _controllerAddress,
      keyboardType: TextInputType.text,
      decoration: const InputDecoration(
        labelText: "Address",
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

  Widget _buildTextFieldPhone() {
    return TextField(
      controller: _controllerPhone,
      keyboardType: TextInputType.number,
      decoration: const InputDecoration(
        labelText: "Phone",
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

  Widget _buildTextFieldEmail() {
    return TextField(
      controller: _controllerEmail,
      keyboardType: TextInputType.emailAddress,
      decoration: const InputDecoration(
        labelText: "Email",
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

  void showSnackbarMessage(String message) {
    ScaffoldMessenger.of(context)
        .showSnackBar(SnackBar(content: Text(message)));
  }
}
