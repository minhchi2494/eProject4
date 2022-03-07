// To parse this JSON data, do
//
//     final manager = managerFromJson(jsonString);

import 'dart:convert';

import 'package:sale_man_app/models/Location.dart';

Manager managerFromJson(String str) => Manager.fromJson(json.decode(str));

String managerToJson(Manager data) => json.encode(data.toJson());

class Manager {
  Manager({
    required this.id,
    required this.fullname,
    required this.locationId,
    required this.staffQuantity,
    required this.location,
    required this.users,
  });

  String id;
  String fullname;
  int locationId;
  int staffQuantity;
  Location? location;
  List<dynamic> users;

  factory Manager.fromJson(Map<String, dynamic> json) => Manager(
    id: json["id"],
    fullname: json["fullname"],
    locationId: json["locationId"],
    staffQuantity: json["staffQuantity"],
    location: json["location"] == null  ? null : Location.fromJson(json["location"]),
    users: List<dynamic>.from(json["users"].map((x) => x)),
  );

  Map<String, dynamic> toJson() => {
    "id": id,
    "fullname": fullname,
    "locationId": locationId,
    "staffQuantity": staffQuantity,
    "location": location?.toJson(),
    "users": List<dynamic>.from(users.map((x) => x)),
  };
}

