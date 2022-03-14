import 'dart:convert';


import 'package:http/http.dart' as http;
import 'package:sale_man_app/models/User.dart';
import 'package:sale_man_app/network/network_api.dart';

class AuthenticationServices {
  // var client = new http.Client();
  static Uri url = Network.url_user;

  static Future<http.Response> doLogin(String username, String password) async {
    var response = await http.get(Uri.parse('${url}/${username}/${password}?username=${username}'));
    return response;
  }
}