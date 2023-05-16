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


    private float rotateVelocity;
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
            MoveShip();
            RotateShipNew();
        }
    }

    public IEnumerator StartGame()
    {
        yield return new WaitForSeconds(2);
        isEnable = true;
    }

    void MoveShip()
    {
        verticalVelocity -= gravityForce * Time.deltaTime;
        float newPosX = transform.position.x - verticalVelocity * Time.deltaTime;
        rb.MovePosition(new Vector2(Mathf.Clamp(newPosX, -1 * gravityForce, gravityForce), transform.position.y));
    }


    public void RotateShipNew()
    {
        //transform.eulerAngles = Vector3.Lerp(new Vector3(-90,0,0),new Vector3(-90,359,0), rollCurve.Evaluate())
        _currentRoll = Mathf.MoveTowards(_currentRoll, _targetRoll, 0.9f * Time.deltaTime);
        float _rotation = Mathf.Lerp(0, 360, rollCurve.Evaluate(_currentRoll));
        transform.rotation = Quaternion.Euler(new Vector3(-90, _rotation, 0));
        //transform.rotation = Quaternion.Lerp(Quaternion.Euler(new Vector3(-90, 0, 0)), Quaternion.Euler(new Vector3(-90, 360, 0)), rollCurve.Evaluate(_currentRoll));
    }


}
