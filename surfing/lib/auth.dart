import 'dart:math';

import 'package:crypto/crypto.dart';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';
import 'package:shared_preferences/shared_preferences.dart';
import 'reg.dart';
import 'main.dart';

int codeEmail = -1;
String emailUpdate = '';

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
        mainAxisSize: MainAxisSize.min,
        children: <Widget>[
          TextField(
            controller: myController1,
            decoration: const InputDecoration(
              hintText: 'Введите почту',
            ),
          ),
          const SizedBox(height: 8),
          TextField(
            controller: myController2,
            decoration: const InputDecoration(
              hintText: 'Введите пароль',
            ),
            obscureText: true,
          ),
          const SizedBox(height: 16),
          Row(
            mainAxisAlignment: MainAxisAlignment.spaceEvenly,
            children: [
              ElevatedButton(
                onPressed: () {
                  runApp(MaterialApp(home: RegistrationScreen()));
                },
                child: const Text("Регистрация"),
              ),
              ElevatedButton(
                onPressed: () {
                  if (myController1.text.isNotEmpty &&
                      myController2.text.isNotEmpty) {
                    if (isValidEmail(myController1.text)) {
                      checkPassword(myController1, myController2, context);
                    } else {
                      showCustomDialog(context, "Некорректный формат почты");
                    }
                  } else {
                    showCustomDialog(context, "Заполните все поля");
                  }
                },
                child: const Text('Авторизация'),
              ),
            ],
          ),
          const SizedBox(height: 20),
          TextButton(
            onPressed: () {
              Navigator.push(
                  context, MaterialPageRoute(builder: (context) => Recovery()));
            },
            child: const Text(
              "Забыл пароль?",
              style: TextStyle(
                color: Colors.blue,
              ),
            ),
          ),
        ],
      ),
    );
  }
}

class Recovery extends StatelessWidget {
  final mailController = TextEditingController();
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: Scaffold(
        appBar: AppBar(
          title: const Text('Востановление пароля'),
          backgroundColor: Color.fromARGB(255, 96, 150, 180),
          centerTitle: true,
          leading: IconButton(
            icon: Icon(Icons.arrow_back_ios),
            onPressed: () => Navigator.push(
                  context, MaterialPageRoute(builder: (context) => Auth())),
          ),
        ),
        body: Padding(
          padding: const EdgeInsets.all(16.0),
          child: Column(
            mainAxisSize: MainAxisSize.min,
            children: <Widget>[
              TextField(
                controller: mailController,
                decoration: const InputDecoration(
                  hintText: 'Введите почту',
                ),
              ),
              const SizedBox(height: 8),
              ElevatedButton(
                onPressed: () {
                  if (mailController.text.isNotEmpty) {
                    if (isValidEmail(mailController.text)) {
                      checkEmail(mailController, context);
                    } else {
                      showCustomDialog(context, "Некорректный формат почты");
                    }
                  } else {
                    showCustomDialog(context, "Заполните все поля");
                  }
                },
                child: const Text('Востановить'),
              ),
            ],
          ),
        ),
      ),
    );
  }
}

class ChangePassword extends StatelessWidget {
  final codeController = TextEditingController();
  final passwordController = TextEditingController();
  final password2Controller = TextEditingController();
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: Scaffold(
        appBar: AppBar(
          title: const Text('Востановление пароля'),
          backgroundColor: Color.fromARGB(255, 96, 150, 180),
          centerTitle: true,
          leading: IconButton(
            icon: Icon(Icons.arrow_back_ios),
            onPressed: () => runApp(Auth()),
          ),
        ),
        body: Padding(
          padding: const EdgeInsets.all(16.0),
          child: Column(
            mainAxisSize: MainAxisSize.min,
            children: <Widget>[
              TextField(
                controller: codeController,
                decoration: const InputDecoration(
                  hintText: 'Введите код с почты',
                ),
              ),
              const SizedBox(height: 8),
              TextField(
                controller: passwordController,
                decoration: const InputDecoration(
                  hintText: 'Введите новый пароль',
                ),
                obscureText: true,
              ),
              const SizedBox(height: 8),
              TextField(
                controller: password2Controller,
                decoration: const InputDecoration(
                  hintText: 'Подтвердите пароль',
                ),
                obscureText: true,
              ),
              const SizedBox(height: 8),
              ElevatedButton(
                onPressed: () {
                  if (codeController.text.isNotEmpty &&
                      passwordController.text.isNotEmpty &&
                      password2Controller.text.isNotEmpty) {
                    if (codeController.text == codeEmail.toString()) {
                      if (passwordController.text == password2Controller.text) {
                        UpdatePassword(emailUpdate, passwordController.text);
                      } else {
                        showCustomDialog(context, "Не совпадают пароли");
                      }
                    } else {
                      showCustomDialog(context, "Не верный код");
                    }
                  } else {
                    showCustomDialog(context, "Заполните все поля");
                  }
                },
                child: const Text('Изменить'),
              ),
            ],
          ),
        ),
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

void checkPassword(
    final myController1, final myController2, BuildContext context) async {
  bool authResult = await sendAuth(myController1.text, myController2.text);
  if (authResult == true) {
    await saveEmail(myController1.text);
    showCustomDialog(context, "Всё хорошо");
    runApp(Profile(
      userEmail: myController1.text,
    ));
  } else {
    showCustomDialog(context, "Не корректная почта или пароль");
  }
}

void checkEmail(final myController1, BuildContext context) async {
  bool authResult = await mailFind(myController1.text);
  if (authResult == true) {
    sendEmail(myController1.text);
    emailUpdate = myController1.text;
    Navigator.push(
        context, MaterialPageRoute(builder: (context) => ChangePassword()));
  } else {
    showCustomDialog(context, "Не существует почты");
    // Не успешно
  }
}

Future<bool> mailFind(String email) async {
  final response = await http.post(
    Uri.parse('http://10.0.2.2/couchsurfing/auth.php'),
    body: {'email': email},
  );

  if (response.statusCode == 200) {
    var jsonResponse = json.decode(response.body);
    String storedPassword = jsonResponse['password'] ?? '';
    return storedPassword != '';
  } else {
    return false;
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
    return generatePasswordHash(password) == storedPassword;
  } else {
    // Ошибка
    return false;
  }
}

Future<void> sendEmail(String email) async {
  var rnd = Random();
  int code = rnd.nextInt(9000) + 1000;
  codeEmail = code;
  final uri = Uri.parse('http://10.0.2.2/couchsurfing/sendmail.php');
  final response = await http.post(
    uri,
    body: {
      'email': email,
      'body': "Добрый день, вы хотите изменить пароль. Введите данный код",
      'code': code.toString(),
    },
  );
  if (response.statusCode == 200) {
    print('Письмо успешно отправлено');
    print(response.body);
  } else {
    print('Ошибка при отправке письма: ${response.body}');
  }
}

void UpdatePassword(String mail, String password) async {
  String passwordHash = generatePasswordHash(password);
  final response = await http.post(
    Uri.parse('http://10.0.2.2/couchsurfing/updateInfo.php'),
    body: {
      'email': mail,
      'passwordHash': passwordHash,
    },
  );
  if (response.statusCode == 200) {
    saveEmail(mail);
    runApp(Profile(
      userEmail: mail,
    ));
  } else {}
}

Future<void> saveEmail(String email) async {
  final SharedPreferences prefs = await SharedPreferences.getInstance();
  await prefs.setString('userEmail', email);
}

Future<String?> loadEmail() async {
  final SharedPreferences prefs = await SharedPreferences.getInstance();
  return prefs.getString('userEmail');
}

String generatePasswordHash(String password) {
  final bytes = utf8.encode(password);
  final digest = sha256.convert(bytes);
  return digest.toString();
}
