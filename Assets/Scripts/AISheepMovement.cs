using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISheepMovement : MonoBehaviour
{
    public Transform AI;
    public Vector3[] Positions;
    int index;

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
}
