using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dippe : MonoBehaviour
{
    public Animator anim;
    Rigidbody rb;
    public KeyCode up, down, left, right, attack, dodge, jump;
    public float moveSpeed, jumpForce;
    
    public bool canIMove;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canIMove == true)
        {
            if (Input.GetKey(left))
            {
                transform.rotation = new Quaternion(0, -180, 0, 0);
                anim.SetBool("running", true);
                transform.Translate(new Vector3(1, 0, 0) * moveSpeed);
            }
            if (Input.GetKey(right))
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
                anim.SetBool("running", true);
                transform.Translate(new Vector3(1, 0, 0) * moveSpeed);
            }
            if (Input.GetKey(left) == false && Input.GetKey(right) == false)
            {
                anim.SetBool("running", false);
            }
            if (Input.GetKey(left) && Input.GetKey(right))
            {
                anim.SetBool("running", false);
            }
            if (Input.GetKeyDown(jump))
            {
                if(anim.GetBool("grounded") == true)
                {
                    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                }
            }
            if (Input.GetMouseButton(0))
            {
                anim.SetBool("aim", true);
            }
            else
            {
                anim.SetBool("aim", false);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            anim.SetBool("grounded", true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            anim.SetBool("grounded", false);
        }
    }

    public void canMove()
    {
        canIMove = true;
    }

    public void cantMove()
    {
        canIMove = false;
    }
}
