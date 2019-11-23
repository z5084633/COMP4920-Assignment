using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets
{
    class GameLoader
    {
        private List<String> characterList;
        private List<String> itemsList;
        private String itemSelectIndicator;
        public GameLoader(){
            // All characters
            characterList =  new List<string>();
            characterList.Add("PreFabs/Player1");
            characterList.Add("PreFabs/Player2");
            characterList.Add("PreFabs/Player6");
            characterList.Add("PreFabs/Player4");
            // All items
            itemSelectIndicator = "PreFabs/Items/Selected";
            itemsList = new List<string>();
            itemsList.Add("PreFabs/Items/RedPotion");
            itemsList.Add("PreFabs/Items/YellowPotion");
            itemsList.Add("PreFabs/Items/BluePotion");
            itemsList.Add("PreFabs/Items/GreenPotion");
        }
        public List<String> getCharacterList() {
            return this.characterList;
        }

        public List<String> getItemsList()
        {
            return this.itemsList;
        }
        public String getItemSelectIndicator() {
            return itemSelectIndicator;
        }
        /* 
         * Return a new game
         * Input: player character, name, skills, etc
         * 
        */
        public GameModel createGame(List<Player> players) {
            GameModel gameModel = new GameModel(players);

            return gameModel;
        }



    }
}
