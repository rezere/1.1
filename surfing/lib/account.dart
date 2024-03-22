import 'package:flutter/material.dart';
import 'dart:async';
import 'dart:convert';
import 'package:http/http.dart' as http;
import 'package:shared_preferences/shared_preferences.dart';
import 'auth.dart';
import 'find.dart';
import 'map.dart';
import 'home.dart';
import 'dart:typed_data';


class ProfilePage extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: UserProfilePage(email: ''),
    );
  }
}

class UserProfilePage extends StatefulWidget {
  final String email;

  UserProfilePage({Key? key, required this.email}) : super(key: key);

  @override
  _UserProfilePageState createState() => _UserProfilePageState();
}

class _UserProfilePageState extends State<UserProfilePage> {
  late Future<dynamic> userDataFuture, userRateFuture;
  int totalStars = 5;
  String? userEmail, profileEmail;
  int _currentIndex = 3;
  dynamic userData;
  String? selectedReason;
Uint8List kTransparentImage = Uint8List.fromList([
  0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A, 0x00, 0x00, 0x00, 0x0D, 0x49, 0x48, 0x44, 0x52,
  0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x01, 0x08, 0x06, 0x00, 0x00, 0x00, 0x1F, 0x15, 0xC4,
  0x89, 0x00, 0x00, 0x00, 0x0A, 0x49, 0x44, 0x41, 0x54, 0x78, 0x9C, 0x63, 0x00, 0x01, 0x00, 0x00,
  0x05, 0x00, 0x01, 0x0D, 0x0A, 0x2D, 0xB4, 0x00, 0x00, 0x00, 0x00, 0x49, 0x45, 0x4E, 0x44, 0xAE,
  0x42, 0x60, 0x82
]);
  @override
  void initState() {
    loadUserEmail();
    super.initState();
    // Объединяем оба Future в один с помощью Future.wait
    userDataFuture = Future.wait([
      _fetchUserData(widget.email),
      _fetchRateData(widget.email),
    ]);
    profileEmail = '';
  }

  void loadUserEmail() async {
    userEmail = await loadEmail();
    setState(() {}); // Обновляем UI после загрузки email
  }

  void _onItemTapped(int index) {
    setState(() {
      _currentIndex = index;
      switch (_currentIndex) {
        case 0:
          {
            runApp(Home());
            break;
          }
        case 1:
          {
            runApp(MapPage());
          }
        case 2:
          {
            runApp(Find());
            break;
          }
      }
    });
  }

  void _showReasonDialog() {
    showDialog<String>(
      context: context,
      builder: (BuildContext context) {
        return SimpleDialog(
          title: const Text('Выберите причину жалобы'),
          children: <Widget>[
            SimpleDialogOption(
              onPressed: () {
                AddReport(
                    userEmail!, profileEmail!, 'Обман/Ввод в заблуждение');
                Navigator.of(context).pop();
              },
              child: const Text('Обман/Ввод в заблуждение'),
            ),
            SimpleDialogOption(
              onPressed: () {
                AddReport(userEmail!, profileEmail!, 'Ложная информация');
                Navigator.of(context).pop();
              },
              child: const Text('Ложная информация'),
            ),
            SimpleDialogOption(
              onPressed: () {
                AddReport(userEmail!, profileEmail!, 'Плохое качество');
                Navigator.of(context).pop();
              },
              child: const Text('Плохое качество'),
            ),
            TextButton(
              onPressed: () => Navigator.of(context).pop(),
              child: Text('ОК'),
            ),
          ],
        );
      },
    ).then((value) {
      // Обновление состояния виджета с выбранной причиной
      if (value != null) {
        setState(() {
          selectedReason = value;
        });
        // Отображение выбранной причины
        ScaffoldMessenger.of(context).showSnackBar(
            SnackBar(content: Text('Выбранная причина: $selectedReason')));
      }
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Профиль'),
        backgroundColor: Color.fromARGB(255, 96, 150, 180),
        centerTitle: true,
        actions: <Widget>[
          IconButton(
            icon: Icon(Icons.announcement_outlined),
            onPressed: _showReasonDialog,
          ),
        ],
      ),
      body: FutureBuilder<dynamic>(
        future: userDataFuture,
        builder: (context, snapshot) {
          if (snapshot.connectionState == ConnectionState.done) {
            if (snapshot.hasData) {
              userData = snapshot.data![0];
              profileEmail = userData['Email'];
              final userRateData = snapshot.data![1];
              return Column(
                children: <Widget>[
                  SizedBox(height: 20),
                  Container(
                      padding:
                          EdgeInsets.all(2), // Расстояние рамки от CircleAvatar
                      decoration: BoxDecoration(
                        color: const Color.fromARGB(255, 0, 0, 0),
                        shape: BoxShape.circle,
                        boxShadow: [
                          BoxShadow(
                            color: Colors.grey.withOpacity(0.5),
                            spreadRadius: 5,
                            blurRadius: 7,
                            offset: Offset(0, 3),
                          ),
                        ],
                      ),
                      child: CircleAvatar(
                        radius: 50,
                        // Используйте FadeInImage.memoryNetwork для загрузки изображения
                        backgroundImage: FadeInImage.memoryNetwork(
                          placeholder: kTransparentImage, // Это должна быть прозрачная картинка
                          image: userData['ProfilePicture'],
                          fit: BoxFit.cover,
                          imageErrorBuilder: (context, error, stackTrace) {
                            // Возвращает виджет с иконкой, если изображение не загружено
                            return Icon(Icons.person,
                                size: 100, color: Colors.grey);
                          },
                        ).image,
                      )),
                  SizedBox(height: 20),
                  Row(
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: <Widget>[
                      Text('${userData['Surname']} ${userData['Name']}',
                          style: TextStyle(fontSize: 24)),
                    ],
                  ),
                  SizedBox(height: 20),
                  Row(
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: List.generate(totalStars, (index) {
                      double averageRating;
                      if (userRateData['averageRating'] == null) {
                        averageRating = 0;
                      } else {
                        averageRating =
                            double.parse(userRateData['averageRating']);
                      }
                      // Полная звезда, если индекс меньше целой части среднего рейтинга
                      if (index < averageRating.floor()) {
                        return Icon(Icons.star, color: Colors.amber);
                        // Половина звезды, если индекс меньше среднего рейтинга и больше или равен его целой части
                      } else if (index < averageRating &&
                          index >= averageRating.floor()) {
                        return Icon(Icons.star_half, color: Colors.amber);
                        // Пустая звезда в остальных случаях
                      } else {
                        return Icon(Icons.star_border, color: Colors.amber);
                      }
                    }),
                  ),
                  SizedBox(height: 20),
                  Text(
                      'Адрес: ${userData['Country']}, ${userData['City']}, ${userData['Street']}'),
                  SizedBox(height: 10),
                  Text('О себе: ${userData['BIO']}'),
                  SizedBox(height: 20),
                  if (userData['Email'] == userEmail)
                    Row(
                      mainAxisAlignment: MainAxisAlignment.center,
                      children: <Widget>[
                        ElevatedButton(
                          onPressed: () {
                            removeEmail();
                            runApp(Auth());
                          },
                          child: const Text('Выйти'),
                        ),
                        SizedBox(
                          width: 50,
                        ),
                        ElevatedButton(
                          onPressed: () {
                            showCustomDialog(
                                context,
                                "Вы уверены что хотите удалить аккаунт?",
                                userEmail.toString());
                          },
                          child: const Text('Удалить'),
                        ),
                      ],
                    )
                ],
              );
            } else if (snapshot.hasError) {
              return Text("${snapshot.error}");
            }
          }
          return CircularProgressIndicator();
        },
      ),
      bottomNavigationBar: BottomNavigationBar(
        backgroundColor: Colors.black,
        currentIndex: _currentIndex, // Текущий индекс
        onTap: _onItemTapped, // Обработка нажатий
        items: const <BottomNavigationBarItem>[
          BottomNavigationBarItem(
            backgroundColor: Colors.black,
            icon: Icon(Icons.home),
            label: 'Главная',
          ),
          BottomNavigationBarItem(
            backgroundColor: Colors.black,
            icon: Icon(Icons.fmd_good_outlined),
            label: 'Избранное',
          ),
          BottomNavigationBarItem(
            backgroundColor: Colors.black,
            icon: Icon(Icons.search),
            label: 'Поиск',
          ),
          BottomNavigationBarItem(
            backgroundColor: Colors.black,
            icon: Icon(Icons.account_circle),
            label: 'Аккаунт',
          ),
        ],
        selectedItemColor: Colors.amber[800], // Цвет выбранного элемента
      ),
    );
  }
}

Future<dynamic> _fetchUserData(String email) async {
  final response = await http.post(
    Uri.parse('http://10.0.2.2/couchsurfing/getTable.php'),
    body: {'email': email},
  );

  if (response.statusCode == 200) {
    return json.decode(response.body);
  } else {
    throw Exception('Failed to load user data');
  }
}

Future<dynamic> _fetchRateData(String email) async {
  final response = await http.post(
    Uri.parse('http://10.0.2.2/couchsurfing/rate.php'),
    body: {'email': email},
  );

  if (response.statusCode == 200) {
    return json.decode(response.body);
  } else {
    throw Exception('Failed to load user data');
  }
}

void DestroyAccount(String email) async {
  String request = "DELETE FROM users WHERE `users`.`Email` = $email";
  final response = await http.post(
    Uri.parse('http://10.0.2.2/couchsurfing/destroyTable.php'),
    body: {'request': request},
  );
  if (response.statusCode == 200) {
    runApp(Auth());
  } else {}
}

void showCustomDialog(BuildContext context, String text, String email) {
  showDialog(
    context: context,
    builder: (BuildContext context) {
      return AlertDialog(
        title: Text(
          'Внимание',
          textAlign: TextAlign.center,
        ),
        content: Text(text),
        actions: <Widget>[
          TextButton(
            onPressed: () {
              Navigator.of(context).pop();
            },
            child: Text('Отмена'),
          ),
          TextButton(
            onPressed: () {
              DestroyAccount(email);
            },
            child: Text('Удалить'),
          ),
        ],
      );
    },
  );
}

Future<void> removeEmail() async {
  final SharedPreferences prefs = await SharedPreferences.getInstance();
  await prefs.remove('userEmail');
}

void AddReport(String email, String reportedEmail, String info) async {
  DateTime date = DateTime.now();
  String? ID, reportedID;
  final response = await http.post(
    Uri.parse('http://10.0.2.2/couchsurfing/getID.php'),
    body: {'email': email},
  );
  if (response.statusCode == 200) {
    var jsonResponse = json.decode(response.body);
    ID = jsonResponse['UserID'].toString();
    final respon = await http.post(
      Uri.parse('http://10.0.2.2/couchsurfing/getID.php'),
      body: {'email': reportedEmail},
    );
    if (respon.statusCode == 200) {
      jsonResponse = json.decode(respon.body);
      reportedID = jsonResponse['UserID'].toString() ?? '';

      String request =
          "INSERT INTO `report` (`firstID`, `secondID`, `Info`, `Date`) VALUES ('$ID', '$reportedID', '$info', '$date');";
      final del = await http.post(
        Uri.parse('http://10.0.2.2/couchsurfing/addTable.php'),
        body: {'request': request},
      );
    }
  } else {
    throw Exception('Failed to load user data');
  }
}
