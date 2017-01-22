using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleWaveTextureScroll : MonoBehaviour {

  [Range (0, 1)]
  public float scrollSpeed = 0.5f;

  void Start () {
    GetComponent<AudioSource> ().Play ();
  }

  void Update () {
    GetComponent<MeshRenderer> ().material.mainTextureOffset += Vector2.right * Time.deltaTime * scrollSpeed;

    if (Input.anyKeyDown) {
      SceneManager.LoadScene ("Level");
    }
  }
}
