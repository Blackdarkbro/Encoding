using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement1 : MonoBehaviour
{
    [SerializeField] private float charSpeed = default;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var forwardMove = Input.GetAxis("VerticalArrow") * charSpeed * Time.deltaTime;
        var sideMove = Input.GetAxis("HorizontalArrow") * charSpeed * Time.deltaTime;
        
        transform.Translate(sideMove, 0, forwardMove);
    }
}
