import 'dart:convert';

import 'package:sale_man_app/network/network_api.dart';

import '../models/Product.dart';
import 'package:http/http.dart' as http;

class ProductService {
  static Uri url = Network.url_products;

  static List<Product> parseProduct(String responeBody){
    final list = json.decode(responeBody) as List<dynamic>;
    List<Product> product = list.map((e) => Product.fromJson(e)).toList();
    return product;
  }

  static Future<List<Product>> getProducts({int page = 1}) async{
    final response = await http.get(url);
    if (response.statusCode == 200) {
      return parseProduct(response.body);
    }else if (response.statusCode == 404) {
      throw Exception('Not Found!');
    } else{
      throw Exception('Cant get product');
    }

  }
  static Future<http.Response> updateProduct(Product product) async {
    final response = await http.put(Uri.parse("${url}?Id=${product.id}&Name=${product.name}&Price=${product.price}&Unit=${product.unit}&Images=${product.images}&IsActive=${product.isActive}"),

      body: productToJson(product),
    );
    return response;
  }

}