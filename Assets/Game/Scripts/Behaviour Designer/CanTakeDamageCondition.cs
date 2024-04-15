using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[TaskName("Can Take Damage")]
[TaskCategory("Generic")]
[TaskDescription("Returns Success if it go into the red wall")]
public class CanTakeDamageCondition : Conditional
{
    public SharedVector2 redWallPosition;
    public SharedGameObject guard;

    public override TaskStatus OnUpdate()
    {   
        if(guard!=null)
        {
            Vector2 guardPosition = new Vector2(guard.Value.transform.position.x, guard.Value.transform.position.z);
            if(Vector2.Distance(guardPosition, redWallPosition.Value) < 5f)
            {
                return TaskStatus.Success;
            }
        }
        return TaskStatus.Failure;
    }


}
