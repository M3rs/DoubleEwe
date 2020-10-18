using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOpenDoor : MonoBehaviour
{
    public GameObject Door;

    public Sprite UpSprite;
    public Sprite DownSprite;

    public AudioSource ButtonSfx;
    public AudioSource DoorSfx;

    public Sprite DoorOpenSprite;
    public Sprite DoorClosedSprite;    

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
        r.sprite = DoorOpenSprite;

        var c = Door.GetComponent<BoxCollider2D>();
        c.enabled = false;

        Debug.Log("Door Open");

        var br = GetComponent<SpriteRenderer>();
        br.sprite = DownSprite;

        ButtonSfx.Play();
        DoorSfx.Play();
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        var r = Door.GetComponent<SpriteRenderer>();
        r.sprite = DoorClosedSprite;


        var c = Door.GetComponent<BoxCollider2D>();
        c.enabled = true;       

        var br = GetComponent<SpriteRenderer>();
        br.sprite = UpSprite;

        ButtonSfx.Play();
        DoorSfx.Play();
    }
}
