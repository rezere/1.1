import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:flutter_map/flutter_map.dart';
import 'package:latlong2/latlong.dart';
import 'package:http/http.dart' as http;
import 'package:surfing/home.dart';
import 'auth.dart';
import 'find.dart';

class MapPage extends StatefulWidget {
  @override
  _MapPage createState() => _MapPage();
}

class _MapPage extends State<MapPage> {
  final String apiKey =
      "AijrCN7Z38en6zUT31gTgEFQUjsx_FbcgrEGSdEnFcK48Wq5yo03uVxbjkqva-W4";

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: Scaffold(
        appBar: AppBar(
          title: Text('Карта'),
          backgroundColor: Color.fromARGB(255, 96, 150, 180),
          centerTitle: true,
        ),
        body: FlutterMap(
          options: MapOptions(
            center: LatLng(40.7128, -74.0060), // Пример координат: Нью-Йорк
            zoom: 10.0,
          ),
          children: <Widget>[
            BingMapsTileLayer(
              apiKey: apiKey,
              imagerySet: BingMapsImagerySet.road, // Или любой другой тип карты
            ),
          ],
        ),
        bottomNavigationBar: BottomNavigationBar(
          backgroundColor: Colors.black,
          currentIndex: 1,
          onTap: (index) {
            switch (index) {
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
                  //runApp(Profile(userEmail: email!));
                }
            }
          },
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
      ),
    );
  }
}

enum BingMapsImagerySet {
  road('RoadOnDemand', zoomBounds: (min: 0, max: 21)),
  aerial('Aerial', zoomBounds: (min: 0, max: 20)),
  aerialLabels('AerialWithLabelsOnDemand', zoomBounds: (min: 0, max: 20)),
  canvasDark('CanvasDark', zoomBounds: (min: 0, max: 21)),
  canvasLight('CanvasLight', zoomBounds: (min: 0, max: 21)),
  canvasGray('CanvasGray', zoomBounds: (min: 0, max: 21)),
  ordnanceSurvey('OrdnanceSurvey', zoomBounds: (min: 12, max: 17));

  final String urlValue;
  final ({int min, int max}) zoomBounds;

  const BingMapsImagerySet(this.urlValue, {required this.zoomBounds});
}

// Custom tile provider that contains the quadkeys logic
// Note that you can also extend from the CancellableNetworkTileProvider
class BingMapsTileProvider extends NetworkTileProvider {
  BingMapsTileProvider({super.headers});

  String _getQuadKey(int x, int y, int z) {
    final quadKey = StringBuffer();
    for (int i = z; i > 0; i--) {
      int digit = 0;
      final int mask = 1 << (i - 1);
      if ((x & mask) != 0) digit++;
      if ((y & mask) != 0) digit += 2;
      quadKey.write(digit);
    }
    return quadKey.toString();
  }

  @override
  Map<String, String> generateReplacementMap(
    String urlTemplate,
    TileCoordinates coordinates,
    TileLayer options,
  ) =>
      super.generateReplacementMap(urlTemplate, coordinates, options)
        ..addAll(
          {
            'culture': 'en-GB', // Or your culture value of choice
            'subdomain': options.subdomains[
                (coordinates.x + coordinates.y) % options.subdomains.length],
            'quadkey': _getQuadKey(coordinates.x, coordinates.y, coordinates.z),
          },
        );
}

// Custom `TileLayer` wrapper that can be inserted into a `FlutterMap`
class BingMapsTileLayer extends StatelessWidget {
  const BingMapsTileLayer({
    super.key,
    required this.apiKey,
    required this.imagerySet,
  });

  final String apiKey;
  final BingMapsImagerySet imagerySet;

  @override
  Widget build(BuildContext context) {
    return FutureBuilder(
      future: http.get(
        Uri.parse(
          'http://dev.virtualearth.net/REST/V1/Imagery/Metadata/${imagerySet.urlValue}?output=json&include=ImageryProviders&key=$apiKey',
        ),
      ),
      builder: (context, response) {
        if (response.data == null) return const Placeholder();

        return TileLayer(
          urlTemplate: (((((jsonDecode(response.data!.body)
                          as Map<String, dynamic>)['resourceSets']
                      as List<dynamic>)[0] as Map<String, dynamic>)['resources']
                  as List<dynamic>)[0] as Map<String, dynamic>)['imageUrl']
              as String,
          tileProvider: BingMapsTileProvider(),
          subdomains: const ['t0', 't1', 't2', 't3'],
          minNativeZoom: imagerySet.zoomBounds.min,
          maxNativeZoom: imagerySet.zoomBounds.max,
        );
      },
    );
  }
}
