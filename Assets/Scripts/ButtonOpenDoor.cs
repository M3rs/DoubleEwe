using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOpenDoor : MonoBehaviour
{
    public GameObject Door;
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
        var r = Door.GetComponent<SpriteRenderer>();
        r.enabled = false;

        var c = Door.GetComponent<BoxCollider2D>();
        c.enabled = false;

        Debug.Log("Door Open");
    }

    void OnTriggerExit2D(Collider2D collision)
    {
         var r = Door.GetComponent<SpriteRenderer>();
        r.enabled = true;

        var c = Door.GetComponent<BoxCollider2D>();
        c.enabled = true;       
    }
}
