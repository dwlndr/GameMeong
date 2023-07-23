using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Membesar : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    private bool membesar = true;
    private int zoom = 1;
    // Update is called once per frame
    void Update()
    {
        if (membesar)
        {
            zoom++;
            transform.localScale += new Vector3(0.001f, 0, 0);
            if (zoom > 2000) { membesar = false; }
        }
        else
        {
            zoom--;
            transform.localScale -= new Vector3(0.001f, 0, 0);
            if (zoom < 1) { membesar = true; }
        }
    }
}
