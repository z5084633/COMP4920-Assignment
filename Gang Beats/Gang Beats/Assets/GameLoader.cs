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
        public GameLoader(){
            // All characters
            characterList =  new List<string>();
            characterList.Add("PreFabs/Player0");
            characterList.Add("PreFabs/Player1");
        }
        public List<String> getCharacterList() {
            return this.characterList;
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
