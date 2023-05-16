using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyMovement : MonoBehaviour
{
    public float flapForce = 5f;
    public float gravityForce = 9.8f;
    public bool isEnable = true;

    private float verticalVelocity;
    private Rigidbody rb;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        StartCoroutine(StartGame());
    }

    void Update()
    {
        if (Input.GetMouseButton(0) || Input.GetButtonDown("Jump"))
        {
            verticalVelocity = flapForce;
        }

        if (isEnable)
        {
        verticalVelocity -= gravityForce * Time.deltaTime;
        float newPosX = transform.position.x - verticalVelocity * Time.deltaTime;

        rb.MovePosition(new Vector2(Mathf.Clamp(newPosX, -1 * gravityForce, gravityForce), transform.position.y));
        }
    }

    public IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1);
        isEnable = true;
    }
}
