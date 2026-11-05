
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class AITargetChomper : MonoBehaviour
{

    [Header("Configyracion de las distancias")]
    public Transform target;
    public float attackDistance = 2.0f;
    public float chaseDistance = 10.0f;

    private NavMeshAgent m_Agent;
    private Animator m_Animator;
    private Vector3 m_StartingPoint;


    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        m_Animator = GetComponent<Animator>();
        m_StartingPoint = transform.position;
    }

    void Update()
    {
        if (target == null) return;
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        //1. Estado de ATAQUE (jugador en rango de golpeo)

        if (distanceToTarget <= attackDistance) {
            m_Agent.isStopped = true;
            m_Animator.SetBool("Attack", true);
        }

        //2. Estado de PERSECUCIÓN (jugador en rango de persecución)
        else if (distanceToTarget <= chaseDistance)
        {
            m_Agent.isStopped = false;
            m_Animator.SetBool("Attack", false);
            m_Agent.SetDestination(target.position);
        }
        //3. Estado de RETORNO (jugador ha esscapado)
        else
        {
            m_Agent.isStopped = false;
            m_Animator.SetBool("Attack", false);
            m_Agent.SetDestination(m_StartingPoint);
        }
    }

    private void OnAnimatorMove()
    {
        if (!m_Animator.GetBool("Attack")) {
            m_Agent.speed = (m_Animator.deltaPosition / Time.deltaTime).magnitude;
        }
    }

    private void OnDrawGizmosSelected()
    {
        //Radio de ataque (Rojo)
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDistance);
        //Radio de persecución en amarillo
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, chaseDistance);
    }

}
