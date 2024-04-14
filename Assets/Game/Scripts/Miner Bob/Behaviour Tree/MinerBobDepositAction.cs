using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[TaskName("Miner Bob Deposit")]
[TaskCategory("Miner Bob")]
[TaskDescription("Miner Bob will deposit a percentage of gold")]
public class MinerBobDepositAction : MinerBobBaseAction
{
    public SharedFloat depositPercentage = 1.0f;

    public override TaskStatus OnUpdate()
    {
        base.OnUpdate();

        minerBob.Deposit(minerBob.currentGold * depositPercentage.Value);
        Debug.Log($"Deposited gold! I have {minerBob.bankAccount} in the bank, getting close to retirement");

        return TaskStatus.Success;
    }

    public override void OnReset()
    {
        base.OnReset();
        depositPercentage.Value = 1.0f;
    }
}
