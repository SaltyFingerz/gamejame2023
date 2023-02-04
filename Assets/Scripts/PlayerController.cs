using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementConstant = 7f;
    [Range(0, 0.05f)] [SerializeField] private float movementSmoothing = .001f;
    Rigidbody playerRigidBody;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 inputVector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        inputVector = Vector3.ClampMagnitude(inputVector, 1f);

        Vector3 movementVector = inputVector * movementConstant;
        Vector3 redundantVelocity = Vector3.zero;
        playerRigidBody.velocity = Vector3.SmoothDamp(playerRigidBody.velocity, movementVector, ref redundantVelocity, movementSmoothing);

    }
}
