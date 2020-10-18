using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSheepAi : MonoBehaviour
{
    public Sprite Left;
    public Sprite Right;

    float startPos;
    int dest;
    float dx;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (dest++ >= 120) {
            dx = Random.Range(-4.0f, 4.0f);
            dest = 0;
        }

        var r = GetComponent<SpriteRenderer>();
        r.sprite = dx > 0 ? Right : Left;

        transform.position += new Vector3(dx * Time.deltaTime, 0, 0);
    }
}
