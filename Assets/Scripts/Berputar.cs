using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Berputar : MonoBehaviour
{
    private float rotasiZ;
    public float RotationSpeed;
    public bool ClockwiseRotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ClockwiseRotation == false)
        {
            rotasiZ += Time.deltaTime * RotationSpeed;
        }
        else
        {
            rotasiZ += -Time.deltaTime * RotationSpeed;
        }
        transform.rotation = Quaternion.Euler(0, 0, rotasiZ);
    }
}
