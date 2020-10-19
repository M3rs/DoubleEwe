using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISheepMovement : MonoBehaviour
{
    public Transform AI;
    public Vector3[] Positions;
    int index;

    public AudioSource Bah;
    public GameObject WoolEmitter;

    
    public Sprite Forward;
    public Sprite Back;
    public Sprite Left;
    public Sprite Right;

    public Sprite Dead;

    bool alive;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        alive = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        if (index < Positions.Length) {
            var lastPos = AI.position;
            AI.position = Positions[index];
            index++;
            
            var n = Vector3.Normalize(AI.position - lastPos);
            var r = GetComponent<SpriteRenderer>();
            if (n.x == 1) {
                r.sprite = Right;
            }
            if (n.x == -1) {
                r.sprite = Left;
            }
            if (n.y == 1) {
                r.sprite = Forward;
            }
            if (n.y == -1) {
                r.sprite = Back;
            }

            if (!alive) {
                r.sprite = Dead;
            }
        }
    }

    
    void OnTriggerStay2D(Collider2D collision)
    {
        /*
        if (!alive) {
            return;
        }
        */
        if (collision.gameObject.tag != "trap") {
            return;
        }

        //Debug.Log("Trigger! " + collision.gameObject.tag);

        Bah.Play();
        alive = false;

        var p = collision.gameObject.GetComponent<PersistentTrap>();
        if (p != null) {
            return;
        }

        collision.enabled = false;

        var c = GetComponent<BoxCollider2D>();
        c.enabled = false;


        foreach (ParticleSystem ps in WoolEmitter.transform.GetComponentsInChildren<ParticleSystem>()) {
            var wer = ps.GetComponent<ParticleSystemRenderer>();
            ps.time = 0;
            ps.Play();
        }


    }
}
