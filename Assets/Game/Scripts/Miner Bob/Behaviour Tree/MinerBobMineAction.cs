using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[TaskName("Miner Bob Mine")]
[TaskCategory("Miner Bob")]
[TaskDescription("Miner Bob work and mine for gold")]
public class MinerBobMineAction : MinerBobBaseAction
{
    public SharedFloat decreaseHealth = 1.0f;
    public SharedFloat mineRate = 1.0f;
    public SharedFloat fatigueRate = 1.0f;
    public SharedFloat thirstRate = 1.0f;

    public override TaskStatus OnUpdate()
    {
        base.OnUpdate();

        minerBob.Mine(mineRate.Value, fatigueRate.Value, thirstRate.Value);
        minerBob.TakeDamage(decreaseHealth.Value);
        Debug.Log($"Work Work Work....");

        return TaskStatus.Running;
    }

    public override void OnReset()
    {
        base.OnReset();

        mineRate.Value = 1.0f;
        fatigueRate.Value = 1.0f;
        thirstRate.Value = 1.0f;
    }
}
