using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Assets;
class GameGlobal
{
    // Singleton 

    private static GameGlobal instance = null;
    public static GameGlobal getInstance() {
        if (instance == null) {
            instance = new GameGlobal();
        }
        return instance;
    }

    private String test = "";
    private GameModel gameModel;
    GameGlobal() {
    }
    public void setTest(String str) {
        test = str;
    }
    public String getTest() {
        return test;
    }
    public void setGameModel(GameModel gameModel) {
        this.gameModel = gameModel;
    }
    public GameModel getGameModel() {
        return gameModel;
    }
}

