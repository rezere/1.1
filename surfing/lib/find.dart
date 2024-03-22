import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:surfing/map.dart';
import 'dart:convert';
import 'account.dart';
import 'auth.dart';
import 'map.dart';
import 'home.dart';

class Find extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: SearchScreen(),
    );
  }
}

class SearchScreen extends StatefulWidget {
  @override
  _SearchScreenState createState() => _SearchScreenState();
}

class _SearchScreenState extends State<SearchScreen> {
  int _currentIndex = 2;
  String? email = '';

  @override
  void initState() {
    loadUserEmail();
    super.initState();
  }

  void loadUserEmail() async {
    email = await loadEmail();
    setState(() {});
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
        case 3:
          {
            runApp(Profile(userEmail: email!));
          }
      }
    });
  }

  final TextEditingController _controller = TextEditingController();
  List<dynamic> _searchResults = [];

  Future<void> _search() async {
    final response = await http.get(Uri.parse(
        'http://10.0.2.2/couchsurfing/findTable.php?search=${_controller.text}'));
    if (response.statusCode == 200) {
      final List<dynamic> results = json.decode(response.body);
      setState(() {
        _searchResults = results;
      });
    } else {
      // Обработка ошибки
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Поиск пользователей'),
        backgroundColor: const Color.fromARGB(255, 96, 150, 180),
        centerTitle: true,
      ),
      body: Column(
        children: [
          Padding(
            padding: const EdgeInsets.all(8.0),
            child: TextField(
              controller: _controller,
              decoration: InputDecoration(
                border: const OutlineInputBorder(),
                labelText: 'Поиск',
                suffixIcon: IconButton(
                  icon: const Icon(Icons.search),
                  onPressed: _search,
                ),
              ),
            ),
          ),
          Expanded(
            child: ListView.builder(
              itemCount: _searchResults.length,
              itemBuilder: (context, index) {
                final user = _searchResults[index];
                final rating = user['averageRating'] != null
                    ? double.parse(user['averageRating'].toString())
                        .toStringAsFixed(1)
                    : '0';
                return ListTile(
                  title: Row(
                    mainAxisAlignment: MainAxisAlignment.spaceBetween,
                    children: <Widget>[
                      Row(
                        children: <Widget>[
                          ClipOval(
                            child: user['ProfilePicture'] != null
                                ? Image.network(
                                    user['ProfilePicture'],
                                    width: 50,
                                    height: 50,
                                    fit: BoxFit.cover,
                                    errorBuilder: (BuildContext context,
                                        Object exception,
                                        StackTrace? stackTrace) {
                                      return Icon(Icons.person, size: 50);
                                    },
                                  )
                                : Container(
                                    width: 50,
                                    height: 50,
                                    decoration: BoxDecoration(
                                      shape: BoxShape.circle,
                                      color: Colors.grey,
                                    ),
                                    child: Icon(Icons.person,
                                        size: 50, color: Colors.white),
                                  ),
                          ),
                          const SizedBox(width: 10),
                          Text('${user['Surname']} ${user['Name']}'),
                        ],
                      ),
                      Text('$rating ★'),
                    ],
                  ),
                  onTap: () {
                    runApp(Profile(userEmail: user['Email']));
                  },
                );
              },
            ),
          ),
        ],
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

class Profile extends StatelessWidget {
  final String userEmail;

  const Profile({Key? key, required this.userEmail}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: UserProfilePage(email: userEmail),
    );
  }
}
