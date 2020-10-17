using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordMovement : MonoBehaviour
{
    List<GameObject> otherSheep;
    List<Vector3> positions;

    public Transform player;
    public Transform AI;
    public bool recording = true;
    public bool clone = false;
    public GameObject SheepClone;

    public AudioSource Bah;

    private bool active;
    //rivate Collider

    // Start is called before the first frame update
    void Start()
    {
        otherSheep = new List<GameObject>();
        positions = new List<Vector3>();

        active = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (recording) {
            //Debug.Log("Move?");
            positions.Add(player.position);
        } else {

        }

    }

    /*
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (clone) {
            return;
        }
        if (!active) {
            return;
        }

        if (collision.gameObject.tag == "trap") {

            Debug.Log("Trigger!" + collision.gameObject.tag + " " + collision.gameObject.name);
            player.position = positions[0];
            var x = Instantiate(SheepClone, positions[0], Quaternion.identity);

            var ai = x.GetComponent<AISheepMovement>();
            ai.Positions = positions.ToArray();
            ai.AI = x.transform;

            positions.Clear();

            active = false;

            Bah.Play();

            //collision.enabled = false;
        }
    }
    */
    
    void OnTriggerStay2D(Collider2D collision)
    {

        if (clone) {
            return;
        }
        if (!active) {
            return;
        }

        if (collision.gameObject.tag == "trap") {

            Debug.Log("Trigger!" + collision.gameObject.tag + " " + collision.gameObject.name);
            player.position = positions[0];
            var x = Instantiate(SheepClone, positions[0], Quaternion.identity);

            var ai = x.GetComponent<AISheepMovement>();
            ai.Positions = positions.ToArray();
            ai.AI = x.transform;

            positions.Clear();

            active = false;

            Bah.Play();

            collision.enabled = false;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "trap") {
            return;
        }

        active = true;
        collision.enabled = true;
        Debug.Log("exit");
    }
}
