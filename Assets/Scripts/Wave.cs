using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Wave : MonoBehaviour {

  [Header ("Config")]
  [Range (0, 10)]
  public float waveSlow = 1;
  [Range (0, 50)]
  public float waveFast = 5;

  public AnimationCurve speedCurve;

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
      t.Translate (currentSpeed * (player == Player.One ? 1 : -1), -Time.deltaTime * 0.25f, 0);
      waveSize -= Time.deltaTime * 0.5f;
    }
  }

  public void Detatch (Player player) {
    t.parent = null;
    detatched = true;
    player = player;
  }
}
