using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[TaskName("Miner Bob Drink")]
[TaskCategory("Miner Bob")]
[TaskDescription("Miner Bob will drink and spend his precious gold")]
public class MinerBobDrinkAction : MinerBobBaseAction
{
    public SharedFloat decreaseHealth = 1.0f;
    public SharedFloat decreaseThirstRate = -1.5f;
    public SharedFloat costOfDrink = 1.0f;

    public override TaskStatus OnUpdate()
    {
        base.OnUpdate();

        minerBob.TakeDamage(decreaseHealth.Value);
        minerBob.Drink(decreaseThirstRate.Value, costOfDrink.Value);
        Debug.Log($"Sipping on my Tequila, enjoying a break");

        return TaskStatus.Success;
    }

    public override void OnReset()
    {
        base.OnReset();

        decreaseThirstRate.Value = -1.5f;
        costOfDrink.Value = -1.0f;
    }

}
