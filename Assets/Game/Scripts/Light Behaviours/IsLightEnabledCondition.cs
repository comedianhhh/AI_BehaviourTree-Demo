using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[TaskName("Is Light Enabled")]
[TaskCategory("Custom/Light")]
[TaskDescription("Checks to see if the light component is enabled")]
public class IsLightEnabledCondition : Conditional
{
    [BehaviorDesigner.Runtime.Tasks.Tooltip("Reference to the light Game Object")]
    public SharedGameObject LightGameObject;

    private Light light;

    public override void OnAwake()
    {
        if (LightGameObject != null && LightGameObject.Value != null)
        {
            light = LightGameObject.Value.GetComponent<Light>();
        }
    }

    public override TaskStatus OnUpdate()
    {
        if (light == null)
        {
            Debug.LogError($"{gameObject.name} requries a Light component variable");
            return TaskStatus.Failure;
        }

        return (light.enabled == true ? TaskStatus.Success : TaskStatus.Failure);
    }

    public override void OnReset()
    {
        LightGameObject.Value = null;
    }

}
