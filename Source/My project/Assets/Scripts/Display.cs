using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;

public class Display : MonoBehaviour
{
    
    private int step = 0;
    private GameObject[] all_steps;

    public TMP_Text counter;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Inisialize()
    {
    
        step = 0;
        

        all_steps = GameObject.FindGameObjectsWithTag("SawCut");
        
        foreach (GameObject o in all_steps)
        {
            o.SetActive(false);
        }
        counter.text = step.ToString();
    }

    public void clear()
    {
        if(all_steps != null)
        {
            foreach (GameObject o in all_steps)
            {
                DestroyImmediate(o);
            }
            all_steps = null;
        }
    }

    public void next_Step()
    {
        if(all_steps != null){

        
        step ++;
        if(step > all_steps.Length)
        {
            step= all_steps.Length;
        }
        foreach (GameObject o in all_steps)
        {
            o.SetActive(false);
        }
        for(int i = 0; i < step; i++)
        {
            all_steps[i].SetActive(true);
        }
        }
        counter.text = step.ToString();
    }

    public void previous_Step()
    {
        step --;
        if(step < 0)
        {
            step= 0;
        }
        foreach (GameObject o in all_steps)
        {
            o.SetActive(false);
        }
        for(int i = 0; i < step; i++)
        {
            all_steps[i].SetActive(true);
        }
        counter.text = step.ToString();
    }

    public void firstStep()
    {
        step = 1;
        foreach (GameObject o in all_steps)
        {
            o.SetActive(false);
        }
        for(int i = 0; i < step; i++)
        {
            all_steps[i].SetActive(true);
        }
        counter.text = step.ToString();
    }

    public void lastStep()
    {
        step = all_steps.Length;
        foreach (GameObject o in all_steps)
        {
            o.SetActive(false);
        }
        for(int i = 0; i < step; i++)
        {
            all_steps[i].SetActive(true);
        }
        counter.text = step.ToString();
    }
}
