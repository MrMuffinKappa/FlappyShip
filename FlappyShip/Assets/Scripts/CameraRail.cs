using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRail : MonoBehaviour
{

    public Vector3 startPos;
    public Vector3 endPos;
    public Quaternion startRotation;
    public Quaternion endRotation;
    public float startSize;
    public float endSize;
    private Camera camera;
    public float duration = 2.0f;

    void Awake()
    {
        camera = GetComponent<Camera>();
    }
    void Start()
    {
        StartCoroutine(MoveAndRotateCamera());
    }

    IEnumerator MoveAndRotateCamera()
    {
        float elapsed = 0;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;

            transform.position = Vector3.Lerp(startPos, endPos, t);
            //transform.rotation = Quaternion.Lerp(startRotation, endRotation, t);
            camera.orthographicSize = Mathf.Lerp(startSize, endSize, t);

            yield return null;
        }

        // Ensure it's fully moved to the end position.
        transform.position = endPos;
        //transform.rotation = endRotation;
    }
}

