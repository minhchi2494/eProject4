import 'dart:convert';

import 'package:sale_man_app/network/network_api.dart';

import '../models/Store.dart';
import 'package:http/http.dart' as http;

class StoreService {
  static Uri url = Network.url_store;

  static List<Store> parseStore(String responeBody){
    final list = json.decode(responeBody) as List<dynamic>;
    List<Store> store = list.map((e) => Store.fromJson(e)).toList();
    return store;
  }

  static Future<List<Store>> getStores({int page = 1}) async{
    final response = await http.get(url);
    if (response.statusCode == 200) {
      return parseStore(response.body);
    }else if (response.statusCode == 404) {
      throw Exception('Not Found!');
    } else{
      throw Exception('Cant get product');
    }

  }
}