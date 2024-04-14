using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

[TaskName("Toggle Light")]
[TaskCategory("Custom/Light")]
[TaskDescription("Enables/Disables the light component. Returns Success.")]
public class ToggleLightAction : Action
{
    [BehaviorDesigner.Runtime.Tasks.Tooltip("The objec to use, it should have a light component")]
    public SharedGameObject specifiedObject;

    private Light light;

    public override void OnAwake()
    {
        if (specifiedObject != null && specifiedObject.Value != null)
        {
            light = specifiedObject.Value.GetComponent<Light>();
        }
    }

    public override TaskStatus OnUpdate()
    {
        if (light == null)
        {
            Debug.LogError($"Specified Game Object {gameObject.name}does not have a light component");
            return TaskStatus.Failure;
        }

        light.enabled = !light.enabled;

        return TaskStatus.Success;
    }

    public override void OnReset()
    {
        if (specifiedObject != null)
        {
            specifiedObject.Value = null;
        }
    }
}
