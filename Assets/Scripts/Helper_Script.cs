using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper_Script : MonoBehaviour
{
    LayerMask groundLayerMask;

    public void FlipObject(bool flip)
    {
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();

        if (flip == true)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }
    public bool DoRayCollisionCheck(float xoffs, float yoffs)
    {
        float rayLength = 0.5f;
        bool groundCheck;

        Vector3 offset = new Vector3(xoffs, yoffs, 0);

        RaycastHit2D hit;


        hit = Physics2D.Raycast(transform.position + offset, -Vector2.up, rayLength, groundLayerMask);

        Color hitColor = Color.white;


        if (hit.collider != null)
        {
            print("Player has collided with Ground layer");
            hitColor = Color.green;
            groundCheck = true;
        }
        else
        {
            groundCheck = false;
        }

        Debug.DrawRay(transform.position + offset, -Vector2.up * rayLength, hitColor);

        return groundCheck;


    }
    ////public void Patrol()
    //{
    //    Transform groundDetection;

    //    transform.Translate(Vector2.right * speed * Time.deltaTime);

    //    RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance);
    //    if(groundInfo.collider == false)
    //    {
    //        if(movingRight == true)
    //        {
    //            transform.eulerAngles = new Vector3(0, -180, 0);
    //            movingRight = false;
    //        }
    //        else
    //        {
    //            transform.eulerAngles = new Vector3(0, 0, 0);
    //            movingRight = true;
    //        }
    //    }

    void Start()
    {
        groundLayerMask = LayerMask.GetMask("Ground");    
    }
}
