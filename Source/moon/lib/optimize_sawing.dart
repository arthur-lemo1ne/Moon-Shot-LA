import 'package:flutter/services.dart';
import 'package:moon/algorythms.dart';
import 'package:flutter/material.dart';
import 'package:moon/algorythmsInputs.dart';
import 'package:moon/types.dart';

class OptimizeSawing extends StatefulWidget {
  const OptimizeSawing({super.key});


  @override
  State<OptimizeSawing> createState() => _OptimizeSawingState();
}

class _OptimizeSawingState extends State<OptimizeSawing> {

  final GlobalKey key = GlobalKey();

  // Algorythms
  List<DropdownMenuItem<String>> SawTypes = [];
  String? def = null;
  SetTypes()
  {
    SawTypes.clear();
    SawTypes.add(DropdownMenuItem(value: "Live Sawing",child: Text("Live Sawing")));
    SawTypes.add(DropdownMenuItem(value: "Plain Sawing",child: Text("Plain Sawing")));
  }

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
    SetTypes();
    Widget sawing;
    switch (def) {
      case null:
        sawing = Placeholder();
        break;
      case "Live Sawing":
        sawing = Placeholder();
        break;
      case "Plain Sawing":
        sawing = SawingInputs();
        break;
      default:
        throw UnimplementedError('no widget for $def');
    }
    return Row(
        children: [
          Expanded(
            flex: 2,
            child: Container(
              color: Theme.of(context).colorScheme.surfaceDim,
              child: Column(
                mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                children: [
                  DropdownButton(
                    value: def,
                    items: SawTypes, 
                    onChanged: (value) 
                    {
                      def = value;
                      setState(() {
                        
                      });
                    },
                    hint: Text("here"),
                  ),
                  sawing,
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
                  Row(
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: [
                      IconButton(onPressed: (){}, icon: const Icon(Icons.fast_rewind)),
                      IconButton(onPressed: (){}, icon: const Icon(Icons.skip_previous)),
                      IconButton(onPressed: (){}, icon: const Icon(Icons.skip_next)),
                      IconButton(onPressed: (){}, icon: const Icon(Icons.fast_forward)),
                    ],
                  )
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