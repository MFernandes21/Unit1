using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;
    public LayerMask groundLayer;
    private void OnCollisionEnter2D(Collision2D other)
    {

    }
    Helper_Script helper;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        print("Start");
        sr = GetComponent<SpriteRenderer>();
        helper = gameObject.AddComponent<Helper_Script>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("walk", false);
        anim.SetBool("jump", false);
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            transform.position = new Vector2(transform.position.x - (2 * Time.deltaTime), transform.position.y);
            anim.SetBool("walk", true);
            helper.FlipObject(true);
        }

        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            transform.position = new Vector2(transform.position.x + (2 * Time.deltaTime), transform.position.y);
            anim.SetBool("walk", true);
            helper.FlipObject(false);
        }

        DoJump();

        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetTrigger("attack");
        }
    }


    void DoJump()
    {
        bool groundCheck = helper.DoRayCollisionCheck(0f, 0f);

        if (Input.GetKeyDown(KeyCode.UpArrow) && groundCheck == true)
        {
            anim.SetBool("walk", false);
            anim.SetBool("jump", true);
            rb.AddForce(new Vector3(0, 5f, 0), ForceMode2D.Impulse);
        }
    }

}
