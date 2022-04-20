using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnanaMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public Vector2 speedMinMax;
    float speed;
    float visibleHeightThreshold;
    private void Start()
    {
        visibleHeightThreshold = -Camera.main.orthographicSize - transform.localScale.y;
        speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent());
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(0f, -speed);

        if(transform.position.y < visibleHeightThreshold) 
        {
            Destroy(gameObject);
        }
    }
}
