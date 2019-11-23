using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets;
using System.IO;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CharacterSelector {
    private List<GameObject> characterList;
    private int currCharacter;
    public CharacterSelector(List<GameObject> characterList) {
        this.characterList = characterList;
        foreach (GameObject obj in this.characterList) {
            obj.SetActive(false);
        }
        this.currCharacter = 0;
        this.characterList[0].SetActive(true);
    }
    public void shiftCurrCharacter(int shift) {
        characterList[currCharacter].SetActive(false);
        currCharacter = (currCharacter + shift + characterList.Count) % characterList.Count;
        characterList[currCharacter].SetActive(true);
    }
    public int getCurrCharacter() {
        return currCharacter;
    }
}
public class ItemsSelector
{
    GameObject itemSelector;
    private List<GameObject> itemsList;
    private int currItem;


    public ItemsSelector(List<GameObject> itemsList, GameObject itemSelector, int x, int y)
    {
        int i = 0;
        this.itemSelector = itemSelector;
        this.itemSelector.transform.SetParent(GameObject.Find("Canvas").gameObject.transform);
        this.itemsList = itemsList;
        foreach (GameObject obj in this.itemsList)
        {
            int t = i;
            Button currButton = obj.GetComponent<Button>();
            currButton.onClick.AddListener(delegate ()
            {
                setCurrItem(t);
            });
            obj.transform.SetParent(GameObject.Find("Canvas").gameObject.transform);
            obj.transform.localPosition = new Vector3(x + 50 * i, y, 0);
            i++;
        }
        setCurrItem(0);


    }
    public void setCurrItem(int i) {
        itemSelector.transform.localPosition = itemsList[i].transform.localPosition;
        this.currItem = i;
    }
    public int getCurrItem() {
        return this.currItem;
    }
}
public class SelectionManagerScript : MonoBehaviour
{


    private GameObject loadInstance(string path, Vector3 location, bool freeze = false) {
        GameObject instance = (GameObject)Instantiate(Resources.Load(path), location, transform.rotation);
        if (freeze)
        {
            Rigidbody2D rigidbody = instance.GetComponent<Rigidbody2D>();
            rigidbody.constraints |= RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX;
        }
        return instance;
    }
    private List<GameObject> loadInstanceFromList(List<string> paths, Vector3 location, bool freeze = false) {
        List<GameObject> objList = new List<GameObject>();
        foreach (string path in paths) {
            objList.Add(loadInstance(path, location, freeze));
        }
        return objList;
    }
    #region Public Attributes
    public InputField player1Name;
    public InputField player2Name;
    #endregion

    GameLoader gameLoader;
    CharacterSelector player1Select;
    CharacterSelector player2Select;

    ItemsSelector player1ItemsSelect;
    ItemsSelector player2ItemsSelect;
    // Start is called before the first frame update
    void Start()
    {
        gameLoader = new GameLoader();
        player1Select = new CharacterSelector(loadInstanceFromList(gameLoader.getCharacterList(), new Vector3(-6, 0, 0), true));
        player2Select = new CharacterSelector(loadInstanceFromList(gameLoader.getCharacterList(), new Vector3(6, 0, 0), true));
        player1ItemsSelect = new ItemsSelector(
            loadInstanceFromList(gameLoader.getItemsList(), new Vector3(-6, 0, 0), false),
            loadInstance(gameLoader.getItemSelectIndicator(), new Vector3(0, 0, 0)),
            -400,
            -150);
        player2ItemsSelect = new ItemsSelector(
            loadInstanceFromList(gameLoader.getItemsList(), new Vector3(6, 0, 0), false),
            loadInstance(gameLoader.getItemSelectIndicator(), new Vector3(0, 0, 0)),
            200, 
            -150);
        // Set up default name
        player1Name.SetTextWithoutNotify("Player1");
        player2Name.SetTextWithoutNotify("Player2");

    }
    public void player1Shift(int shift)
    {
        player1Select.shiftCurrCharacter(shift);
    }
    public void player2Shift(int shift)
    {
        player2Select.shiftCurrCharacter(shift);
    }
    public void onClickStart() {
        GameGlobal.getInstance().setTest(player1Name.text + " VS " + player2Name.text);
        List<Player> players = new List<Player>();
        List<String> characterNames = gameLoader.getCharacterList();
        List<String> itemsNames = gameLoader.getItemsList();
        players.Add(new Player(
            player1Name.text, 
            characterNames[player1Select.getCurrCharacter()],
            itemsNames[player1ItemsSelect.getCurrItem()]
            ));
        players.Add(new Player(
            player2Name.text, 
            characterNames[player2Select.getCurrCharacter()],
            itemsNames[player2ItemsSelect.getCurrItem()]
            ));
        GameGlobal.getInstance().setGameModel(gameLoader.createGame(players));
        SceneManager.LoadScene(1);
    }
    
    // Update is called once per frame
    void Update()
    {
    }
}
