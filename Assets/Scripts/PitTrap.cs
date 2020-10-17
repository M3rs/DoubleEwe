﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitTrap : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var r = GetComponent<SpriteRenderer>();
        r.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        var r = GetComponent<SpriteRenderer>();
        r.enabled = true;
        Debug.Log("Pit trap on");
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        var r = GetComponent<SpriteRenderer>();
        r.enabled = false;
        Debug.Log("Pit trap off");
    }
}