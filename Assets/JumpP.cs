using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpP : MonoBehaviour
{

    public float jumpForce = 150;
    public bool isJump = false;
    
    private Rigidbody2D rigid;

    private void Start()
    {


        rigid = GetComponent<Rigidbody2D>();

    }

    
    private void FixedUpdate()
    {


        if (Input.GetKey(KeyCode.Space))
        {
            if (isJump == false)
            {
                rigid.AddForce(Vector2.up * jumpForce);
                isJump = true;
            }

        }


    }
    
    
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Ground"))
        {
            isJump = false;
        }



    }



}
