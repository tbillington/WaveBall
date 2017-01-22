using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour {

  [Header ("Config")]
  public GameObject ball;
  public Sprite[] sprites;
  [Range (0.2f, 2f)]
  public float spriteSizeMultiplier = 1;
  public AnimationCurve spriteSize;

  [Header ("Read Only")]
  public bool active;
  public float timeRemaining;

  private SpriteRenderer sr;
  private Transform t;
  private AudioSource a;

  void Start () {
    sr = GetComponent<SpriteRenderer> ();
    t = GetComponent<Transform> ();
    a = GetComponent<AudioSource> ();
    Begin ();
  }

  void Update () {
    if (!active) {
      return;
    }
    timeRemaining -= Time.deltaTime;

    if (timeRemaining <= 0.1) {
      active = false;
      sr.sprite = null;
      ball.SetActive (true);
    }

    Sprite currentSprite = sprites [3 - Mathf.CeilToInt (timeRemaining)];
    if (sr.sprite != null && sr.sprite.name != currentSprite.name) {
      sr.sprite = currentSprite;
    }
    t.localScale = Vector3.one * (spriteSize.Evaluate (timeRemaining) * spriteSizeMultiplier);
  }

  public void Begin () {
    active = true;
    timeRemaining = 3;
    sr.sprite = sprites [0];
    a.Play ();
  }
}
