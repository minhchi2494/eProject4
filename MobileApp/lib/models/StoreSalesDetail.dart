// To parse this JSON data, do
//
//     final storeSalesDetail = storeSalesDetailFromJson(jsonString);

import 'dart:convert';

import 'package:sale_man_app/models/Product.dart';
import 'package:sale_man_app/models/SaleDetail.dart';
import 'package:sale_man_app/models/Store.dart';

StoreSalesDetail storeSalesDetailFromJson(String str) => StoreSalesDetail.fromJson(json.decode(str));

String storeSalesDetailToJson(StoreSalesDetail data) => json.encode(data.toJson());

class StoreSalesDetail {
  StoreSalesDetail({
    required this.id,
    required this.quantityCommit,
    required this.salesDetailId,
    required this.productId,
    required this.price,
    required this.date,
    required this.storeId,
    required this.storeActualQuantity,
    required this.product,
    required this.salesDetail,
    required this.store,
  });

  int id;
  int quantityCommit;
  int salesDetailId;
  String productId;
  double price;
  DateTime date;
  String storeId;
  int storeActualQuantity;
  Product product;
  SalesDetail salesDetail;
  Store store;

  factory StoreSalesDetail.fromJson(Map<String, dynamic> json) => StoreSalesDetail(
    id: json["id"],
    quantityCommit: json["quantityCommit"],
    salesDetailId: json["salesDetailId"],
    productId: json["productId"],
    price: json["price"].toDouble(),
    date: DateTime.parse(json["date"]),
    storeId: json["storeId"],
    storeActualQuantity: json["storeActualQuantity"],
    product: Product.fromJson(json["product"]),
    salesDetail: SalesDetail.fromJson(json["salesDetail"]),
    store: Store.fromJson(json["store"]),
  );

  Map<String, dynamic> toJson() => {
    "id": id,
    "quantityCommit": quantityCommit,
    "salesDetailId": salesDetailId,
    "productId": productId,
    "price": price,
    "date": date.toIso8601String(),
    "storeId": storeId,
    "storeActualQuantity": storeActualQuantity,
    "product": product.toJson(),
    "salesDetail": salesDetail.toJson(),
    "store": store.toJson(),
  };
}

