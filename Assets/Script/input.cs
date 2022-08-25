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
    [SerializeField] Animator _animator;

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
        //Movement
        Vector2 direction = new Vector2(_playerMovement.x, 0);
        _root.transform.Translate(_playerMovement * Time.fixedDeltaTime * _speed);

        //Animator
        if(direction.x > 0) // Si on bouge
        {
            _animator.SetBool("IsWaiting", true);
        }
        else  //Sinon c'est que l'on ne bouge pas donc false
        {
            _animator.SetBool("IsWalking", false);
        }

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
