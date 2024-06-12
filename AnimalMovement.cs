using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class AnimalMovement : MonoBehaviour
{
    private Vector3 target;
    [Serialize]private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        SetTargetPosition();
      
    }
    private void SetTargetPosition()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition) + " " + (transform.position));
            SetAgentPosition();

        }
    }
    private void SetAgentPosition()
    {
            agent.SetDestination(new Vector3(target.x,target.y, transform.position.z));
    }
}

