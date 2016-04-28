using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;

public class Drag : MonoBehaviour {

    public GameObject target;
    public GameObject text;
    bool isMouseDrag;
    bool input_entered;
    Vector3 screenPosition, offset;
    bool shaken;
	

	void Start () {
        target = GameObject.Find("ball");
        shaken = false;
        float rand = Random.Range(1, 6);
        string search = rand.ToString();

        text = GameObject.Find(search);
	}

    
    void Update()
    {
        if (input_entered)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hitInfo;
                target = ReturnClickedObject(out hitInfo);
                if (target != null)
                {
                    isMouseDrag = true;
                    Debug.Log("target position :" + target.transform.position);
                    //Convert world position to screen position.
                    screenPosition = Camera.main.WorldToScreenPoint(target.transform.position);
                    offset = target.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z));
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                isMouseDrag = false;
                Shaken();

            }
            if (isMouseDrag)
            {

                //track mouse position.
                Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPosition.z);
                //convert screen position to world position with offset changes.
                Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offset;
                //It will update target gameobject's current postion.
                target.transform.position = currentPosition;
                shaken = true;
            }
        }
    }

    GameObject ReturnClickedObject(out RaycastHit hit)
    {
        GameObject target = null;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray.origin, ray.direction * 10, out hit))
        {
            target = hit.collider.gameObject;

        }
        return target;
    }

    void Shaken()
    {
       
        if(shaken)
        {
            text.GetComponent<Text>().enabled = true;
            shaken = false;
        }
        
    }

    public void input()
    {
        input_entered = true;
    }
}
