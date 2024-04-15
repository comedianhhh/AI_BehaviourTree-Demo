using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[TaskName("NPC Patrol")]
[TaskCategory("Generic")]
[TaskDescription("The NPC will patrol a list of game objects for waypoints")]
public class PatrolAction : MoveToGoalAction
{
    public SharedGameObjectList waypoints;
    public SharedBool triggerIdle;
    public bool loop = true;
    private int index = 0;
    public SharedInt numOfWaypoints = 0;
    public override void OnStart()
    {
        base.OnStart();
        if (index < waypoints.Value.Count)
        {
            agent.isStopped = false;
            agent.SetDestination(waypoints.Value[index].transform.position);
        }
    }
    
    public override TaskStatus OnUpdate()
    {
        TaskStatus baseStatus = base.OnUpdate();

        if (baseStatus != TaskStatus.Running && index != waypoints.Value.Count)
        {
            index++;
            numOfWaypoints.Value++;

            if (numOfWaypoints.Value % 3 == 0)
            {
                triggerIdle.Value = true;
                return TaskStatus.Failure;
            }

            if (index >= waypoints.Value.Count && loop == true)
            {
                index = 0;
            }

            if (index < waypoints.Value.Count)
            {
                agent.SetDestination(waypoints.Value[index].transform.position);
                return TaskStatus.Running;
            }
        }

        return baseStatus;
    }
}
