import 'package:ea_frontend/website.dart';
import 'package:flutter/material.dart';
import 'package:hooks_riverpod/hooks_riverpod.dart';

void main() {
  runApp(
    const ProviderScope(
      child: MaterialApp(
        debugShowCheckedModeBanner: false,
        title: "EETAC Go",
        home: MyWebPage(),
      ),
    ),
  );
}
