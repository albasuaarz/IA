using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

namespace Unity.AI.Navigation.Samples
{
    /// <summary>
    /// Use physics raycast hit from mouse click to set agent destination
    /// </summary>
    
    [RequireComponent(typeof(NavMeshAgent))]
    public class ClickToMove : MonoBehaviour
    {
        NavMeshAgent m_Agent;
        Animator m_Animator;
        RaycastHit m_HitInfo = new RaycastHit();
        [SerializeField] LayerMask groundLayer;
        [SerializeField] float speedThreshold = 0.1f; //Umbral que permite moverse

        void Start()
        {
            m_Agent = GetComponent<NavMeshAgent>();
            m_Animator = GetComponent<Animator>();
            //Evitamos que se quede intentando llegar a un sitio imposible
            m_Agent.stoppingDistance = 0.5f;
        }

        void Update()
        {
            //Cuando se hace clic, Raycast se mueve. No mientras se mantiene, para ello, debes añadir un temporizador a 'isPressed'
            if (Mouse.current.leftButton.wasPressedThisFrame && !Keyboard.current.leftShiftKey.isPressed) {
                Vector2 mousePosition = Mouse.current.position.ReadValue();
                Ray ray = Camera.main.ScreenPointToRay(mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, groundLayer)) {
                    m_Agent.SetDestination(hit.point);
                }
            }

            //Solución para la animación,  usamos la magnitud de velocidad pero tambien comprobamos si falta mucho para llegar. remainingDistance es mas fiable que la velocidad para aber si el agente quiere moverse

            bool isMoving = m_Agent.velocity.sqrMagnitude > speedThreshold && m_Agent.remainingDistance > m_Agent.stoppingDistance;
            if (!m_Agent.pathPending)
            {
                m_Animator.SetBool("Running", isMoving);
            }
            //if (Input.GetMouseButtonDown(0) && !Input.GetKey(KeyCode.LeftShift))
            //{
             //   var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
               // if (Physics.Raycast(ray.origin, ray.direction, out m_HitInfo))
                //    m_Agent.destination = m_HitInfo.point;
            //}
        }
    }
}