using UnityEngine;
using Unity.AI.Navigation;

public class StepScript : MonoBehaviour
{
    private NavMeshSurface[] m_StepsSurface;
    public bool HaveAccess = false;

    void Start()
    {
        m_StepsSurface = GetComponentsInChildren<NavMeshSurface>();
        m_StepsSurface[1].enabled = false;
    }

    void Update()
    {
        if (HaveAccess) {
            if (m_StepsSurface[1].isActiveAndEnabled == false) {
                m_StepsSurface[1].enabled = true;
            }
        }        
    }
}
