import 'package:flutter/services.dart';
import 'package:moon/algorythm.dart';
import 'package:flutter/material.dart';
import 'package:moon/types.dart';

class OptimizeSawing extends StatefulWidget {
  const OptimizeSawing({super.key});


  @override
  State<OptimizeSawing> createState() => _OptimizeSawingState();
}

class _OptimizeSawingState extends State<OptimizeSawing> {

  final GlobalKey key = GlobalKey();

  // UI
  TextStyle styleTitle = TextStyle(fontSize: 30);
  Size drawsize = Size(500,500);

  // Inputs
  bool repetition = false;
  double logSize = 0.0;
  double? si;
  double discoveryHeight = 0;


  // Outputs
  List<Cut> sawCuts = List.empty();

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
                    inputFormatters: <TextInputFormatter>[
                      FilteringTextInputFormatter.digitsOnly
                    ],
                    onChanged: (text) {
                      if(text == '')
                      {
                        logSize = 0;
                      }
                      else
                      {
                        logSize = double.parse(text);
                      }
                    },
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
                      Checkbox(
                        value: repetition, 
                        onChanged: (value) {
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
                    inputFormatters: <TextInputFormatter>[
                      FilteringTextInputFormatter.digitsOnly
                    ],
                    onChanged: (value) {
                    if(value !='')
                      {
                        discoveryHeight = double.parse(value);
                      }                    
                    },
                  ),
                  ElevatedButton(
                    onPressed: () {
                      setState(() {
                        print(discoveryHeight);
                        drawsize = Size(MediaQuery.sizeOf(context).width,MediaQuery.sizeOf(context).height);
                        var re = Algorythm.simpleAlgorythm((key.currentContext?.size?.width, drawsize.height) , logSize, Lumber(150,18,200), discoveryHeight);
                        sawCuts = re.$1;
                        si = re.$2;
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
                  key: key,
                  size: drawsize,
                  painter: Drawer(sawCuts, si),
                ),
              ),
            ),
          ),
        ],
      );
  }
}

class Drawer extends CustomPainter{

  Drawer(List<Cut> input, double? circle){
    sawCuts = input;
    if(circle != null)
    {
      drawSawCut = circle;
    }
  }
  double? drawSawCut = 0;
  List<Cut> sawCuts = List.empty();
  @override
  void paint(Canvas canvas, Size size) {
    final paint = Paint();
    paint.color = Colors.black;
    paint.style = PaintingStyle.stroke;
    paint.strokeWidth = 4;
    Offset a;
    if(drawSawCut == 0)
    {
      a = Offset(size.width/2, size.height/2);
    }
    else
    {
      a = Offset(drawSawCut!/2, size.height/2);
    }
    canvas.drawCircle(a, (size.height/2)*0.7, paint);
    //canvas.drawRect(Rect.fromCenter(center: a, width: size.width, height: size.height), paint);
    
      for(int i = 0; i < sawCuts.length; i++)
      {
        canvas.drawLine(Offset(sawCuts[i].a.x, sawCuts[i].a.y), Offset(sawCuts[i].b.x, sawCuts[i].b.y), paint);
      }

  }

  @override
  bool shouldRepaint(covariant CustomPainter oldDelegate) => true;
}