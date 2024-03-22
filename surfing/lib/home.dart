import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:surfing/map.dart';
import 'dart:convert';
import 'account.dart';
import 'auth.dart';
import 'map.dart';
import 'find.dart';

class Home extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: HomePage(),
    );
  }
}

class HomePage extends StatefulWidget {
  @override
  _HomePage createState() => _HomePage();
}

class _HomePage extends State<HomePage> {
  int _currentIndex = 0;
  String? email = '';

  @override
  void initState() {
    loadUserEmail();
    _loadRental();
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
            //runApp();
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
  List<dynamic> _loadResults = [];
  int _count = -1;

  Future<void> _loadRental() async {
    final response = await http.get(Uri.parse(
        'http://10.0.2.2/couchsurfing/getRental.php'));
    if (response.statusCode == 200) {
      print(response.body);
      final List<dynamic> results = json.decode(response.body);
      _count = results.length;
      setState(() {
        _loadResults = results;
      });
    } else {
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Главная'),
        backgroundColor: Color.fromARGB(255, 96, 150, 180),
        centerTitle: true,
      ),
      body: Column(
        children: [
          Expanded(
            child: ListView.builder(
              itemCount: _loadResults.length,
              itemBuilder: (context, index) {
                final rental = _loadResults[index];
                return ListTile(
                  title: Row(
                    mainAxisAlignment: MainAxisAlignment.spaceBetween,
                    children: <Widget>[
                      Row(
                        children: <Widget>[
                          SizedBox(width: 10),
                          Text('${rental['Title']}'),
                        ],
                      ),
                      Text('${rental['Country']} ${rental['City']}'),
                    ],
                  ),
                  onTap: () {
                    //runApp(Profile(userEmail: user['Email']));
                  },
                );
              },
            ),
          ),
          FloatingActionButton(
          onPressed: () {
            // Действие кнопки
          },
          child: Icon(Icons.add),
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