using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent (typeof(Text))]
public class ScoreManager : MonoBehaviour {

  public int score;
  public int scoreToWin = 10;
  public Player player;
  public GameObject crowdWave;
  public WinText winText;

  private Text text;

  void Start () {
    text = GetComponent <Text> ();
  }

  void Update () {
		
  }

  IEnumerator ResetWithDelayTime (float time) {
    yield return new WaitForSeconds (time);
    SceneManager.LoadScene ("Menu");
  }

  public void Score (int points) {
    score += points;
    text.text = score.ToString ();

    if (score >= scoreToWin) {
      // win
      Instantiate (crowdWave);
      winText.Win (player);
      StartCoroutine (ResetWithDelayTime (2f));
    }
  }
}
