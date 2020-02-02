using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float energy;

    public GameLogic gameLogic;

    public int playerNumber;

    public GameObject shoot;
    public GameObject special;
    public GameObject missile;
    public GameObject shield;

    public bool special_touching;
    public bool missile1_touching;
    public bool missile2_touching;
    public bool shield1_touching;
    public bool shield2_touching;
    public bool shield3_touching;

    public GameObject explosion;

    public TextMeshProUGUI energyTxt;

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

        if (collision.tag == "shield1")
        {
            shield1_touching = true;
        }
        if (collision.tag == "shield2")
        {
            shield2_touching = true;
        }
        if (collision.tag == "shield3")
        {
            shield3_touching = true;
        }

        if(collision.tag == "shootEnemy1" || collision.tag == "shootEnemy2" || collision.tag == "shootEnemy3")
        {
            energy -= collision.GetComponent<Shoot>().damage;
            
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

        if (collision.tag == "shield1")
        {
            shield1_touching = false;
        }
        if (collision.tag == "shield2")
        {
            shield2_touching = false;
        }
        if (collision.tag == "shield3")
        {
            shield3_touching = false;
        }
    }

    IEnumerator Wait(float t)
    {
        yield return new WaitForSeconds(t);

        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }

    void Update()
    {
        if (!this.GetComponent<SpriteRenderer>().enabled)
            return;

        if(energyTxt)
            energyTxt.text = energy.ToString();//tirar do update e fazer evento

        if (energy <= 0)
        {
            GameObject go = Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(go, 0.5f);
            this.GetComponent<SpriteRenderer>().enabled = false;
            //chamar o game over / recomeçar
            //tirar do update aqui...
            //fazer barra de energia...
            StartCoroutine(Wait(2));
        }

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
                if (shield1_touching)
                {
                    gameLogic.shield1_b = true;
                    gameLogic.shield1_go.SetActive(false);
                    shield1_touching = false;
                }
                if (shield2_touching)
                {
                    gameLogic.shield2_b = true;
                    gameLogic.shield2_go.SetActive(false);
                    shield2_touching = false;
                }
                if (shield3_touching)
                {
                    gameLogic.shield3_b = true;
                    gameLogic.shield3_go.SetActive(false);
                    shield3_touching = false;
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

            if (gameLogic.shield1_b && gameLogic.shield2_b && gameLogic.shield3_b)
            {
                if (shield)//na verdade testar se ja existe antes de criar novo
                {
                    Instantiate(shield, this.transform.position, Quaternion.identity);
                }
                gameLogic.shield1_b = false;
                gameLogic.shield2_b = false;
                gameLogic.shield3_b = false;
            }
        }
    }
}
