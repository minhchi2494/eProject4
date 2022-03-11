// To parse this JSON data, do
//
//     final store = storeFromJson(jsonString);

import 'dart:convert';

import 'package:sale_man_app/models/Location.dart';

Store storeFromJson(String str) => Store.fromJson(json.decode(str));

String storeToJson(Store data) => json.encode(data.toJson());

class Store {
  Store({
    required this.id,
    required this.name,
    required this.email,
    required this.phone,
    required this.address,
    required this.longitude,
    required this.latitude,
    required this.locationId,
    required this.isActive,
    required this.location,
    required this.storeSalesDetails,
    required this.users,
  });

  String id;
  String name;
  String email;
  String phone;
  String address;
  double longitude;
  double latitude;
  int locationId;
  bool isActive;
  Location? location;
  List<dynamic> storeSalesDetails;
  List<dynamic> users;

  factory Store.fromJson(Map<String, dynamic> json) =>
      Store(
        id: json["id"],
        name: json["name"],
        email: json["email"],
        phone: json["phone"],
        address: json["address"],
        longitude: json["longitude"].toDouble(),
        latitude: json["latitude"].toDouble(),
        locationId: json["locationId"],
        isActive: json["isActive"],
        location: json["location"] == null ? null : Location.fromJson(
            json["location"]),
        storeSalesDetails: List<dynamic>.from(
            json["storeSalesDetails"].map((x) => x)),
        users: List<dynamic>.from(json["users"].map((x) => x)),
      );

  Map<String, dynamic> toJson() =>
      {
        "id": id,
        "name": name,
        "email": email,
        "phone": phone,
        "address": address,
        "longitude": longitude,
        "latitude": latitude,
        "locationId": locationId,
        "isActive": isActive,
        "location": location?.toJson(),
        "storeSalesDetails": List<dynamic>.from(
            storeSalesDetails.map((x) => x)),
        "users": List<dynamic>.from(users.map((x) => x)),
      };
}
