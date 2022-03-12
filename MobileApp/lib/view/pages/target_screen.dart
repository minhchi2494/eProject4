import 'package:flutter/material.dart';
import 'package:sale_man_app/models/Target.dart';
import 'package:sale_man_app/service/target_service.dart';
import 'package:sale_man_app/view/pages/target/create_target.dart';
import 'package:sale_man_app/view/pages/target/detail_target.dart';

class TargetScreen extends StatefulWidget{
  const TargetScreen({Key? key}) : super(key: key);

  @override
  State<TargetScreen> createState() => _TargetScreenState();
}

class _TargetScreenState extends State<TargetScreen> {
  List<Target> target = [];

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    TargetService.getTarget().then((data) {
      setState(() {
        target = data;
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
              title: const Text('Actual/Target'),
              trailing: const Text('all'),
              subtitle: Text('This is all the actual quantity and targets'),
              onTap: () {
                // setState(() {
                //   Navigator.of(context).pushReplacement(MaterialPageRoute(
                //     builder: (context) => CategoryScreen(),
                //   ));
                // });
              },
            ),
            // Expanded(
            //   flex: 1,
               Container(
                height: 450,
                child: ListView.builder(
                    scrollDirection: Axis.vertical,
                    itemCount: target.length,
                    itemBuilder: (context, index) =>
                        buildProducts(index, context)),
              ),
            // ),
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
        padding: EdgeInsets.zero,
        child: Container(
          padding: EdgeInsets.all(10.0),
          color: index % 2 == 0 ? Color(0xFF1E57F1) : Color(0xFFFDD100),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            mainAxisAlignment: MainAxisAlignment.spaceBetween,
            children: [
              Text(
                'Targets: ${target[index].targets.toString()}', style: TextStyle(fontSize: 16.0, fontWeight: FontWeight.bold),
              ),
              Text(
                'Actual Quantity: ${target[index].actualQuantity.toString()}', style: TextStyle(fontSize: 16.0, fontWeight: FontWeight.bold),
              ),
            ],
          ),
        ),
      ),
    );
  }
}