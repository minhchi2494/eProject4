import 'package:flutter/material.dart';
import 'package:sale_man_app/models/User.dart';
import 'package:sale_man_app/service/user_service.dart';
import 'package:sale_man_app/view/pages/profile/update_profile.dart';

class Profile extends StatefulWidget {
  const Profile({Key? key}) : super(key: key);

  @override
  State<Profile> createState() => _ProfileState();
}

class _ProfileState extends State<Profile> {
  List<User> users = [];
  // late int id;
  @override
  void initState() {
    // TODO: implement initState
    super.initState();
    UserService.getUsers().then((user) {
      setState(() {
        users = user;
        // for(User item in user){
        //   log('${item.fullname}');
        // }
      });
    });
    // UserService.getUserDetails(id);
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
    return SingleChildScrollView(
      child: Column(
        children: <Widget>[
          Stack(
            children: [
              Container(
                width: double.infinity,
                margin: const EdgeInsets.only(top: 10),
                child: Column(
                  children: <Widget>[
                    const SizedBox(height: 5.0),
                    Text(
                      users[0].fullname,
                      style: TextStyle(fontWeight: FontWeight.bold, fontSize: 18.0),
                    ),
                    const SizedBox(height: 5.0),
                  ],
                ),
              )
            ],
          ),
          const SizedBox(height: 10.0),
          UserInfo(),
        ],
      ),
    );
  }

  Widget UserInfo() {
    return Container(
      padding: EdgeInsets.all(10),
      child: Column(
        children: <Widget>[
          Container(
            padding: const EdgeInsets.only(left: 8.0, bottom: 4.0),
            alignment: Alignment.topLeft,
            child: Text(
              "User Information",
              style: TextStyle(
                color: Colors.black87,
                fontWeight: FontWeight.w500,
                fontSize: 16,
              ),
              textAlign: TextAlign.left,
            ),
          ),
          Card(
            child: Container(
              alignment: Alignment.topLeft,
              padding: EdgeInsets.all(15),
              child: Column(
                children: <Widget>[
                  Column(
                    children: <Widget>[
                      ...ListTile.divideTiles(
                        color: Colors.grey,
                        tiles: [
                          ListTile(
                            // contentPadding: EdgeInsets.symmetric(
                            //     horizontal: 12, vertical: 4),
                            leading: Icon(Icons.my_location),
                            title: Text("Location"),
                            // subtitle: Text("Kathmandu"),
                              subtitle: Text(users[0].address)
                          ),
                          ListTile(
                            leading: Icon(Icons.email),
                            title: Text("Email"),
                            // subtitle: Text("sudeptech@gmail.com"),
                              subtitle: Text(users[0].email),
                          ),
                          ListTile(
                            leading: Icon(Icons.phone),
                            title: Text("Phone"),
                            // subtitle: Text("99--99876-56"),
                              subtitle: Text(users[0].phone),
                          ),
                        ],
                      ),
                    ],
                  ),
                  Row(
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: [
                      Expanded(
                        child: ElevatedButton(
                          child: const Text('Update'),
                          onPressed: () {
                            Navigator.push(
                                context,
                                MaterialPageRoute(
                                    builder: (context) => ProfileUpdate(user: users[0],)));
                          },
                        ),
                      ),
                    ],
                  ),
                  Row(
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: [
                      Expanded(
                        child: ElevatedButton(
                          child: const Text('Logout'),
                          onPressed: () {
                            Navigator.pop(context);
                          },
                        ),
                      ),
                    ],
                  ),
                ],
              ),
            ),
          )
        ],
      ),
    );
  }
}