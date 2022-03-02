import 'dart:convert';

import 'package:sale_man_app/network/network_api.dart';

import '../models/Product.dart';
import 'package:http/http.dart' as http;

class ProductService {
  static Uri url = Network.url_products;

  static List<Product> parseProduct(String responeBody){
    Map<String, dynamic> map = json.decode(responeBody);

    List<dynamic> data = map["data"];

    List<Product> products = data.map((model) => Product.fromJson(model)).toList();
    return products;
  }

  static Future<List<Product>> fetchProducts({int page = 1}) async{
    final response = await http.get(url);
    if (response.statusCode == 200) {
      return parseProduct(response.body);
    }else if (response.statusCode == 404) {
      throw Exception('Not Found!');
    } else{
      throw Exception('Cant get product');
    }

  }
}