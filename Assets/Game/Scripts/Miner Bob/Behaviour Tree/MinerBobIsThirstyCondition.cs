using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[TaskName("Is Miner Bob Thirsty")]
[TaskCategory("Miner Bob")]
[TaskDescription("Returns Success if Miner Bob is Thirsty")]
public class MinerBobIsThirstyCondition : MinerBobBaseConditional
{
    public override TaskStatus OnUpdate()
    {
        return (minerBob.thirstThreshold <= minerBob.thirstLevel ? TaskStatus.Success : TaskStatus.Failure);
    }
}
