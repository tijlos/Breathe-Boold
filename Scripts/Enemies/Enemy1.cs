using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    private float dirY;
    private Rigidbody2D rb;
    private bool facingUp = false;
    private Vector3 localScale;
    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        dirY = DataFunctions.RandomPosNeg();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Ceiling>())
        {
            dirY *= -1f;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(rb.velocity.x, dirY * DataStoreMovement.Instance.MoveSpeedVis);
    }
    void LateUpdate()
    {
        CheckWhereToFace();
    }

    void CheckWhereToFace()
    {
        if(dirY > 0)
        {
            facingUp = true;
        }
        else if(dirY < 0)
        {
            facingUp=false;
        }
        if(((facingUp) && (localScale.x < 0)) || ((!facingUp) && (localScale.x > 0)))
        {
            localScale.x *= -1;
        }
        transform.localScale = localScale;  
    }
}
