using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class BuffSpeedUp : Buff
{
    private float speed;
    public BuffSpeedUp(NewPlayerController controller, DateTime startTime) : base(controller, startTime, 10)
    {
    }
    public override Buff buffStart()
    {
        this.speed = getController().speed;
        getController().speed += this.speed;
        return this;
    }

    public override void buffUpdate()
    {
    }
    public override void buffEnd()
    {
        getController().speed -= this.speed;
    }

}