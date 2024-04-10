import 'package:flutter/material.dart';
import 'package:surfing/home.dart';
import 'auth.dart';
import 'account.dart';
import 'find.dart';
import 'map.dart';
import 'package:flutter_map/flutter_map.dart';
import 'package:latlong2/latlong.dart';

import 'rental.dart';

void main() {
  WidgetsFlutterBinding.ensureInitialized();
  //runApp(Rental());
  initializeApp();
}



Future<void> initializeApp() async {
  String? userEmail = await loadEmail();
  if (userEmail != null) {
    runApp(Home());
  } else {
    runApp(Auth());
  }
}

class Profile extends StatelessWidget {
  final String userEmail;

  const Profile({Key? key, required this.userEmail}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    // Теперь вы можете использовать userEmail внутри MyApp для дальнейшей логики
    return MaterialApp(
      home: UserProfilePage(email: userEmail), // Пример использования
    );
  }
}
