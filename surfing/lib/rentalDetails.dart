import 'package:flutter/material.dart';
import 'package:surfing/serverInfo.dart';
import 'package:intl/intl.dart';
import 'package:shared_preferences/shared_preferences.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

class RentalDetailPage extends StatelessWidget {
  final Map<String, dynamic> rental;

  RentalDetailPage({Key? key, required this.rental}) : super(key: key);

  Future<String?> getIDUser() async {
    final SharedPreferences prefs = await SharedPreferences.getInstance();
    final String? email = prefs.getString('userEmail');
    final response = await http.post(
      Uri.parse('${GetServer()}/getID.php'),
      body: {'email': email},
    );
    if (response.statusCode == 200) {
      var jsonResponse = json.decode(response.body);
      return jsonResponse['UserID'].toString();
    }
    return null;
  }

  @override
  Widget build(BuildContext context) {
    final String imagePath = '${GetServer()}/uploads/rental/${rental['RentalID']}_';
    return Scaffold(
      appBar: AppBar(
        title: Text('Объявление'),
        backgroundColor: Color.fromARGB(255, 96, 150, 180),
        centerTitle: true,
      ),
      body: SingleChildScrollView(
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.start,
          children: [
            SizedBox(
              height: 250.0,
              child: PageView.builder(
                itemCount: rental['PhotoCount'],
                itemBuilder: (BuildContext context, int index) {
                  String imageUrl = imagePath + '${index + 1}.jpg';
                  return Image.network(
                    imageUrl,
                    fit: BoxFit.cover,
                    errorBuilder: (context, error, stackTrace) => Center(child: Text('Изображение не доступно')),
                  );
                },
              ),
            ),
            Padding(
              padding: const EdgeInsets.all(16.0),
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Text(rental['Title'], style: TextStyle(fontSize: 24, fontWeight: FontWeight.bold)),
                  SizedBox(height: 8),
                  Text(rental['Description']),
                  SizedBox(height: 8),
                  Text('${rental['Country']} ${rental['City']} ${rental['Street']}'),
                  ElevatedButton(
                    onPressed: () {
                      // Действие для просмотра адреса
                    },
                    child: Text('Просмотреть адрес'),
                  ),
                ],
              ),
            ),
            FutureBuilder<String?>(
              future: getIDUser(),
              builder: (context, snapshot) {
                if (snapshot.connectionState == ConnectionState.done && snapshot.hasData) {
                  if (snapshot.data != rental['LessorID'].toString()) {
                    return Center(
                      child: ElevatedButton(
                        onPressed: () {
                          // Действия, когда пользователь - арендодатель
                        },
                        child: Text('Откликнутся'),
                      ),
                    );
                  }
                }
                return SizedBox(); // Возвращаем пустой виджет, если условие не выполняется
              },
            ),
          ],
        ),
      ),
    );
  }
}
