using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class ScoreManager : MonoBehaviour {

  public int score;

  private Text text;

  void Start () {
    text = GetComponent <Text> ();
  }

  void Update () {
		
  }

  public void Score (int points) {
    score += points;
    text.text = score.ToString ();
  }
}
