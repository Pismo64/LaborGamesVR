using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;

public class Bot4HandleDeath : Conditional
{
    private float lastUpdate;
    public Bot4Script bot;

    public override TaskStatus OnUpdate()
    {
        if (Time.time - lastUpdate >= 1f)
        {
            if (bot.health <= 0)
            {
                bot.Explode();
                return TaskStatus.Success;
            }

            //bot.TakeDamage(10);
            lastUpdate = Time.time;
        }

        return TaskStatus.Running;

    }
}
