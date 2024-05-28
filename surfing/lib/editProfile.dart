import 'package:flutter/material.dart';
import 'account.dart';
import 'package:http/http.dart' as http;

import 'main.dart';
import 'serverInfo.dart';

class FormPage extends StatefulWidget {
  final String surname;
  final String name;
  final String email;
  final String bio;
  final String country;
  final String city;
  final String street;

  FormPage({
    required this.surname,
    required this.name,
    required this.email,
    required this.bio,
    required this.country,
    required this.city,
    required this.street,
  });

  @override
  _FormPageState createState() => _FormPageState();
}

class _FormPageState extends State<FormPage> {
  late TextEditingController _surnameController;
  late TextEditingController _nameController;
  late TextEditingController _emailController;
  late TextEditingController _bioController;
  late TextEditingController _countryController;
  late TextEditingController _cityController;
  late TextEditingController _streetController;

  @override
  void initState() {
    super.initState();
    _surnameController = TextEditingController(text: widget.surname);
    _nameController = TextEditingController(text: widget.name);
    _emailController = TextEditingController(text: widget.email);
    _bioController = TextEditingController(text: widget.bio);
    _countryController = TextEditingController(text: widget.country);
    _cityController = TextEditingController(text: widget.city);
    _streetController = TextEditingController(text: widget.street);
  }

  @override
  void dispose() {
    _surnameController.dispose();
    _nameController.dispose();
    _bioController.dispose();
    _countryController.dispose();
    _cityController.dispose();
    _streetController.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        leading: IconButton(
          icon: const Icon(Icons.arrow_back_ios),
          onPressed: () => runApp(Profile(userEmail: _emailController.text!)),
        ),
        title: const Text('Редагування профілю'),
        backgroundColor: const Color.fromARGB(255, 96, 150, 180),
        centerTitle: true,
      ),
      body: Padding(
        padding: const EdgeInsets.all(16.0),
        child: ListView(
          children: [
            TextField(
              controller: _surnameController,
              decoration: const InputDecoration(labelText: 'Прізвище'),
            ),
            TextField(
              controller: _nameController,
              decoration: const InputDecoration(labelText: 'Ім`я'),
            ),
            TextField(
              controller: _bioController,
              decoration: const InputDecoration(labelText: 'О собі'),
            ),
            TextField(
              controller: _countryController,
              decoration: const InputDecoration(labelText: 'Країна'),
            ),
            TextField(
              controller: _cityController,
              decoration: const InputDecoration(labelText: 'Місто'),
            ),
            TextField(
              controller: _streetController,
              decoration: const InputDecoration(labelText: 'Адреса'),
            ),
            ElevatedButton(
              onPressed: () {
                if (_surnameController.text.isNotEmpty &&
                    _nameController.text.isNotEmpty &&
                    _countryController.text.isNotEmpty &&
                    _cityController.text.isNotEmpty) {
                  updateUser(
                      _emailController.text,
                      _surnameController.text,
                      _nameController.text,
                      _bioController.text,
                      _countryController.text,
                      _cityController.text,
                      _streetController.text);
                  runApp(Profile(userEmail: _emailController.text!));
                }
              },
              child: const Text('Зберегти'),
            ),
          ],
        ),
      ),
    );
  }
}

Future<void> updateUser(String userID, String surname, String name, String bio,
    String country, String city, String street) async {
  final response = await http.post(
    Uri.parse('${GetServer()}/editProfile.php'),
    body: {
      'Email': userID,
      'Surname': surname,
      'Name': name,
      'Bio': bio,
      'Country': country,
      'City': city,
      'Street': street,
    },
  );

  if (response.statusCode == 200) {
  } else {}
}
