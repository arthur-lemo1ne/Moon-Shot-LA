using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Button_delete : MonoBehaviour
{

    public GameObject obj;
    private Table_UI parent;

    // Start is called before the first frame update
    void Start()
    {
        parent = this.transform.GetComponentInParent<Transform>().GetComponentInParent<Transform>().GetComponentInParent<Table_UI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void On_click()
    {
        Destroy(obj);
    }
}
