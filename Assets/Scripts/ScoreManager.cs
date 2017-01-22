using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent (typeof(Text))]
public class ScoreManager : MonoBehaviour {

  public int score;
  public int scoreToWin = 10;
  public GameObject crowdWave;

  private Text text;

  void Start () {
    text = GetComponent <Text> ();
  }

  void Update () {
		
  }

  public void Score (int points) {
    score += points;
    score = scoreToWin;
    text.text = score.ToString ();

    if (score >= scoreToWin) {
      // win
      Instantiate (crowdWave);
    }
  }
}
