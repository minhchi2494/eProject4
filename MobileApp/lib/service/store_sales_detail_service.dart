import 'dart:convert';

import 'package:sale_man_app/models/StoreSalesDetail.dart';
import 'package:sale_man_app/network/network_api.dart';

import '../models/Product.dart';
import 'package:http/http.dart' as http;

class StoreSalesDetailService {
  static Uri url = Network.url_products;

  static List<StoreSalesDetail> parseStoreSalesDetail(String responeBody){
    final list = json.decode(responeBody) as List<dynamic>;
    List<StoreSalesDetail> product = list.map((e) => StoreSalesDetail.fromJson(e)).toList();
    return product;
  }

  static Future<List<StoreSalesDetail>> getStoreSalesDetails({int page = 1}) async{
    final response = await http.get(url);
    if (response.statusCode == 200) {
      return parseStoreSalesDetail(response.body);
    }else if (response.statusCode == 404) {
      throw Exception('Not Found!');
    } else{
      throw Exception('Cant get product');
    }

  }
  static Future<http.Response> createStoreSalesDetail(StoreSalesDetail storeSalesDetail) async {
    final response = await http.post(Uri.parse("${url}?storeId=${storeSalesDetail.storeId}&ProductId=${storeSalesDetail.productId}&Date=${storeSalesDetail.date}&StoreId=${storeSalesDetail.storeId}&StoreActualQuantity=${storeSalesDetail.storeActualQuantity}"),
      body: storeSalesDetailToJson(storeSalesDetail),
    );
    return response;
  }

}