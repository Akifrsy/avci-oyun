using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarakterHareket : MonoBehaviour
{

    
    Rigidbody2D rgb;
    Vector3 velocity;
    public Animator animator;

    public int damage;

    float speedAmount = 5f;

    Vector2 forward;
    
    public Vector3 offset;

    bool faceRight = true;
    bool canAttack = true;

    RaycastHit2D hit;

    void Start()
    {

        rgb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        

    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.F) && canAttack)
        {
            Attack();
        }
    }
    
    
    void Update()
    {

        velocity = new Vector3(Input.GetAxis("Horizontal"), 0f);
        transform.position += velocity * speedAmount * Time.deltaTime;
        animator.SetFloat("hiz", Mathf.Abs(Input.GetAxis("Horizontal")));
        
        
    
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        
        


    }
     

    private void Attack()
    {
        canAttack = false;

        if (!faceRight)
        {
            forward = transform.TransformDirection(Vector2.right * -2);
        }
        else
        {
            forward = transform.TransformDirection(Vector2.right * 2);
        }

        RaycastHit2D hit = Physics2D.Raycast(transform.position + offset, forward, 1.0f);

        if (hit)
        {
            if (hit.transform.tag == "Dusman")
            {
                hit.transform.GetComponent<EnemyHealth>().GetDamage(damage);
            }
            else
            {
                Debug.Log("nothing to hit");
            }

        }


        animator.SetTrigger("attack");

        StartCoroutine(AttackDelay());
    }
    
    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(0.5f);
        canAttack = true;
    }



}
