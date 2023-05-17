using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public List<GameObject> barrels;
    public int holeSize = 3;

    void Awake()
    {
        int holestart = Random.Range(0, barrels.Count-holeSize);
        for (int i = 0; i < 3; i++)
        {
            Destroy(barrels[holestart + i]);
        }
    }
}
