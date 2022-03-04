// To parse this JSON data, do
//
//     final welcome = welcomeFromJson(jsonString);

import 'dart:convert';

Welcome welcomeFromJson(String str) => Welcome.fromJson(json.decode(str));

String welcomeToJson(Welcome data) => json.encode(data.toJson());

class Welcome {
  Welcome({
    required this.id,
    required this.salesActualQuantity,
    required this.targetId,
    required this.productId,
    required this.price,
    required this.date,
    required this.product,
    required this.target,
    required this.storeSalesDetails,
  });

  int id;
  int salesActualQuantity;
  int targetId;
  String productId;
  double price;
  DateTime date;
  List<dynamic> product;
  List<dynamic> target;
  List<dynamic> storeSalesDetails;

  factory Welcome.fromJson(Map<String, dynamic> json) => Welcome(
    id: json["id"],
    salesActualQuantity: json["salesActualQuantity"],
    targetId: json["targetId"],
    productId: json["productId"],
    price: json["price"].toDouble(),
    date: DateTime.parse(json["date"]),
    product: List<dynamic>.from(json["product"].map((x) => x)),
    target: List<dynamic>.from(json["target"].map((x) => x)),
    storeSalesDetails: List<dynamic>.from(json["storeSalesDetails"].map((x) => x)),
  );

  Map<String, dynamic> toJson() => {
    "id": id,
    "salesActualQuantity": salesActualQuantity,
    "targetId": targetId,
    "productId": productId,
    "price": price,
    "date": date.toIso8601String(),
    "product": List<dynamic>.from(product.map((x) => x)),
    "target": List<dynamic>.from(target.map((x) => x)),
    "storeSalesDetails": List<dynamic>.from(storeSalesDetails.map((x) => x)),
  };
}
