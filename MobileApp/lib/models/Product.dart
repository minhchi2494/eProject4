import 'dart:convert';

import 'dart:ffi';

class Product {
  String id;
  String name;
  Float price;
  String unit;
  String images;
  bool isActive;
  String imagesNavigation;
  String salesDetails;
  String storeSalesDetails;

  Product(this.id,this.name,this.price,this.unit,this.images,this.isActive,this.imagesNavigation,this.salesDetails,this.storeSalesDetails);

   Product.fromJson(dynamic json)
  {
    id = json["id"];
    name = json["name"];
    price = json["price"];
    unit = json["unit"];
    images = json["images"];
    isActive = json["isActive"];
    imagesNavigation = json["imagesNavigation"];
    salesDetails = json["salesDetails"];
    storeSalesDetails = json["storeSalesDetails"];
  }

  Map<String,dynamic> toJson()
  {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data["id"] = id;
    data["name"] = name;
    data["price"] = price;
    data["unit"] = unit;
    data["images"] = images;
    data["isActive"] = isActive;
    data["imagesNavigation"] = imagesNavigation;
    data["salesDetails"] = salesDetails;
    data["storeSalesDetails"] = storeSalesDetails;
    return data;
  }
}

