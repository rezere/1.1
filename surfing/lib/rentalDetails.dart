import 'package:flutter/material.dart';
import 'package:surfing/rental.dart';
import 'package:surfing/serverInfo.dart';
import 'package:intl/intl.dart';
import 'package:shared_preferences/shared_preferences.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';


final GlobalKey<ScaffoldMessengerState> scaffoldMessengerKey = GlobalKey<ScaffoldMessengerState>();

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
   Future<void> updateRenterID(int rentalID,) async {
    String userID = await GetID();
    final uri = Uri.parse('${GetServer()}/respondRental.php');
    final response = await http.post(uri, body: {
      'rentalID': rentalID.toString(),
      'renterID': userID,
    });

    if (response.statusCode == 200) {
      final jsonResponse = json.decode(response.body);
      if (jsonResponse['success'] != null) {
        // Успешное обновление
        print('RenterID updated successfully');
        showDialog("Вы откликнулись на объявление");
      } else if (jsonResponse['error'] != null) {
        // Обработка конфликта дат
        print('Date conflict detected');
        showDialog("К сожалению произошёл конфликт дат");
      }
    } else {
      // Обработка ошибки запроса
      print('Failed to update RenterID: ${response.statusCode}');
    }
  }
  @override
  Widget build(BuildContext context) {
    final String imagePath = '${GetServer()}/uploads/rental/${rental['RentalID']}_';
    return ScaffoldMessenger(
      key: scaffoldMessengerKey,
      child: Scaffold(
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
                  if (snapshot.data != rental['LessorID'].toString() && rental['RenterID'] == null) {
                    return Center(
                      child: ElevatedButton(
                        onPressed: () {
                          updateRenterID(rental['RentalID']);
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
    ),
    );
  }
}

void showDialog(String value) {
  final snackBar = SnackBar(content: Text(value));
  scaffoldMessengerKey.currentState?.showSnackBar(snackBar);
}