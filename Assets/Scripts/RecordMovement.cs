using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordMovement : MonoBehaviour
{
    List<Vector3> positions;
    int index;

    public Transform player;
    public Transform AI;
    public bool recording;

    // Start is called before the first frame update
    void Start()
    {
        positions = new List<Vector3>();
        index = 0;
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
            if (index < positions.Count) {
                AI.position = positions[index];
                index++;
            }
        }
    }
}
