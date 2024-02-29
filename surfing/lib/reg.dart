import 'dart:io';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:image_picker/image_picker.dart';
import 'package:crypto/crypto.dart';
import 'main.dart';
import 'auth.dart';

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

  ImagePicker _picker = ImagePicker();
  File? _image;
  String? urlImage;

  Future<void> _pickImage() async {
    final pickedFile = await _picker.getImage(source: ImageSource.gallery);
    if (pickedFile != null) {
      setState(() {
        _image = File(pickedFile.path);
      });
      urlImage = await uploadImage(_image!);
    }
  }

  void _submitForm() {
    if (_formKey.currentState!.validate()) {
      AddProfile(surname.text, name.text, bio.text, country.text, city.text,
          street.text, mail.text, password.text, urlImage);
    } else {
      // Если какие-либо поля не прошли валидацию, действия не требуются,
      // так как сообщения об ошибках будут автоматически показаны пользователю.
    }
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
                decoration: InputDecoration(labelText: 'BIO'),
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
                    return 'Пожалуйста, заполните поле BIO';
                  } else if (value != password.text) {
                    return 'Пароли не совпадают';
                  }
                  return null; // Возвращаем null, если ошибок нет
                },
              ),
              SizedBox(height: 20),
              ElevatedButton(
                onPressed: _submitForm,
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
      "http://10.0.2.2/couchsurfing/upload.php"); // Укажите URL вашего API для загрузки
  var request = http.MultipartRequest('POST', uri)
    ..files.add(await http.MultipartFile.fromPath(
      'file', // Ключ, по которому сервер ожидает файл
      imageFile.path,
    ));

  var streamedResponse = await request.send();

  if (streamedResponse.statusCode == 200) {
    // Если файл успешно загружен, получаем ответ от сервера
    var response = await http.Response.fromStream(streamedResponse);
    var responseData = json.decode(response.body);

    if (responseData['status'] == 'success') {
      print("Image uploaded");
      return responseData['url']; // Возвращаем URL файла
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
      Uri.parse('http://10.0.2.2/couchsurfing/addTable.php'),
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
    Uri.parse('http://10.0.2.2/couchsurfing/auth.php'),
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
