using UnityEngine;
using System.Collections;

public class LightToggle : MonoBehaviour {

    public GameObject green;
    public GameObject yellow;
    public GameObject red;
    SpriteRenderer g, y, r;

    string state;
    float time = 2;

    // Use this for initialization
    void Start () {

        Debug.Log(PlayerPrefs.GetString("state"));
        g = green.GetComponent<SpriteRenderer>();
        y = yellow.GetComponent<SpriteRenderer>();
        r = red.GetComponent<SpriteRenderer>();

        g.enabled = true;
        y.enabled = false;
        r.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {

        g = green.GetComponent<SpriteRenderer>();
        y = yellow.GetComponent<SpriteRenderer>();
        r = red.GetComponent<SpriteRenderer>();
        if (time > 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            if (g.enabled)
            {
                state = "yellow";
                g.enabled = false;
                y.enabled = true;
            }
            else if(y.enabled)
            {
                state = "red";
                y.enabled = false;
                r.enabled = true;
            }
            else if(r.enabled)
            {
                state = "green";
                r.enabled = false;
                g.enabled = true;
            }
            time = 2;
            PlayerPrefs.SetString("state", state);
            PlayerPrefs.Save();
            //Debug.Log(state);
        }
	}
}
