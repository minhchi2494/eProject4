import 'package:flutter/material.dart';
import 'package:flare_flutter/flare_actor.dart';
import 'package:sale_man_app/view/pages/login.dart';


class Onboarding extends StatefulWidget{
  static final String path = "lib/view/pages/dashboard.dart";
  @override
  State<Onboarding> createState() => _OnboardingState();
}

const brightBlue = Color(0xFF1E57F1);
const darkBlue = Color(0xF1001E57);

class _OnboardingState extends State<Onboarding> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: brightBlue,
      body: Column(
        children: [
          const Flexible(
            flex: 8,
            child: FlareActor(
              'assets/flare/bus.flr',
              alignment: Alignment.center,
              fit: BoxFit.contain,
              animation: 'driving',
            ),
          ),
          Flexible(
            flex: 2,
            child: RaisedButton(
              color: darkBlue,
              elevation: 4,
              shape: RoundedRectangleBorder(
                  borderRadius: BorderRadius.circular(50)),
              child: const Text(
                'Get Started',
                style: TextStyle(color: Colors.white),
              ),
              onPressed: () {
                Navigator.push(
                  context,
                  MaterialPageRoute(builder: (context) => const LoginPage()),
                );
              }
            ),
          ),
        ],
      ),
    );
  }
}


