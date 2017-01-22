using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour {

  public Player player;
  [Range (1, 5)]
  public int points;
  public ScoreManager scoreManager;
  public GameObject crowdWave;

  private Animator a;
  private EdgeCollider2D e;

  void Start () {
    a = GetComponent<Animator> ();
    e = GetComponent<EdgeCollider2D> ();
  }

  void Update () {

  }

  void Score (Collider2D other) {
    
    a.SetTrigger ("Goal");
    GetComponent<AudioSource> ().Play ();
    e.enabled = false;
    other.gameObject.SetActive (false);
    other.transform.position = new Vector2 ();
    other.GetComponent<Rigidbody2D> ().velocity = new Vector2 ();
    GameObject.Instantiate<GameObject> (crowdWave);
    StartCoroutine (GoalWithDelayTime (0.75f, other));
  }

  IEnumerator GoalWithDelayTime (float time, Collider2D other) {
    yield return new WaitForSeconds (time);
    scoreManager.Score (points);
    e.enabled = true;
    other.gameObject.SetActive (true);
    GameObject.FindGameObjectWithTag ("Countdown").GetComponent<Countdown> ().Begin ();
  }

  void OnTriggerEnter2D (Collider2D other) {
    if (other.CompareTag ("Ball")) {
      Score (other);
    }
  }
}
