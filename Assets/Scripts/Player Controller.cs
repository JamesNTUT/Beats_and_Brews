using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public Transform _Player;
    public Camera _Camera;
    public float _LookSpeed = 2f;
    public float _LookLimit = 45f;
    Vector3 moveDirection = Vector3.zero;
    float _rotationX = 0;
    public bool _canMove = true;
    public Transform _Position1;
    public Transform _Position2;
    public Transform _Position3;
    public Transform _Position4;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (_canMove)
        {
        _rotationX += -Input.GetAxis("Mouse Y") * _LookSpeed;
        _rotationX = Mathf.Clamp(_rotationX, -_LookLimit, _LookLimit);
        _Camera.transform.localRotation = Quaternion.Euler(_rotationX, 0, 0);
        transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * _LookSpeed, 0);

        }
        
    }
}
