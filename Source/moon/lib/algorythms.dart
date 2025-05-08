import 'dart:math';

import 'package:moon/types.dart';


class Algorythm {
  static (List<Cut>, double?) plainAlgorythm((double?,double) canvasSize, double logSize, Lumber lumber, double discoveryHeight){
    
    final output = <Cut>[];
    
    output.add(Cut(Point(canvasSize.$2/2 - canvasSize.$2/2*0.7,100),Point(0,0)));
    double diameter = logSize; // Represent (canvasSize.$2*0.7);
    double currentY = -(diameter/2);
    double currentX = diameter/2;
    //double currentY2 = (diameter/2);
    double scale =  (canvasSize.$2*0.7) / logSize;
    bool flag = false;

    //First Side
    do {
      currentY += discoveryHeight;

      double x1 = sqrt(pow((diameter / 2), 2) - pow(currentY, 2)) * scale;
      double x2 = -sqrt(pow((diameter / 2), 2) - pow(currentY, 2)) * scale;

      Point p1 = Point(x1+canvasSize.$1!/2, currentY * scale + canvasSize.$2/2);
      Point p2 = Point(x2+canvasSize.$1!/2, currentY * scale + canvasSize.$2/2);
      
      output.add(Cut(p1,p2));
      
    } while(currentY < -((diameter *0.7)/2));

    //Second Side
    do {
      
      currentX -= discoveryHeight;

      double y1, y2;

      if(currentX < sqrt(pow((diameter / 2), 2) - pow(currentY, 2)))
      {
        y1 = currentY*scale;
        y2 = sqrt(pow((diameter / 2), 2) - pow(currentX, 2)) * scale;
        flag = true;
      }
      else
      {
        y1 = sqrt(pow((diameter / 2), 2) - pow(currentX, 2)) * scale;
        y2 = -sqrt(pow((diameter / 2), 2) - pow(currentX, 2)) * scale;
      }

      Point p1 = Point(currentX*scale+canvasSize.$1!/2, y1+canvasSize.$2/2); 
      Point p2 = Point(currentX*scale+canvasSize.$1!/2, y2+canvasSize.$2/2); 

      output.add(Cut(p1,p2));

    } while (currentX > (diameter*0.7)/2 && !flag);

    //Third Side
    do {
      
    } while (false);

    return (output,canvasSize.$1);
  }

  static (List<Cut>, double?) liveAlgorythm((double?,double) canvasSize, double logSize, double slabThickness){
    final output = <Cut>[];
    double diameter = logSize; // Represent (canvasSize.$2*0.7);
    double currentY = -(diameter/2);
    double scale =  (canvasSize.$2*0.7) / logSize;

    do {
      currentY += slabThickness;

      double x1 = sqrt(pow((diameter / 2), 2) - pow(currentY, 2)) * scale;
      double x2 = -sqrt(pow((diameter / 2), 2) - pow(currentY, 2)) * scale;

      Point p1 = Point(x1+canvasSize.$1!/2, currentY * scale + canvasSize.$2/2);
      Point p2 = Point(x2+canvasSize.$1!/2, currentY * scale + canvasSize.$2/2);
      
      output.add(Cut(p1,p2));
      
    } while(currentY < diameter/2);

    return (output, canvasSize.$1);
  }
}