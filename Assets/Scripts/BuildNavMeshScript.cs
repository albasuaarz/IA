using System.Collections;
using Unity.AI.Navigation;
using UnityEngine;

public class BuildNavMeshScript : MonoBehaviour
{
    private NavMeshSurface m_NaneMeshSurface;
    public GameObject[] Characters;
    public Transform[] SpawnPoint;

    public void Awake()
    {
        //Characters = new GameObject[Characters.Length];
        m_NaneMeshSurface = GetComponent<NavMeshSurface>();
    }

    void Start()
    {
        m_NaneMeshSurface.BuildNavMesh();
        StartCoroutine(SpawnCharacter());
    }


    IEnumerator SpawnCharacter() { 

        yield return new WaitForEndOfFrame();
        for (int i = 0; i < Characters.Length; i++) {
            Instantiate(Characters[i], SpawnPoint[i].position, SpawnPoint[i].rotation);
        }
    }

}
