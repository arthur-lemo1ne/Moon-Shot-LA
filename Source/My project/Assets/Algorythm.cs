/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using classes;
using TMPro;


public class Algorythm : MonoBehaviour
{

    public GameObject Cut;
    public float diameter = 650;

    public TMP_InputField input;

    private float CurrentZeroX;
    private float CurrentZeroY;

    public Lumber WantedLumber ;

    public Lumber[] AdditionalLumber = new Lumber[4];

    public float Width = 27;
    public float Height = 40;
    public LumberClass classe = LumberClass.RAFTERS;
    


    // Start is called before the first frame update
    void Start()
    {
        AdditionalLumber[0] = new Lumber(170, 70, LumberClass.PURLIN);
        AdditionalLumber[1] = new Lumber(80, 70, LumberClass.RAFTERS);
        AdditionalLumber[2] = new Lumber(150, 18, LumberClass.RAFTERS);
        AdditionalLumber[3] = new Lumber(27, 40, LumberClass.RAFTERS);

        WantedLumber = new(Width, Height, classe);
        
        var X1 = Side1(diameter);

        List<Line> cuts = X1.Item1;
        CurrentZeroY = X1.Item2;

        var X2 = Side2(diameter, CurrentZeroY);
        List<Line> cuts2 = X2.Item1;
        CurrentZeroX = X2.Item2;

        List<Line> cuts3  = Side3_4(-diameter, CurrentZeroY, CurrentZeroX, WantedLumber, AdditionalLumber);

        GameObject a;

        float x;
        float y;
        foreach (Line li in cuts)
        {
            a = Instantiate(Cut);
            a.tag = "SawCut";
            LineRenderer LR = a.GetComponent<LineRenderer>();
            x = li.po1.Getx();
            y = li.po1.Gety();
            LR.SetPosition(0, new Vector2(x/100,y/100));
            x = li.po2.Getx();
            y = li.po2.Gety();
            LR.SetPosition(1, new Vector2(x/100,y/100));
        }
        foreach (Line li in cuts2)
        {
            a = Instantiate(Cut);
            a.tag = "SawCut";
            LineRenderer LR = a.GetComponent<LineRenderer>();
            x = li.po1.Getx();
            y = li.po1.Gety();
            LR.SetPosition(0, new Vector2(x/100,y/100));
            x = li.po2.Getx();
            y = li.po2.Gety();
            LR.SetPosition(1, new Vector2(x/100,y/100));
        }
        foreach (Line li in cuts3)
        {
            a = Instantiate(Cut);
            a.tag = "SawCut";
            LineRenderer LR = a.GetComponent<LineRenderer>();
            x = li.po1.Getx();
            y = li.po1.Gety();
            LR.SetPosition(0, new Vector2(x/100,y/100));
            x = li.po2.Getx();
            y = li.po2.Gety();
            LR.SetPosition(1, new Vector2(x/100,y/100));
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Button_click(){


        foreach(GameObject cut in GameObject.FindGameObjectsWithTag("SawCut"))
        {
            Destroy(cut);
        }
        
        WantedLumber = new(Width, Height, classe);


        diameter = float.Parse(input.text);
        //diameter = diameter * 100 * 2;

        var X1 = Side1(diameter);

        List<Line> cuts = X1.Item1;
        CurrentZeroY = X1.Item2;

        var X2 = Side2(diameter, CurrentZeroY);
        List<Line> cuts2 = X2.Item1;
        CurrentZeroX = X2.Item2;

        List<Line> cuts3 = Side3_4(-diameter, CurrentZeroY, CurrentZeroX, WantedLumber, AdditionalLumber);
        
        GameObject a;
        
        float x;
        float y;
        foreach (Line li in cuts)
        {
            a = Instantiate(Cut);
            a.tag = "SawCut";
            LineRenderer LR = a.GetComponent<LineRenderer>();
            x = li.po1.Getx();
            y = li.po1.Gety();
            LR.SetPosition(0, new Vector2(x/100,y/100));
            x = li.po2.Getx();
            y = li.po2.Gety();
            LR.SetPosition(1, new Vector2(x/100,y/100));
        }
        foreach (Line li in cuts2)
        {
            a = Instantiate(Cut);
            a.tag = "SawCut";
            LineRenderer LR = a.GetComponent<LineRenderer>();
            x = li.po1.Getx();
            y = li.po1.Gety();
            LR.SetPosition(0, new Vector2(x/100,y/100));
            x = li.po2.Getx();
            y = li.po2.Gety();
            LR.SetPosition(1, new Vector2(x/100,y/100));
        }
        foreach (Line li in cuts3)
        {
            a = Instantiate(Cut);
            a.tag = "SawCut";
            LineRenderer LR = a.GetComponent<LineRenderer>();
            x = li.po1.Getx();
            y = li.po1.Gety();
            LR.SetPosition(0, new Vector2(x/100,y/100));
            x = li.po2.Getx();
            y = li.po2.Gety();
            LR.SetPosition(1, new Vector2(x/100,y/100));
        }
        

    }


    (List<Line>, float) Side1(float h)
    {
        List<Line> output = new List<Line>();

        int count = 0;
        float y = h / 2;
        float lastCutHight;
        do
        {

            y -= 25; // Value to change in the future

            lastCutHight = y;

            float x1 = Mathf.Round(Mathf.Sqrt(Mathf.Pow(((float)h / 2), 2) - Mathf.Pow((float)y, 2)));
            float x2 = Mathf.Round(-Mathf.Sqrt(Mathf.Pow(((float)h  / 2), 2) - Mathf.Pow((float)y, 2)));

            Point p1 = new(x1, y);
            Point p2 = new(x2, y);
            Line c = new(p1, p2, count);
            count++;
            output.Add(c);

        } while (y > ((h * 0.7) / 2));

        return (output, lastCutHight);
    }


    (List<Line>, float) Side2(float h, float lastCutHight)
    {

        List<Line> output = new List<Line>();

        int count = 0;
        float x = h / 2;
        float LastCutWidth;

        do
        {

            x -= 25; // Value to change in the future
            LastCutWidth = x;

            float y1;

            if(Mathf.Round(Mathf.Sqrt(Mathf.Pow(((float)h / 2), 2) - Mathf.Pow((float)x, 2))) > lastCutHight)
            {
                y1 = lastCutHight;
            }
            else
            {
                y1 = Mathf.Round(Mathf.Sqrt(Mathf.Pow(((float)h / 2), 2) - Mathf.Pow((float)x, 2)));
            }

            float y2 = Mathf.Round(-Mathf.Sqrt(Mathf.Pow(((float)h / 2), 2) - Mathf.Pow((float)x, 2)));

            Point p1 = new(x, y1);
            Point p2 = new(x, y2);
            Line c = new(p1, p2, count);
            count++;
            output.Add(c);

        } while (x > (h * 0.7) / 2);


        return (output, LastCutWidth);

    }

    List<Line> Side3_4(float h, float czy, float czx, Lumber WL, Lumber[] AL)
    {
        List<Line> output = new List<Line>();

        Lumber Secondary = null;

        float RemainingHight = Mathf.Sqrt(Mathf.Pow((float)(czy - (h/2)), 2));
        float RemainingWidth = Mathf.Sqrt(Mathf.Pow((float)(czx - (h / 2)), 2));
        float currentX = CurrentZeroX;
        float currentY = CurrentZeroY;

        int count;

        float diff = 0;
        float savedDiff = 100;
        LumberClass cl = LumberClass.BEAM;

        switch(cl){
            case LumberClass.BEAM:
                RemainingHight = Mathf.Sqrt(Mathf.Pow((float)(czy - Mathf.Round(-Mathf.Sqrt(Mathf.Pow(((float)h / 2), 2) - Mathf.Pow((float)czx, 2)))), 2));
                int numberOfBeams = (int)(RemainingHight / WantedLumber.GetHeight());
                foreach (Lumber lumber in AL)
                {
                    diff = (RemainingHight - (WL.GetHeight() * numberOfBeams)) % lumber.GetHeight();
                    if (diff < savedDiff )
                    {
                        savedDiff = diff;
                        Secondary = lumber;
                    }
                }
                count = 0;
                for(int i = 0; i < numberOfBeams ; i++)
                {
                    currentY -= WantedLumber.GetHeight();
                    float x1 = Mathf.Round(Mathf.Sqrt(Mathf.Pow(((float)h / 2), 2) - Mathf.Pow((float)currentY, 2)));
                    float x2 = Mathf.Round(-Mathf.Sqrt(Mathf.Pow(((float)h / 2), 2) - Mathf.Pow((float)currentY, 2)));
                    if(x1 > CurrentZeroX){
                        x1 = CurrentZeroX;
                    }
                    Point p1 = new Point(x1, currentY);
                    Point p2 = new Point(x2, currentY);
                    Line l = new Line(p1, p2, count);
                    count ++;
                    output.Add(l);
                }
                int numberOfSecondary = (int)((Mathf.Sqrt(Mathf.Pow((float)(currentY - (h / 2)), 2)))/ Secondary.GetHeight());
                float maxHeightS = currentY - numberOfSecondary*Secondary.GetHeight();
                while(currentY > maxHeightS)
                {
                    currentY -= Secondary.GetHeight();
                    float x1 = Mathf.Round(Mathf.Sqrt(Mathf.Pow(((float)h / 2), 2) - Mathf.Pow((float)currentY, 2)));
                    float x2 = Mathf.Round(-Mathf.Sqrt(Mathf.Pow(((float)h / 2), 2) - Mathf.Pow((float)currentY, 2)));
                    if(x1 > CurrentZeroX){
                        x1 = CurrentZeroX;
                    }
                    Point p1 = new Point(x1, currentY);
                    Point p2 = new Point(x2, currentY);
                    Line l = new Line(p1, p2, count);
                    count ++;
                    output.Add(l);
                }

                RemainingHight = Mathf.Sqrt(Mathf.Pow((float)(czx - Mathf.Round(-Mathf.Sqrt(Mathf.Pow(((float)h / 2), 2) - Mathf.Pow((float)czy, 2)))), 2));
                numberOfBeams = (int)(RemainingHight / WantedLumber.GetHeight());
                foreach (Lumber lumber in AL)
                {
                    diff = (RemainingHight - (WL.GetWidth() * numberOfBeams)) % lumber.GetWidth();
                    if (diff < savedDiff )
                    {
                        savedDiff = diff;
                        Secondary = lumber;
                    }
                }

                count = 0;
                for(int i = 0; i < numberOfBeams ; i++)
                {
                    currentX -= WantedLumber.GetWidth();
                    float y1 = Mathf.Round(Mathf.Sqrt(Mathf.Pow(((float)h / 2), 2) - Mathf.Pow((float)currentX, 2)));
                    float y2 = Mathf.Round(-Mathf.Sqrt(Mathf.Pow(((float)h / 2), 2) - Mathf.Pow((float)currentX, 2)));
                    if(y1 > CurrentZeroY){
                        y1 = CurrentZeroY;
                    }
                    Point p1 = new Point(currentX, y1);
                    Point p2 = new Point(currentX, y2);
                    Line l = new Line(p1, p2, count);
                    count ++;
                    output.Add(l);
                }


                numberOfSecondary = (int)((Mathf.Sqrt(Mathf.Pow((float)(currentX - (h / 2)), 2)))/ Secondary.GetWidth());
                maxHeightS = currentX - numberOfSecondary*Secondary.GetWidth();
                while(currentX > maxHeightS)
                {
                    currentX -= Secondary.GetWidth();
                    float y1 = Mathf.Round(Mathf.Sqrt(Mathf.Pow(((float)h / 2), 2) - Mathf.Pow((float)currentX, 2)));
                    float y2 = Mathf.Round(-Mathf.Sqrt(Mathf.Pow(((float)h / 2), 2) - Mathf.Pow((float)currentX, 2)));
                    if(y1 > CurrentZeroX){
                        y1 = CurrentZeroX;
                    }
                    Point p1 = new Point(currentX, y1);
                    Point p2 = new Point(currentX, y2);
                    Line l = new Line(p1, p2, count);
                    count ++;
                    output.Add(l);
                }

                break;
            case LumberClass.PURLIN:
                break;
            case LumberClass.RAFTERS:
                int numberOfRafters = (int)(RemainingHight / WantedLumber.GetHeight());
                float maxHeight = CurrentZeroY - numberOfRafters*WantedLumber.GetHeight();
                count = 0;
                while (currentY > maxHeight)
                {
                    currentY -= WantedLumber.GetHeight();
                    float x1 = Mathf.Round(Mathf.Sqrt(Mathf.Pow(((float)h / 2), 2) - Mathf.Pow((float)currentY, 2)));
                    float x2 = Mathf.Round(-Mathf.Sqrt(Mathf.Pow(((float)h / 2), 2) - Mathf.Pow((float)currentY, 2)));
                    if(x1 > CurrentZeroX){
                        x1 = CurrentZeroX;
                    }
                    Point p1 = new Point(x1, currentY);
                    Point p2 = new Point(x2, currentY);
                    Line l = new Line(p1, p2, count);
                    count ++;
                    output.Add(l);
                }
                numberOfRafters = (int)(RemainingWidth / WantedLumber.GetWidth());
                maxHeight = CurrentZeroX - numberOfRafters*WantedLumber.GetWidth();
                while(currentX > maxHeight)
                {
                    currentX -= WantedLumber.GetWidth();
                    float y1 = Mathf.Round(Mathf.Sqrt(Mathf.Pow(((float)h/2), 2) - Mathf.Pow((float)currentX, 2)));
                    float y2 = Mathf.Round(-Mathf.Sqrt(Mathf.Pow(((float)h/2), 2) - Mathf.Pow((float)currentX, 2)));
                    if(y1 > CurrentZeroY){
                        y1 = CurrentZeroY;
                    }
                    Point p1 = new Point(currentX, y1);
                    Point p2 = new Point(currentX, y2);
                    Line l = new Line(p1, p2, count);
                    count ++;
                    output.Add(l);
                }
                break;
            default:
                break;
        }

        

        if (Secondary != null)
        {
            //Debug.Log(Secondary.GetHeight());
            //Console.WriteLine("Lumber : {0}x{1}", Secondary.GetWidth(), Secondary.GetHeight());
            //Console.WriteLine("Number : {0}", Math.Floor((RemainingHight - WL.GetHeight()) / Secondary.GetHeight()));
            //Console.WriteLine("Looses : {0} mm", (RemainingHight - WL.GetHeight()) % Secondary.GetHeight());
        }

        return output;
    }
}


/*namespace classes
{

    public enum LumberClass{
        BEAM,
        PURLIN,
        RAFTERS,
    }
    public class Lumber
    {
        private float width;
        private float height;
        private LumberClass lclass;

        public Lumber(float xwidth, float xheight, LumberClass xlclass)
        {
            width = xwidth;
            height = xheight;
            lclass = xlclass;
        }
        public float GetWidth()
        {
            return width;
        }
        public float GetHeight()
        {
            return height;
        }
        public LumberClass GetClass(){
            return lclass;
        }
    }

    public class Point
    {
        private float x;
        private float y;

        public Point(float xx, float xy)
        {
            x = xx;
            y = xy;
        }
        public float Getx()
        {
            return x;
        }
        public float Gety()
        {
            return y;
        }
    }

    public class Line
    {
        public int id;
        public Point po1;
        public Point po2;

        public Line(Point poo1, Point poo2, int xid)
        {
            po1 = poo1;
            po2 = poo2;
            id = xid;
        }

        public int GetID()
        {
            return id;
        }

        public (Point, Point) GetPosition()
        {
            return (po1, po2);
        }

        public void display()
        {
            //Console.WriteLine("--- Line : {0} ---", id);
            //Console.WriteLine("point 1 : ({0} , {1})", po1.Getx(), po1.Gety());
            //Console.WriteLine("point 2 : ({0} , {1})", po2.Getx(), po2.Gety());
            //Console.WriteLine("------------");
        }
    }
}*/


