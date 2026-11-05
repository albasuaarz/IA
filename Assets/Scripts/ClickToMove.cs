using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class ClickToMove : MonoBehaviour
{
    NavMeshAgent m_Agent;
    Animator m_Animator;

    [SerializeField] LayerMask groundLayer;
    [SerializeField] float speedThreshold = 0.1f; // Umbral más sensible

    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        m_Animator = GetComponent<Animator>();

        // Evita que el agente se quede intentando llegar a un punto imposible
        m_Agent.stoppingDistance = 0.5f;
    }

    void Update()
    {
        // 1. Solo disparamos el Raycast cuando se HACE clic (no mientras se mantiene)
        // Si prefieres mantener presionado, mantén 'isPressed' pero usa un temporizador.
        if (Mouse.current.leftButton.wasPressedThisFrame && !Keyboard.current.leftShiftKey.isPressed)
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, groundLayer))
            {
                m_Agent.SetDestination(hit.point);
            }
        }

        // --- SOLUCIÓN PARA LA ANIMACIÓN ---

        // Usamos la magnitud de la velocidad, pero también comprobamos si falta mucho para llegar
        // 'remainingDistance' es más fiable que la velocidad para saber si el agente "quiere" moverse.
        bool isMoving = m_Agent.velocity.sqrMagnitude > speedThreshold && m_Agent.remainingDistance > m_Agent.stoppingDistance;

        if (!m_Agent.pathPending)
        {
            m_Animator.SetBool("Running", isMoving);
        }
    }
}