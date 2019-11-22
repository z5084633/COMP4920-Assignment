using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class BuffCure : Buff
{
    private static int amount = 10;
    public BuffCure(NewPlayerController controller, DateTime startTime):base(controller, startTime, 10)
    {
    }
    public override Buff buffStart() {
        return this;
    }

    public override void buffUpdate()
    {
        this.getController().addHp(amount);
    }
    public override void buffEnd() {

    }

}