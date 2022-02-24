import 'package:flutter/material.dart';

GetAppBar(){
  return AppBar(
    elevation: 0.8,
    backgroundColor: Colors.white,
    title: Container(
      child: Row(
        // mainAxisAlignment: MainAxisAlignment.spaceBetween,
        children: const [
          Text(
            "Sale Management",
            style: TextStyle(color: Colors.black),
          ),
        ],
      ),
    ),
  );
}