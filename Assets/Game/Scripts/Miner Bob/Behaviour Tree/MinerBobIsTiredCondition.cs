using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[TaskName("Is Miner Bob Tired")]
[TaskCategory("Miner Bob")]
[TaskDescription("Returns Success if Miner Bob is tired")]
public class MinerBobIsTiredCondition : MinerBobBaseConditional
{
    public override TaskStatus OnUpdate()
    {
        return (minerBob.tirednessThreshold <= minerBob.fatigueLevel ? TaskStatus.Success : TaskStatus.Failure);
    }
}
