using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpPower;
    public float speed;
    private float inputMove;
    private Rigidbody2D rb;

    void Start() 
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() 
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = Vector2.up * jumpPower;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Obstacle"))
        {
            GameManager.Instance.GameOver();
        }
    }
}
