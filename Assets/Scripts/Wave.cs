using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Diagnostics;

public class Wave : MonoBehaviour {

  [Header ("Config")]
  [Range (0, 10)]
  public float waveSlow = 1;
  [Range (0, 50)]
  public float waveFast = 5;

  public AnimationCurve speedCurve = AnimationCurve.EaseInOut (0, 0, 1, 1);

  public float lowestPointY = -26.05f;

  [Header ("Read Only")]

  [Range (0, 1)]
  public float waveSize = 1;
  public float currentSpeed = 0;

  public bool detatched = false;
  public Player player;

  private Transform t;

  void Start () {
    t = GetComponent <Transform> ();
  }

  void Update () {
    if (detatched) {
      currentSpeed = Mathf.Lerp (waveSlow, waveFast, speedCurve.Evaluate (1 - waveSize)) * Time.deltaTime;
      t.Translate (currentSpeed * (player == Player.Pink ? 1 : -1), -Time.deltaTime * 0.25f, 0);
      waveSize -= Time.deltaTime * 0.5f;

      if (t.position.y < lowestPointY) {
        Destroy (gameObject);
      }
    }
  }

  public void Detatch (Player p) {
    GetComponent <Transform> ().parent = null;
    detatched = true;
    player = p;
  }

  void OnTriggerEnter2D (Collider2D other) {
    Debug.Log (other.tag);
    if (other.CompareTag ("Player") && other.gameObject != t.parent.gameObject) {
      other.gameObject.GetComponent <PlayerController> ().KnockOutOfWave ();
    }
  }
}
