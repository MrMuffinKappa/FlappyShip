using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyMovement : MonoBehaviour
{
    public float flapForce = 5f;
    public float gravityForce = 9.8f;
    public bool isEnable = true;
    public float maxRotate = 40f;
    public float rotateForce = 40f;
    public AnimationCurve rollCurve;
    public float _currentRoll, _targetRoll;


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
            _currentRoll = 0;
            _targetRoll = 1;

        }

        if (isEnable)
        {
            verticalVelocity -= gravityForce * Time.deltaTime;
            float newPosX = transform.position.x - verticalVelocity * Time.deltaTime;
            transform.position = new Vector3(Mathf.Clamp(newPosX, -1 * gravityForce, gravityForce), transform.position.y, 0);


            _currentRoll = Mathf.MoveTowards(_currentRoll, _targetRoll, 0.95f * Time.deltaTime);
            float _rotation = Mathf.Lerp(0, 360, rollCurve.Evaluate(_currentRoll));
            transform.rotation = Quaternion.Euler(new Vector3(-90, _rotation, 0));
        }
    }

    public IEnumerator StartGame()
    {
        yield return new WaitForSeconds(1);
        isEnable = true;
    }

}
