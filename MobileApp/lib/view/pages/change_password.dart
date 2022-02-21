import 'package:flutter/material.dart';
import 'package:sale_man_app/view/pages/login.dart';

class ChangePassword extends StatefulWidget{
  const ChangePassword({Key? key}) : super(key: key);

  @override
  State<ChangePassword> createState() => _ChangePasswordState();
}

class _ChangePasswordState extends State<ChangePassword> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SafeArea(
        child: ListView(
          padding: const EdgeInsets.symmetric(horizontal: 24.0),
          children: <Widget>[
            const SizedBox(height: 80.0),
            Column(
              children: const <Widget>[
                // Image.asset('assets/diamond.png'),
                Text('Icon'),
                SizedBox(height: 16.0),
                Text('Sales Management'),
              ],
            ),
            const SizedBox(height: 120.0),
            // [Name]
            const TextField(
              decoration: InputDecoration(
                filled: true,
                labelText: 'Email',
              ),
            ),
            // spacer
            const SizedBox(height: 12.0),
            // Button
            ElevatedButton(
              child: const Text('Reset'),
              onPressed: () {
                // TODO: Show the next page (101)
              },
            ),
            // TODO: Add an elevation to NEXT (103)
            // TODO: Add a beveled rectangular border to NEXT (103)
            TextButton(
              child: const Text('Login'),
              onPressed: () {
                Navigator.pop(context);
              },
            ),
          ],
        ),
      ),
    );
  }
}