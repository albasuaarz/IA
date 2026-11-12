using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class AiTargetChomperTerrain : MonoBehaviour
{
    private Transform Target;
    public float AttackDistance = 1.0f;

    private NavMeshAgent m_Agent;
    private Animator m_Animator;
    public float m_Distance;


    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").transform;
        m_Agent = GetComponent<NavMeshAgent>();
        m_Animator = GetComponent<Animator>();
        m_Animator.speed = Random.Range(0.6f, 1.6f);
        m_Agent.avoidancePriority = Random.Range(10, 65);
        float RadiusValue = Random.Range(0.5f, 0.8f);
        m_Agent.radius = Mathf.Round(RadiusValue * 10) * 0.1f;
    }

    void Update()
    {
        m_Distance = Vector3.Distance(transform.position, Target.position);
        if (m_Distance < AttackDistance) {
            m_Agent.isStopped = true;
            m_Animator.SetBool("Attack", true);
        } else {
            m_Agent.isStopped = false;
            m_Animator.SetBool("Attack", false);
            m_Agent.destination = Target.position;
        }
    }
}
