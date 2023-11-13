using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    private Rigidbody rbCharacter;
    private float jumpForce = 40f;
    private float moveForce  = 2f;
    private bool bCollision = false;
    public Animator aCharacter;
    // Start is called before the first frame update
    void Start()
    {
        rbCharacter = GetComponent<Rigidbody>();
        aCharacter = GetComponent<Animator>();
        Physics.gravity = new Vector3(0, -14, 0);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            Move();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Rotate180(0);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Rotate180(180);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Wall"))
        {
            bCollision = true;
            aCharacter.SetBool("jump", false);
        }
            
    }

    private void OnCollisionExit(Collision collision)
    {
        bCollision = false;
    }

    private void Jump()
    {
        if (bCollision)
        {            
            rbCharacter.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            aCharacter.SetBool("jump", true);
        }
    }
    private void Move()
    {
        transform.Translate(Vector3.right * Time.deltaTime * moveForce);        
    }
    private void Rotate180(float direction)
    {
        transform.rotation = Quaternion.Euler(0f, direction, 0f);
    }
}
