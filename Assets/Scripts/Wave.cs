using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Wave : MonoBehaviour {

  public float waveSpeed = 2;

  public bool detatched = false;

  private Transform t;

  void Start () {
    t = GetComponent <Transform> ();
  }

  void Update () {
    if (detatched) {
      t.Translate (waveSpeed * Time.deltaTime, 0, 0);
    }
  }

  public void Detatch () {
    t.parent = null;
    detatched = true;
  }
}
