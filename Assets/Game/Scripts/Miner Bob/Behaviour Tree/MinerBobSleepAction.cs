using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[TaskName("Miner Bob Sleep")]
[TaskCategory("Miner Bob")]
[TaskDescription("Miner Bob sleep")]
public class MinerBobSleepAction : MinerBobBaseAction
{
    public SharedFloat decreaseHealth = 1.0f;

    [BehaviorDesigner.Runtime.Tasks.Tooltip("Decreases the fatigue level (negative is good)")]
    public SharedFloat restSpeed = -1.0f;

    public override TaskStatus OnUpdate()
    {
        base.OnUpdate();

        minerBob.TakeDamage(decreaseHealth.Value);
        minerBob.Sleep(restSpeed.Value);
        Debug.Log($"Getting some much needed and maybe deserved rest");

        return TaskStatus.Success;
    }

    public override void OnReset()
    {
        base.OnReset();

        restSpeed.Value = -1.0f;
    }
}
