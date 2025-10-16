
class Point{
  double x = 0;
  double y = 0;
  Point(double inputX, double inputY)
  {
    x = inputX;
    y = inputY;
  }
  void setCoordinates(double inputX, double inputY)
  {
    x = inputX;
    y = inputY;
  }
  (double, double) getCoordinates()
  {
    return (x,y);
  }
}

class Cut{
  Point a = Point(0,0);
  Point b = Point(0,0);
  Cut(Point inputA, Point inputB)
  {
    a = inputA;
    b = inputB;
  }
  (Point?, Point?) getCoordinates()
  {
    return (a,b);
  }
}

class Lumber{
  double width=0;
  double height=0;
  double length=0;
  Lumber(double inputWidth, double inputHeight, double inputLength)
  {
    width = inputWidth;
    height = inputHeight;
    length = inputLength;
  }
}