using UnityEngine;
using System.Collections;

public class DrawButton : MonoBehaviour {

    public GameObject draw_script;
    bool enabled;
	// Use this for initialization
	void Start () {
        enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick()
    {
        if (!enabled)
        {
            draw_script.GetComponent<Drawing>().enabled = true;
            enabled = true;
        }
       //else
        //{
           // draw_script.GetComponent<Drawing>().enabled = false;
            //enabled = false;
        //}
    }
}
