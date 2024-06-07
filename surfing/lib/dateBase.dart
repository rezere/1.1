import 'dart:convert';
import 'dart:io';
import 'package:file_picker/file_picker.dart';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'package:path_provider/path_provider.dart';
import 'package:path/path.dart';
import 'package:permission_handler/permission_handler.dart';
import 'package:surfing/serverInfo.dart';

Future<void> backupDatabase() async {
  try {
    // URL вашего PHP-скрипта на сервере
    final url = '${GetServer()}/getBD.php';

    // Отправляем запрос на создание дампа базы данных
    final response = await http.get(Uri.parse(url));

    if (response.statusCode == 200) {
      final data = json.decode(response.body);

      if (data['status'] == 'success') {
        // Получаем путь к созданному дампу базы данных
        final backupFile = data['file'];

        // Загружаем дамп базы данных с сервера
        final backupResponse =
            await http.get(Uri.parse('${GetServer()}/' + backupFile));

        if (backupResponse.statusCode == 200) {
          // Сохраняем дамп базы данных на устройство
          Directory documentsDirectory =
              await getApplicationDocumentsDirectory();
          String backupPath = join(documentsDirectory.path, backupFile);

          File file = File(backupPath);
          await file.writeAsBytes(backupResponse.bodyBytes);

          print('Database backup saved at $backupPath');
        } else {
          print('Failed to download database backup');
        }
      } else {
        print('Failed to create database backup: ${data['message']}');
        print('Error details: ${data['error']}');
        print('Command: ${data['command']}');
        print('Return var: ${data['return_var']}');
      }
    } else {
      print('Failed to create database backup');
    }
  } catch (e) {
    print('Error while creating database backup: $e');
  }
}
