using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum Player {
  One,
  Two}
;

public class PlayerController : MonoBehaviour {

  public GameObject waveFab;

  [Header ("Controls")]
  public Player player;
  public KeyCode leftKey;
  public KeyCode rightKey;
  public KeyCode upKey;
  public KeyCode downKey;
  public KeyCode jumpOutKey;
  public KeyCode kickKey;

  [Header ("Config")]
  [Range (0, 5)]
  public float horizontalSpeed = 5.0f;
  [Range (0, 5)]
  public float verticalSpeed = 5.0f;

  [Range (0, 50)]
  public float jumpStrength = 20f;
  [Range (0, 50)]
  public float kickStrength = 25f;
  [Range (0, 5)]
  public float kickRange = 1.5f;

  [Range (0, 5)]
  public float fallSpeed = 2;

  [Range (0, 5)]
  public float waveCooldown = 1;

  public float floorY = -3;

  public float maxJumpY = 0;

  [Header ("Read Only")]
  public bool finishedRising = false;
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
      if (t.position.y < floorY)
        t.Translate (0, floorY - t.position.y, 0);
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
        wave.Detatch (player);
        waveCooldownRemaining = waveCooldown;
        rb.AddForce (Vector2.up * jumpStrength);
      }
    }

    if (waveCooldownRemaining > 0) {
      waveCooldownRemaining -= Time.deltaTime;
    }

    if (Input.GetKeyDown (kickKey)) {
      GameObject ball = GameObject.FindGameObjectWithTag ("Ball");

      Vector2 directionOfBall = Vector2.ClampMagnitude (ball.transform.position - t.position, 1);

      float distanceToBall = Vector2.Distance (t.position, ball.transform.position);

      Debug.DrawRay (t.position, directionOfBall * kickRange, distanceToBall >= kickRange ? Color.green : Color.red, 0.2f);
      if (distanceToBall < kickRange && GetComponentInChildren <Wave> () == null) {
        ball.GetComponent<Rigidbody2D> ().AddForce (directionOfBall * kickStrength);
      }
    }
  }
}
