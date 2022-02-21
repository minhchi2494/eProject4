import 'package:flutter/material.dart';

class HomeScreen extends StatefulWidget {
  const HomeScreen({Key? key}) : super(key: key);

  @override
  State<HomeScreen> createState() => _HomeScreenState();
}

class _HomeScreenState extends State<HomeScreen> {
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
            SizedBox(
              width: size.width,
              // height: 500,
              // decoration: BoxDecoration(
              //   image:
              // ),
            ),
            Padding(
              padding: const EdgeInsets.only(top: 35, right: 10),
              child: Row(
                mainAxisAlignment: MainAxisAlignment.end,
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
            ),
          ],
        ),
        const SizedBox(
          height: 10,
        ),

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
        const SizedBox(height: 20,),
        // Nội Dung
        Row(
          // nội dung
          children: [],
        ),
        const SizedBox(
          height: 40,
        ),

        //title top area
        Row(
          children: [
            const Text(
              "Top Area",
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
        const SizedBox(height: 20,),
        // nội dung
        Row(
          // nội dung
          children: [],
        ),
        const SizedBox(
          height: 40,
        ),

        //title top product
        Row(
          children: [
            const Text(
              "Top Products",
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
        const SizedBox(height: 20,),
        // nội dung
        Row(
          // nội dung
          children: [],
        ),
        const SizedBox(
          height: 40,
        ),

        //title top store
        Row(
          children: [
            const Text(
              "Top Store",
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
        const SizedBox(height: 20,),
        // nội dung
        Row(
          // nội dung
          children: [],
        ),
        const SizedBox(
          height: 40,
        ),
      ],
    );
  }
}
