using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepBallInPlay : MonoBehaviour {

  // Use this for initialization
  void Start () {
		
  }
	
  // Update is called once per frame
  void Update () {
    if (Vector2.Distance (Vector2.zero, transform.position) > 50) {
      transform.position = Vector2.zero;
      GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
    }
  }
}
