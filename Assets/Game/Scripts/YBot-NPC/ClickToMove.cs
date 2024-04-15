using BehaviorDesigner.Runtime;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(BehaviorTree))]
public class ClickToMove : MonoBehaviour
{
    public BehaviorTree behaviorTree;
    private SharedBool HasDestination;

    private SharedVector3 destination;

    public List<Vector3> destinations = new List<Vector3>();
    private const int maxDestinations = 5; // Maximum queue size

    private float cooldown = 1.5f;
    private float clickTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        behaviorTree = gameObject.GetComponent<BehaviorTree>();
        HasDestination = behaviorTree.GetVariable("HasDestination") as SharedBool;
        Debug.Assert(HasDestination != null, $"{gameObject.name}'s Behavior Tree requries a Shared Bool named HasDestination");
        destination = behaviorTree.GetVariable("Destination") as SharedVector3;
    }

    // Update is called once per frame
    void Update()
    {
        if (clickTimer > 0)
        {
            clickTimer -= Time.deltaTime;
        }
        if (Input.GetMouseButton(0) &&clickTimer <= 0 && destinations.Count < maxDestinations)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                AddDestination(hit.point);
                clickTimer = cooldown;
                HasDestination.Value = true;
            }
        }
        if (HasDestination.Value && destinations.Count > 0)
        {
            if (Vector3.Distance(transform.position, destination.Value) < 2f)
            {
                destinations.Remove(destination.Value);
                if (destinations.Count > 0)  // There are still points left to investigate
                {
                    destination.Value = FindClosestDestination(); // Update to the next closest point
  
                }

            }
        }
        if(destinations.Count == 0)
        {
            HasDestination.Value = false;
        }
    }
    Vector3 FindClosestDestination()
    {
        Vector3 currentLocation = transform.position;
        Vector3 closest = destinations
            .OrderBy(d => Vector3.Distance(currentLocation, d))
            .FirstOrDefault();
        return closest;
    }
    void AddDestination(Vector3 newDestination)
    {
        if (destinations.Count < maxDestinations)
        {
            destinations.Add(newDestination);
            if (destinations.Count == 1)
            {
                // If this is the first destination added, immediately sort and set it
                destination.Value = destinations[0];
            }
        }
    }
    private void OnDrawGizmos()
    {
        if (HasDestination != null && destinations.Count > 0)
        {
            Gizmos.color = Color.red;
            foreach (Vector3 point in destinations)
            {
                Gizmos.DrawSphere(point, 1f);
            }
        }
    }
}
