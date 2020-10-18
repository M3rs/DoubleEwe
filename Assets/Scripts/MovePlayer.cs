using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float Speed;

    public Sprite Forward;
    public Sprite Back;
    public Sprite Left;
    public Sprite Right;

    public bool Enabled = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!Enabled) {
            return;
        }
        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            var x = 1 * Speed * Time.deltaTime;
            transform.position += new Vector3(x, 0, 0);
            var r = GetComponent<SpriteRenderer>();
            r.sprite = Right;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            var x = -1 * Speed *Time.deltaTime;
            transform.position += new Vector3(x, 0, 0);
            var r = GetComponent<SpriteRenderer>();
            r.sprite = Left;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            var y = -1 * Speed * Time.deltaTime;
            transform.position += new Vector3(0, y, 0);
            var r = GetComponent<SpriteRenderer>();
            r.sprite = Back;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            var y = 1 * Speed * Time.deltaTime;
            transform.position += new Vector3(0, y, 0);
            var r = GetComponent<SpriteRenderer>();
            r.sprite = Forward;
        }
        
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Stop recording!");
            var rec = GetComponent<RecordMovement>();
            if (rec != null) {
                rec.recording = false;
            }
        }
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //Do something
        //Debug.Log("Trigger!" + collision.gameObject.tag);
    //}
}
