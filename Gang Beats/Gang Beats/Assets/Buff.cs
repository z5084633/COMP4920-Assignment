using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class Buff
{
    private DateTime startTime;
    private int duration;
    private int frequency;
    private NewPlayerController controller;
    private int lastTime;
    private int live;
    public Buff(NewPlayerController controller, DateTime startTime, int duration) {
        this.controller = controller;
        this.startTime = startTime;
        this.duration = duration;
        this.lastTime = getSec(startTime);
        this.live = 1;
    }
    static public int dateTimeToInt(DateTime dateTime) {
        return dateTime.Hour * 3600 + dateTime.Minute * 60 + dateTime.Second;
    }
    public NewPlayerController getController() {
        return controller;
    }
    public int getSec(DateTime currTime)
    {
        return duration - (dateTimeToInt(currTime) - dateTimeToInt(startTime));
    }
    public void update(DateTime currTime) {
        if (this.live == 0) {
            return;
        } 
        int curr = getSec(currTime);
        if (curr <= 0)
        {
            buffEnd();
            //controller.getBuffs().Remove(this);
            this.live = 0;
            return;
        }
        else {
            if (lastTime != curr)
            {
                //controller.Log("" + curr + "   " + lastTime);
                buffUpdate();
                lastTime = curr;
            }
        }

    }

    public abstract Buff buffStart();
    public abstract void buffUpdate();
    public abstract void buffEnd();
}

