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
        [SerializeField] float speedThreshold = 0.1f;

        void Start()
        {
            m_Agent = GetComponent<NavMeshAgent>();
            m_Animator = GetComponent<Animator>();
            m_Agent.stoppingDistance = 0.5f;
        }

        void Update()
        {
            if (Mouse.current.leftButton.wasPressedThisFrame && !Keyboard.current.leftShiftKey.isPressed) {
                Vector2 mousePosition = Mouse.current.position.ReadValue();
                Ray ray = Camera.main.ScreenPointToRay(mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, groundLayer)) {
                    m_Agent.SetDestination(hit.point);
                }
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