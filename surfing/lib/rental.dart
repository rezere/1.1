import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';
import 'auth.dart';

class Rental extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: InputPage(),
    );
  }
}

class InputPage extends StatefulWidget {
  @override
  _InputPageState createState() => _InputPageState();
}

class _InputPageState extends State<InputPage> {
  final _formKey = GlobalKey<FormState>();
  final TextEditingController _titleController = TextEditingController();
  final TextEditingController _infoController = TextEditingController();
  final TextEditingController _countryController = TextEditingController();
  final TextEditingController _cityController = TextEditingController();
  final TextEditingController _streetController = TextEditingController();
  int _peopleCount = 1;
  DateTime? _startDate;
  DateTime? _endDate;

  Future<void> _selectDate(BuildContext context, bool isStart) async {
    final DateTime? picked = await showDatePicker(
      context: context,
      initialDate:
          isStart ? _startDate ?? DateTime.now() : _endDate ?? DateTime.now(),
      firstDate: DateTime(2000),
      lastDate: DateTime(2025),
    );
    if (picked != null) {
      setState(() {
        if (isStart) {
          _startDate = picked;
        } else {
          _endDate = picked;
        }
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Новое объявление'),
        backgroundColor: Color.fromARGB(255, 96, 150, 180),
        centerTitle: true,
      ),
      body: SingleChildScrollView(
        padding: EdgeInsets.all(16.0),
        child: Form(
          key: _formKey,
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.stretch,
            children: <Widget>[
              TextFormField(
                controller: _titleController,
                decoration: InputDecoration(labelText: 'Заголовок'),
                maxLength: 50,
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return 'Введите заголовок';
                  }
                  return null;
                },
              ),
              TextFormField(
                controller: _infoController,
                decoration: InputDecoration(labelText: 'Информация'),
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return 'Введите информацию';
                  }
                  return null;
                },
              ),
              TextFormField(
                controller: _countryController,
                maxLength: 50,
                decoration: InputDecoration(labelText: 'Страна'),
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return 'Введите страну';
                  }
                  return null;
                },
              ),
              TextFormField(
                controller: _cityController,
                maxLength: 50,
                decoration: InputDecoration(labelText: 'Город'),
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return 'Введите город';
                  }
                  return null;
                },
              ),
              TextFormField(
                controller: _streetController,
                maxLength: 100,
                decoration: InputDecoration(labelText: 'Адрес'),
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return 'Введите адрес';
                  }
                  return null;
                },
              ),
              DropdownButtonFormField<int>(
                value: _peopleCount,
                decoration: InputDecoration(labelText: 'Количество людей'),
                items: List.generate(
                  5,
                  (index) => DropdownMenuItem(
                    value: index + 1,
                    child: Text('${index + 1}'),
                  ),
                ),
                onChanged: (value) {
                  setState(() {
                    _peopleCount = value!;
                  });
                },
              ),
              ListTile(
                title: Text(
                    'Дата заселения: ${_startDate?.toIso8601String().split('T').first ?? "Не выбрано"}'),
                trailing: Icon(Icons.calendar_today),
                onTap: () => _selectDate(context, true),
              ),
              ListTile(
                title: Text(
                    'Дата выселения: ${_endDate?.toIso8601String().split('T').first ?? "Не выбрано"}'),
                trailing: Icon(Icons.calendar_today),
                onTap: () => _selectDate(context, false),
              ),
              ElevatedButton(
                onPressed: () {
                  if (_formKey.currentState!.validate()) {
                    AddRental(_titleController.text, _infoController.text, _countryController.text, _cityController.text, _streetController.text, _peopleCount, _startDate, _endDate);
                  }
                },
                child: Text('Добавить'),
              ),
            ],
          ),
        ),
      ),
    );
  }
}

void AddRental(
    String title,
    String info,
    String country,
    String city,
    String adress,
    int count,
    DateTime? dateRental,
    DateTime? dateEviction) async {
  DateTime date = DateTime.now();
  String? userID = await GetID();
  String request =
      "INSERT INTO `rental` (`Title`, `Description`, `MaxPeople`, `Country`, `City`, `Street`, `DateRental`, `DateEviction`, `LessorID`, `DateCreate`) VALUES ('$title', '$info', '$count', '$country', '$city', '$adress', '$dateRental', '$dateEviction', '$userID', '$date');";
  final response = await http.post(
    Uri.parse('http://10.0.2.2/couchsurfing/addTable.php'),
    body: {'request': request},
  );
  if (response.statusCode == 200) {
  } else {}
}

Future<String> GetID() async {
  DateTime date = DateTime.now();
  String ID = '-1';
  String? email = await loadEmail();
  final response = await http.post(
    Uri.parse('http://10.0.2.2/couchsurfing/getID.php'),
    body: {'email': email},
  );
  if (response.statusCode == 200) {
    var jsonResponse = json.decode(response.body);
    ID = jsonResponse['UserID'].toString() ?? '';
  }
  return ID;
}
