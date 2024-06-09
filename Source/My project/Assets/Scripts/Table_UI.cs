using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table_UI : MonoBehaviour
{

    public GameObject Cell;
    public GameObject Content;
    public GameObject scrollBar;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Check_Sizes();
    }

    public void On_click()
    {
        GameObject x;
        x = Instantiate(Cell, Content.transform);
    }

    public void Check_Sizes()
    {
        if(scrollBar.activeInHierarchy)
        {
            for(int i = 0; i < Content.transform.childCount; i++)
            {
                RectTransform tr = Content.transform.GetChild(i).GetComponent<RectTransform>();
                tr.sizeDelta = new Vector2(165, 50);
            }
        }
        else
        {
            for(int i = 0; i < Content.transform.childCount; i++)
            {
                RectTransform tr = Content.transform.GetChild(i).GetComponent<RectTransform>();
                tr.sizeDelta = new Vector2(182, 50);

            }
        }
    }
}
