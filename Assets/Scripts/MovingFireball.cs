using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingFireball : MonoBehaviour
{
    public float XSpeed;
    public float YSpeed;
    public float MaxDistance;
    public AudioSource HitSfx;

    Vector3 StartPos;
    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var dx = XSpeed * Time.deltaTime;
        var dy = YSpeed * Time.deltaTime;

        transform.position += new Vector3(dx, dy, 0);

        var dist = Vector3.Distance(StartPos, transform.position);
        if (dist >= MaxDistance) {
            transform.position = StartPos;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "clone_sheep") {
            HitSfx.Play();
        }
    }
}
