import 'dart:convert';

import 'package:sale_man_app/network/network_api.dart';
import 'package:http/http.dart' as http;
import 'package:sale_man_app/models/TargetUser.dart';

class TargetUserService {
  static Uri url = Network.url_targetUser;

  static List<TargetUser> parseTarget(String responeBody) {
    final list = json.decode(responeBody) as List<dynamic>;
    List<TargetUser> target = list.map((e) => TargetUser.fromJson(e)).toList();
    return target;
  }

  static Future<List<TargetUser>> getTargetUser({int page = 1}) async {
    final response = await http.get(url);
    if (response.statusCode == 200) {
      return parseTarget(response.body);
    } else if (response.statusCode == 404) {
      throw Exception('Not Found!');
    } else {
      throw Exception('Cant get product');
    }
  }
}
