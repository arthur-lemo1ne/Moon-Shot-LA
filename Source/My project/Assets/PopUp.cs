using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour
{
    public GameObject popUpWindow;
    public GameObject UI;    
    public TMP_Text display;

    private Button[] buttons;
    private TMP_InputField[] inputFields;
    private Toggle[] toggles;

    // Start is called before the first frame update
    void Start()
    {
        buttons = UI.GetComponentsInChildren<Button>();
        inputFields = UI.GetComponentsInChildren<TMP_InputField>();
        toggles = UI.GetComponentsInChildren<Toggle>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Set(bool setValue)
    {
        foreach (Button b in buttons)
        {
            b.interactable = setValue;
        }
        foreach (TMP_InputField i in inputFields)
        {
            i.interactable = setValue;
        }
        foreach (Toggle t in toggles)
        {
            t.interactable = setValue;
        }
    }

    public void Inisialize(int alertCase)
    {
        Set(false);
        popUpWindow.SetActive(true);
        switch(alertCase)
        {
            // case log diameter
            case 0:
                display.text = "Please fill the \"log diameter\" parameter";
                break;
            // case Wanted Lumber
            case 1:
                display.text = "Please fill the \"Wanted Lumber\" parameter";
                break;
            // case Additional Lumber
            case 2:
                display.text = "Please fill the \"Additional Lumber\" parameter or clear the table";
                break;
            // case Discovery
            case 3:
                display.text = "Please fill the \"Discovery Plank\" parameter";
                break;
            default:
                display.text = "Invalid Error, Please restart the software";
                break;
        }
    }

    public void On_Ok_click()
    {
        Set(true);
        popUpWindow.SetActive(false);
    }
}
