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

  // Future<User> changePassword(String newPassword) async {
  //   String jsonData = await sharedPreferencesHelper.getUserDataModel();
  //   User user = User.fromJson(jsonDecode(jsonData));
  //
  //   var body = json.encode({
  //     "id": user.id,
  //     "newPassword": newPassword
  //   });
  //
  //   var response = await client.post('${Server.baseUrl}/change-password', body: body, headers: headers);
  //   if (response.statusCode != 200) {
  //     return null;
  //   } else {
  //     JsonResult jsonResult = JsonResult.fromJson(jsonDecode(response.body));
  //     if (jsonResult.success) {
  //       user = User.fromJson(jsonResult.data);
  //     }
  //     return user;
  //   }
  // }

//  url image: https://my.vietphilcamp.com/storage/users/default.png
}