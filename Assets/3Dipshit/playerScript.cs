using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerScript : MonoBehaviour
{
    Animator anim;
    Rigidbody rb;
    public GameObject cameraObject;
    public float camSpeed;
    public KeyCode forward, backward, left, right, jump, crouch;
    public float jumpForce;
    public float movementSpeed;
    Quaternion wantedDirection, camDirection;
    Vector3 debugEulerAngles;
    Vector3 resetPos;

    // Start is called before the first frame update
    void Start()
    {
        wantedDirection = transform.rotation;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Resetto();
        }
        if (Input.GetKey(forward))
        {
            wantedDirection = Quaternion.Euler(0, 0, 0);
            anim.SetFloat("InputY", 1);
        }
        if (Input.GetKey(backward))
        {
            wantedDirection = Quaternion.Euler(0, 180, 0);
            anim.SetFloat("InputY", -1);
        }
        if (Input.GetKey(left))
        {
            wantedDirection = Quaternion.Euler(0, 270, 0);
            anim.SetFloat("InputX", -1);
        }
        if (Input.GetKey(right))
        {
            wantedDirection = Quaternion.Euler(0, 90, 0);
            anim.SetFloat("InputX", 1);
        }
        if(Input.GetKey(forward) && Input.GetKey(right))
        {
            wantedDirection = Quaternion.Euler(0, 45, 0);
            anim.SetFloat("InputX", 1);
            anim.SetFloat("InputY", 1);
        }
        if (Input.GetKey(backward) && Input.GetKey(right))
        {
            wantedDirection = Quaternion.Euler(0, 135, 0);
            anim.SetFloat("InputX", 1);
            anim.SetFloat("InputY", -1);
        }
        if (Input.GetKey(backward) && Input.GetKey(left))
        {
            wantedDirection = Quaternion.Euler(0, 225, 0);
            anim.SetFloat("InputX", -1);
            anim.SetFloat("InputY", -1);
        }
        if (Input.GetKey(forward) && Input.GetKey(left))
        {
            wantedDirection = Quaternion.Euler(0, 315, 0);
            anim.SetFloat("InputX", 1);
            anim.SetFloat("InputY", 1);
        }
        if (Input.GetKey(forward) == false && Input.GetKey(backward) == false && Input.GetKey(left) == false && Input.GetKey(right) == false)
        {
            anim.SetFloat("InputX", 0);
            anim.SetFloat("InputY", 0);
        }
        else
        {
            wantedDirection = Quaternion.Euler(0, wantedDirection.eulerAngles.y + cameraObject.transform.rotation.eulerAngles.y, 0);
            transform.Translate(Vector3.forward * movementSpeed * 0.1f);
        }
        //camDirection = Quaternion.Euler(cameraObject.transform.rotation);

        transform.rotation = (Quaternion.Slerp(transform.rotation, wantedDirection, Time.deltaTime * camSpeed));

        debugEulerAngles = wantedDirection.eulerAngles;
    }

    private void OnCollisionStay(Collision other)
    {
        if(other.gameObject.tag == "Ground")
        {
            if (Input.GetKeyDown(jump))
            {
                rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
                anim.SetTrigger("jump");
            }
            anim.SetBool("inAir", false);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if(other.gameObject.tag == "Ground")
        {
            anim.SetBool("inAir", true);
        }
    }

    void Resetto()
    {
        transform.position = resetPos;
        rb.velocity = new Vector3(0, 0, 0);
    }
}