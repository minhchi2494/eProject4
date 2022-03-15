import 'package:flutter/material.dart';
import 'package:sale_man_app/models/User.dart';
import 'package:sale_man_app/service/login.dart';
// import 'package:sale_man_app/view/pages/change_password.dart';
import 'package:sale_man_app/view/pages/home.dart';
import 'package:sale_man_app/view/pages/root_app.dart';

class LoginPage extends StatefulWidget {
  const LoginPage({Key? key}) : super(key: key);

  @override
  _LoginPageState createState() => _LoginPageState();
}

class _LoginPageState extends State<LoginPage> {
  late bool _isFieldEmailValid;
  late bool _isFieldPasswordValid;

  late User user;

  TextEditingController _controllerUsername = TextEditingController();
  TextEditingController _controllerPassword = TextEditingController();
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SafeArea(
        child: Padding(
          padding: const EdgeInsets.symmetric(horizontal: 24.0),
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            crossAxisAlignment: CrossAxisAlignment.center,
            children: <Widget>[
              Column(
                children: <Widget>[
                  Image(
                    image: AssetImage('assets/beer.png'),
                    width: 50,
                  ),
                  SizedBox(height: 16.0),
                  Text('Sales Management'),
                ],
              ),
              const SizedBox(height: 10.0),
              // [Name]
              TextField(
                controller: _controllerUsername,
                decoration: InputDecoration(
                  filled: true,
                  labelText: 'Username',
                ),
              ),
              // spacer
              const SizedBox(height: 12.0),
              // [Password]
              TextField(
                controller: _controllerPassword,
                decoration: InputDecoration(
                  filled: true,
                  labelText: 'Password',
                ),
                obscureText: true,
              ),
              ElevatedButton(
                child: const Text('Login'),
                onPressed: () {
                  // Navigator.push(
                  //   context,
                  //   MaterialPageRoute(builder: (context) => const RootApp()),
                  // );
                  String username = _controllerUsername.text.toString().trim();
                  String pass = _controllerPassword.text.toString().trim();
                  if (username.isEmpty) {
                    showSnackbarMessage("Username is required");
                  } else if (pass.isEmpty) {
                    showSnackbarMessage("Password is required");
                  } else {
                    setState(() {
                      AuthenticationServices.doLogin(username, pass).then((response) {
                        if (response.statusCode == 200) {
                          Navigator.push(context, MaterialPageRoute(builder: (context) => RootApp(),));
                        } else {
                          print("error: " + response.statusCode.toString());
                          showSnackbarMessage("Invalid username and password");
                        }
                      });
                    });
                  }
                },
              ),
              // TODO: Add an elevation to NEXT (103)
              // TODO: Add a beveled rectangular border to NEXT (103)
            ],
          ),
        ),
      ),
    );
  }

  void showSnackbarMessage(String message) {
    ScaffoldMessenger.of(context)
        .showSnackBar(SnackBar(content: Text(message)));
  }
}
