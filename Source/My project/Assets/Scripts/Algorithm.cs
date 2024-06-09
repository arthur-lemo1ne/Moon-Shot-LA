using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

using classes;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Algorithm : MonoBehaviour
{
    // Related to the UI
    public GameObject cut;
    public PopUp popUp;
    public GameObject[] buttons;
    
    // Related to the log
    public TMP_InputField input_logSize;

    // Related to the Wanted Lumber
    public TMP_InputField input_Width;
    public TMP_InputField input_Height;
    public Toggle Repetition;
    private Lumber wantedLumber;

    // Related to additional Lumber

    public TMP_InputField input_Dicovery_height;
    public GameObject table_content;
    private List<Lumber> addLumber = new List<Lumber>();

    // Related to the Algorithm
    private float Current_Zero_X;
    private float Current_Zero_Y;


    // Related to display
    private Display display;

    // Start is called before the first frame update
    void Start()
    {
        display = GetComponent<Display>();
        foreach (GameObject o in buttons)
        {
            o.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void On_click()
    {

        // Make sure that all main parameters are correctly filled
        
        bool check;

        if(input_logSize.text != "")
        {
            check = true;
            if(input_Dicovery_height.text != "")
            {
                check = true;
                if(input_Height.text != "" && input_Width.text != "")
                {
                    check = true;

                    bool f = false;
                    foreach (Transform o in table_content.transform)
                    {
                        foreach (TMP_InputField i in o.GetComponentsInChildren<TMP_InputField>())
                        {
                            if(i.text == "")
                            {
                                check = false;
                                popUp.Inisialize(2);
                                f = true;
                                break;
                            }
                        }
                        if(f){break;}
                    }
                }
                else
                {
                    popUp.Inisialize(1);
                    check = false;
                }
            }
            else
            {
                popUp.Inisialize(3);
                check = false;
            }
        }
        else
        {
            popUp.Inisialize(0);
            check = false;
        }

        // NEED TO implement the additional lumber
        
        
        if(check)
        {
            addLumber.Clear();
            foreach (Transform o in table_content.transform)
            {
                TMP_InputField[] widthHeight = o.GetComponentInChildren<Transform>().GetComponentInChildren<Transform>().GetComponentsInChildren<TMP_InputField>();
                float width = 0, height = 0;
                foreach (TMP_InputField i in widthHeight)
                {
                    if(i.name == "Width")
                    {
                        width = float.Parse(i.text);
                    }
                    if(i.name == "Height")
                    {
                        height = float.Parse(i.text);
                    }
                }
                Lumber n = new Lumber(width, height);
                addLumber.Add(n);
            }

            // Make sure to clean the interface to be able to draw the new instructions
            display.clear();

            var first_side = Side1(math.abs(float.Parse(input_logSize.text)), math.abs(float.Parse(input_Dicovery_height.text)));

            var second_side = Side2(math.abs(float.Parse(input_logSize.text)), math.abs(float.Parse(input_Dicovery_height.text)), first_side.Item2);

            wantedLumber = new Lumber(math.abs(float.Parse(input_Width.text)), math.abs(float.Parse(input_Height.text)));

            var thirdSide = Side3_4(math.abs(float.Parse(input_logSize.text)), first_side.Item2, second_side.Item2.x, wantedLumber, addLumber, Repetition.isOn, second_side.Item2.y, math.abs(float.Parse(input_Dicovery_height.text)));

            GameObject a;
            
            float x;
            float y;
            foreach (Saw_cut li in first_side.Item1)
            {
                a = Instantiate(cut);
                a.tag = "SawCut";
                LineRenderer LR = a.GetComponent<LineRenderer>();
                x = li.GetC1().x;
                y = li.GetC1().y;
                LR.SetPosition(0, new Vector2(x/100,y/100));
                x = li.GetC2().x;
                y = li.GetC2().y;
                LR.SetPosition(1, new Vector2(x/100,y/100));
                LR.startWidth = math.abs(float.Parse(input_logSize.text)) * 0.000028f + 0.04f; // x*0.00008 + 0.27
                LR.endWidth = math.abs(float.Parse(input_logSize.text)) * 0.000028f + 0.04f; // 200 -> 0.05 || 2000 -> 0.1
            }
            foreach (Saw_cut li in second_side.Item1)
            {
                a = Instantiate(cut);
                a.tag = "SawCut";
                LineRenderer LR = a.GetComponent<LineRenderer>();
                x = li.GetC1().x;
                y = li.GetC1().y;
                LR.SetPosition(0, new Vector2(x/100,y/100));
                x = li.GetC2().x;
                y = li.GetC2().y;
                LR.SetPosition(1, new Vector2(x/100,y/100));
                LR.startWidth = math.abs(float.Parse(input_logSize.text)) * 0.000028f + 0.04f; // x*0.00008 + 0.27
                LR.endWidth = math.abs(float.Parse(input_logSize.text)) * 0.000028f + 0.04f; // 200 -> 0.05 || 2000 -> 0.1
            }
            foreach (Saw_cut li in thirdSide)
            {
                a = Instantiate(cut);
                a.tag = "SawCut";
                LineRenderer LR = a.GetComponent<LineRenderer>();
                x = li.GetC1().x;
                y = li.GetC1().y;
                LR.SetPosition(0, new Vector2(x/100,y/100));
                x = li.GetC2().x;
                y = li.GetC2().y;
                LR.SetPosition(1, new Vector2(x/100,y/100));
                LR.startWidth = math.abs(float.Parse(input_logSize.text)) * 0.000028f + 0.04f; // x*0.00008 + 0.27
                LR.endWidth = math.abs(float.Parse(input_logSize.text)) * 0.000028f + 0.04f; // 200 -> 0.05 || 2000 -> 0.1
            }
            display.Inisialize();   
            foreach (GameObject o in buttons)
            {
                o.SetActive(true);
            }
        }
    }

    // Calculate the first side of the sawing given the log's diameter and the wanted discovery plank's height
    (List<Saw_cut>,float) Side1(float dia, float discovery_height)
    {
        List<Saw_cut> output = new List<Saw_cut>();

        float currentY = dia/2;
        float lastCutHeight;

        do
        {
            currentY -= discovery_height;
            lastCutHeight = currentY;

            // Calculating the current X for the current Y on the circle of given diameter
            float x1 = Mathf.Round(Mathf.Sqrt(Mathf.Pow(((float)dia / 2), 2) - Mathf.Pow((float)currentY, 2)));
            float x2 = Mathf.Round(-Mathf.Sqrt(Mathf.Pow(((float)dia  / 2), 2) - Mathf.Pow((float)currentY, 2)));

            // Storing the values into to points and then in a line (or Saw_cut)
            Vector2 p1 = new Vector2(x1, currentY);
            Vector2 p2 = new Vector2(x2, currentY);
            Saw_cut cut = new Saw_cut(p1, p2);

            // Adding the Saw_cut to the output
            output.Add(cut);

        }while(currentY > ((dia * 0.7) / 2));

        return (output, lastCutHeight);
    

    }

    (List<Saw_cut>, Vector2) Side2(float dia, float discovery_height, float lastCutHeight)
    {

        List<Saw_cut> output = new List<Saw_cut>();

        float currentX = dia/2;
        float LastCutWidth;
        float LastPoint;

        bool flag = false;

        do
        {

            currentX -= discovery_height;
            LastCutWidth = currentX;

            float y1;

            if(Mathf.Round(Mathf.Sqrt(Mathf.Pow(((float)dia / 2), 2) - Mathf.Pow((float)currentX, 2))) > lastCutHeight)
            {
                y1 = lastCutHeight;
                flag = true;
            }
            else
            {
                y1 = Mathf.Round(Mathf.Sqrt(Mathf.Pow(((float)dia / 2), 2) - Mathf.Pow((float)currentX, 2)));
            }

            float y2 = Mathf.Round(-Mathf.Sqrt(Mathf.Pow(((float)dia / 2), 2) - Mathf.Pow((float)currentX, 2)));

            Vector2 p1 = new Vector2(currentX, y1);
            Vector2 p2 = new Vector2(currentX, y2);
            Saw_cut cut = new Saw_cut(p1, p2);
            LastPoint = p2.y;

            output.Add(cut);

        }while(currentX > (dia * 0.7) / 2 && !flag);

        return (output,new Vector2(LastCutWidth, LastPoint));

    }

    List<Saw_cut> Side3_4(float dia, float czy, float czx, Lumber wantedLumber, List<Lumber> addLumber, bool repetition, float lastp, float discovery_height)
    {
        List<Saw_cut> output = new List<Saw_cut>();

        if(repetition)
        {
            float RemainingHeight = Mathf.Sqrt(Mathf.Pow((float)(czy - (lastp)), 2));
            float RemainingWidth = Mathf.Sqrt(Mathf.Pow((float)(czx - (-dia / 2)), 2));
            float currentX;
            float maxHeight = czy;
            float firstCutHeight;

            int numberOfLumbers = (int)(RemainingHeight / wantedLumber.GetHeight());
            
            firstCutHeight = czy - numberOfLumbers*wantedLumber.GetHeight();
            float discorest = Mathf.Sqrt(Mathf.Pow((float)(firstCutHeight - (-dia / 2)), 2));
            int numberOfPlanks = (int)(discorest / discovery_height);
            float currentY = firstCutHeight - numberOfPlanks*discovery_height;

            while(currentY < firstCutHeight)
            {
                float x1 = Mathf.Round(Mathf.Sqrt(Mathf.Pow(((float)dia / 2), 2) - Mathf.Pow((float)currentY, 2)));
                float x2 = Mathf.Round(-Mathf.Sqrt(Mathf.Pow(((float)dia / 2), 2) - Mathf.Pow((float)currentY, 2)));
                if(x1 > czx){
                    x1 = czx;
                }
                Vector2 p1 = new Vector2(x1, currentY);
                Vector2 p2 = new Vector2(x2, currentY);
                Saw_cut l = new Saw_cut(p1, p2);
                output.Add(l);
                currentY += discovery_height;
            }
            
            
            while (currentY < maxHeight)
            {
                float x1 = Mathf.Round(Mathf.Sqrt(Mathf.Pow(((float)dia / 2), 2) - Mathf.Pow((float)currentY, 2)));
                float x2 = Mathf.Round(-Mathf.Sqrt(Mathf.Pow(((float)dia / 2), 2) - Mathf.Pow((float)currentY, 2)));
                if(x1 > czx){
                    x1 = czx;
                }
                Vector2 p1 = new Vector2(x1, currentY);
                Vector2 p2 = new Vector2(x2, currentY);
                Saw_cut l = new Saw_cut(p1, p2);
                output.Add(l);
                currentY += wantedLumber.GetHeight();
            }
            
            numberOfLumbers = (int)(RemainingWidth / wantedLumber.GetWidth());
            currentX = czx - numberOfLumbers*wantedLumber.GetWidth();
            maxHeight = czx;
            while(currentX < maxHeight)
            {
                float y1 = Mathf.Round(Mathf.Sqrt(Mathf.Pow(((float)dia/2), 2) - Mathf.Pow((float)currentX, 2)));
                float y2 = Mathf.Round(-Mathf.Sqrt(Mathf.Pow(((float)dia/2), 2) - Mathf.Pow((float)currentX, 2)));
                if(y1 > czy){
                    y1 = czy;
                }
                if(y2 < firstCutHeight){
                    y2 = firstCutHeight;
                }
                Vector2 p1 = new Vector2(currentX, y1);
                Vector2 p2 = new Vector2(currentX, y2);
                Saw_cut l = new Saw_cut(p1, p2);
                output.Add(l);
                currentX += wantedLumber.GetWidth();
            }
        }
        else
        {
            
            float RemainingHeight = Mathf.Sqrt(Mathf.Pow((float)((czy - wantedLumber.GetHeight()) - lastp), 2));
            float RemainingWidth = Mathf.Sqrt(Mathf.Pow((float)(czx - (-dia / 2)), 2));
            float currentX;
            float maxHeight = czy - wantedLumber.GetHeight();
            float firstCutHeight;

            //need to define which wanted lumber is best
            Lumber WantedSecondaryLumber = new Lumber(dia,dia);
            foreach (Lumber l in addLumber)
            {
                int numberOfLumbers = (int)(RemainingHeight / l.GetHeight());
                float rest = math.abs(RemainingHeight - (numberOfLumbers * l.GetHeight()));
                int currentNumberOfLumbers = (int)(RemainingHeight / WantedSecondaryLumber.GetHeight());
                float currentRest = math.abs(RemainingHeight - (WantedSecondaryLumber.GetHeight() * currentNumberOfLumbers));

                if(rest < currentRest && l.GetWidth() == wantedLumber.GetWidth())
                {
                    WantedSecondaryLumber = new Lumber(l.GetWidth(), l.GetHeight());
                }
            }
            int SnumberOfLumbers = (int)(RemainingHeight / WantedSecondaryLumber.GetHeight());
            firstCutHeight = czy - wantedLumber.GetHeight() - SnumberOfLumbers*WantedSecondaryLumber.GetHeight();

            float discorest = Mathf.Sqrt(Mathf.Pow((float)(firstCutHeight - (-dia / 2)), 2));
            int numberOfPlanks = (int)(discorest / discovery_height);
            float currentY = firstCutHeight - numberOfPlanks*discovery_height;

            while(currentY < firstCutHeight)
            {
                float x1 = Mathf.Round(Mathf.Sqrt(Mathf.Pow(((float)dia / 2), 2) - Mathf.Pow((float)currentY, 2)));
                float x2 = Mathf.Round(-Mathf.Sqrt(Mathf.Pow(((float)dia / 2), 2) - Mathf.Pow((float)currentY, 2)));
                if(x1 > czx){
                    x1 = czx;
                }
                Vector2 p1 = new Vector2(x1, currentY);
                Vector2 p2 = new Vector2(x2, currentY);
                Saw_cut l = new Saw_cut(p1, p2);
                output.Add(l);
                currentY += discovery_height;
            }
            
            while (currentY <= maxHeight)
            {
                float x1 = Mathf.Round(Mathf.Sqrt(Mathf.Pow(((float)dia / 2), 2) - Mathf.Pow((float)currentY, 2)));
                float x2 = Mathf.Round(-Mathf.Sqrt(Mathf.Pow(((float)dia / 2), 2) - Mathf.Pow((float)currentY, 2)));
                if(x1 > czx){
                    x1 = czx;
                }
                Vector2 p1 = new Vector2(x1, currentY);
                Vector2 p2 = new Vector2(x2, currentY);
                Saw_cut l = new Saw_cut(p1, p2);
                output.Add(l);
                currentY += WantedSecondaryLumber.GetHeight();
            }
            
            //--------------------------------------------------------------------------------------------------

            SnumberOfLumbers = (int)(RemainingWidth / WantedSecondaryLumber.GetWidth());
            currentX = czx - SnumberOfLumbers*WantedSecondaryLumber.GetWidth();
            maxHeight = czx - wantedLumber.GetWidth();
            while(currentX <= maxHeight)
            {
                float y1 = Mathf.Round(Mathf.Sqrt(Mathf.Pow(((float)dia/2), 2) - Mathf.Pow((float)currentX, 2)));
                float y2 = Mathf.Round(-Mathf.Sqrt(Mathf.Pow(((float)dia/2), 2) - Mathf.Pow((float)currentX, 2)));
                if(y1 > czy- wantedLumber.GetHeight()){
                    y1 = czy-wantedLumber.GetHeight();
                }
                if(y2 < firstCutHeight){
                    y2 = firstCutHeight;
                }
                Vector2 p1 = new Vector2(currentX, y1);
                Vector2 p2 = new Vector2(currentX, y2);
                Saw_cut l = new Saw_cut(p1, p2);
                output.Add(l);
                currentX += WantedSecondaryLumber.GetWidth();
            }

            //--------------------------------------------------------------------------------------------------
            
            firstCutHeight = czy - wantedLumber.GetHeight();

            WantedSecondaryLumber = new Lumber(dia,dia);

            foreach (Lumber l in addLumber)
            {
                int numberOfLumbers = (int)((RemainingWidth - wantedLumber.GetWidth()) / l.GetWidth());
                float rest = math.abs(RemainingWidth - (numberOfLumbers * l.GetWidth()));
                int currentNumberOfLumbers = (int)((RemainingWidth - wantedLumber.GetWidth()) / WantedSecondaryLumber.GetWidth());
                float currentRest = math.abs(RemainingWidth - (WantedSecondaryLumber.GetWidth() * currentNumberOfLumbers));

                if(rest < currentRest && l.GetHeight() == wantedLumber.GetHeight())
                {
                    WantedSecondaryLumber = new Lumber(l.GetWidth(), l.GetHeight());
                }
            }


            SnumberOfLumbers = (int)((RemainingWidth - wantedLumber.GetWidth()) / WantedSecondaryLumber.GetWidth());
            Debug.Log(SnumberOfLumbers);
            currentX = czx -wantedLumber.GetWidth() - SnumberOfLumbers*WantedSecondaryLumber.GetWidth();
            maxHeight = czx - wantedLumber.GetWidth();
            while(currentX <= maxHeight)
            {
                float y1 = Mathf.Round(Mathf.Sqrt(Mathf.Pow(((float)dia/2), 2) - Mathf.Pow((float)currentX, 2)));
                float y2 = Mathf.Round(-Mathf.Sqrt(Mathf.Pow(((float)dia/2), 2) - Mathf.Pow((float)currentX, 2)));
                if(y1 > czy){
                    y1 = czy;
                }
                if(y2 < firstCutHeight){
                    y2 = firstCutHeight;
                }
                Vector2 p1 = new Vector2(currentX, y1);
                Vector2 p2 = new Vector2(currentX, y2);
                Saw_cut l = new Saw_cut(p1, p2);
                output.Add(l);
                currentX += WantedSecondaryLumber.GetWidth();
            }

        }

        return output;
    }


}

// Here are the classes used by the algorithm
namespace classes
{
    // The Saw_cut class is representing a simple line
    public class Saw_cut
    {
        private Vector2 C1;
        private Vector2 C2;


        public Saw_cut(Vector2 xc1, Vector2 xc2)
        {
            C1 = xc1;
            C2 = xc2;
        }

        public Vector2 GetC1()
        {
            return C1;
        }

        public Vector2 GetC2()
        {
            return C2;
        }
    }

    // The lumber class is representing a piece of wood and its dimensions
    public class Lumber
    {
        private float width;
        private float height;

        public Lumber(float xwidth, float xheight)
        {
            width = xwidth;
            height = xheight;
        }
        public float GetWidth()
        {
            return width;
        }
        public float GetHeight()
        {
            return height;
        }

    }
}
