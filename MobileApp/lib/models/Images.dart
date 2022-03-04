// To parse this JSON data, do
//
//     final welcome = welcomeFromJson(jsonString);

import 'dart:convert';

Welcome welcomeFromJson(String str) => Welcome.fromJson(json.decode(str));

String welcomeToJson(Welcome data) => json.encode(data.toJson());

class Welcome {
  Welcome({
    required this.id,
    required this.images,
    required this.productId,
    this.product,
  });

  int id;
  String images;
  String productId;
  dynamic product;

  factory Welcome.fromJson(Map<String, dynamic> json) => Welcome(
    id: json["id"],
    images: json["images"],
    productId: json["productId"],
    product: json["product"],
  );

  Map<String, dynamic> toJson() => {
    "id": id,
    "images": images,
    "productId": productId,
    "product": product,
  };
}
