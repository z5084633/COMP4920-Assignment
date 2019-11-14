using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Assets;


class GameModel
{
    private List<Player> players;
    public GameModel(List<Player> players)
    {
        this.players = players;
    }
    public List<Player> getPlayers() {
        return players;
    }
}

