import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:surfing/map.dart';
import 'dart:convert';
import 'rentalDetails.dart';
import 'account.dart';
import 'auth.dart';
import 'map.dart';
import 'find.dart';
import 'rental.dart';
import 'serverInfo.dart';

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
  final response = await http.get(Uri.parse('${GetServer()}/getRental.php'));
  _updateRentalList(response);
}

Future<void> _loadMyRentals() async {
  String userId = await GetID();
  final response = await http.get(Uri.parse('${GetServer()}/getRantalUser.php?field=LessorID&value=$userId'));
  _updateRentalList(response);
}

Future<void> _loadMyResponses() async {
  String userId = await GetID();
  final response = await http.get(Uri.parse('${GetServer()}/getRantalUser.php?field=RenterID&value=$userId'));
  _updateRentalList(response);
}

void _updateRentalList(http.Response response) {
  if (response.statusCode == 200) {
    final List<dynamic> results = json.decode(response.body);
    setState(() {
      _loadResults = results;
      _count = results.length;
    });
  } else {
    print('Failed to load rentals: ${response.body}');
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
      children: <Widget>[
        Row(
          mainAxisAlignment: MainAxisAlignment.spaceEvenly,
          children: [
            ElevatedButton(
              onPressed: _loadRental,
              child: Text('Все'),
            ),
            ElevatedButton(
              onPressed: _loadMyRentals,
              child: Text('Мои объявления'),
            ),
            ElevatedButton(
              onPressed: _loadMyResponses,
              child: Text('Отклики'),
            ),
          ],
        ),
        Expanded(
          child: ListView.builder(
            itemCount: _loadResults.length,
            itemBuilder: (context, index) {
              final rental = _loadResults[index];
              final imageUrl = '${GetServer()}/uploads/rental/${rental['RentalID']}_1.jpg';
              return InkWell(
                onTap: () {
                  Navigator.push(
                    context,
                    MaterialPageRoute(
                      builder: (context) => RentalDetailPage(rental: rental),
                    ),
                  );
                },
                child: Card(
                  child: Row(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      Image.network(imageUrl, width: 100, height: 100, fit: BoxFit.cover),
                      Expanded(
                        child: Padding(
                          padding: const EdgeInsets.all(8.0),
                          child: Column(
                            crossAxisAlignment: CrossAxisAlignment.start,
                            children: [
                              Text(rental['Title'], style: TextStyle(fontSize: 18, fontWeight: FontWeight.bold)),
                              Text('${rental['Country']} ${rental['City']}'),
                              Text('Бронь: с ${rental['DateRental']} до ${rental['DateEviction']}'),
                              Text('Людей: ${rental['MaxPeople']}'),
                            ],
                          ),
                        ),
                      ),
                    ],
                  ),
                ),
              );
            },
          ),
        ),
        FloatingActionButton(
          onPressed: () {
            runApp(Rental());
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
