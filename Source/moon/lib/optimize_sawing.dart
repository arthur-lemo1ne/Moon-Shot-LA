import 'dart:ui';

import 'package:flutter/material.dart';

class OptimizeSawing extends StatefulWidget {
  const OptimizeSawing({super.key});

  @override
  State<OptimizeSawing> createState() => _OptimizeSawingState();
}

class _OptimizeSawingState extends State<OptimizeSawing> {
  TextStyle styleTitle = TextStyle(fontSize: 30);
  bool repetition = false;
  Size drawsize = Size(500,500);

  @override
  Widget build(BuildContext context){
    return Row(
        children: [
          Expanded(
            flex: 2,
            child: Container(
              color: Theme.of(context).colorScheme.surfaceDim,
              child: Column(
                mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                children: [
                  Text(
                    "Log Size", 
                    style: styleTitle,
                  ),
                  TextField(
                    textAlign: TextAlign.center,
                  ),
                  Text(
                    "Wanted Lumber",
                    style: styleTitle,
                  ),
                  TextField(
                    textAlign: TextAlign.center,
                  ),
                  TextField(
                    textAlign: TextAlign.center,
                  ),
                  Row(
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: [
                      Checkbox(value: repetition, onChanged: (value) {
                        setState(() {
                          repetition = value!;
                        });
                      }),
                      Text(
                        "Repetition"
                      )
                    ],
                  ),
                  Text(
                    "Discovery Plank",
                    style: styleTitle,
                  ),
                  TextField(
                    textAlign: TextAlign.center,
                  ),
                  ElevatedButton(
                    onPressed: () {
                      setState(() {
                        drawsize = Size(0,MediaQuery.sizeOf(context).height);
                      });
                    }, 
                    child: Text("Launch"),
                  ),
                ],
              ),
            ),
          ),
          Expanded(
            flex: 8,
            child: Container(
              color: Theme.of(context).colorScheme.primaryContainer,
              child: SingleChildScrollView(
                child: CustomPaint(
                  size: drawsize,
                  painter: Drawer(),
                ),
              ),
            ),
          ),
        ],
      );
  }
}

class Drawer extends CustomPainter{
  @override
  void paint(Canvas canvas, Size size) {
    final paint = Paint();
    paint.color = Colors.black;
    paint.style = PaintingStyle.stroke;
    paint.strokeWidth = 5;
    var a = Offset(size.width/2, size.height/2);
    canvas.drawCircle(a, (size.height/2)*0.7, paint);
    canvas.drawRect(Rect.fromCenter(center: a, width: size.width, height: size.height), paint);
  }

  @override
  bool shouldRepaint(covariant CustomPainter oldDelegate) => true;
    
}