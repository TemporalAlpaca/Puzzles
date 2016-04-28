using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameLogic : MonoBehaviour
{
    public Text text;
    public bool playing;
    public GameObject[] reference;
    public GameObject X, O, Bar, CrossBar;
    public enum Fill { EMPTY, O, X };
    public Fill turn;
    public Fill[] Cells;
    Vector2 p1, p2;


    void Start()
    {
        reference = new GameObject[9];
        playing = true;
        Cells = new Fill[9];

        for (int i = 0; i < 9; ++i)
        {
            Cells[i] = Fill.EMPTY;
        }

    }

    void Update()
    {
        if (playing)
        {
            if (Draw())
            {
                text.text = "DRAW";
                Debug.Log("DRAW");
                text.color = Color.black;
            }
        }
        else
        {
            string winner = Winner().ToString();
            winner += " wins!";
            text.text = winner;
            text.color = Color.black;
            Debug.Log(winner);
        }
    }
    public void Spawn(GameObject obj, int idx)
    {
        Debug.Log(idx);

        Cells[idx] = turn;
        if (turn == Fill.X)
        {
            turn = Fill.O;
            reference[idx] = Instantiate(X, obj.transform.position, Quaternion.identity) as GameObject;
        }
        else
        {
            turn = Fill.X;
            reference[idx] = Instantiate(O, obj.transform.position, Quaternion.identity) as GameObject;
        }
        if (Winner() != Fill.EMPTY && playing)
        {
            Vector2 center = calCenter();
            if (p1.x == p2.x)
            {
                Instantiate(Bar, center, Quaternion.identity);
            }
            else if (p1.y == p2.y)
            {
                Instantiate(Bar, center, Quaternion.Euler(0, 0, -90));
            }
            else
            {
                if (p1.x < 0)
                    Instantiate(CrossBar, center, Quaternion.Euler(0, 0, 45));
                else
                    Instantiate(CrossBar, center, Quaternion.Euler(0, 0, -45));
            }
            playing = false;
        }
        Destroy(obj.gameObject);
    }

    public bool CheckState()
    {
        return true;
    }

    Fill Winner()
    {
        Fill flag = Fill.EMPTY;
        if (Cells[0] != Fill.EMPTY)
        {
            p1 = reference[0].transform.position;
            if ((Cells[0] == Cells[1]) && Cells[2] == Cells[0])
            {
                flag = Cells[0];
                p2 = reference[2].transform.position;
            }
            else if ((Cells[0] == Cells[3]) && Cells[0] == Cells[6])
            {
                flag = Cells[0];
                p2 = reference[6].transform.position;
            }
            else if ((Cells[0] == Cells[4]) && Cells[0] == Cells[8])
            {
                flag = Cells[0];
                p2 = reference[8].transform.position;
            }
        }
        if (flag == Fill.EMPTY && Cells[8] != Fill.EMPTY)
        {
            p1 = reference[8].transform.position;
            if ((Cells[8] == Cells[7]) && Cells[6] == Cells[8])
            {
                flag = Cells[8];
                p2 = reference[6].transform.position;
            }
            else if ((Cells[8] == Cells[5]) && Cells[2] == Cells[8])
            {
                flag = Cells[8];
                p2 = reference[2].transform.position;
            }
        }
        if (flag == Fill.EMPTY && Cells[4] != Fill.EMPTY)
        {
            if ((Cells[4] == Cells[3]) && Cells[4] == Cells[5])
            {
                flag = Cells[4];
                p1 = reference[3].transform.position;
                p2 = reference[5].transform.position;
            }
            else if ((Cells[4] == Cells[1]) && Cells[4] == Cells[7])
            {
                flag = Cells[4];
                p1 = reference[1].transform.position;
                p2 = reference[7].transform.position;
            }
            else if ((Cells[4] == Cells[2]) && Cells[4] == Cells[6])
            {
                flag = Cells[4];
                p1 = reference[2].transform.position;
                p2 = reference[6].transform.position;
            }
        }
        return flag;
    }

    Vector2 calCenter()
    {
        float x = (p1.x + p2.x) / 2,
              y = (p1.y + p2.y) / 2;
        return new Vector2(x, y);
    }

    bool Draw()
    {
        if (Winner() != Fill.EMPTY)
            return false;
        for (int i = 0; i < 9; i++)
            if (Cells[i] == Fill.EMPTY)
                return false;
        return true;
    }
}

