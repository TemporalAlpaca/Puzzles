//ATTACH THIS SCRIPT TO THE CUBE PICKUP OBJECTS PREFAB
using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
{

    //so the rotation is applied to them
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
    //Update is called once per frame
    //so all operations should be adjusted by delta time
    //delta time is 1/fps
}
