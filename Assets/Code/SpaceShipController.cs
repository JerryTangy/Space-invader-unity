using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController : MonoBehaviour
{
    private Quaternion shipRotation;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

    [Header("Movement Keys")]
    public KeyCode UpKey;
    public KeyCode DownKey;
    public KeyCode LeftKey;
    public KeyCode RightKey;

    [Header("Fire Keys")]

    public KeyCode FireKey1;
    public KeyCode FireKey2;
    public KeyCode FireKey3;


    [Header("Movement Speed")]
    public float moveSpeed = 5f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        checkMovement();
        checkFire();
    }

    void checkMovement () {
        Vector2 moveDirection = Vector2.zero;
        float leanAngle = 0f;

        if (Input.GetKey(UpKey))
        {
            moveDirection += Vector2.up;
        }
        if (Input.GetKey(DownKey))
        {
            moveDirection += Vector2.down;
        }
        if (Input.GetKey(LeftKey))
        {
            moveDirection += Vector2.left;
            leanAngle = 5f;
        }
        if (Input.GetKey(RightKey))
        {
            moveDirection += Vector2.right;
            leanAngle = -5f;
        }

        rb.velocity = moveDirection * moveSpeed;
         if (moveDirection.x != 0) {
            shipRotation = Quaternion.Euler(0, 0, leanAngle);
        } else {
            shipRotation = Quaternion.Euler(0, 0, 0); 
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, shipRotation, Time.deltaTime * 10); 
    }

    void checkFire () {
        if (Input.GetKeyDown(FireKey1))
        {
            // Fire weapon 1
        }
        if (Input.GetKeyDown(FireKey2))
        {
            // Fire weapon 2
        }
        if (Input.GetKeyDown(FireKey3))
        {
            // Fire weapon 3
        }
    }
}
