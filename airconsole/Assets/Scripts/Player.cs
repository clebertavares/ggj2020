using UnityEngine;

public class Player : MonoBehaviour
{
	public GameLogic gameLogic;

    public int playerNumber;

    public GameObject shoot;
    public GameObject special;
    public GameObject missile;
    public GameObject shield;

    public bool special_touching;
    public bool missile1_touching;
    public bool missile2_touching;

    //criar um numero q receba shiel duration e contador p so poder criar depois canCreateShield

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "special")
        {
            special_touching = true;
        }
        if (collision.tag == "missile1")
        {
            missile1_touching = true;
        }
        if (collision.tag == "missile2")
        {
            missile2_touching = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "special")
        {
            special_touching = false;
        }
        if (collision.tag == "missile1")
        {
            missile1_touching = false;
        }
        if (collision.tag == "missile2")
        {
            missile2_touching = false;
        }
    }

    void Update()
    {
        if (playerNumber == 0)//esquerda robo
        {
            if (gameLogic.buttonOnePlayerLeft)
            {
                if (special_touching)
                {
                    gameLogic.special_b = true;
                    special_touching = false;
                    gameLogic.special_go.SetActive(false);
                }
                if (missile1_touching)
                {
                    gameLogic.missile1_b = true;
                    gameLogic.missile1_go.SetActive(false);
                    missile1_touching = false;
                }
                if (missile2_touching)
                {
                    gameLogic.missile2_b = true;
                    gameLogic.missile2_go.SetActive(false);
                    missile2_touching = false;
                }
                gameLogic.buttonOnePlayerLeft = false;
            }

        }

        if (playerNumber==1)//direita nave
        {
            if(gameLogic.buttonOnePlayerRight)
            {
                if(shoot)
                {
                    Instantiate(shoot, this.transform.position, Quaternion.identity);
                }
                gameLogic.buttonOnePlayerRight = false;
            }
            
            if (gameLogic.special_b)
            {
                if (special)
                {
                    Instantiate(special, this.transform.position, Quaternion.identity);
                }
                gameLogic.special_b = false;
            }
            
            if (gameLogic.missile1_b && gameLogic.missile2_b)
            {
                if (missile)
                {
                    Instantiate(missile, this.transform.position, Quaternion.identity);
                }
                gameLogic.missile1_b = false;
                gameLogic.missile2_b = false;
            }

            if (gameLogic.buttonFourPlayerRight)
            {
                if (shield)//na verdade testar se ja existe antes de criar novo
                {
                    Instantiate(shield, this.transform.position, Quaternion.identity);
                }
                gameLogic.buttonFourPlayerRight = false;
            }
        }
    }
}
