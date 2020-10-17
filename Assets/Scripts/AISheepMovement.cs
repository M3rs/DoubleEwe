using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISheepMovement : MonoBehaviour
{
    public Transform AI;
    public Vector3[] Positions;
    int index;

    public AudioSource Bah;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (index < Positions.Length) {
            AI.position = Positions[index];
            index++;
        }
    }

    
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "trap") {
            return;
        }

        Debug.Log("Trigger! " + collision.gameObject.tag);

        Bah.Play();

        var p = collision.gameObject.GetComponent<PersistentTrap>();
        if (p != null) {
            return;
        }

        collision.enabled = false;
    }
}
