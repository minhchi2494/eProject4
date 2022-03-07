import 'package:flutter/material.dart';
import 'package:sale_man_app/view/Icon/Constrant.dart';
import 'package:sale_man_app/view/pages/home.dart';
import 'package:sale_man_app/view/pages/product_screen.dart';
import 'package:sale_man_app/view/pages/profile.dart';
import 'package:sale_man_app/view/pages/store_screen.dart';
import 'package:sale_man_app/view/pages/target_screen.dart';

class RootApp extends StatefulWidget {
  const RootApp({Key? key}) : super(key: key);

  @override
  State<RootApp> createState() => _RootAppState();
}

class _RootAppState extends State<RootApp> {
  int activeTab = 0;

  AppBar? appbar;
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: Colors.white,
      bottomNavigationBar: getFooter(),
      appBar: getAppBar(),
      body: getBody(),
    );
  }

  getAppBar() {
    switch (activeTab) {
      case 0:
        return AppBar(
          elevation: 0.8,
          backgroundColor: Colors.white,
          title: Row(
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [
              Text(
                "Home",
                style: TextStyle(color: Colors.black),
              ),
              TextButton(
                style: ElevatedButton.styleFrom(
                  onPrimary: Colors.white, // background
                ),
                child: const Icon(
                  Icons.menu,
                  color: Colors.black,
                  size: 28,
                ),
                onPressed: () {},
              ),
            ],
          ),
        );
        break;
      case 1:
        return AppBar(
          elevation: 0.8,
          backgroundColor: Colors.white,
          title: const Text(
            "Products",
            style: TextStyle(color: Colors.black),
          ),
        );
        break;
      case 2:
        return AppBar(
          elevation: 0.8,
          backgroundColor: Colors.white,
          title: Container(
            child: Row(
              mainAxisAlignment: MainAxisAlignment.spaceBetween,
              children: [
                const Text(
                  "Location",
                  style: TextStyle(color: Colors.black),
                ),
                const SizedBox(
                  height: 20,
                ),
                TextButton(
                  style: ElevatedButton.styleFrom(
                    onPrimary: Colors.white, // background
                  ),
                  child: const Icon(
                    Icons.menu,
                    color: Colors.black,
                    size: 28,
                  ),
                  onPressed: () {},
                ),
              ],
            ),
          ),
        );
        break;
      case 3:
        return AppBar(
          elevation: 0.8,
          backgroundColor: Colors.white,
          title: const Text(
            "Target",
            style: TextStyle(color: Colors.black),
          ),
        );
        break;
      case 4:
        return AppBar(
          elevation: 0.8,
          backgroundColor: Colors.white,
          title: const Text(
            "Profile",
            style: TextStyle(color: Colors.black),
          ),
        );
        break;
      default:
    }
  }

  getBody() {
    return IndexedStack(
      index: activeTab,
      children: const [
        HomeScreen(),
        ProductScreen(),
        StoreScreen(),
        TargetScreen(),
        Profile()
      ],
    );
  }

  getFooter() {
    return Container(
      height: 80,
      decoration: BoxDecoration(
          color: Colors.white,
          border: Border(top: BorderSide(color: Colors.grey.withOpacity(0.2)))),
      child: Padding(
        padding: const EdgeInsets.only(left: 10, right: 10, top: 5),
        child: Row(
            crossAxisAlignment: CrossAxisAlignment.start,
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: List.generate(itemsTab.length, (index) {
              return IconButton(
                  icon: Icon(
                    itemsTab[index]['icon'],
                    size: itemsTab[index]['size'],
                    color: activeTab == index
                        ? const Color(0xFF1E57F1)
                        : Colors.black,
                  ),
                  onPressed: () {
                    setState(() {
                      activeTab = index;
                    });
                  });
            })),
      ),
    );
  }
}
