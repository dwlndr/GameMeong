using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerakAtasBawah : MonoBehaviour
{
    public float kecepatan;
    public float batasAtas;
    public float batasBawah;

    private bool naik = true;
    // Start is called before the first frame update
    void Start()
    {
        naik = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posisiBaru = new Vector3();
        posisiBaru.x = transform.position.x;
        posisiBaru.z = transform.position.z;
        if (naik)
        {
            posisiBaru.y = transform.position.y + kecepatan;
            if (posisiBaru.y > batasAtas) { naik = false; }
        }
        else
        {
            posisiBaru.y = transform.position.y - kecepatan;
            if (posisiBaru.y < batasBawah) { naik = true; }
        }
        transform.position = posisiBaru;
    }
}
