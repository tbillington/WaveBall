using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdWaveMoveRight : MonoBehaviour {

  [Range (0, 10)]
  public float lifetime = 5;
  [Range (0, 100)]
  public float speed = 20;

  void Update () {
    lifetime -= Time.deltaTime;
    if (lifetime <= 0) {
      Destroy (gameObject);
    }
    transform.Translate (speed * Time.deltaTime, 0, 0);
  }
}
