using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Movement : MonoBehaviour
{
    [SerializeField] private  Transform head = default;
    [SerializeField] private Camera _camera = default;
    
    public static float charSpeed = default;
    [SerializeField] private float mouseSensitivity = default;
    
    private float _rotationY;

    void Start()
    {

    }
    
    void Update()
    {
        // character move
        var forwardMove = Input.GetAxis("VerticalWASD") * charSpeed * Time.deltaTime;
        var sideMove = Input.GetAxis("HorizontalWASD") * charSpeed * Time.deltaTime;
        
        transform.Translate(sideMove, 0, forwardMove);

        // rotate body oY
        var newRot = transform.localEulerAngles;
        newRot.y += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        transform.localEulerAngles = newRot;
        
        // rotate head oX
        _rotationY += Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        _rotationY = Mathf.Clamp (_rotationY, -40, 40);
        
        head.localEulerAngles = new Vector3(-_rotationY, 0, 0);

        
        
        if (Input.GetKey(KeyCode.Mouse1))
        {
            _camera.fieldOfView = 30;
        }
        else
        {
            _camera.fieldOfView = 60;
        }
    }

    private void Zoom()
    {
        
    }
}
