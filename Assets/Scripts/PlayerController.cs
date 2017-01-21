using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour {

  public GameObject waveFab;

  public KeyCode leftKey;
  public KeyCode rightKey;
  public KeyCode upKey;
  public KeyCode downKey;
  public KeyCode jumpOutKey;

  public float horizontalSpeed = 5.0f;
  public float verticalSpeed = 5.0f;

  public float fallSpeed = 2;
  public float floorY = -3;

  public float maxJumpY = 0;
  public bool finishedRising = false;

  public float waveCooldown = 1;
  public float waveCooldownRemaining = 0;

  private Rigidbody2D rb;
  private Transform t;

  void Start () {
    rb = GetComponent<Rigidbody2D> ();
    t = GetComponent<Transform> ();
  }

  void Update () {

    // Left + Right input
    if (Input.GetKey (leftKey)) {
      rb.AddForce (Vector2.left * horizontalSpeed);
    } else if (Input.GetKey (rightKey)) {
      rb.AddForce (Vector2.right * horizontalSpeed);
    }

    // Up + Down input
    if (Input.GetKey (upKey) && !finishedRising) {
      rb.AddForce (Vector2.up * verticalSpeed);
    } else if (Input.GetKey (downKey)) {
      rb.AddForce (Vector2.down * verticalSpeed);
    }

    //  Falling
    if (t.position.y > floorY) {
      if (!Input.GetKey (upKey) && !finishedRising) {
        finishedRising = true;
      }
      if (finishedRising) {
        rb.AddForce (Vector2.down * fallSpeed);
        finishedRising = true;
      }
    } else if (t.position.y <= floorY) { // In the ground
      finishedRising = false;
      rb.velocity = new Vector2 (rb.velocity.x, Mathf.Max (rb.velocity.y, 0f));
      if (GetComponentInChildren <Wave> () == null && waveCooldownRemaining <= 0) {
        GameObject newWave = Instantiate<GameObject> (waveFab, t.position, Quaternion.identity, t);
      }
    }

    // Max jump height
    if (t.position.y >= maxJumpY) {
      finishedRising = true;
    }

    if (Input.GetKeyDown (jumpOutKey)) {
      Wave wave = GetComponentInChildren<Wave> ();
      if (wave != null) {
        wave.Detatch ();
        waveCooldownRemaining = waveCooldown;
      }
    }

    if (waveCooldownRemaining > 0) {
      waveCooldownRemaining -= Time.deltaTime;
    }
  }
}
