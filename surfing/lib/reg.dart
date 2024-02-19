import 'dart:io';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:image_picker/image_picker.dart';
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

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
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
              ),
              TextFormField(
                controller: name,
                decoration: InputDecoration(labelText: 'Имя'),
                maxLength: 50,
              ),
              TextFormField(
                  controller: bio,
                  decoration: InputDecoration(labelText: 'BIO')),
              TextFormField(
                controller: country,
                decoration: InputDecoration(labelText: 'Страна'),
                maxLength: 50,
              ),
              TextFormField(
                controller: city,
                decoration: InputDecoration(labelText: 'Город'),
                maxLength: 50,
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
              ),
              TextFormField(
                controller: password,
                decoration: InputDecoration(labelText: 'Пароль'),
                obscureText: true,
                maxLength: 100,
              ),
              TextFormField(
                controller: passwordCheck,
                decoration: InputDecoration(labelText: 'Подтвердите пароль'),
                obscureText: true,
              ),
              SizedBox(height: 20),
              ElevatedButton(
                onPressed: () {
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
  if (urlImage != null) {
    // Разбиваем URL по частям и вставляем 'couchsurfing'
    List<String> parts = urlImage.split('/');
    int indexToInsert = parts.indexOf('uploads');
    parts.insert(indexToInsert, 'couchsurfing');
    urlImage = parts.join('/');
  }

  String request =
      "INSERT INTO `users` (`Surname`, `Name`, `Email`, `Bio`, `ProfilePicture`, `Password`, `CreateAt`, `Country`, `City`, `Street`) VALUES ('$surname', '$name', '$mail', '$bio', '$urlImage', '$password', '$date', '$country', '$city', '$street');";
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
}
