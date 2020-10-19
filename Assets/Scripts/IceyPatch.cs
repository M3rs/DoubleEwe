using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceyPatch : MonoBehaviour
{
    public float SlipperySpeed;
    public float MaxSlipSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player") {
            return;
        }

        var r = collision.gameObject.GetComponent<MovePlayer>();
        if (r.Speed < MaxSlipSpeed) {
            r.Speed += SlipperySpeed;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player") {
            return;
        }

        var r = collision.gameObject.GetComponent<MovePlayer>();
        r.Speed = r.OriginalSpeed;
    }
}
