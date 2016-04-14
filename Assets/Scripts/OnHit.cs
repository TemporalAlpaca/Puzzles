using UnityEngine;
using System.Collections;

public class OnHit : MonoBehaviour {
    public int idx;
    GameScript Script;
    public GameObject Camera;

    void Awake()
    {
        //camera = GameObject.FindGameObjectWithTag("MainCamera");
        Script = Camera.GetComponent<GameScript>();
    }

    void OnMouseDown()
    {
        if(Script.playing)
            Script.SpawnNew(this.gameObject, idx);
    }
}
