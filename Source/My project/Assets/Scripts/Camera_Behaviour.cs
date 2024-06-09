using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Mathematics;

public class Camera_Behaviour : MonoBehaviour
{

    public float speed = 10f;
    public TMP_InputField input;

    private Camera cam;
    private float start; 
    private float currentPosition; 
    private float step;
    private float end;
    private bool flag;

    // Start is called before the first frame update
    void Start()
    {
        cam = this.gameObject.GetComponent<Camera>();
        start = cam.orthographicSize;
        currentPosition = cam.orthographicSize;
        step = 0f;
        end = cam.orthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if(flag)
        {
            if(cam.orthographicSize != end)
            {
                currentPosition = Mathf.Lerp(start,end, step);
                cam.orthographicSize = currentPosition;
                step += 0.1f*Time.deltaTime*speed;
            }else
            {
                flag = false;
            }
        }
        
        
        
    }

    public void button()
    {
        if(input.text != "")
        {
            flag = true;
            step = 0f;
            start = cam.orthographicSize;
            end = (math.abs(float.Parse(input.text))/200)+0.75f;
        }
    }
}
