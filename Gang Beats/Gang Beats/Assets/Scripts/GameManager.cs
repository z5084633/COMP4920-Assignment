using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Public Attributes
    public Text testLog;
    public Text winnerText;
    public GameObject panel;
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
    private List<Player> players;
    private NewPlayerController controller1;
    private NewPlayerController controller2;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        testLog.GetComponent<Text>().text = "test input";
        testLog.GetComponent<Text>().text = GameGlobal.getInstance().getTest();

        gameModel = GameGlobal.getInstance().getGameModel();
        if (gameModel != null) {
            //Summon players
            players = gameModel.getPlayers();
            //player 1
            controller1 = loadInstance(players[0].getCharacter(), Vector3.zero, false).GetComponent<NewPlayerController>();
            //player 2
            controller2 = loadInstance(players[1].getCharacter(), Vector3.one, false).GetComponent<NewPlayerController>();
            controller2.tag = "Player 2";
            
            //Setting

            controller1.playerOne = true;
            controller2.Flip();
            controller1.setName(players[0].getName());
            controller2.setName(players[1].getName());
        }
    }
    // Update is called once per frame
    void Update()
    {

        if (controller1.getHealth() < 0)
        {
            panel.SetActive(true);
            winnerText.text = players[1].getName() + " win!";
        }
        else if (controller2.getHealth() < 0) {
            panel.SetActive(true);
            winnerText.text = players[0].getName() + " win!";
        }
    }

    public void onClickBack()
    {
        SceneManager.LoadScene(2);
    }

}
