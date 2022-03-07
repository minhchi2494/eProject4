// To parse this JSON data, do
//
//     final target = targetFromJson(jsonString);

import 'dart:convert';

Target targetFromJson(String str) => Target.fromJson(json.decode(str));

String targetToJson(Target data) => json.encode(data.toJson());

class Target {
  Target({
    required this.id,
    required this.targets,
    required this.fromDate,
    required this.toDate,
    required this.actualQuantity,
    required this.createdOn,
    required this.salesDetails,
    required this.users,
  });

  int id;
  int targets;
  DateTime fromDate;
  DateTime toDate;
  int actualQuantity;
  DateTime createdOn;
  List<dynamic> salesDetails;
  List<dynamic> users;

  factory Target.fromJson(Map<String, dynamic> json) => Target(
    id: json["id"],
    targets: json["targets"],
    fromDate: DateTime.parse(json["fromDate"]),
    toDate: DateTime.parse(json["toDate"]),
    actualQuantity: json["actualQuantity"],
    createdOn: DateTime.parse(json["createdOn"]),
    salesDetails: List<dynamic>.from(json["salesDetails"].map((x) => x)),
    users: List<dynamic>.from(json["users"].map((x) => x)),
  );

  Map<String, dynamic> toJson() => {
    "id": id,
    "targets": targets,
    "fromDate": fromDate.toIso8601String(),
    "toDate": toDate.toIso8601String(),
    "actualQuantity": actualQuantity,
    "createdOn": createdOn.toIso8601String(),
    "salesDetails": List<dynamic>.from(salesDetails.map((x) => x)),
    "users": List<dynamic>.from(users.map((x) => x)),
  };
}
