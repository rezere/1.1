import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:image_picker/image_picker.dart';
import 'package:http/http.dart' as http;
import 'package:surfing/serverInfo.dart';
import 'dart:convert';
import 'auth.dart';
import 'home.dart';

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';
import 'package:image_picker/image_picker.dart';
import 'dart:io';

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
  final ImagePicker _picker = ImagePicker();
  List<XFile>? _images = [];
  List<String> _countryOptions = [
    'Україна',
    'Канада',
    'США',
    'Німеччина',
    'Франція',
    'Велика Британія',
    'Італія',
    'Іспанія',
    'Австралія',
    'Бразилія',
    'Аргентина',
    'Мексика',
    'Японія',
    'Китай',
    'Індія',
    'Росія',
    'Швеція',
    'Норвегія',
    'Фінляндія',
    'Данія',
  ];

  Future<void> _pickImages() async {
    final List<XFile>? selectedImages = await _picker.pickMultiImage();
    if (selectedImages != null && selectedImages.isNotEmpty) {
      setState(() {
        _images = selectedImages;
      });
    }
  }

  Future<void> _selectDate(BuildContext context, bool isStartDate) async {
    final DateTime? picked = await showDatePicker(
      context: context,
      initialDate: isStartDate
          ? _startDate ?? DateTime.now()
          : _endDate ?? DateTime.now(),
      firstDate: DateTime(2000),
      lastDate: DateTime(2025),
    );
    if (picked != null) {
      if (isStartDate) {
        if (_endDate != null && picked.isAfter(_endDate!)) {
          // Показываем сообщение об ошибке
          ScaffoldMessenger.of(context).showSnackBar(
            SnackBar(
              content:
                  Text('Дата заселення може бути пізніше дати виселення.'),
            ),
          );
        } else {
          setState(() {
            _startDate = picked;
          });
        }
      } else {
        if (_startDate != null && picked.isBefore(_startDate!)) {
          // Показываем сообщение об ошибке
          ScaffoldMessenger.of(context).showSnackBar(
            SnackBar(
              content:
                  Text('Дата виселення не може бути раніше дати заселення.'),
            ),
          );
        } else {
          setState(() {
            _endDate = picked;
          });
        }
      }
    }
  }

  Future<List<String>> _fetchCityOptions(String query, String country) async {
    final apiKey = 'AijrCN7Z38en6zUT31gTgEFQUjsx_FbcgrEGSdEnFcK48Wq5yo03uVxbjkqva-W4';
    final url = 'http://dev.virtualearth.net/REST/v1/Locations?query=$query&key=$apiKey&culture=uk-UA';

  final response = await http.get(Uri.parse(url));

  if (response.statusCode == 200) {
    final data = json.decode(response.body);
    final resources = data['resourceSets'][0]['resources'] as List;

    return resources
        .where((resource) => resource['address']['countryRegion'] == country)
        .map<String>((resource) {
          final locality = resource['address']['locality'];
          final adminDistrict = resource['address']['adminDistrict'];
          return locality != null && locality.isNotEmpty ? locality : (adminDistrict != null && adminDistrict.isNotEmpty ? adminDistrict : '');
        })
        .where((city) => city.isNotEmpty)
        .toList();
  } else {
    throw Exception('Failed to load cities');
  }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Нове оголошення'),
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
              GestureDetector(
                onTap: () {
                  _pickImages();
                },
                child: CircleAvatar(
                  radius: 50,
                  backgroundColor: Colors.grey[200],
                  child: _images != null && _images!.isNotEmpty
                      ? Image.file(File(_images!.first.path))
                      : Icon(Icons.add_a_photo, color: Colors.grey[800]),
                ),
              ),
              TextFormField(
                controller: _titleController,
                decoration: InputDecoration(labelText: 'Заголовок'),
                maxLength: 50,
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return 'Введіть заголовок';
                  }
                  return null;
                },
              ),
              TextFormField(
                controller: _infoController,
                decoration: InputDecoration(labelText: 'Інформація'),
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return 'Введіть інформацію';
                  }
                  return null;
                },
              ),
              Autocomplete<String>(
                optionsBuilder: (TextEditingValue textEditingValue) {
                  if (textEditingValue.text.isEmpty) {
                    return const Iterable<String>.empty();
                  }
                  return _countryOptions.where((String option) {
                    return option.toLowerCase().contains(textEditingValue.text.toLowerCase());
                  });
                },
                onSelected: (String selection) {
                  _countryController.text = selection;
                  print('You just selected $selection');
                },
                fieldViewBuilder: (BuildContext context, TextEditingController textEditingController, FocusNode focusNode, VoidCallback onFieldSubmitted) {
                  textEditingController.addListener(() {
                    if (_countryOptions.contains(textEditingController.text)) {
                      setState(() {
                        _countryController.text = textEditingController.text;
                      });
                    }
                  });
                  return TextField(
                    controller: textEditingController,
                    focusNode: focusNode,
                    decoration: InputDecoration(
                      labelText: 'Країна',
                    ),
                  );
                },
                optionsViewBuilder: (BuildContext context, AutocompleteOnSelected<String> onSelected, Iterable<String> options) {
                  return Align(
                    alignment: Alignment.topLeft,
                    child: Material(
                      child: Container(
                        width: MediaQuery.of(context).size.width * 0.8,
                        child: ListView.builder(
                          padding: EdgeInsets.all(8.0),
                          itemCount: options.length,
                          itemBuilder: (BuildContext context, int index) {
                            final String option = options.elementAt(index);
                            return GestureDetector(
                              onTap: () {
                                onSelected(option);
                              },
                              child: ListTile(
                                title: Text(option),
                              ),
                            );
                          },
                        ),
                      ),
                    ),
                  );
                },
              ),
              Autocomplete<String>(
                optionsBuilder: (TextEditingValue textEditingValue) async {
                  if (textEditingValue.text.isEmpty) {
                    return const Iterable<String>.empty();
                  }
                  return await _fetchCityOptions(textEditingValue.text, _countryController.text);
                },
                onSelected: (String selection) {
                  _cityController.text = selection;
                  print('You just selected $selection');
                },
                fieldViewBuilder: (BuildContext context, TextEditingController textEditingController, FocusNode focusNode, VoidCallback onFieldSubmitted) {
                  return TextField(
                    controller: textEditingController,
                    focusNode: focusNode,
                    decoration: InputDecoration(
                      labelText: 'Місто',
                    ),
                  );
                },
                optionsViewBuilder: (BuildContext context, AutocompleteOnSelected<String> onSelected, Iterable<String> options) {
                  return Align(
                    alignment: Alignment.topLeft,
                    child: Material(
                      child: Container(
                        width: MediaQuery.of(context).size.width * 0.8,
                        child: ListView.builder(
                          padding: EdgeInsets.all(8.0),
                          itemCount: options.length,
                          itemBuilder: (BuildContext context, int index) {
                            final String option = options.elementAt(index);
                            return GestureDetector(
                              onTap: () {
                                onSelected(option);
                              },
                              child: ListTile(
                                title: Text(option),
                              ),
                            );
                          },
                        ),
                      ),
                    ),
                  );
                },
              ),
              TextFormField(
                controller: _streetController,
                maxLength: 100,
                decoration: InputDecoration(labelText: 'Адреса'),
                validator: (value) {
                  if (value == null || value.isEmpty) {
                    return 'Введіть адресу';
                  }
                  return null;
                },
              ),
              DropdownButtonFormField<int>(
                value: _peopleCount,
                decoration: InputDecoration(labelText: 'Кількість людей'),
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
                    'Дата заселення: ${_startDate?.toIso8601String().split('T').first ?? "Не вибрано"}'),
                trailing: Icon(Icons.calendar_today),
                onTap: () => _selectDate(context, true),
              ),
              ListTile(
                title: Text(
                    'Дата виселення: ${_endDate?.toIso8601String().split('T').first ?? "Не вибрано"}'),
                trailing: Icon(Icons.calendar_today),
                onTap: () => _selectDate(context, false),
              ),
              ElevatedButton(
                onPressed: () {
                  if (_formKey.currentState!.validate()) {
                    // Реализуйте функцию AddRental для обработки данных
                    AddRental(
                        _titleController.text,
                        _infoController.text,
                        _countryController.text,
                        _cityController.text,
                        _streetController.text,
                        _peopleCount,
                        _startDate,
                        _endDate,
                        _images!);
                    runApp(Home());
                  }
                },
                child: Text('Додати'),
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
    DateTime? dateEviction,
    List<XFile> images) async {
  DateTime date = DateTime.now();
  String? userID = await GetID();
  int photoCount = images.length;
  String request =
      "INSERT INTO `rental` (`Title`, `Description`, `MaxPeople`, `Country`, `City`, `Street`, `DateRental`, `DateEviction`, `LessorID`, `DateCreate`, `PhotoCount`) VALUES ('$title', '$info', '$count', '$country', '$city', '$adress', '$dateRental', '$dateEviction', '$userID', '$date', '$photoCount');";
  final response = await http.post(
    Uri.parse('${GetServer()}/addTable.php'),
    body: {'request': request},
  );
  if (response.statusCode == 200) {
    prepareFilesForUpload(images);
  } else {}
}

Future<String> GetID() async {
  DateTime date = DateTime.now();
  String ID = '-1';
  String? email = await loadEmail();
  final response = await http.post(
    Uri.parse('${GetServer()}/getID.php'),
    body: {'email': email},
  );
  if (response.statusCode == 200) {
    var jsonResponse = json.decode(response.body);
    ID = jsonResponse['UserID'].toString() ?? '';
  }
  return ID;
}

void prepareFilesForUpload(List<XFile> images) {
  List<Map<String, dynamic>> files = [];
  for (int i = 0; i < images.length; i++) {
    String newName = "mail_$i.jpg";
    Map<String, dynamic> fileData = {
      "path": images[i].path,
      "newName": newName,
    };
    files.add(fileData);
  }
  uploadFiles(files);
}

Future<void> uploadFiles(List<Map<String, dynamic>> filest) async {
  var uri = Uri.parse("${GetServer()}/uploadRental.php");
  String prefix = await GetLastRental();
  print(prefix);
  var request = http.MultipartRequest('POST', uri);
  request.fields['prefix'] = prefix;
  var response;
  for (var file in filest) {
    request.files.add(await http.MultipartFile.fromPath(
      'file[]',
      file['path'],
      filename: file['newName'],
    ));
  }
  response = await request.send();
  if (response.statusCode == 200) {
    print('Upload successful');
  } else {
    print('Upload failed');
  }
}

Future<String> GetLastRental() async {
  
  String? email = await loadEmail(); 
  final response = await http.post(
    Uri.parse('${GetServer()}/lastRental.php'),
    body: {'email': email},
  );
  if (response.statusCode == 200) {
    var jsonResponse = json.decode(response.body);
    String ID = jsonResponse['RentalID'].toString();
    return ID;
  } else {
    return '';
  }
}
