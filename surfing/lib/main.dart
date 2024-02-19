import 'package:flutter/material.dart';
import 'auth.dart';
import 'account.dart';
import 'find.dart';

void main() {
  WidgetsFlutterBinding.ensureInitialized();
  initializeApp();
}

Future<void> initializeApp() async {
  String? userEmail =
      await loadEmail();
  if (userEmail != null) {
    runApp(Profile(userEmail: userEmail)); // Передаем userEmail в MyApp
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
