import 'package:flutter/material.dart';


void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({Key? key}) : super(key: key);

// This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Инкремент',
      theme: ThemeData(

        primarySwatch: Colors.pink,
      ),
      home: const MyHomePage(title: 'Инкремент'),
    );
  }
}

class MyHomePage extends StatefulWidget {
  const MyHomePage({Key? key, required this.title}) : super(key: key);

  final String title;

  @override
  State<MyHomePage> createState() => _MyHomePageState();
}

class _MyHomePageState extends State<MyHomePage> {
  int _counter = 0;

  void _incrementPlus() {
    setState(() {
      _counter++;
    });
  }

  void _incrementMinus() {
    setState(() {
      _counter--;
    });
  }

  void _incrementNul() {
    setState(() {
      _counter = 0;
    });
  }

  @override
  Widget build(BuildContext context) {

    return Scaffold(
      appBar: AppBar(
        title: Text(widget.title),
      ),
      body: Center(

        child: Column(

          mainAxisAlignment: MainAxisAlignment.center,
          children: <Widget>[
            const Text(
              'Значение',
              style: TextStyle(
                  color: Colors.pink,
                  fontSize: 23
              ),
            ),
            Text(
              '$_counter',
              style: TextStyle(
                  color: Colors.pink,
                  fontSize: 23
              ),

            ),
            Row(

                mainAxisAlignment: MainAxisAlignment.center,
                children: <Widget>[

                  Expanded(
                    child: Padding(
                      padding: const EdgeInsets.fromLTRB(190, 10, 10, 10),
                      child: ElevatedButton(
                          style: ElevatedButton.styleFrom(
                            primary: Colors.pink,
                          ),
                          onPressed: _incrementMinus,
                          child: const Text("-")
                      ),
                    ),
                  ),
                  Expanded(
                    child: Padding(
                      padding: const EdgeInsets.fromLTRB(10, 10, 190, 10),
                      child: ElevatedButton(
                          style: ElevatedButton.styleFrom(
                            primary: Colors.pink,
                          ),
                          onPressed: _incrementPlus,
                          child: const Text("+")
                      ),
                    ),
                  ),

                ]
            ),


            TextButton(
                onPressed: _incrementNul,
                child: const Text("Сбросить")
            )
          ],
        ),
      ),
    );
  }
}
