using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour {

  public Player player;
  [Range (1, 5)]
  public int points;
  public ScoreManager scoreManager;

  void Start () {
		
  }

  void Update () {

  }

  void Score (Collider2D other) {
    other.transform.position = new Vector2 ();
    other.GetComponent<Rigidbody2D> ().velocity = new Vector2 ();
    scoreManager.Score (points);
  }

  void OnTriggerEnter2D (Collider2D other) {
    if (other.CompareTag ("Ball")) {
      Score (other);
    }
  }
}
