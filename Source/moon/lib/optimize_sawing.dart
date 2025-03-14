import 'package:flutter/material.dart';

class OptimizeSawing extends StatefulWidget {
  const OptimizeSawing({super.key});

  @override
  State<OptimizeSawing> createState() => _OptimizeSawingState();
}

class _OptimizeSawingState extends State<OptimizeSawing> {
  TextStyle styleTitle = TextStyle(fontSize: 30);
  bool repetition = false;

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
                    onPressed: () {}, 
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
                  painter: Drawer(),
                  child: Container(
                    height: 600,
                    width: 580,
                  ),
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
    // TODO: implement paint
    final paint = Paint();
    paint.color = Colors.black;
    var a = Offset(size.width/2, size.height/2);
    canvas.drawCircle(a, 60, paint);
  }

  @override
  bool shouldRepaint(covariant CustomPainter oldDelegate) {
    // TODO: implement shouldRepaint
    // throw UnimplementedError();
    return false;
  }

}