import 'package:flutter/material.dart';
import 'package:sale_man_app/models/Target.dart';
import 'package:sale_man_app/models/TargetUser.dart';
import 'package:sale_man_app/service/target_service.dart';
import 'package:sale_man_app/service/target_user_service.dart';
import 'package:sale_man_app/view/pages/target/create_target.dart';
import 'package:sale_man_app/view/pages/target/detail_target.dart';

class TargetScreen extends StatefulWidget{
  const TargetScreen({Key? key}) : super(key: key);

  @override
  State<TargetScreen> createState() => _TargetScreenState();
}

class _TargetScreenState extends State<TargetScreen> {
  List<Target> target = [];
  List<TargetUser> targetUser = [];

  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    TargetService.getTarget().then((data) {
      setState(() {
        target = data;
      });
    });
    TargetUserService.getTargetUser().then((data) {
      setState(() {
        targetUser = data;
        // for(TargetUser item in targetUser){
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
                    // itemCount: target.length,
                   // itemCount: targetUser.length,
                    itemCount: 1,
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
                'Full name: ${targetUser[0].fullname}', style: TextStyle(fontSize: 16.0, fontWeight: FontWeight.bold),
              ),
              Text(
                'Targets: ${targetUser[0].targets.toString()}', style: TextStyle(fontSize: 16.0, fontWeight: FontWeight.bold),
                // 'Targets: ${target[index].targets.toString()}', style: TextStyle(fontSize: 16.0, fontWeight: FontWeight.bold),
              ),
              Text(
                'Actual Quantity: ${targetUser[0].actualQuantity.toString()}', style: TextStyle(fontSize: 16.0, fontWeight: FontWeight.bold),
                // 'Actual Quantity: ${target[index].actualQuantity.toString()}', style: TextStyle(fontSize: 16.0, fontWeight: FontWeight.bold),
              ),
            ],
          ),
        ),
      ),
    );
  }
}