using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    float speed = 0.3f;
    Rigidbody2D rb;
    Transform target;
    Vector2 moveDirection;

    // Start is called before the first frame update

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public Transform player;
    public Vector2 relativePoint;
    Helper_Script helper;
    void Start()
    {
        target = GameObject.Find("Player").transform;
        helper = gameObject.AddComponent<Helper_Script>();
    }

    // Update is called once per frame
    void Update()
    {
        if(target)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            moveDirection = direction;
        }
        relativePoint = transform.InverseTransformPoint(player.position);
        if (relativePoint.x < 0f && Mathf.Abs(relativePoint.x) > Mathf.Abs(relativePoint.y))
        {
            Debug.Log("Right");
            helper.FlipObject(false);
        }
        if (relativePoint.x > 0f && Mathf.Abs(relativePoint.x) > Mathf.Abs(relativePoint.y))
        {
            Debug.Log("Left");
            helper.FlipObject(true);
        }
    }
    private void FixedUpdate()
    {
        if(target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * speed;
        }

    }
}
