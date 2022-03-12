import 'package:flutter/material.dart';
// import 'package:sale_man_app/view/pages/change_password.dart';
import 'package:sale_man_app/view/pages/home.dart';
import 'package:sale_man_app/view/pages/root_app.dart';

class LoginPage extends StatefulWidget {
  const LoginPage({Key? key}) : super(key: key);

  @override
  _LoginPageState createState() => _LoginPageState();
}

class _LoginPageState extends State<LoginPage> {
  // TODO: Add text editing controllers (101)
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SafeArea(
        child: ListView(
          padding: const EdgeInsets.symmetric(horizontal: 24.0),
          children: <Widget>[
            const SizedBox(height: 80.0),
            Column(
              children: <Widget>[
                Image(
                  image: AssetImage('assets/beer.png'),
                  width: 100,
                ),
                SizedBox(height: 16.0),
                Text('Sales Management'),
              ],
            ),
            const SizedBox(height: 120.0),
            // [Name]
            const TextField(
              decoration: InputDecoration(
                filled: true,
                labelText: 'Username',
              ),
            ),
            // spacer
            const SizedBox(height: 12.0),
            // [Password]
            const TextField(
              decoration: InputDecoration(
                filled: true,
                labelText: 'Password',
              ),
              obscureText: true,
            ),
            ElevatedButton(
              child: const Text('Login'),
              onPressed: () {
                Navigator.push(
                  context,
                  MaterialPageRoute(builder: (context) => const RootApp()),
                );
              },
            ),
            // TODO: Add an elevation to NEXT (103)
            // TODO: Add a beveled rectangular border to NEXT (103)
            TextButton(
              child: const Text('Forgot Password.'),
              onPressed: () {
                // Navigator.push(
                //   context,
                //   MaterialPageRoute(
                //       builder: (context) => const ChangePassword()),
                // );
              },
            ),
          ],
        ),
      ),
    );
  }
}
