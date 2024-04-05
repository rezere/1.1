import 'dart:io';
import 'dart:math';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';
import 'package:image_picker/image_picker.dart';
import 'package:crypto/crypto.dart';
import 'main.dart';
import 'auth.dart';
import 'serverInfo.dart';

class RegistrationScreen extends StatefulWidget {
  @override
  _RegistrationScreenState createState() => _RegistrationScreenState();
}

class _RegistrationScreenState extends State<RegistrationScreen> {
  final _formKey = GlobalKey<FormState>();
  final surname = TextEditingController();
  final name = TextEditingController();
  final mail = TextEditingController();
  final bio = TextEditingController();
  final country = TextEditingController();
  final city = TextEditingController();
  final street = TextEditingController();
  final password = TextEditingController();
  final passwordCheck = TextEditingController();
  TextEditingController _controller = TextEditingController();

  ImagePicker _picker = ImagePicker();
  File? _image;
  String? urlImage;
  List<String> _searchResults = [];
  String _apiKey =
      'AijrCN7Z38en6zUT31gTgEFQUjsx_FbcgrEGSdEnFcK48Wq5yo03uVxbjkqva-W4';
  Future<void> _pickImage() async {
    final pickedFile = await _picker.getImage(source: ImageSource.gallery);
    if (pickedFile != null) {
      setState(() {
        _image = File(pickedFile.path);
      });
      urlImage = await uploadImage(_image!);
    }
  }

  bool _submitForm() {
    
    if (_formKey.currentState!.validate()) {
      return true;
    } else {
      return false;
    }
  }

  void _searchCountries(String query) async {
    final url = Uri.parse(
        'http://dev.virtualearth.net/REST/v1/Locations?q=$query&key=$_apiKey');
    final response = await http.get(url);

    if (response.statusCode == 200) {
      final data = json.decode(response.body);
      final List<dynamic> resources = data['resourceSets'][0]['resources'];

      setState(() {
        _searchResults = resources.map((r) => r['name'] as String).toList();
        print(_searchResults);
      });
    } else {
      // Обработка ошибок запроса
    }
  }

  Future<bool?> _showInputNumberDialog(BuildContext context, int code) async {
    final TextEditingController _controller = TextEditingController();
    return showDialog<bool>(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: const Text('Введите код с почты'),
          content: TextField(
            controller: _controller,
            keyboardType: TextInputType.number,
            decoration: InputDecoration(hintText: "Код"),
          ),
          actions: <Widget>[
            TextButton(
              child: const Text('Зарегистрироваться'),
              onPressed: () {
                final int? enteredNumber = int.tryParse(_controller.text);
                if (enteredNumber != null && enteredNumber == code) {
                  Navigator.of(context).pop(true);
                } else {
                  Navigator.of(context).pop(false);
                }
              },
            ),
          ],
        );
      },
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        leading: IconButton(
          icon: Icon(Icons.arrow_back_ios),
          onPressed: () => runApp(Auth()),
        ),
        title: Text('Регистрация'),
        backgroundColor: Color.fromARGB(255, 96, 150, 180),
        centerTitle: true,
      ),
      body: SingleChildScrollView(
        padding: EdgeInsets.all(20),
        child: Form(
          key: _formKey,
          child: Column(
            children: [
              GestureDetector(
                onTap: () {
                  _pickImage(); // Место для логики выбора изображения
                },
                child: CircleAvatar(
                  radius: 50,
                  backgroundColor:
                      Colors.grey[200], // Фоновый цвет для иконки камеры
                  backgroundImage: _image != null
                      ? FileImage(_image!)
                      : null, // Изображение если выбрано
                  child: _image ==
                          null // Если изображение не выбрано, показываем иконку камеры
                      ? Icon(Icons.camera_alt,
                          size: 50, color: Colors.grey[800])
                      : null, // Если изображение выбрано, иконку не показываем
                ),
              ),
              TextFormField(
                controller: surname,
                decoration: InputDecoration(labelText: 'Фамилия'),
                maxLength: 50,
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return 'Пожалуйста, заполните поле Фамилия';
                  }
                  return null;
                },
              ),
              TextFormField(
                controller: name,
                decoration: InputDecoration(labelText: 'Имя'),
                maxLength: 50,
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return 'Пожалуйста, заполните поле Имя';
                  }
                  return null; // Возвращаем null, если ошибок нет
                },
              ),
              TextFormField(
                controller: bio,
                decoration: InputDecoration(labelText: 'О себе'),
              ),
              TextFormField(
                controller: country,
                decoration: InputDecoration(labelText: 'Страна'),
                maxLength: 50,
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return 'Пожалуйста, заполните поле Страна';
                  }
                  return null; // Возвращаем null, если ошибок нет
                },
                onChanged: _searchCountries,
              ),
              TextFormField(
                controller: city,
                decoration: InputDecoration(labelText: 'Город'),
                maxLength: 50,
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return 'Пожалуйста, заполните поле Город';
                  }
                  return null; // Возвращаем null, если ошибок нет
                },
              ),
              TextFormField(
                controller: street,
                decoration: InputDecoration(labelText: 'Улица'),
                maxLength: 100,
              ),
              TextFormField(
                controller: mail,
                decoration: InputDecoration(labelText: 'Почта'),
                maxLength: 50,
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return 'Пожалуйста, заполните поле Почта';
                  }
                  return null; // Возвращаем null, если ошибок нет
                },
              ),
              TextFormField(
                controller: password,
                decoration: InputDecoration(labelText: 'Пароль'),
                obscureText: true,
                maxLength: 100,
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return 'Пожалуйста, заполните поле Пароль';
                  }
                  return null; // Возвращаем null, если ошибок нет
                },
              ),
              TextFormField(
                controller: passwordCheck,
                decoration: InputDecoration(labelText: 'Подтвердите пароль'),
                obscureText: true,
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return 'Пожалуйста, заполните поле Пароль';
                  } else if (value != password.text) {
                    return 'Пароли не совпадают';
                  }
                  return null; // Возвращаем null, если ошибок нет
                },
              ),
              SizedBox(height: 20),
              ElevatedButton(
                onPressed: () async {
                  if (_submitForm() == true) {
                    var rnd = Random();
                    int code = rnd.nextInt(9000) + 1000;
                    sendEmail(mail.text, code);
                    bool? isValidNumber =
                        await _showInputNumberDialog(context, code);
                    if (isValidNumber == true) {
                      AddProfile(
                          surname.text,
                          name.text,
                          bio.text,
                          country.text,
                          city.text,
                          street.text,
                          mail.text,
                          password.text,
                          urlImage);
                    } else {}
                  }
                },
                child: Text('Зарегистрироваться'),
              ),
            ],
          ),
        ),
      ),
    );
  }
}

Future<String?> uploadImage(File imageFile) async {
  var uri = Uri.parse(
      "${GetServer()}/uploadPhoto.php"); // Укажите URL вашего API для загрузки
  var request = http.MultipartRequest('POST', uri)
    ..files.add(await http.MultipartFile.fromPath(
      'file', // Ключ, по которому сервер ожидает файл
      imageFile.path,
    ));

  var streamedResponse = await request.send();

  if (streamedResponse.statusCode == 200) {
    var response = await http.Response.fromStream(streamedResponse);
    var responseData = json.decode(response.body);
    if (responseData['status'] == 'success') {
      print("Image uploaded");
      return responseData['url'];
    } else {
      print("Upload failed: ${responseData['message']}");
      return null;
    }
  } else {
    print("Upload failed with status code: ${streamedResponse.statusCode}");
    return null;
  }
}

void AddProfile(
    String surname,
    String name,
    String bio,
    String country,
    String city,
    String street,
    String mail,
    String password,
    String? urlImage) async {
  DateTime date = DateTime.now();
  bool emailResult = await sendAuth(mail);
  if (urlImage != null) {
    // Разбиваем URL по частям и вставляем 'couchsurfing'
    List<String> parts = urlImage.split('/');
    int indexToInsert = parts.indexOf('uploads');
    parts.insert(indexToInsert, 'couchsurfing');
    urlImage = parts.join('/');
  }
  if (emailResult == true) {
    String passwordHash = generatePasswordHash(password);
    String request =
        "INSERT INTO `users` (`Surname`, `Name`, `Email`, `Bio`, `ProfilePicture`, `Password`, `CreateAt`, `Country`, `City`, `Street`) VALUES ('$surname', '$name', '$mail', '$bio', '$urlImage', '$passwordHash', '$date', '$country', '$city', '$street');";
    final response = await http.post(
      Uri.parse('${GetServer()}/addTable.php'),
      body: {'request': request},
    );
    if (response.statusCode == 200) {
      saveEmail(mail);
      runApp(Profile(
        userEmail: mail,
      ));
    } else {}
  } else {}
}

Future<bool> sendAuth(String email) async {
  final response = await http.post(
    Uri.parse('${GetServer()}/auth.php'),
    body: {'email': email},
  );
  if (response.statusCode == 200) {
    var jsonResponse = json.decode(response.body);
    String storedPassword = jsonResponse['password'] ?? '';
    return storedPassword == '';
  } else {
    // Ошибка
    return false;
  }
}

String generatePasswordHash(String password) {
  final bytes = utf8.encode(password);
  final digest = sha256.convert(bytes);
  return digest.toString();
}

Future<void> sendEmail(String email, int code) async {
  final uri = Uri.parse('${GetServer()}/sendmail.php');
  final response = await http.post(
    uri,
    body: {
      'email': email,
      'body': "Добрый день, для подтверждения почты введите данный код",
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
