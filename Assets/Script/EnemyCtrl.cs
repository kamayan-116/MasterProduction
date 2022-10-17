using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCtrl : MonoBehaviour
{
    enum AIState
    {
        Go,
        Push,
        Nothing,
    };


    NavMeshAgent navMeshAgent;
    [SerializeField] Transform Player;
    AIState currentState = AIState.Nothing;
    float distance;
    public float pushPower = 2.0f;
    bool isPush = false;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(this.transform.position, Player.transform.position);

        if(distance > 1.0f)
        {
            currentState = AIState.Go;
        }
        else
        {
            currentState = AIState.Push;
        }

        if(currentState == AIState.Go)
        {
            // navMeshAgent.SetDestination(Player.position);
            navMeshAgent.destination = Player.transform.position;
        }

        if(currentState == AIState.Push)
        {
            isPush = true;
        }
        
        Debug.Log(currentState);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(isPush)
        {
            Rigidbody rb = hit.collider.attachedRigidbody;

            if(rb == null || rb.isKinematic) return;

            Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

            rb.velocity = pushDir * pushPower;
        }   
    }
}
