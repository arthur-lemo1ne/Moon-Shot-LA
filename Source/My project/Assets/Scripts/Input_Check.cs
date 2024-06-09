using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Input_Check : MonoBehaviour
{

    public TMP_InputField input_field;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void On_deselect()
    {
        if(float.Parse(input_field.text)> 1500)
        {
            input_field.text = "1500";
        }
    }
}
