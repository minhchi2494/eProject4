// To parse this JSON data, do
//
//     final product = productFromJson(jsonString);

import 'dart:convert';

Product productFromJson(String str) => Product.fromJson(json.decode(str));

String productToJson(Product data) => json.encode(data.toJson());

class Product {
  Product({
    required this.name,
    required this.id,
    required this.price,
    required this.unit,
    required this.images,
    required this.isActive,
    required this.imagesNavigation,
    required this.salesDetails,
    required this.storeSalesDetails,
  });

  String id;
  String name;
  double price;
  String unit;
  String images;
  bool isActive;
  List<dynamic> imagesNavigation;
  List<dynamic> salesDetails;
  List<dynamic> storeSalesDetails;

  factory Product.fromJson(Map<String, dynamic> json) => Product(
    id: json["id"],
    name: json["name"],
    price: json["price"].toDouble(),
    unit: json["unit"],
    images: json["images"],
    isActive: json["isActive"],
    imagesNavigation: List<dynamic>.from(json["imagesNavigation"].map((x) => x)),
    salesDetails: List<dynamic>.from(json["salesDetails"].map((x) => x)),
    storeSalesDetails: List<dynamic>.from(json["storeSalesDetails"].map((x) => x)),
  );

  Map<String, dynamic> toJson() => {
    "id": id,
    "name": name,
    "price": price,
    "unit": unit,
    "images": images,
    "isActive": isActive,
    "imagesNavigation": List<dynamic>.from(imagesNavigation.map((x) => x)),
    "salesDetails": List<dynamic>.from(salesDetails.map((x) => x)),
    "storeSalesDetails": List<dynamic>.from(storeSalesDetails.map((x) => x)),
  };
}
