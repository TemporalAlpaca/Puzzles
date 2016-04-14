using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameScript : MonoBehaviour {
    public GameObject[] references;
    public enum Seed {EMPTY,CROSS,NOUGHT};
    public Seed[] Cells;
    public GameObject Cross, Nought,Empty,Bar,CrossBar;
    //public enum Players {PLAYER, CPU};
    public Seed turn,player1,player2;
    Vector2 pos1, pos2;
    public Text Instructions;
    public bool playing = true;
    int delay = 30;
    public Button playagain;
    System.Random rnd = new System.Random();

	// Use this for initialization
	void Start () {
        playagain.enabled = false;
        Cells = new Seed[9];
        for (int i = 0; i < 9; i++)
        {
            Cells[i] = Seed.EMPTY;
        }
        int x = rnd.Next(0, 2);
        if (x == 0)
            turn = Seed.CROSS;
        else
            turn = Seed.NOUGHT;

        Instructions.text = "Turn: " + turn.ToString();
	}
	
	// Update is called once per frame
	void Update () {
        if (playing)
            Instructions.text = "Turn: " + turn.ToString();
        else if (isDraw())
            Instructions.text = "It's a Draw!!";
        else
            Instructions.text = whoWon().ToString() + " Won!";
        //if (!playing)
        //{
        //    GetDelay();
        //    Application.LoadLevel("main");
        //}
           
	}
    

    public void SpawnNew(GameObject empty,int idx){
        
        Cells[idx] = turn;
        if (turn == Seed.CROSS)
        {
            turn = Seed.NOUGHT;
            references[idx] = Instantiate(Cross, empty.transform.position, Quaternion.identity) as GameObject;
        }
        else if(turn == Seed.NOUGHT)
        {
            turn = Seed.CROSS;
            references[idx] = Instantiate(Nought, empty.transform.position, Quaternion.identity) as GameObject;
        }
        /*else
        {
            references[idx] = Instantiate(Empty, empty.transform.position, Quaternion.identity) as GameObject;
        }*/
        if (isDraw() == true)
        {
            turn = Seed.EMPTY;
            playing = false;
        }
        if (whoWon() != Seed.EMPTY && playing)
        {
            Vector2 center = calCenter();
            if (pos1.x == pos2.x)
            {
                Instantiate(Bar, center, Quaternion.identity);
            }
            else if (pos1.y == pos2.y)
            {
                Instantiate(Bar, center, Quaternion.Euler(0, 0, -90));
            }
            else
            {
                if (pos1.x < 0)
                    Instantiate(CrossBar, center, Quaternion.Euler(0, 0, 45));
                else
                    Instantiate(CrossBar, center, Quaternion.Euler(0, 0, -45));
            }
            playing = false;
        }
        if (!playing)
        {
            playagain.GetComponent<CanvasGroup>().alpha = 1;
            //playagain.interactable = true;
            playagain.enabled = true;
        }
        Destroy(empty);
        
    }

    bool isDraw()
    {
        if(whoWon() != Seed.EMPTY)
            return false;
        for (int i = 0; i < 9;i++)
            if(Cells[i]==Seed.EMPTY)
                return false;
        return true;
    }

    Seed whoWon()
    {
        Seed flag=Seed.EMPTY;
        if (Cells[0] != Seed.EMPTY)
        {
            pos1 = references[0].transform.position;
            if ((Cells[0] == Cells[1]) && Cells[2] == Cells[0])
            {
                flag = Cells[0];              
                pos2 = references[2].transform.position;
            }
            else if ((Cells[0] == Cells[3]) && Cells[0] == Cells[6])
            {
                flag = Cells[0];
                pos2 = references[6].transform.position;
            }
            else if ((Cells[0] == Cells[4]) && Cells[0] == Cells[8])
            {
                flag = Cells[0];
                pos2 = references[8].transform.position;
            }
        }
        if (flag == Seed.EMPTY && Cells[8] != Seed.EMPTY)
        {
            pos1 = references[8].transform.position;
            if ((Cells[8] == Cells[7]) && Cells[6] == Cells[8])
            {
                flag = Cells[8];
                pos2 = references[6].transform.position;
            }
            else if ((Cells[8] == Cells[5]) && Cells[2] == Cells[8])
            {
                flag = Cells[8];
                pos2 = references[2].transform.position;
            }
        }
        if (flag == Seed.EMPTY && Cells[4] != Seed.EMPTY)
        {
            if ((Cells[4] == Cells[3]) && Cells[4] == Cells[5])
            {
                flag = Cells[4];
                pos1 = references[3].transform.position;
                pos2 = references[5].transform.position;
            }
            else if ((Cells[4] == Cells[1]) && Cells[4] == Cells[7])
            {
                flag = Cells[4];
                pos1 = references[1].transform.position;
                pos2 = references[7].transform.position;
            }
            else if ((Cells[4] == Cells[2]) && Cells[4] == Cells[6])
            {
                flag = Cells[4];
                pos1 = references[2].transform.position;
                pos2 = references[6].transform.position;
            }
        }
        return flag;
    }

    Vector2 calCenter()
    {
        float x = (pos1.x + pos2.x)/2,
              y = (pos1.y + pos2.y)/2;
        return new Vector2(x, y);
    }

    void GameOver(string display)
    {

    }

    IEnumerator GetDelay()
    {
        yield return new WaitForSeconds(delay);
    }
}
