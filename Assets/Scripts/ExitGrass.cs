using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGrass : MonoBehaviour
{
    public AudioSource Bah;
    public string NextLevel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player") {
            return;
        }

        Debug.Log("Exit Grass");
        StartCoroutine(ToVictory());
    }

    IEnumerator ToVictory()
    {
        Bah.Play();
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(NextLevel);

    }
}
