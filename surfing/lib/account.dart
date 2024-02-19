import 'package:flutter/material.dart';
import 'dart:async';
import 'dart:convert';
import 'package:http/http.dart' as http;
import 'auth.dart';

class MyApp extends StatelessWidget {
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
  String? userEmail;
  int _currentIndex = 3;
  @override
  void initState() {
    loadUserEmail();
    super.initState();
    // Объединяем оба Future в один с помощью Future.wait
    userDataFuture = Future.wait([
      _fetchUserData(widget.email),
      _fetchRateData(widget.email),
    ]);
  }

  void loadUserEmail() async {
    userEmail = await loadEmail();
    setState(() {}); // Обновляем UI после загрузки email
  }

  void _onItemTapped(int index) {
    setState(() {
      _currentIndex = index;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Профиль'),
        backgroundColor: Color.fromARGB(255, 96, 150, 180),
        centerTitle: true,
      ),
      body: FutureBuilder<dynamic>(
        future: userDataFuture,
        builder: (context, snapshot) {
          if (snapshot.connectionState == ConnectionState.done) {
            if (snapshot.hasData) {
              final userData = snapshot.data![0];
              final userRateData = snapshot.data![1];
              return Column(
                children: <Widget>[
                  SizedBox(height: 20),
                  Container(
                    padding:
                        EdgeInsets.all(2), // Расстояние рамки от CircleAvatar
                    decoration: BoxDecoration(
                      color: const Color.fromARGB(255, 0, 0,
                          0), // Цвет фона рамки, можно задать любой цвет
                      shape: BoxShape.circle, // Форма рамки
                      boxShadow: [
                        BoxShadow(
                          color:
                              Colors.grey.withOpacity(0.5), // Цвет тени рамки
                          spreadRadius: 5, // Размер тени
                          blurRadius: 7, // Размытие тени
                          offset: Offset(0, 3), // Смещение тени
                        ),
                      ],
                    ),
                    child: CircleAvatar(
                      radius: 50,
                      backgroundImage: NetworkImage(userData['ProfilePicture']),
                    ),
                  ),
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
                    ElevatedButton(
                      onPressed: () {
                        showCustomDialog(
                            context,
                            "Вы уверены что хотите удалить аккаунт?",
                            userEmail.toString());
                      },
                      child: Text('Удалить'),
                    ),
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
            icon: Icon(Icons.favorite),
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
    print(response.body);
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
    print(response.body);
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
        title: Text('Внимание', textAlign: TextAlign.center,),
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
