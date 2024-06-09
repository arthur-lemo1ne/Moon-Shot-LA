using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Mathematics;

public class Log : MonoBehaviour
{

    public LineRenderer CircleRenderer;
    public TMP_InputField input;

    public int NBsteps = 10;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DRC(){
        if(input.text != "")
        {
            DrawCircle(NBsteps, math.abs(float.Parse(input.text))/200);
            CircleRenderer.endWidth = math.abs(float.Parse(input.text)) * 0.000028f + 0.04f;
            CircleRenderer.startWidth = math.abs(float.Parse(input.text)) * 0.000028f + 0.04f;
        }
    }

    void DrawCircle(int steps, float radius)
    {
        CircleRenderer.positionCount = steps;

        for(int currentStep=0; currentStep<steps; currentStep++)
        {
            float CircumferenceProgress = (float)currentStep/steps;

            float currentRadiant = CircumferenceProgress * 2 * Mathf.PI;

            float xscale = Mathf.Cos(currentRadiant);
            float yscale = Mathf.Sin(currentRadiant);

            float x = radius * xscale;
            float y = radius * yscale;

            Vector2 currentPosition = new Vector2(x,y);

            CircleRenderer.SetPosition(currentStep, currentPosition);
        }
        
    }
}
