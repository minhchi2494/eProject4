// To parse this JSON data, do
//
//     final welcome = welcomeFromJson(jsonString);

import 'dart:convert';

Welcome welcomeFromJson(String str) => Welcome.fromJson(json.decode(str));

String welcomeToJson(Welcome data) => json.encode(data.toJson());

class Welcome {
  Welcome({
    required this.id,
    required this.quantityCommit,
    required this.salesDetailId,
    required this.productId,
    required this.price,
    required this.date,
    required this.storeId,
    required this.storeActualQuantity,
    required this.product,
    required this.store,
    required this.salesDetail,
  });

  int id;
  int quantityCommit;
  int salesDetailId;
  String productId;
  double price;
  DateTime date;
  String storeId;
  int storeActualQuantity;
  List<dynamic> product;
  List<dynamic> salesDetail;
  List<dynamic> store;

  factory Welcome.fromJson(Map<String, dynamic> json) => Welcome(
    id: json["id"],
    quantityCommit: json["quantityCommit"],
    salesDetailId: json["salesDetailId"],
    productId: json["productId"],
    price: json["price"].toDouble(),
    date: DateTime.parse(json["date"]),
    storeId: json["storeId"],
    storeActualQuantity: json["storeActualQuantity"],
    product: List<dynamic>.from(json["product"].map((x) => x)),
    salesDetail: List<dynamic>.from(json["salesDetail"].map((x) => x)),
    store: List<dynamic>.from(json["store"].map((x) => x)),
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
    "product": List<dynamic>.from(product.map((x) => x)),
    "salesDetail": List<dynamic>.from(salesDetail.map((x) => x)),
    "store": List<dynamic>.from(store.map((x) => x)),
  };
}
