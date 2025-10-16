import 'package:moon/algorythms.dart';
import 'package:flutter/material.dart';
import 'package:moon/algorythms_inputs.dart';
import 'package:moon/types.dart';

class OptimizeSawing extends StatefulWidget {
  const OptimizeSawing({super.key});

  @override
  State<OptimizeSawing> createState() => _OptimizeSawingState();
}

class _OptimizeSawingState extends State<OptimizeSawing> {

  getInputs(double ilogsize, double idiscoverysize)
  {
    logSize = ilogsize;
    discoveryHeight = idiscoverysize;
  }

  getInputsP(double ilogsize, double idiscoverysize, double iWidth, double iHeight)
  {
    logSize = ilogsize;
    discoveryHeight = idiscoverysize;
    wanted.width = iWidth;
    wanted.height = iHeight;
  }


  final GlobalKey key = GlobalKey();

  // Algorythms
  List<DropdownMenuItem<String>> sawTypes = [];
  String? def;
  setTypes()
  {
    sawTypes.clear();
    sawTypes.add(DropdownMenuItem(value: "Live Sawing",child: Text("Live Sawing")));
    sawTypes.add(DropdownMenuItem(value: "Plain Sawing",child: Text("Plain Sawing")));
    // url to keep : https://veneerhub.com/log-wood-sawing-skills/
  }

  // UI
  TextStyle styleTitle = TextStyle(fontSize: 30);
  Size drawsize = Size(500,500);

  // Inputs
  bool repetition = false;
  double logSize = 0.0;
  double? si;
  double discoveryHeight = 0;
  Lumber wanted = Lumber(0,0,0);


  // Outputs
  List<Cut> sawCuts = List.empty();
  int currentCutIndex = 0;

  @override
  Widget build(BuildContext context){
    setTypes();
    Widget sawing;
    switch (def) {
      case null:
        sawing = Placeholder();
        break;
      case "Live Sawing":
        sawing = SawingInputsLive(getInputs);
        break;
      case "Plain Sawing":
        sawing = SawingInputsPlain(getInputsP);
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
                    items: sawTypes, 
                    onChanged: (value) 
                    {
                      def = value;
                      setState(() {});
                    },
                    hint: Text("Sawing type"),
                  ),
                  sawing,
                  ElevatedButton(
                    onPressed: () {
                      setState(() {
                        drawsize = Size(MediaQuery.sizeOf(context).width,MediaQuery.sizeOf(context).height);
                        (List<Cut>, double?) re;
                        if(logSize != 0 && discoveryHeight != 0)
                        {
                          currentCutIndex = 0;
                          switch (def) {
                            case "Live Sawing":
                              re = Algorythm.liveAlgorythm((key.currentContext?.size?.width, drawsize.height) , logSize, discoveryHeight);
                              sawCuts = re.$1;
                              si = re.$2;
                              break;
                            case "Plain Sawing":
                              re = Algorythm.plainAlgorythm((key.currentContext?.size?.width, drawsize.height) , logSize, wanted, discoveryHeight);
                              sawCuts = re.$1;
                              si = re.$2;
                              break;
                            default:
                              break;
                          }
                        }
                      });
                    }, 
                    child: Text("Launch"),
                  ),
                  Row(
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: [
                      IconButton(onPressed: (){
                        setState(() {
                            currentCutIndex = 0;
                        });}, icon: const Icon(Icons.fast_rewind)),
                      IconButton(onPressed: (){
                        setState(() {
                          if(currentCutIndex > 0)
                          {
                            currentCutIndex --;
                          }
                        });}, icon: const Icon(Icons.skip_previous)),
                      IconButton(onPressed: (){setState(() {
                          if(sawCuts.length > currentCutIndex)
                          {
                            currentCutIndex ++;
                          }
                        });}, icon: const Icon(Icons.skip_next)),
                      IconButton(onPressed: (){setState(() {
                          if(sawCuts.length != currentCutIndex)
                          {
                            currentCutIndex = sawCuts.length;
                          }
                        });}, icon: const Icon(Icons.fast_forward)),
                    ],
                  ),
                  Text(currentCutIndex.toString()),
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
                  painter: Drawer(sawCuts, si, currentCutIndex, logSize),
                ),
              ),
            ),
          ),
        ],
      );
  }
}

class Drawer extends CustomPainter{
  Drawer(List<Cut> input, double? circle, int currentCutIndex, double InLogS){
    sawCuts = input;
    LogS = InLogS;
    currentIndex = currentCutIndex;
    if(circle != null)
    {
      drawSawCut = circle;
    }
  }
  double LogS = 0;
  double? drawSawCut = 0;
  List<Cut> sawCuts = List.empty();
  int currentIndex = 0;
  @override
  void paint(Canvas canvas, Size size) {
    //Parameters
    final paint = Paint();
    paint.color = Colors.black;
    paint.style = PaintingStyle.stroke;
    paint.strokeWidth = 4;

    final paintR = Paint();
    paintR.color = Colors.red;
    paintR.style = PaintingStyle.stroke;
    paintR.strokeWidth = 4;

    Offset a;

    const textStyle = TextStyle(
      color: Colors.black,
      fontSize: 20,
    );


    //Log
    if(drawSawCut == 0)
    {
      a = Offset(size.width/2, size.height/2);
    }
    else
    {
      a = Offset(drawSawCut!/2, size.height/2);
    }
    

    //sawcuts
    for(int i = 0; i < currentIndex; i++)
    {
      if(i == currentIndex-1)
      {
        canvas.drawLine(Offset(sawCuts[i].a.x, sawCuts[i].a.y), Offset(sawCuts[i].b.x, sawCuts[i].b.y), paintR);
      }
      else
      {
        canvas.drawLine(Offset(sawCuts[i].a.x, sawCuts[i].a.y), Offset(sawCuts[i].b.x, sawCuts[i].b.y), paint);
      }
      var scale = (size.height*0.7) / LogS;
      var cutHeight = (size.height/2+((size.height/2)*0.7))-sawCuts[i].a.y ;//* scale;
      cutHeight /= scale;

      var textspan = TextSpan(
        text: cutHeight.round().toString() + " mm",
        style: textStyle,
      );
      var textPainter = TextPainter(
        text: textspan,
        textDirection: TextDirection.ltr,
      );
      textPainter.layout(
        minWidth: 0,
        maxWidth: size.width,
      );
      textPainter.paint(canvas, Offset(size.width*0.8, sawCuts[i].a.y-15));
    }

    canvas.drawCircle(a, (size.height/2)*0.7, paint);

  }

  @override
  bool shouldRepaint(covariant CustomPainter oldDelegate) => true;
}