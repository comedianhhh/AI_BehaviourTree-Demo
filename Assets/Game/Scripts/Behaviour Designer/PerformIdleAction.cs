using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[TaskName("NPC Idle")]
[TaskCategory("Generic")]
[TaskDescription("The NPC will perform an idle action")]
public class PerformIdleAction : Action
{
    private Animator animator;
    private string[] idleAnimations = { "Idle1", "Idle2", "Idle3" };

    public override void OnAwake()
    {
        animator = gameObject.GetComponent<Animator>();

    }

    public override TaskStatus OnUpdate()
    {
        string animationToPlay = idleAnimations[Random.Range(0, idleAnimations.Length)];
        animator.SetTrigger(animationToPlay);
        return TaskStatus.Success;
    }
}
