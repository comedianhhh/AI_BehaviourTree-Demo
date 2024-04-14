using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[TaskName("Miner Bob Should Deposit")]
[TaskCategory("Miner Bob")]
[TaskDescription("Returns Success if Minder Bob needs to deposit gold")]
public class MinerBobShouldDepositCondition : MinerBobBaseConditional
{
    public override TaskStatus OnUpdate()
    {
        return (minerBob.maxCarryNuggets <= minerBob.currentGold ? TaskStatus.Success : TaskStatus.Failure);
    }
}
