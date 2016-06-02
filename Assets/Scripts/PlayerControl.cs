//ATTACH THIS SCRIPT TO THE PLAYER SPHERE
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerControl : MonoBehaviour
{
    //SET SPEED IN THE IDE
    public int Pickup_Num;
    public float JumpHeight;
    public float speed;//controls how much force to apply to move the ball
    private int count;//this will count how many cubes have been gathered by player
                      //ATTACH THESE TEXT OBJECTS TO THE SCRIPT
    public UnityEngine.UI.Text countText;//---Or you can define these variables with the full name
    public UnityEngine.UI.Text winText;

    void Start()
    {

        count = 0;//player score starts at 0
        countText.text = "Count: 0";//Display score on GUI at startup
        winText.text = "";//this will become a congratulatory message upon the win condition
    }

    void Update()
    {
        if (transform.position.y < -1)
            winText.text = "YOU LOSE, PUNK!!!!!!!";
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, JumpHeight, 0));

        }
    }

    void FixedUpdate()
    {//all physics calculations are done here

        //Get whether the arrow keys have been pressed
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");//vertical actually means in the z direction

        //Move the ball in the direction of those keys
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        //Second param is 0 cuz the ball is only moving from side to side

        //Apply the force - ball will now move as though it were 'pushed'
        GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
        //remember to adjust ball speed by delta time,
        //or it will run at different speeds on different machines
        //depending on the machine's frame rate

    }

    //This is called when 'this' player passes thru a trigger collider
    void OnTriggerEnter(Collider other)
    {
        //If the collider was a pickup object
        if (other.gameObject.tag == "PickUp")
        {
            //make it disappear
            other.gameObject.SetActive(false);
            //increase the score
            count++;
            //update score on screen
            countText.text = "Count: " + count.ToString();
        }
        //if all the pickup objects have been gathered
        if (count > Pickup_Num - 1)
        {
            //congrats to the player
            winText.text = "You win!!!!!!!";
        }
    }


}
