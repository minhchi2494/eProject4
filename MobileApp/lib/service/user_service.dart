import 'dart:convert';

import 'package:sale_man_app/network/network_api.dart';

import '../models/User.dart';
import 'package:http/http.dart' as http;

class UserService {
  static Uri url = Network.url_user;

  static List<User> parseUser(String responeBody){
    final list = json.decode(responeBody) as List<dynamic>;
    List<User> user = list.map((e) => User.fromJson(e)).toList();
    return user;
  }

  static Future<List<User>> getUsers({int page = 1}) async{
    final response = await http.get(url);
    if (response.statusCode == 200) {
      return parseUser(response.body);
    }else if (response.statusCode == 404) {
      throw Exception('Not Found!');
    } else{
      throw Exception('Cant get users');
    }
  }

  static Future<http.Response> updateStore(User data) async {
    final response = await http.put(Uri.parse("$url?Id=${data.id}&TargetId=${data.targetId}&Username=${data.username}&Password=${data.password}&Fullname=${data.fullname}&Email=${data.email}&Phone=${data.phone}&Address=${data.address}&StoreId=${data.storeId}&LocationId=${data.locationId}&RoleId=${data.roleId}&ManagerId=${data.managerId}&IsActive=${data.isActive}"),
      headers: {"content-type": "application/json"},
      body: userToJson(data),
    );
    return response;
  }

  // static Future<http.Response> getUserDetails(int id) async{
  //   var response =  await http.get(Uri.parse('${url}/${id}'));
  //   return response;
  // }

}