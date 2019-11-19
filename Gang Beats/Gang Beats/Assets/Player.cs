using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Assets;
class Player
{
    private string name;
    private string character;
    private string itemName;
    public Player(String name, String character, string itemName) {
        this.name = name;
        this.character = character;
        this.itemName = itemName;
    }
    public String getName() {
        return name;
    }
    public String getCharacter()
    {
        return character;
    }
    public String getItemName()
    {
        return itemName;
    }
}
