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
        bool groundCheck = false;

        Vector3 offset = new Vector3(xoffs, yoffs, 0);

        RaycastHit2D hit;


        hit = Physics2D.Raycast(transform.position + offset, -Vector2.up, rayLength, groundLayerMask);

        Color hitColor = Color.white;


        if (hit.collider != null)
        {
            hitColor = Color.green;
            groundCheck = true;
        }
        Debug.DrawRay(transform.position + offset, -Vector2.up * rayLength, hitColor);
        return groundCheck;
    }

    void Start()
    {
        groundLayerMask = LayerMask.GetMask("Ground");    
    }
}
