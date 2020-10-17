using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            var speed = 1 * Time.deltaTime;
            transform.position += new Vector3(speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            var speed = -1 * Time.deltaTime;
            transform.position += new Vector3(speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            var speed = -1 * Time.deltaTime;
            transform.position += new Vector3(0, speed, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            var speed = 1 * Time.deltaTime;
            transform.position += new Vector3(0, speed, 0);
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
}
