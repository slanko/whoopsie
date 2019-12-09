using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class efef : MonoBehaviour
{
    NavMeshAgent nav;
    Vector3 navPos;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        changePosition();
    }

    void changePosition()
    {
        Invoke("changePosition", Random.Range(0.1f, 1f));
        navPos = Random.insideUnitSphere * Random.Range(5, 30) + transform.position;
        nav.SetDestination(navPos);
    }
}
