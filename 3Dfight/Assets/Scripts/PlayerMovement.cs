using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController characterController;
    public float moveSpeed = 3f;
    public float gravity = 9.81f;
    public float roationSpeed = 0.15f;
    public float rotateDegreePerSecond = 180f;
    // Start is called before the first frame update
    void Awake()
    {
        characterController=GetComponent<CharacterController>();   
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        if (Input.GetAxis(Axis.VERTICAL_AXIS) > 0)
        {
            Vector3 moveDirection = transform.forward;
            moveDirection.y -= gravity * Time.deltaTime;

            characterController.Move(moveDirection*moveSpeed*Time.deltaTime);

        }else if(Input.GetAxis(Axis.VERTICAL_AXIS) < 0)
        {
            Vector3 moveDirection = -transform.forward;
            moveDirection.y -= gravity * Time.deltaTime;

            characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
        }

        Roate();
    }
    void Roate()
    {
        Vector3 rotate_Direction = Vector3.zero;
        if(Input.GetAxis(Axis.HORIZONTAL_AXIS) < 0)
        {
            rotate_Direction = transform.TransformDirection(Vector3.left);
        }

        if (Input.GetAxis(Axis.HORIZONTAL_AXIS) > 0)
        {
            rotate_Direction = transform.TransformDirection(Vector3.right);
        }

        if (rotate_Direction != Vector3.zero)
        {
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                Quaternion.LookRotation(rotate_Direction),
                rotateDegreePerSecond*Time.deltaTime);
        }
    }
}
