using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour
{
    CharacterController Controller;
    public float speed = 5;
    float gravity = 10;
    float verticalVelocity = 0;
    public float jump = 10;
     
    // Start is called before the first frame update
    void Start()
    {
        Controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        bool isSprint = Input.GetKey(KeyCode.LeftShift);
        float sprinting = isSprint ? 3.5f : 1;

            Vector3 moveDirection = new Vector3(horizontal, 0, vertical);

        if (Controller.isGrounded)
        {
            if (Input.GetAxis("Jump") > 0)
                verticalVelocity = jump;
        }
        else
            verticalVelocity -= gravity * Time.deltaTime;
        

        if (moveDirection.magnitude > 0.1)
        {
            float angle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }

        moveDirection = Camera.main.transform.TransformDirection(moveDirection);

        moveDirection = new Vector3(
            moveDirection.x * speed * sprinting
            , verticalVelocity
            , moveDirection.z * speed*sprinting
            );

        Controller.Move( moveDirection * Time.deltaTime );
    }
}
