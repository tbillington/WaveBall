using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

  void Start () {
		
  }

  void Update () {

  }

  void Score (Collider2D other) {
    other.transform.position = new Vector2 ();
    other.GetComponent<Rigidbody2D> ().velocity = new Vector2 ();
  }

  void OnTriggerEnter2D (Collider2D other) {
    if (other.CompareTag ("Ball")) {
      Score (other);
    }
  }
}
