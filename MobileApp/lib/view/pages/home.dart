import 'dart:developer';

import 'package:flutter/material.dart';
import 'package:sale_man_app/models/Product.dart';
import 'package:sale_man_app/models/Store.dart';
import 'package:sale_man_app/models/User.dart';
import 'package:sale_man_app/service/product_service.dart';
import 'package:sale_man_app/service/store_service.dart';
import 'package:sale_man_app/service/user_service.dart';

class HomeScreen extends StatefulWidget {
  const HomeScreen({Key? key}) : super(key: key);

  @override
  State<HomeScreen> createState() => _HomeScreenState();
}

class _HomeScreenState extends State<HomeScreen> {
  List<Product> products = [];
  List<Store> stores = [];
  List<User> users = [];

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    ProductService.getProducts().then((data) {
      setState(() {
        products = data;
      });
    });
    StoreService.getStores().then((store) {
      setState(() {
        stores = store;

      });
    });
    UserService.getUsers().then((user) {
      setState(() {
          users = user;
          // for(User item in user){
          //   log('${item.fullname}');
          // }
      });
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.white,
      body: SafeArea(
        child: getBody(),
      ),
    );
  }

  getBody() {
    var size = MediaQuery.of(context).size;
    return Column(
      children: [
        // Stack(
        //   children: [
        //     Padding(
        //       padding: const EdgeInsets.only(top: 10, right: 10),
        //       child: Row(
        //         mainAxisAlignment: MainAxisAlignment.end,
        //         children: const [
        //           Icon(
        //             Icons.menu,
        //             color: Colors.black,
        //             size: 28,
        //           ),
        //         ],
        //       ),
        //     ),
        //   ],
        // ),
        Column(
          children: [
            ListTile(
              title: const Text('Products'),
              trailing: const Text('All'),
              subtitle: Text('This is all the products'),
              onTap: () {
                // setState(() {
                //   Navigator.of(context).pushReplacement(MaterialPageRoute(
                //     builder: (context) => CategoryScreen(),
                //   ));
                // });
              },
            ),
            Expanded(
              flex: 0,
              child: Container(
                height: 60,
                child: ListView.builder(
                    scrollDirection: Axis.horizontal,
                    itemCount: products.length,
                    itemBuilder: (context, index) =>
                        buildProducts(index, context)),
              ),
            ),
          ],
        ),
        Column(
          children: [
            ListTile(
              title: const Text('Store'),
              trailing: const Text('All'),
              subtitle: Text('This is all the stores'),
              onTap: () {
                // setState(() {
                //   Navigator.of(context).pushReplacement(MaterialPageRoute(
                //     builder: (context) => CategoryScreen(),
                //   ));
                // });
              },
            ),
            Expanded(
              flex: 0,
              child: Container(
                height: 60,
                child: ListView.builder(
                    scrollDirection: Axis.horizontal,
                    itemCount: stores.length,
                    itemBuilder: (context, index) =>
                        buildStores(index, context)),
              ),
            ),
          ],
        ),
        Column(
          children: [
            ListTile(
              title: const Text('User'),
              trailing: const Text('All'),
              subtitle: Text('This is all the users'),
              onTap: () {
                // setState(() {
                //   Navigator.of(context).pushReplacement(MaterialPageRoute(
                //     builder: (context) => CategoryScreen(),
                //   ));
                // });
              },
            ),
            Expanded(
              flex: 0,
              child: Container(
                height: 187,
                child: ListView.builder(
                    // scrollDirection: Axis.horizontal,
                    itemCount: users.length,
                    itemBuilder: (context, index) =>
                        buildUser(index, context)),
              ),
            ),
          ],
        ),
      ],
    );
  }

  Widget buildProducts(int index, BuildContext context) {
    return GestureDetector(
      onTap: () {
        setState(() {});
      },
      child: Padding(
        padding: const EdgeInsets.symmetric(horizontal: 20.0),
        child: Container(
          padding: EdgeInsets.all(10.0),
          color: index % 2 == 0 ? Color(0xFF1E57F1) : Color(0xFFFDD100),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [
              Text(
                products[index].name, style: TextStyle(fontSize: 16.0, fontWeight: FontWeight.bold),
              ),
              Text(
                products[index].price.toString(), style: TextStyle(fontSize: 16.0),
              ),
              // Container(
              //   margin: EdgeInsets.only(top: 5.0),
              //   height: 2,
              //   width: 30,
              //   color: isSelected == index ? Colors.black : Colors.grey,
              // )
            ],
          ),
        ),
      ),
    );
  }
  Widget buildStores(int index, BuildContext context) {
    return GestureDetector(
      onTap: () {
        setState(() {});
      },
      child: Padding(
        padding: const EdgeInsets.symmetric(horizontal: 20.0),
        child: Container(
          padding: EdgeInsets.all(10.0),
          color: index % 2 == 0 ? Color(0xFF1E57F1) : Color(0xFFFDD100),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [
              Text(
                stores[index].name, style: TextStyle(fontSize: 16.0, fontWeight: FontWeight.bold),
              ),
              Text(
                stores[index].address, style: TextStyle(fontSize: 16.0),
              ),
              // Container(
              //   margin: EdgeInsets.only(top: 5.0),
              //   height: 2,
              //   width: 30,
              //   color: isSelected == index ? Colors.black : Colors.grey,
              // )
            ],
          ),
        ),
      ),
    );
  }
  Widget buildUser(int index, BuildContext context) {
    return GestureDetector(
      onTap: () {
        setState(() {});
      },
      child: Padding(
        padding: const EdgeInsets.symmetric(horizontal: 20.0),
        child: Container(
          padding: EdgeInsets.all(10.0),
          color: index % 2 == 0 ? Color(0xFF1E57F1) : Color(0xFFFDD100),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [
              Text(
                users[index].fullname, style: TextStyle(fontSize: 16.0, fontWeight: FontWeight.bold),
              ),
              Text(
                users[index].phone, style: TextStyle(fontSize: 16.0),
              ),
              // Container(
              //   margin: EdgeInsets.only(top: 5.0),
              //   height: 2,
              //   width: 30,
              //   color: isSelected == index ? Colors.black : Colors.grey,
              // )
            ],
          ),
        ),
      ),
    );
  }
}
