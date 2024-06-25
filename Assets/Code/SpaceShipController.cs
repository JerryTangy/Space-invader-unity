using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipController: MonoBehaviour {
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
  public float moveSpeed = 5 f;

  [Header("Lasers")]
  public float bulletMoveSpeed;
  public float destroyTime;
  public Sprite[] laserSprites;

  [Header("Fire Point")]
  public GameObject firePoint;

  void Start() {
    rb = GetComponent < Rigidbody2D > ();
    sprite = GetComponent < SpriteRenderer > ();
  }

  void Update() {
    checkMovement();
    checkFire();
  }

  void checkMovement() {
    Vector2 moveDirection = Vector2.zero;
    float leanAngle = 0 f;

    if (Input.GetKey(UpKey) || Input.GetKey(KeyCode.UpArrow)) {
      moveDirection += Vector2.up;
    }
    if (Input.GetKey(DownKey) || Input.GetKey(KeyCode.DownArrow)) {
      moveDirection += Vector2.down;
    }
    if (Input.GetKey(LeftKey) || Input.GetKey(KeyCode.LeftArrow)) {
      moveDirection += Vector2.left;
      leanAngle = 5 f;
    }
    if (Input.GetKey(RightKey) || Input.GetKey(KeyCode.RightArrow)) {
      moveDirection += Vector2.right;
      leanAngle = -5 f;
    }

    rb.velocity = moveDirection * moveSpeed;
    if (moveDirection.x != 0) {
      shipRotation = Quaternion.Euler(0, 0, leanAngle);
    } else {
      shipRotation = Quaternion.Euler(0, 0, 0);
    }

    transform.rotation = Quaternion.Lerp(transform.rotation, shipRotation, Time.deltaTime * 10);
  }

  void checkFire() {
    if (Input.GetKeyDown(FireKey1)) {
      FireLaser(0);
    }
    if (Input.GetKeyDown(FireKey2)) {
      // Fire weapon 2
    }
    if (Input.GetKeyDown(FireKey3)) {
      // Fire weapon 3
    }

    void FireLaser(int index) {
      if (index >= 0 && index < laserSprites.Length) {
        GameObject laser = new GameObject("Laser");

        SpriteRenderer laserSpriteRenderer = laser.AddComponent < SpriteRenderer > ();
        laserSpriteRenderer.sprite = laserSprites[index];

        BoxCollider2D collider = laser.AddComponent < BoxCollider2D > ();
        collider.isTrigger = true;

        laser.transform.position = firePoint.transform.position;
        laser.transform.rotation = firePoint.transform.rotation;

        Rigidbody2D laserRb = laser.AddComponent < Rigidbody2D > ();
        laserRb.gravityScale = 0;
        laserRb.velocity = laser.transform.up * bulletMoveSpeed;

        Destroy(laser, destroyTime);
      }
    }
  }
}