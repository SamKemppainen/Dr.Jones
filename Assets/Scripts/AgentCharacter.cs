using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Base class for all agent characters; players and NPCs
/// </summary>
public class AgentCharacter : MonoBehaviour
{
    protected NavMeshAgent agent => GetComponent<NavMeshAgent>();
    protected Animator animator => GetComponent<Animator>();

    protected virtual void Awake() {}

    protected virtual void Update() 
    {
        animator.SetFloat("AgentVelocityMagnitude", agent.velocity.magnitude);
    }
}
