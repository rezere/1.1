import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';
import 'package:shared_preferences/shared_preferences.dart';
import 'reg.dart';
import 'main.dart';

class Auth extends StatelessWidget {
  const Auth({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: Scaffold(
        appBar: AppBar(
          title: const Text('Авторизация'),
          backgroundColor: Color.fromARGB(255, 96, 150, 180),
          centerTitle: true,
        ),
        body: const MyForm(),
      ),
    );
  }
}

class MyForm extends StatefulWidget {
  const MyForm({super.key});

  @override
  MyFormState createState() {
    return MyFormState();
  }
}

class MyFormState extends State<MyForm> {
  // Контроллеры для текстовых полей
  final myController1 = TextEditingController();
  final myController2 = TextEditingController();
  String text = "Не валидно";
  @override
  void dispose() {
    // Очистка контроллеров при уничтожении виджета
    myController1.dispose();
    myController2.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.all(16.0),
      child: Column(
        mainAxisSize: MainAxisSize
            .min, // Используется для занимания минимального пространства по вертикали
        children: <Widget>[
          TextField(
            controller: myController1,
            decoration: const InputDecoration(
              hintText: 'Введите почту',
            ),
          ),
          const SizedBox(height: 8), // Отступ между полями
          TextField(
            controller: myController2,
            decoration: const InputDecoration(
              hintText: 'Введите пароль',
            ),
            obscureText: true,
          ),
          const SizedBox(height: 16), // Отступ между полями ввода и кнопками
          Row(
            mainAxisAlignment: MainAxisAlignment
                .spaceEvenly, // Равномерное распределение по горизонтали
            children: [
              ElevatedButton(
                onPressed: () {
                   runApp(MaterialApp(
    home: RegistrationScreen()));
                },
                child: Text("Регистрация"),
              ),
              ElevatedButton(
                onPressed: () {
                  if (myController1.text.isNotEmpty &&
                      myController2.text.isNotEmpty) {
                    if (isValidEmail(myController1.text) == true) {
                      
                      checkPassword(myController1, myController2, context);
                    } else {
                      showCustomDialog(context, "Не коректный формат почты");
                    }
                  } else {
                    showCustomDialog(context, "Заполните все поля");
                  }
                },
                child: const Text('Авторизация'),
              ),
            ],
          ),
        ],
      ),
    );
  }
}

bool isValidEmail(String email) {
  // Регулярное выражение для проверки электронной почты
  final RegExp emailRegex = RegExp(
    r'^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$',
  );

  return emailRegex.hasMatch(email);
}

void showCustomDialog(BuildContext context, String text) {
  showDialog(
    context: context,
    builder: (BuildContext context) {
      return AlertDialog(
        title: Text('Внимание'),
        content: Text(text),
        actions: <Widget>[
          TextButton(
            onPressed: () {
              Navigator.of(context).pop();
            },
            child: Text('ОК'),
          ),
        ],
      );
    },
  );
}

void checkPassword(final myController1, final myController2, BuildContext context) async {
  bool authResult = await sendAuth(myController1.text, myController2.text);
  if (authResult == true) {
    await saveEmail(myController1.text);
    showCustomDialog(context, "Всё хорошо");
    runApp(Profile(userEmail: myController1.text,));
    // Успешно
  } else {
    showCustomDialog(context, "Не корректная почта или пароль");
    // Не успешно
  }
}

Future<bool> sendAuth(String email, String password) async {
  final response = await http.post(
    Uri.parse('http://10.0.2.2/couchsurfing/auth.php'),
    body: {'email': email},
  );

  if (response.statusCode == 200) {
   
    var jsonResponse = json.decode(response.body);
    String storedPassword = jsonResponse['password'] ?? '';
    return password ==
        storedPassword;
  } else {
    // Ошибка
    return false;
  }
}
Future<void> saveEmail(String email) async {
  final SharedPreferences prefs = await SharedPreferences.getInstance();
  await prefs.setString('userEmail', email);
}

Future<String?> loadEmail() async {
  final SharedPreferences prefs = await SharedPreferences.getInstance();
  return prefs.getString('userEmail');
}
