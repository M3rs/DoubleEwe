using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public AudioSource Music;
    public AudioSource ButtonSfx;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey) {
            StartCoroutine(PlayGame());
        }
    }

    IEnumerator PlayGame()
    {
        Music.Stop();
        ButtonSfx.Play();
        yield return new WaitWhile(() => ButtonSfx.isPlaying);
        SceneManager.LoadScene("TestLab 1");
    }
}
