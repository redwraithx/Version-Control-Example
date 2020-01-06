using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _movementSpeed = 8f;
    [SerializeField] private float _sprintSpeed = 5f;
    [SerializeField] private float _currentSpeed = 0f;
    private Vector3 _moveDirection;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        _moveDirection = new Vector3(moveHorizontal, moveVertical, 0f);

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            _currentSpeed = _movementSpeed + _sprintSpeed;
        }
        else
        {
            _currentSpeed = _movementSpeed;
        }

        transform.Translate(_moveDirection * _currentSpeed * Time.deltaTime);
    }
}
