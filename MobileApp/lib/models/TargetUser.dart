// To parse this JSON data, do
//
//     final targetUser = targetUserFromJson(jsonString);

import 'dart:convert';

TargetUser targetUserFromJson(String str) => TargetUser.fromJson(json.decode(str));

String targetUserToJson(TargetUser data) => json.encode(data.toJson());

class TargetUser {
  TargetUser({
    required this.id,
    required this.targets,
    required this.fromDate,
    required this.toDate,
    required this.actualQuantity,
    required this.createdOn,
    required this.fullname,
  });

  int id;
  int targets;
  DateTime fromDate;
  DateTime toDate;
  int actualQuantity;
  DateTime createdOn;
  String fullname;

  factory TargetUser.fromJson(Map<String, dynamic> json) => TargetUser(
    id: json["id"],
    targets: json["targets"],
    fromDate: DateTime.parse(json["fromDate"]),
    toDate: DateTime.parse(json["toDate"]),
    actualQuantity: json["actualQuantity"],
    createdOn: DateTime.parse(json["createdOn"]),
    fullname: json["fullname"],
  );

  Map<String, dynamic> toJson() => {
    "id": id,
    "targets": targets,
    "fromDate": fromDate.toIso8601String(),
    "toDate": toDate.toIso8601String(),
    "actualQuantity": actualQuantity,
    "createdOn": createdOn.toIso8601String(),
    "fullname": fullname,
  };
}
