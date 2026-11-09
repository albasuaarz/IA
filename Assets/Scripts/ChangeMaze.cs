using Unity.AI.Navigation;
using UnityEngine;

public class ChangeMaze : MonoBehaviour
{
    public GameObject[] wallsToRemove;
    public GameObject[] wallsToAdd;
    public NavMeshSurface[] m_NavMeshSurfaces;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);

            if (other.CompareTag("Player")) {
                for (int i = 0; i < wallsToRemove.Length; i++) {
                    wallsToRemove[i].SetActive(false);
                }
                for (int i = 0; i < wallsToAdd.Length; i++)
                {
                    wallsToAdd[i].SetActive(true);
                }
                for (int i = 0; i < m_NavMeshSurfaces.Length; i++)
                {
                    m_NavMeshSurfaces[i].UpdateNavMesh(m_NavMeshSurfaces[i].navMeshData);
                }
                Destroy(gameObject);
            }
        }
    }
