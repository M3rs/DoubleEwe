using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordMovement : MonoBehaviour
{
    List<GameObject> otherSheep;
    List<Vector3> positions;
    int index;

    public Transform player;
    public Transform AI;
    public bool recording = true;
    public bool clone = false;

    public AudioSource Bah;

    private bool active;

    // Start is called before the first frame update
    void Start()
    {
        otherSheep = new List<GameObject>();
        positions = new List<Vector3>();
        index = 0;

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

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (clone) {
            return;
        }
        if (!active) {
            return;
        }

        Debug.Log("Trigger!" + collision.gameObject.tag);
        player.position = positions[0];
        var x = Instantiate(player.gameObject, positions[0], Quaternion.identity);
        var r = x.GetComponent<RecordMovement>();
        r.clone = true;
        Destroy(r);
        var move = x.GetComponent<MovePlayer>();
        Destroy(move);
        var ai = x.AddComponent<AISheepMovement>();
        ai.Positions = positions.ToArray();
        ai.AI = x.transform;

        positions.Clear();

        active = false;

        Bah.Play();
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        active = true;
    }
}
