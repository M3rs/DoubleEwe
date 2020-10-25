using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BananaPeel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //void OnCo

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag != "Player") {
            return;
        }

        GetComponent<AudioSource>().Play();

        var anim = other.gameObject.GetComponent<Animator>();
        anim.SetTrigger("Spin");

        var vec = other.gameObject.GetComponent<MovePlayer>().MoveDir;

        other.gameObject.GetComponent<Rigidbody2D>().AddForce(vec * 900 * Time.deltaTime);

        GetComponent<Rigidbody2D>().AddForce(vec * -1 * 900 * Time.deltaTime);
    }
}
