using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float Speed;
    public float OriginalSpeed;

    public Sprite Forward;
    public Sprite Back;
    public Sprite Left;
    public Sprite Right;

    public bool Enabled = true;

    public Vector3 MoveDir;

    // Start is called before the first frame update
    void Start()
    {
        OriginalSpeed = Speed;
        MoveDir = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Enabled) {
            return;
        }

        var move = new Vector3();
        var r = GetComponent<SpriteRenderer>();
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            var x = 1 * Speed * Time.deltaTime;
            move.x = x;
            //transform.position += new Vector3(x, 0, 0);
            //var r = GetComponent<SpriteRenderer>();
            r.sprite = Right;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            var x = -1 * Speed *Time.deltaTime;
            move.x = x;
            //transform.position += new Vector3(x, 0, 0);
            //var r = GetComponent<SpriteRenderer>();
            r.sprite = Left;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            var y = -1 * Speed * Time.deltaTime;
            move.y = y;
            //transform.position += new Vector3(0, y, 0);
            //var r = GetComponent<SpriteRenderer>();
            r.sprite = Back;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            var y = 1 * Speed * Time.deltaTime;
            move.y = y;
            //transform.position += new Vector3(0, y, 0);
            //var r = GetComponent<SpriteRenderer>();
            r.sprite = Forward;
        }

        //GetComponent<Rigidbody2D>().AddForce(move);
        transform.position += move;
        MoveDir = Vector3.Normalize(move);

        
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //Do something
        //Debug.Log("Trigger!" + collision.gameObject.tag);
    //}
    void OnTriggerStay2D(Collider2D other){
        var ip = other.gameObject.GetComponent<IceyPatch>();
        if (ip != null) {
             //GetComponent<Collider>().material.dynamicFriction = 0;
             GetComponent<Rigidbody2D>().AddForce(MoveDir * 300 * Time.deltaTime);
        }
    }
    void OnTriggerExit2D(Collider2D other) {
        var ip = other.gameObject.GetComponent<IceyPatch>();
        if (ip != null) {
             //GetComponent<Collider>().material.dynamicFriction = 0;
             GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }
    } 

}
