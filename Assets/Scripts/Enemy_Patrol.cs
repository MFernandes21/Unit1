using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Enemy_Patrol : MonoBehaviour
{
    // Start is called before the first frame update
    Helper_Script helper;
    public float speed = 1f;
    public float distance = 1f;


    public Transform groundDetection;   

    void Start()
    {
        helper = gameObject.AddComponent<Helper_Script>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckEdges();
        Move();

    }


    void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void CheckEdges()
    {
        bool left, right;

        left = helper.DoRayCollisionCheck(-0.2f, 0);
        right = helper.DoRayCollisionCheck(0.2f, 0);

        if( speed > 0 )
        {
            if( right == false )
            {
                speed = -speed;
            }
        }
        if(speed < 0 )
        {
            if( left == false )
            {
                speed = 1f;
            }
        }


    }




}
