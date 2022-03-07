import 'dart:convert';

import 'package:sale_man_app/models/Location.dart';
import 'package:sale_man_app/models/Manager.dart';
import 'package:sale_man_app/models/Role.dart';
import 'package:sale_man_app/models/Store.dart';
import 'package:sale_man_app/models/Target.dart';

User userFromJson(String str) => User.fromJson(json.decode(str));

String userToJson(User data) => json.encode(data.toJson());

class User {
  User({
    required this.id,
    required this.targetId,
    required this.username,
    required this.password,
    required this.fullname,
    required this.email,
    required this.phone,
    required this.address,
    required this.storeId,
    required this.locationId,
    required this.roleId,
    required this.managerId,
    required this.isActive,
    required this.location,
    required this.manager,
    required this.role,
    required this.store,
    required this.target,
  });

  int id;
  int targetId;
  String username;
  String password;
  String fullname;
  String email;
  String phone;
  String address;
  String storeId;
  int locationId;
  int roleId;
  String managerId;
  bool isActive;
  Location? location;
  Manager? manager;
  Role? role;
  Store? store;
  Target? target;

  factory User.fromJson(Map<String, dynamic> json) => User(
    id: json["id"],
    targetId: json["targetId"],
    username: json["username"],
    password: json["password"],
    fullname: json["fullname"],
    email: json["email"],
    phone: json["phone"],
    address: json["address"],
    storeId: json["storeId"],
    locationId: json["locationId"],
    roleId: json["roleId"],
    managerId: json["managerId"],
    isActive: json["isActive"],
    location: json["location"] == null  ? null : Location.fromJson(json["location"]),
    manager: json["manager"] == null  ? null : Manager.fromJson(json["manager"]),
    role: Role.fromJson(json["role"]),
    store: json["store"] == null  ? null : Store.fromJson(json["store"]),
    target: Target.fromJson(json["target"]),
  );

  Map<String, dynamic> toJson() => {
    "id": id,
    "targetId": targetId,
    "username": username,
    "password": password,
    "fullname": fullname,
    "email": email,
    "phone": phone,
    "address": address,
    "storeId": storeId,
    "locationId": locationId,
    "roleId": roleId,
    "managerId": managerId,
    "isActive": isActive,
    "location": location?.toJson(),
    "manager": manager?.toJson(),
    "role": role?.toJson(),
    "store": store?.toJson(),
    "target": target?.toJson(),
  };
}