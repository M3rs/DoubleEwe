using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlidingTrap : MonoBehaviour
{
    public Transform InitialPosition;
    public float ExtendSpeed = 10;
    public float RetractSpeed = -2;
    public float MaxDistance = 20;
    public bool Extending = true;

    float StartPos;
    float MaxPos;

    // Start is called before the first frame update
    void Start()
    {
        StartPos = InitialPosition.position.x;
        MaxPos = StartPos + MaxDistance;
    }

    // Update is called once per frame
    void Update()
    {
        if (Extending) {
            Extend();
        } else {
            Retract();
        }
        
    }

    void Extend()
    {
        var x = ExtendSpeed * Time.deltaTime;
        InitialPosition.position += new Vector3(x, 0, 0);

        if (InitialPosition.position.x >= MaxPos) {
            Extending = false;
        }
    }

    void Retract()
    {
        var x = RetractSpeed * Time.deltaTime;
        InitialPosition.position += new Vector3(x, 0, 0);

        if (InitialPosition.position.x <= StartPos) {
            Extending = true;
        }
    }
}
