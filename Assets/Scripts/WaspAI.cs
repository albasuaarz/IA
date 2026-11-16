using UnityEngine;
using UnityEngine.AI;

public class WaspAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;
    private Transform target;
    private float FlyingHeight;
    public float MoveSpeed;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
        //velocidad de aleteo aleatorio
        float randomAnimSpeed = Random.Range(0.1f, 0.5f);
        float newAnimSpeed = Mathf.Round(randomAnimSpeed * 10) / 10;
        animator.speed = newAnimSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
