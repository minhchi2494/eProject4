// To parse this JSON data, do
//
//     final location = locationFromJson(jsonString);

import 'dart:convert';

Location locationFromJson(String str) => Location.fromJson(json.decode(str));

String locationToJson(Location data) => json.encode(data.toJson());

class Location {
  Location({
    required this.id,
    required this.district,
    required this.ward,
    required this.isActive,
    required this.managers,
    required this.stores,
    required this.users,
  });

  int id;
  String district;
  String ward;
  bool isActive;
  List<dynamic> managers;
  List<dynamic> stores;
  List<dynamic> users;

  factory Location.fromJson(Map<String, dynamic> json) => Location(
    id: json["id"],
    district: json["district"],
    ward: json["ward"],
    isActive: json["isActive"],
    managers: List<dynamic>.from(json["managers"].map((x) => x)),
    stores: List<dynamic>.from(json["stores"].map((x) => x)),
    users: List<dynamic>.from(json["users"].map((x) => x)),
  );

  Map<String, dynamic> toJson() => {
    "id": id,
    "district": district,
    "ward": ward,
    "isActive": isActive,
    "managers": List<dynamic>.from(managers.map((x) => x)),
    "stores": List<dynamic>.from(stores.map((x) => x)),
    "users": List<dynamic>.from(users.map((x) => x)),
  };
}
