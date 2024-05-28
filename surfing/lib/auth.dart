import 'dart:math';

import 'package:crypto/crypto.dart';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';
import 'package:shared_preferences/shared_preferences.dart';
import 'package:surfing/home.dart';
import 'reg.dart';
import 'main.dart';
import 'serverInfo.dart';

int codeEmail = -1;
String emailUpdate = '';

class Auth extends StatelessWidget {
  const Auth({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: Scaffold(
        appBar: AppBar(
          title: const Text('Авторизація'),
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
  final myController1 = TextEditingController();
  final myController2 = TextEditingController();
  String text = "Не валідно";
  @override
  void dispose() {
    
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
              hintText: 'Введіть пошту',
            ),
          ),
          const SizedBox(height: 8),
          TextField(
            controller: myController2,
            decoration: const InputDecoration(
              hintText: 'Введіть пароль',
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
                child: const Text("Реєстрація"),
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
                    showCustomDialog(context, "Заповніть всі поля");
                  }
                },
                child: const Text('Авторизація'),
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
              "Забули пароль?",
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
          title: const Text('Відновлення пароля'),
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
                  hintText: 'Введіть пошту',
                ),
              ),
              const SizedBox(height: 8),
              ElevatedButton(
                onPressed: () {
                  if (mailController.text.isNotEmpty) {
                    if (isValidEmail(mailController.text)) {
                      checkEmail(mailController, context);
                    } else {
                      showCustomDialog(context, "Некоректний формат пошти");
                    }
                  } else {
                    showCustomDialog(context, "Заповніть всі поля");
                  }
                },
                child: const Text('Відновити'),
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
          title: const Text('Відновлення пароля'),
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
                  hintText: 'Введіть код із пошти',
                ),
              ),
              const SizedBox(height: 8),
              TextField(
                controller: passwordController,
                decoration: const InputDecoration(
                  hintText: 'Введіть новий пароль',
                ),
                obscureText: true,
              ),
              const SizedBox(height: 8),
              TextField(
                controller: password2Controller,
                decoration: const InputDecoration(
                  hintText: 'Підтвердіть пароль',
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
                        showCustomDialog(context, "Не збігаються паролі");
                      }
                    } else {
                      showCustomDialog(context, "Невірний код");
                    }
                  } else {
                    showCustomDialog(context, "Заповніть всі поля");
                  }
                },
                child: const Text('Змінити'),
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
        title: Text('Увага'),
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
  int reportCount = await getReport(myController1.text);
  if(reportCount<5)
  {
  if (authResult == true) {
    await saveEmail(myController1.text);
    showCustomDialog(context, "Все добре");

    runApp(Home());
  } else {
    showCustomDialog(context, "Не коректна пошта або пароль");
  }
  }
  else
  {
    showCustomDialog(context, "Вы отримали дуже багато скарг, для розблокування зв'яжіться з адміністратором: froust87@gmail.com");
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
    showCustomDialog(context, "Неіснує такої пошти");
  }
}

Future<bool> mailFind(String email) async {
  final response = await http.post(
    Uri.parse('${GetServer()}/auth.php'),
    body: {'email': email},
  );

  if (response.statusCode == 200) {
    var jsonResponse = json.decode(response.body);
    String storedPassword = jsonResponse['password'] ?? '';
    String admin = jsonResponse['admin'] ??'';
    print('TEST!!' + admin);
    return storedPassword != '';
  } else {
    return false;
  }
}

Future<int> getReport(String email) async {
  final response = await http.post(
    Uri.parse('${GetServer()}/getReport.php'),
    body: {'email': email},
  );

  if (response.statusCode == 200) {
    var jsonResponse = json.decode(response.body);
    int countReport = jsonResponse['COUNT(*)'];
    return countReport;
  } else {
    return 0;
  }
}

Future<bool> sendAuth(String email, String password) async {
  final response = await http.post(
    Uri.parse('${GetServer()}/auth.php'),
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
  final uri = Uri.parse('${GetServer()}/sendmail.php');
  final response = await http.post(
    uri,
    body: {
      'email': email,
      'body': "Доброго дня, ви хочете змінити пароль. Введіть цей код",
      'code': code.toString(),
    },
  );
  if (response.statusCode == 200) {
    print('Лист успішно надіслано');
    print(response.body);
  } else {
    print('Помилка при надсиланні листа: ${response.body}');
  }
}

void UpdatePassword(String mail, String password) async {
  String passwordHash = generatePasswordHash(password);
  final response = await http.post(
    Uri.parse('${GetServer()}/updateInfo.php'),
    body: {
      'email': mail,
      'passwordHash': passwordHash,
    },
  );
  if (response.statusCode == 200) {
    saveEmail(mail);
    runApp(Home());
  } else {}
}

Future<void> saveEmail(String email) async {
  final SharedPreferences prefs = await SharedPreferences.getInstance();
  await prefs.setString('userEmail', email);
  saveAdmin(email);
}

Future<void> saveAdmin(String email) async {
  final results;
  final response = await http.post(
    Uri.parse('${GetServer()}/getTable.php'),
    body: {'email': email},
  );

  if (response.statusCode == 200) {
    results = json.decode(response.body);
  } else {
    return;
  }
  final SharedPreferences prefs = await SharedPreferences.getInstance();
  if(results['isAdmin'] == "0")
  await prefs.setString('admin', false.toString());
  else await prefs.setString('admin', true.toString());

}
Future<String?> loadEmail() async {
  final SharedPreferences prefs = await SharedPreferences.getInstance();
  return prefs.getString('userEmail');
}
Future<String?> loadAdmin() async {
  final SharedPreferences prefs = await SharedPreferences.getInstance();
  return prefs.getString('admin');
}
String generatePasswordHash(String password) {
  final bytes = utf8.encode(password);
  final digest = sha256.convert(bytes);
  return digest.toString();
}
