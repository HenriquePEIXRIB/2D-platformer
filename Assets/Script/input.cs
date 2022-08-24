using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class input : MonoBehaviour
{
    [SerializeField] InputActionReference _moveInput;
    [SerializeField] InputActionReference _jumpInput;
    [SerializeField] Transform _root;
    [SerializeField] float _speed;

    Vector2 _playerMovement;


    private void Start()
    {
        //Move
        _moveInput.action.started += StartMove;
        _moveInput.action.performed += UpdateMove;
        _moveInput.action.canceled += EndMove;

        //Jump
        _jumpInput.action.started += JumpLaunch;
    }

    void Update()
    {
        _root.transform.Translate(_playerMovement * Time.deltaTime * _speed);
    }


    private void StartMove(InputAction.CallbackContext obj)
    {
        _playerMovement = obj.ReadValue<Vector2>();

        Debug.Log($"Appelé ! {_playerMovement}");
    }

    private void UpdateMove(InputAction.CallbackContext obj)
    {
        _playerMovement = obj.ReadValue<Vector2>();

        Debug.Log($"Joystick Update ! {_playerMovement}");
    }

    private void EndMove(InputAction.CallbackContext obj)
    {
        _playerMovement = obj.ReadValue<Vector2>();

        Debug.Log("Joystick annulé !");
    }

    private void JumpLaunch(InputAction.CallbackContext obj)
    {
        //Vector2 direction = obj.ReadValue<Vector2>();

        Debug.Log("Jump");
    }


}
