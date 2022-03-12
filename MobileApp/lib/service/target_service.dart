import 'dart:convert';

import 'package:sale_man_app/network/network_api.dart';
import 'package:http/http.dart' as http;
import 'package:sale_man_app/models/Target.dart';

class TargetService {
  static Uri url = Network.url_target;

  static List<Target> parseTarget(String responeBody) {
    final list = json.decode(responeBody) as List<dynamic>;
    List<Target> target = list.map((e) => Target.fromJson(e)).toList();
    return target;
  }

  static Future<List<Target>> getTarget({int page = 1}) async {
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
