using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[TaskName("Wait for 3waypoins")]
[TaskCategory("Generic")]
[TaskDescription("wait pass 3 waypoints")]
public class CheckForIdle : Conditional
{
    public SharedBool triggerIdle;

    public override TaskStatus OnUpdate()
    {
        if(triggerIdle.Value==true)
        {
            triggerIdle.Value = false;
            return TaskStatus.Success;
        }
        else
        {
            return TaskStatus.Failure;
        }

    }
}
