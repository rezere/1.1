import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:shared_preferences/shared_preferences.dart';
import 'package:surfing/map.dart';
import 'dart:convert';
import 'rentalDetails.dart';
import 'account.dart';
import 'auth.dart';
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
    checkLastLogin();
  }

  void loadUserEmail() async {
    email = await loadEmail();
    setState(() {});
  }

  Future<void> checkLastLogin() async {
    SharedPreferences prefs = await SharedPreferences.getInstance();
    String lastLoginDate = prefs.getString('lastLoginDate') ?? '';
    String? email = await loadEmail();
    DateTime now = DateTime.now();
    String today = '${now.year}-${now.month}-${now.day}';

    
    if (lastLoginDate != today) {
      await fetchBookingData(email!);
      prefs.setString('lastLoginDate', today);
    }
  }

  Future<void> fetchBookingData(String email) async {
    String apiUrl = '${GetServer()}/sendPush.php';

    try {
      final response = await http.post(
        Uri.parse(apiUrl),
        body: {
          'email': email,
        },
      );

      if (response.statusCode == 200) {
        List<dynamic> rentalData = jsonDecode(response.body);

        if (rentalData.isNotEmpty &&
            rentalData[0]['message'] != 'No rentals found for tomorrow') {
          showNotification('Завтра у вас заброньовано житло');
        }
      } else {
        throw Exception('Failed to load data');
      }
    } catch (e) {
      print('Error: $e');
    }
  }

  void showNotification(String message) {
    showDialog(
      context: context,
      builder: (context) {
        return AlertDialog(
          title: Text('Повідомлення!'),
          content: Text(message),
          actions: [
            TextButton(
              onPressed: () => Navigator.of(context).pop(),
              child: Text('OK'),
            ),
          ],
        );
      },
    );
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
    final response = await http.get(Uri.parse(
        '${GetServer()}/getRantalUser.php?field=LessorID&value=$userId'));
    _updateRentalList(response);
  }

  Future<void> _loadMyResponses() async {
    String userId = await GetID();
    final response = await http.get(Uri.parse(
        '${GetServer()}/getRantalUser.php?field=RenterID&value=$userId'));
    _updateRentalList(response);
  }

  Future<void> _findResponses(String value) async {
    final response = await http
        .get(Uri.parse('${GetServer()}/findRental.php?search=${value}'));
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
        title: Text('Головна'),
        backgroundColor: Color.fromARGB(255, 96, 150, 180),
        centerTitle: true,
      ),
      body: Column(
        children: <Widget>[
          TextField(
            controller: _controller,
            onChanged: (value) {
              _findResponses(value);
            },
            decoration: InputDecoration(
              border: const OutlineInputBorder(),
              labelText: 'Пошук',
              suffixIcon: IconButton(
                icon: const Icon(Icons.search),
                onPressed: null,
              ),
            ),
          ),
          Row(
            mainAxisAlignment: MainAxisAlignment.spaceEvenly,
            children: [
              ElevatedButton(
                onPressed: _loadRental,
                child: Text('Усе'),
              ),
              ElevatedButton(
                onPressed: _loadMyRentals,
                child: Text('Мої оголошення'),
              ),
              ElevatedButton(
                onPressed: _loadMyResponses,
                child: Text('Відгуки'),
              ),
            ],
          ),
          Expanded(
            child: ListView.builder(
              itemCount: _loadResults.length,
              itemBuilder: (context, index) {
                final rental = _loadResults[index];
                final imageUrl;
                if (rental['PhotoCount'] == 0)
                  imageUrl = null;
                else
                  imageUrl =
                      '${GetServer()}/uploads/rental/${rental['RentalID']}_1.jpg';
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
                        Container(
                          width: 100,
                          height: 100,
                          child: imageUrl != null
                              ? Image.network(
                                  imageUrl,
                                  width: 100,
                                  height: 100,
                                  fit: BoxFit.cover,
                                )
                              : Container(
                                  width: 100,
                                  height: 100,
                                  decoration: BoxDecoration(
                                    shape: BoxShape.rectangle,
                                    color: Colors.grey,
                                  ),
                                  child: Icon(
                                    Icons.person,
                                    size: 100,
                                    color: Colors.white,
                                  ),
                                ),
                        ),
                        Expanded(
                          child: Padding(
                            padding: const EdgeInsets.all(8.0),
                            child: Column(
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: [
                                Text(rental['Title'],
                                    style: TextStyle(
                                        fontSize: 18,
                                        fontWeight: FontWeight.bold)),
                                Text('${rental['Country']} ${rental['City']}'),
                                Text(
                                    'Бронь: с ${rental['DateRental']} до ${rental['DateEviction']}'),
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
            label: 'Головна',
          ),
          BottomNavigationBarItem(
            backgroundColor: Colors.black,
            icon: Icon(Icons.fmd_good_outlined),
            label: 'Уподобання',
          ),
          BottomNavigationBarItem(
            backgroundColor: Colors.black,
            icon: Icon(Icons.search),
            label: 'Пошук',
          ),
          BottomNavigationBarItem(
            backgroundColor: Colors.black,
            icon: Icon(Icons.account_circle),
            label: 'Профіль',
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
