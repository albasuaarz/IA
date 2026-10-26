using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class AITarget : MonoBehaviour
{

    public Transform Target;
    public float AttackDistance;

    private NavMeshAgent m_Agent;

    private Animator m_Animator;
    private float m_Distance;

    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        m_Animator = GetComponent<Animator>();
    }

   
    void Update()
    {
       // m_Distance = Vector3.Distance(trans);
        
    }
}
