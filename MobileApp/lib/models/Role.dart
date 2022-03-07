// To parse this JSON data, do
//
//     final role = roleFromJson(jsonString);

import 'dart:convert';

Role roleFromJson(String str) => Role.fromJson(json.decode(str));

String roleToJson(Role data) => json.encode(data.toJson());

class Role {
  Role({
    required this.id,
    required this.title,
    required this.isActive,
    required this.users,
  });

  int id;
  String title;
  bool isActive;
  List<dynamic> users;

  factory Role.fromJson(Map<String, dynamic> json) => Role(
    id: json["id"],
    title: json["title"],
    isActive: json["isActive"],
    users: List<dynamic>.from(json["users"].map((x) => x)),
  );

  Map<String, dynamic> toJson() => {
    "id": id,
    "title": title,
    "isActive": isActive,
    "users": List<dynamic>.from(users.map((x) => x)),
  };
}
