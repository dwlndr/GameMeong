using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerakMusuh : MonoBehaviour
{
    public float kecepatan;

    Rigidbody2D rb;

    public bool berbalik;


    // Start is called before the first frame update
    void Start()
    {
        berbalik = true;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (berbalik)
        {
            rb.velocity = new Vector2(kecepatan, rb.velocity.y);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else
        {
            rb.velocity = new Vector2(-kecepatan, rb.velocity.y);
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Balik"))
        {
            berbalik = !berbalik;
        }
    }
}
