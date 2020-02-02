using UnityEngine;
using UnityEngine.UI;
using NDream.AirConsole;
using Newtonsoft.Json.Linq;

public class GameLogic : MonoBehaviour
{
	public Rigidbody2D playerLeft;
	public Rigidbody2D playerRight;

    public bool buttonOnePlayerLeft;
    public bool buttonTwoPlayerLeft;
    public bool buttonThreePlayerLeft;
    public bool buttonFourPlayerLeft;

    public bool buttonOnePlayerRight;
    public bool buttonTwoPlayerRight;
    public bool buttonThreePlayerRight;
    public bool buttonFourPlayerRight;

    //public Rigidbody2D ball;
    //public float ballSpeed = 10f;
    public Text uiText;

#if !DISABLE_AIRCONSOLE

    //private int scoreRacketLeft = 0;
	//private int scoreRacketRight = 0;

	void Awake ()
    {
		AirConsole.instance.onMessage += OnMessage;
		AirConsole.instance.onConnect += OnConnect;
		AirConsole.instance.onDisconnect += OnDisconnect;
	}

	/// <summary>
	/// We start the game if 2 players are connected and the game is not already running (activePlayers == null).
	/// 
	/// NOTE: We store the controller device_ids of the active players. We do not hardcode player device_ids 1 and 2,
	///       because the two controllers that are connected can have other device_ids e.g. 3 and 7.
	///       For more information read: http://developers.airconsole.com/#/guides/device_ids_and_states
	/// 
	/// </summary>
	/// <param name="device_id">The device_id that connected</param>
	void OnConnect (int device_id)
    {        
        if (AirConsole.instance.GetActivePlayerDeviceIds.Count == 0)
        {
			if (AirConsole.instance.GetControllerDeviceIds ().Count >= 2)
            {
				StartGame ();
			}
            else
            {
				uiText.text = "PRECISA DE DOIS JOGADORES!";
			}
		}
	}

	/// <summary>
	/// If the game is running and one of the active players leaves, we reset the game.
	/// </summary>
	/// <param name="device_id">The device_id that has left.</param>
	void OnDisconnect (int device_id)
    {
		int active_player = AirConsole.instance.ConvertDeviceIdToPlayerNumber (device_id);

		if (active_player != -1)
        {
			if (AirConsole.instance.GetControllerDeviceIds ().Count >= 2)
            {
				StartGame ();
			}
            else
            {
				AirConsole.instance.SetActivePlayers (0);
                uiText.text = "PRECISA DE DOIS JOGADORES!";
            }
		}
	}

	/// <summary>
	/// We check which one of the active players has moved the paddle.
	/// </summary>
	/// <param name="from">From.</param>
	/// <param name="data">Data.</param>
	void OnMessage (int device_id, JToken data)
    {
		int active_player = AirConsole.instance.ConvertDeviceIdToPlayerNumber (device_id);

		if (active_player != -1)
        {
			if (active_player == 0)
            {
                if (data["move"] != null)
                {
                    //this.playerLeft.velocity = Vector3.up * (float)data["move"];
                    Debug.Log((float)data["move"]);
                    if((float)data["move"]==1)//cima
                    {
                        this.playerLeft.velocity = Vector3.up * 5;
                    }
                    if ((float)data["move"] == 2)//baixo
                    {
                        this.playerLeft.velocity = Vector3.up * -5;
                    }
                    if ((float)data["move"] == 3)//direita
                    {
                        this.playerLeft.velocity = Vector3.right * 5;
                    }
                    if ((float)data["move"] == 4)//esquerda
                    {
                        this.playerLeft.velocity = Vector3.right * -5;
                    }
                    if ((float)data["move"] == 0)//para
                    {
                        this.playerLeft.velocity = Vector3.zero;
                        this.buttonOnePlayerLeft = false;
                        this.buttonTwoPlayerLeft = false;
                        this.buttonThreePlayerLeft = false;
                        this.buttonFourPlayerLeft = false;
                    }
                    if ((float)data["move"] == 5)//botao 1
                    {
                        this.buttonOnePlayerLeft = true;
                    }
                    if ((float)data["move"] == 6)//botao 2
                    {
                        this.buttonTwoPlayerLeft = true;
                    }
                    if ((float)data["move"] == 7)//botao 3
                    {
                        this.buttonThreePlayerLeft = true;
                    }
                    if ((float)data["move"] == 8)//botao 4
                    {
                        this.buttonFourPlayerLeft = true;
                    }
                }
               
            }
			if (active_player == 1)
            {
                if (data["move"] != null)
                {
                    //this.playerRight.velocity = Vector3.up * (float)data["move"];
                    Debug.Log((float)data["move"]);
                    if ((float)data["move"] == 1)//cima
                    {
                        this.playerRight.velocity = Vector3.up * 5;
                    }
                    if ((float)data["move"] == 2)//baixo
                    {
                        this.playerRight.velocity = Vector3.up * -5;
                    }
                    if ((float)data["move"] == 3)//direita
                    {
                        this.playerRight.velocity = Vector3.right * 5;
                    }
                    if ((float)data["move"] == 4)//esquerda
                    {
                        this.playerRight.velocity = Vector3.right * -5;
                    }
                    if ((float)data["move"] == 0)
                    {
                        this.playerRight.velocity = Vector3.zero;
                        this.buttonOnePlayerRight = false;
                        this.buttonTwoPlayerRight = false;
                        this.buttonThreePlayerRight = false;
                        this.buttonFourPlayerRight = false;
                    }
                    if ((float)data["move"] == 5)//botao 1
                    {
                        this.buttonOnePlayerRight = true;
                    }
                    if ((float)data["move"] == 6)//botao 2
                    {
                        this.buttonTwoPlayerRight = true;
                    }
                    if ((float)data["move"] == 7)//botao 3
                    {
                        this.buttonThreePlayerRight = true;
                    }
                    if ((float)data["move"] == 8)//botao 4
                    {
                        this.buttonFourPlayerRight = true;
                    }
                }             
            }
		}
	}

    void StartGame ()
    {
		AirConsole.instance.SetActivePlayers (2);
        uiText.text = "";
    }

	void OnDestroy ()
    {
		// unregister airconsole events on scene change
		if (AirConsole.instance != null)
        {
			AirConsole.instance.onMessage -= OnMessage;
		}
	}
#endif
}
