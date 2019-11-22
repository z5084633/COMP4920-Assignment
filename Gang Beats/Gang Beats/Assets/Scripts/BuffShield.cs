using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class BuffShield : Buff
{
    public BuffShield(NewPlayerController controller, DateTime startTime) : base(controller, startTime, 10)
    {
    }
    public override Buff buffStart()
    {
        getController().shieled = 1;
        return this;
    }

    public override void buffUpdate()
    {
    }
    public override void buffEnd()
    {
        getController().shieled = 0;
    }

}