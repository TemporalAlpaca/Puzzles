//ATTACH THIS SCRIPT TO THE CAMERA
using UnityEngine;
using System.Collections;

public class CamControl : MonoBehaviour
{

    public GameObject player;//ATTACH THE PLAYER TO THIS SCRIPT!
    private Vector3 offset;
    // Use this for initialization
    //Get 'this' camera's initial position
    void Start()
    {
        offset = transform.position;
    }

    //LateUpdate is called after Update
    //cuz we don't want to move the camera until the player has moved
    void LateUpdate()
    {
        //increment the camera by the same distance/direction the player has moved
        transform.position = player.transform.position + offset;
    }

}
