import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';
import 'account.dart';

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
        title: Text('Поиск пользователей'),
      ),
      body: Column(
        children: [
          Padding(
            padding: const EdgeInsets.all(8.0),
            child: TextField(
              controller: _controller,
              decoration: InputDecoration(
                border: OutlineInputBorder(),
                labelText: 'Поиск',
                suffixIcon: IconButton(
                  icon: Icon(Icons.search),
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
                            child: Image.network(
                              user['ProfilePicture'],
                              width: 50,
                              height: 50,
                              fit: BoxFit.cover,
                            ),
                          ),
                          SizedBox(width: 10),
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
    );
  }
}

class Profile extends StatelessWidget {
  final String userEmail;

  const Profile({Key? key, required this.userEmail}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    // Теперь вы можете использовать userEmail внутри MyApp для дальнейшей логики
    return MaterialApp(
      home: UserProfilePage(email: userEmail), // Пример использования
    );
  }
}
