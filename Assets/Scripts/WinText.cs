using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinText : MonoBehaviour {

  public Color red;
  public Color blue;

  public AudioClip redWin;
  public AudioClip blueWin;

  private Text t;

  void Start () {
    t = GetComponent<Text> ();
  }

  void Update () {
    
  }

  public void Win (Player player) {
    t.text = (player == Player.Pink ? "RED" : "BLUE") + " PLAYER WINS";
    t.color = player == Player.Pink ? red : blue;
    GetComponent<AudioSource> ().PlayOneShot (player == Player.Pink ? redWin : blueWin);
  }
}
