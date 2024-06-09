using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class bring_keeboard : MonoBehaviour
{

    public TouchScreenKeyboard touchscreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Bring()
    {
        Debug.Log("touch screen openned");
        touchscreen = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.NumberPad);
    }
}
