using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelScript : MonoBehaviour
{
    public float minSize = 1.5f;
    public float maxSize = 2f;

    void Awake()
    {
        // Set a random size within the specified range
        float scale = Random.Range(minSize, maxSize);

        transform.localScale = new Vector3(scale, scale, scale);

        // Set a random rotation
        float rotationX = Random.Range(0, 360);
        float rotationY = Random.Range(0, 360);
        float rotationZ = Random.Range(0, 360);

        transform.rotation = Quaternion.Euler(rotationX, rotationY, rotationZ);
    }
}
