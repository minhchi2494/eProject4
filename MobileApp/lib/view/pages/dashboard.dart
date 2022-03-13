import 'package:flutter/material.dart';
import 'package:flare_flutter/flare_actor.dart';
import 'package:sale_man_app/view/pages/login.dart';
import 'package:sale_man_app/view/pages/root_app.dart';


class Onboarding extends StatefulWidget{
  static final String path = "lib/view/pages/dashboard.dart";
  @override
  State<Onboarding> createState() => _OnboardingState();
}

const brightYellow = Color(0xFFFDD100);
const darkYellow = Color(0xFFFEB800);

class _OnboardingState extends State<Onboarding> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: brightYellow,
      body: SafeArea(
        child: Column(
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
                color: darkYellow,
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
      ),
    );
  }
}


