using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MinerBobBaseConditional : Conditional
{
    protected MinerBob minerBob;

    public override void OnAwake()
    {
        minerBob = gameObject.GetComponent<MinerBob>();
        Debug.Assert(minerBob != null, $"{gameObject.name} - Behaviour tree requires a MinerBob component");
    }
}
