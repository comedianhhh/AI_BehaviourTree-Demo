using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MinerBobBaseAction : Action
{
    protected MinerBob minerBob;

    public override void OnAwake()
    {
        minerBob = gameObject.GetComponent<MinerBob>();
        Debug.Assert(minerBob != null, $"{gameObject.name} - Behaviour tree requires a MinerBob component");
    }
}
