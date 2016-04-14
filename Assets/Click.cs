using UnityEngine;
using System.Collections;

public class Click : MonoBehaviour {

    public int idx;
    GameLogic Script;
    public GameObject Camera;

    void Awake()
    {
        Camera = GameObject.Find("Camera");
        Script = Camera.GetComponent<GameLogic>();
    }

    void OnMouseDown()
    {
        if (Script.playing)
            Script.Spawn(this.gameObject, idx);
    }
}

