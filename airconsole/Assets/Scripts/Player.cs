using UnityEngine;

public class Player : MonoBehaviour
{
	public GameLogic gameLogic;

    public int playerNumber;

    public GameObject shoot;
    public GameObject special;
    public GameObject missile;
    public GameObject shield;

    //criar um numero q receba shiel duration e contador p so poder criar depois canCreateShield

    void Update()
    {
        if (playerNumber == 0)//esquerda robo
        {
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

            if (gameLogic.buttonTwoPlayerRight)
            {
                if (special)
                {
                    Instantiate(special, this.transform.position, Quaternion.identity);
                }
                gameLogic.buttonTwoPlayerRight = false;//na verdade esse aqui nao ta usando, ta usando no gamelogic 0 qd larga o botao
            }

            if (gameLogic.buttonThreePlayerRight)
            {
                if (missile)
                {
                    Instantiate(missile, this.transform.position, Quaternion.identity);
                }
                gameLogic.buttonThreePlayerRight = false;
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
