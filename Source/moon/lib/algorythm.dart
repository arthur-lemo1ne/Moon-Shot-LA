import 'dart:math';

import 'package:moon/types.dart';


class Algorythm {
  static (List<Cut>, double?) simpleAlgorythm((double?,double) canvasSize, double logSize, Lumber lumber, double discoveryHeight){
    
    final output = <Cut>[];
    double diameter = (canvasSize.$2*0.7);

    double currentY = -(diameter/2);

    do {
      currentY += discoveryHeight;

      double x1 = sqrt(pow((diameter / 2), 2) - pow(currentY, 2));
      double x2 = -sqrt(pow((diameter / 2), 2) - pow(currentY, 2));

      Point p1 = Point(x1+canvasSize.$1!/2, currentY+canvasSize.$2/2);
      Point p2 = Point(x2+canvasSize.$1!/2, currentY+canvasSize.$2/2);
      
      output.add(Cut(p1,p2));
      
    } while(currentY < -((diameter *0.7)/2));


    return (output,canvasSize.$1);
  }
}