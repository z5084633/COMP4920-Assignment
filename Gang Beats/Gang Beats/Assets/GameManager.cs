using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    #region Public Attributes
    public Text testLog;
    #endregion
    private GameObject loadInstance(string path, Vector3 location, bool freeze = false)
    {
        GameObject instance = (GameObject)Instantiate(Resources.Load(path), location, transform.rotation);
        if (freeze)
        {
            Rigidbody2D rigidbody = instance.GetComponent<Rigidbody2D>();
            rigidbody.constraints |= RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX;
        }
        return instance;
    }

    private GameModel gameModel;
    // Start is called before the first frame update
    void Start()
    {
        testLog.GetComponent<Text>().text = "test input";
        testLog.GetComponent<Text>().text = GameGlobal.getInstance().getTest();

        gameModel = GameGlobal.getInstance().getGameModel();
        if (gameModel != null) {
            //Summon players
            List<Player> players = gameModel.getPlayers();
            //player 1
            NewPlayerController controller1 = loadInstance(players[0].getCharacter(), Vector3.zero, false).GetComponent<NewPlayerController>();
            //player 2
            NewPlayerController controller2 = loadInstance(players[1].getCharacter(), Vector3.one, false).GetComponent<NewPlayerController>();
            
            //Setting

            controller1.playerOne = true;
            controller1.setName(players[0].getName());
            controller2.setName(players[1].getName());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
