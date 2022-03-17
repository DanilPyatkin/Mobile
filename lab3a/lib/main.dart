import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

void main() {
  runApp(MyApp());
}
class MyApp extends StatelessWidget{
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      theme: new ThemeData(
          appBarTheme: AppBarTheme(
            color: Colors.green,
          ),
          ),
      home: Scaffold(
      appBar: AppBar(
        title: Text('Общежития КУБГАУ')
      ),
        body:
            SingleChildScrollView(
        child:
            Column(
        children:[
          Row(
            children: [
              Expanded(child: Image(image:NetworkImage('https://sun9-25.userapi.com/impf/ceJ7Eq1oRHDwOYC47tt578irmZFwzF3CN35fug/bJj3P55PBgg.jpg?size=550x300&quality=96&sign=32b1b6ad992693ea00686335882bb167&type=album')),)

            ],
          ),
        Row(
          mainAxisAlignment:MainAxisAlignment.spaceBetween,
          children: [
            Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children:[
                Padding(
                  padding: EdgeInsets.only(top: 30, bottom:0, left:30, right:0),
                  child: Align(
                    alignment: Alignment.topCenter,
                    child: Text(
                        'Общежитие №20',
                        style: TextStyle(fontWeight: FontWeight.bold),
                        textDirection: TextDirection.ltr
                    ),
                  ),
                ),
                Padding(
                  padding: EdgeInsets.only(top: 3, bottom:30, left:30, right:0),
                  child: Align(
                    alignment: Alignment.topCenter,
                    child: Text(
                        'Краснодар, ул.Калинина, 13',
                        style: TextStyle(color:Colors.grey),
                        textDirection: TextDirection.ltr
                    ),
                  ),
                ),
            ],),
            Column(
              children: [
                Row(
                  children: [
                    Icon(Icons.favorite,color:Colors.red, size: 30,),
                    Padding(
                      padding: EdgeInsets.only(top: 30, bottom:30, left:0, right:25),
                      child: Align(
                        alignment: Alignment.topCenter,
                        child: Text(
                            '27',
                            textDirection: TextDirection.ltr
                        ),
                      ),
                    ),
                  ],
                ),
              ],
            ),
          ],
        ),
        Row(
          mainAxisAlignment: MainAxisAlignment.spaceAround ,
          children: [
            Column(
            children: [
              Icon(Icons.call, color: Colors.green,),
            TextButton(onPressed: () {}, child: Text('ПОЗВОНИТЬ',style: TextStyle(color: Colors.green),))
                    ],
                ),
              Column(
              children: [
                Icon(Icons.near_me, color: Colors.green,),
              TextButton(onPressed: () {}, child: Text('MAРШРУТ', style: TextStyle(color: Colors.green),))
          ],
              ),
          Column(
          children: [
            Icon(Icons.share, color: Colors.green,),
          TextButton(onPressed: () {}, child: Text('ПОДЕЛИТЬСЯ',style: TextStyle(color: Colors.green),))
          ],
            ),
          ],
        ),
              Column(
                children:[
                  Padding(
                    padding: EdgeInsets.only(top: 30, bottom:0, left:30, right:30),
                    child: Align(
                      alignment: Alignment.topCenter,
                      child: Expanded(
                        child: SingleChildScrollView(
                          scrollDirection: Axis.vertical,
                          child: Text(
                              'Студенческий городок или так называемый кампус Кубанского ГАУ состоит из двадцати общежитий, в которых проживает более 8000 студентов, что составляет 96% от всех нуждающихся. Студенты первого курса обеспечены местами в общежитии полностью. В соответствии с Положением о студенческих общежитиях университета, при поселении между администрацией и студентами заключается договор найма жилого помещения. Воспитательная работа в общежитиях направлена на улучшение быта, соблюдение правил внутреннего распорядка, отсутствия асоциальных явлений в молодежной среде. Условия проживания в общежитиях университетского кампуса полностью отвечают санитарным нормам и требованиям: наличие оборудованных кухонь, душевых комнат, прачечных, читальных залов, комнат самоподготовки, помещений для заседаний студенческих советов и наглядной агитации. С целью улучшения условий быта студентов активно работает система студенческого самоуправления - студенческие советы организуют всю работу по самообслуживанию.',
                              style: TextStyle(color:Colors.black),
                          ),
                        ),
                      ),
                    ),
                  ),
                ],)
        ],
      ),
      ),
      ),
    );
  }
}


