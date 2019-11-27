using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dipshittte : MonoBehaviour
{
    public GameObject rotationBuddy;
    public Vector3 wawa;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();   
    }
    // Update is called once per frame
    void Update()
    {
        wawa = rotationBuddy.transform.position;
        anim.SetFloat("LookX", wawa.x - transform.position.x);
        anim.SetFloat("LookY", wawa.z - transform.position.z);
    }
}