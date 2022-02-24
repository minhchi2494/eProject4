import 'package:flutter/material.dart';
import 'package:sale_man_app/view/pages/target/create_target.dart';
import 'package:sale_man_app/view/pages/target/detail_target.dart';

class TargetScreen extends StatefulWidget{
  const TargetScreen({Key? key}) : super(key: key);

  @override
  State<TargetScreen> createState() => _TargetScreenState();
}

class _TargetScreenState extends State<TargetScreen> {
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
                  "Actual/Target",
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
                          onPressed: () => Navigator.push(context, MaterialPageRoute(builder: (context) => CreateTarget()))
                        ),
                      ],
                    ),
                  ],
                )
            ),
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
        const SizedBox(height: 20,),
        // Nội Dung
        Row(
          // nội dung
          children: [
            ElevatedButton(
                child: const Text('Detail'),
                onPressed: () => Navigator.push(context, MaterialPageRoute(builder: (context) => DetailTarget()))
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