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
        Debug.Log("You've been stabbed");
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
        anim.SetBool("Walk", false);
        anim.SetBool("Jump", false);
        if (Input.GetKey(KeyCode.LeftArrow) == true)
        {
            print("User pressed left"); transform.position = new Vector2(transform.position.x - (2 * Time.deltaTime), transform.position.y);
            anim.SetBool("Walk", true);
            helper.FlipObject(true);
        }

        if (Input.GetKey(KeyCode.RightArrow) == true)
        {
            print("User pressed right"); transform.position = new Vector2(transform.position.x + (2 * Time.deltaTime), transform.position.y);
            anim.SetBool("Walk", true);
            helper.FlipObject(false);
        }

        DoJump();

        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetTrigger("Attack");
        }
        Debug.Log(transform.position);
    }


    void DoJump()
    {
        bool groundCheck = helper.DoRayCollisionCheck(1f, 0f);

        if (Input.GetKeyDown(KeyCode.UpArrow) && groundCheck == true)
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Jump", true);
            rb.AddForce(new Vector3(0, 10f, 0), ForceMode2D.Impulse);
        }
    }

}
