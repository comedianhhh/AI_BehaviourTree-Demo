using BehaviorDesigner.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BehaviorTree))]
public class ClickToMove : MonoBehaviour
{
    private BehaviorTree behaviorTree;
    private SharedBool mouseButtonClicked;
    private SharedVector3 destination;

    // Start is called before the first frame update
    void Start()
    {
        behaviorTree = GetComponent<BehaviorTree>();
        mouseButtonClicked = behaviorTree.GetVariable("MouseButtonClicked") as SharedBool;
        Debug.Assert(mouseButtonClicked != null, $"{gameObject.name}'s Behavior Tree requries a Shared Bool named MouseButtonClicked");
        destination = behaviorTree.GetVariable("Destination") as SharedVector3;
    }

    // Update is called once per frame
    void Update()
    {
        mouseButtonClicked.Value = false;
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                mouseButtonClicked.Value = true;
                destination.Value = hit.point;
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (mouseButtonClicked != null)
        {
            if (destination.Value != Vector3.zero)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(destination.Value, 1f);

            }
        }
    }
}
