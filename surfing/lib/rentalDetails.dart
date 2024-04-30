import 'package:flutter/material.dart';
import 'package:surfing/rental.dart';
import 'package:surfing/serverInfo.dart';
import 'package:intl/intl.dart';
import 'package:shared_preferences/shared_preferences.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';
import 'package:flutter_rating_bar/flutter_rating_bar.dart';

final GlobalKey<ScaffoldMessengerState> scaffoldMessengerKey =
    GlobalKey<ScaffoldMessengerState>();

class RentalDetailPage extends StatelessWidget {
  final Map<String, dynamic> rental;
  final GlobalKey<ScaffoldMessengerState> scaffoldMessengerKey =
      GlobalKey<ScaffoldMessengerState>();

  RentalDetailPage({Key? key, required this.rental}) : super(key: key);
  String? userID;
  Future<String?> getIDUser() async {
    final SharedPreferences prefs = await SharedPreferences.getInstance();
    final String? email = prefs.getString('userEmail');
    final response = await http.post(
      Uri.parse('${GetServer()}/getID.php'),
      body: {'email': email},
    );
    if (response.statusCode == 200) {
      var jsonResponse = json.decode(response.body);
      userID = jsonResponse['UserID'].toString();
      return jsonResponse['UserID'].toString();
    }
    return null;
  }

  Future<dynamic> _fetchUserData(String userID) async {
    final response = await http.post(
      Uri.parse('${GetServer()}/getUserForID.php'),
      body: {'userID': userID},
    );

    if (response.statusCode == 200) {
      return json.decode(response.body);
    } else {
      throw Exception('Failed to load user data');
    }
  }

  Future<dynamic> _fetchRateData(String email) async {
    final response = await http.post(
      Uri.parse('${GetServer()}/rate.php'),
      body: {'email': email},
    );

    if (response.statusCode == 200) {
      return json.decode(response.body);
    } else {
      throw Exception('Failed to load user data');
    }
  }

  Future<dynamic> getRateInfo(int rental) async {
    String? temp = await getIDUser();
    final response = await http.post(
      Uri.parse('${GetServer()}/getRateInfo.php'),
      body: {
        'firstID': userID.toString(),
        'rental': rental.toString(),
      },
    );

    if (response.statusCode == 200) {
      print(json.decode(response.body));
      return json.decode(response.body);
    } else {
      throw Exception('Failed to fetch rate data');
    }
  }

  Future<void> updateRenterID(
    int rentalID,
  ) async {
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
        showDialogDate("Вы откликнулись на объявление");
      } else if (jsonResponse['error'] != null) {
        // Обработка конфликта дат
        print('Date conflict detected');
        showDialogDate("К сожалению произошёл конфликт дат");
      }
    } else {
      // Обработка ошибки запроса
      print('Failed to update RenterID: ${response.statusCode}');
    }
  }

  void showSnackbar(String message) {
    final snackBar = SnackBar(content: Text(message));
    scaffoldMessengerKey.currentState?.showSnackBar(snackBar);
  }

  @override
  Widget build(BuildContext context) {
    final String imagePath =
        '${GetServer()}/uploads/rental/${rental['RentalID']}_';
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
                      errorBuilder: (context, error, stackTrace) =>
                          Center(child: Text('Изображение не доступно')),
                    );
                  },
                ),
              ),
              Padding(
                padding: const EdgeInsets.all(16.0),
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Text(rental['Title'],
                        style: TextStyle(
                            fontSize: 24, fontWeight: FontWeight.bold)),
                    SizedBox(height: 8),
                    Text(rental['Description']),
                    SizedBox(height: 8),
                    Text(
                        '${rental['Country']} ${rental['City']} ${rental['Street']}'),
                    ElevatedButton(
                      onPressed: () {
                        // Add action for viewing the address if necessary
                      },
                      child: Text('Просмотреть адрес'),
                    ),
                    FutureBuilder<String?>(
                      future: getIDUser(),
                      builder: (context, snapshot) {
                        if (snapshot.connectionState == ConnectionState.done &&
                            snapshot.hasData) {
                          if (snapshot.data != rental['LessorID'].toString() &&
                              rental['RenterID'] == null) {
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
                    //<------------------- Кнопка оценки
                    FutureBuilder<dynamic>(
                      future: getRateInfo(rental['RentalID']),
                      builder: (context, snapshot) {
                        final currentDate = DateTime.now();

                        final evictionDate =
                            DateTime.tryParse(rental['DateEviction'] ?? '');

                        final shouldShowButton = rental['RenterID'] != null &&
                            evictionDate != null &&
                            evictionDate.isBefore(currentDate) &&
                            snapshot.data == null &&
                            (rental['RenterID'].toString() == userID.toString() ||
                                rental['LessorID'].toString() == userID.toString());
                        if (snapshot.connectionState == ConnectionState.done &&
                            shouldShowButton) {
                          return Center(
                            child: ElevatedButton(
                              onPressed: () {
                                
                                if (rental['RenterID'].toString() == userID.toString()) {
                                  showRatingDialog(context, userID.toString(),
                                      rental['LessorID'].toString(), rental['RentalID'].toString());
                                } else if (rental['LessorID'].toString() == userID.toString()) {
                                  showRatingDialog(context, userID.toString(),
                                      rental['RenterID'].toString(), rental['RentalID'].toString());
                                }
                              },
                              child: Text('Оценить'),
                            ),
                          );
                        }
                        return SizedBox();
                      },
                    ),
                    SizedBox(
                      height: 50,
                    ),
                    FutureBuilder<dynamic>(
                      future: _fetchUserData(rental['LessorID'].toString()),
                      builder: (BuildContext context,
                          AsyncSnapshot<dynamic> snapshot) {
                        if (snapshot.connectionState == ConnectionState.done) {
                          if (snapshot.hasData) {
                            var userData = snapshot.data;

                            return FutureBuilder<dynamic>(
                              future: _fetchRateData(userData['Email']),
                              builder: (BuildContext context,
                                  AsyncSnapshot<dynamic> rateSnapshot) {
                                if (rateSnapshot.connectionState ==
                                    ConnectionState.done) {
                                  double averageRating = 0;
                                  if (rateSnapshot.hasData &&
                                      rateSnapshot.data['averageRating'] !=
                                          null) {
                                    averageRating = double.tryParse(rateSnapshot
                                            .data['averageRating']
                                            .toString()) ??
                                        0;
                                  }

                                  int totalStars = 5;

                                  return Column(
                                    crossAxisAlignment:
                                        CrossAxisAlignment.start,
                                    children: [
                                      ListTile(
                                        leading: ClipOval(
                                          child: userData['ProfilePicture'] !=
                                                  null
                                              ? Image.network(
                                                  userData['ProfilePicture'],
                                                  width: 50,
                                                  height: 50,
                                                  fit: BoxFit.cover,
                                                  errorBuilder: (context, error,
                                                      stackTrace) {
                                                    return Icon(Icons.person,
                                                        size: 50);
                                                  },
                                                )
                                              : Icon(Icons.person, size: 50),
                                        ),
                                        title: Text(
                                          '${userData['Surname']} ${userData['Name']}',
                                          style: TextStyle(
                                              fontSize: 20,
                                              fontWeight: FontWeight.bold),
                                        ),
                                      ),
                                      Padding(
                                        padding: const EdgeInsets.only(
                                            left:
                                                80), // Align with the title text of ListTile
                                        child: Row(
                                          children: List.generate(totalStars,
                                              (index) {
                                            return Icon(
                                              index < averageRating
                                                  ? Icons.star
                                                  : Icons.star_border,
                                              color:
                                                  index < averageRating.floor()
                                                      ? Colors.amber
                                                      : Colors.grey,
                                            );
                                          }),
                                        ),
                                      ),
                                    ],
                                  );
                                }
                                return CircularProgressIndicator();
                              },
                            );
                          } else if (snapshot.hasError) {
                            return Text(
                                "Ошибка загрузки данных пользователя: ${snapshot.error}");
                          }
                        }
                        return CircularProgressIndicator();
                      },
                    ),
                  ],
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}

void showDialogDate(String value) {
  final snackBar = SnackBar(content: Text(value));
  scaffoldMessengerKey.currentState?.showSnackBar(snackBar);
}

void showRatingDialog(
    BuildContext context, String firstID, String secondID, String rentalID) {
  final TextEditingController _commentController = TextEditingController();
  double _currentRating = 0;

  showDialog(
    context: context,
    builder: (context) {
      return AlertDialog(
        title: Text('Оценить'),
        content: Column(
          mainAxisSize: MainAxisSize.min,
          children: [
            RatingBar.builder(
              initialRating: _currentRating,
              minRating: 1,
              direction: Axis.horizontal,
              allowHalfRating: true,
              itemCount: 5,
              itemPadding: EdgeInsets.symmetric(horizontal: 4.0),
              itemBuilder: (context, _) => Icon(
                Icons.star,
                color: Colors.amber,
              ),
              onRatingUpdate: (rating) {
                _currentRating = rating;
              },
            ),
            TextField(
              controller: _commentController,
              decoration: InputDecoration(hintText: 'Комментарий'),
            ),
          ],
        ),
        actions: <Widget>[
          TextButton(
            child: Text('Отмена'),
            onPressed: () {
              Navigator.of(context).pop();
            },
          ),
          TextButton(
            child: Text('Оценить'),
            onPressed: () {
              AddRating(firstID,secondID,_currentRating.round(),_commentController.text,rentalID);
              Navigator.of(context).pop();
            },
          ),
        ],
      );
    },
  );
}

void AddRating(String firstID, String secondID, int stars, String info, String rentalID) async {
  
  String request =
      "INSERT INTO `rate` (`firstID`, `secondID`, `Stars`, `Info`, `RentalID`) VALUES ('${int.parse(firstID)}', '${int.parse(secondID)}', '$stars','$info', '${int.parse(rentalID)}');";
  final response = await http.post(
    Uri.parse('${GetServer()}/addTable.php'),
    body: {'request': request},
  );
  if (response.statusCode == 200) {
print("TEST ");
  } else {}
}