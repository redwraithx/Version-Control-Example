using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 8f;
    [SerializeField] private float _sprintSpeed = 5f;
    [SerializeField] private float _currentSpeed = 0f;
    private Vector3 _moveDirection;

    [SerializeField] private float _jumpPower = 8f;
    [SerializeField] private bool _canPlayerJump = true;
    [SerializeField] private float _jumpResetTime = 1.5f;
    private float _setJumpTime = -1f;

    private bool isGrounded = false;

    private Rigidbody _rigidbody;


    private void Start()
    {
        _canPlayerJump = true;

        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {


        //if (Time.time > _setJumpTime && _canPlayerJump == false)
        //{
        //    _canPlayerJump = true;
        //}

        PlayerSprintCheck();

        PlayerMovementUpdate();
    }


    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Debug.Log("space bar is hit");

            _rigidbody.AddForce(new Vector3(0, _jumpPower, 0), ForceMode.Impulse);

            isGrounded = false;
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }

    }

    private void PlayerMovementUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        _moveDirection = new Vector3(moveHorizontal, 0, moveVertical);

        transform.Translate(_moveDirection * _currentSpeed * Time.deltaTime);
    }

    private void PlayerSprintCheck()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _currentSpeed = _movementSpeed + _sprintSpeed;
        }
        else
        {
            _currentSpeed = _movementSpeed;
        }
    }
}
