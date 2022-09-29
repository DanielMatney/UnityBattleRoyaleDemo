using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    CharacterController CharacterControllerPlayer;
    float Speed = 3f;
    float Pitch = 0f;
    public Transform cameraTransform;

    void Start()
    {
        CharacterControllerPlayer = GetComponent<CharacterController>();
    }

    void Update()
    {
        MovePlayer();

        Look();
    }

    void MovePlayer()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        move = Vector3.ClampMagnitude(move, 1f);
        move = transform.TransformDirection(move);

        CharacterControllerPlayer.SimpleMove(move * Speed);
    }

    float Sensitivity = 3f;
    float MinPitch = -45f;
    float MaxPitch = 45f;

    void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * Sensitivity;
        transform.Rotate(0, mouseX, 0);
        
        Pitch -= Input.GetAxis("Mouse Y") * Sensitivity;

        Pitch = Mathf.Clamp(Pitch, MinPitch, MaxPitch);

        cameraTransform.localRotation = Quaternion.Euler(Pitch, 0, 0);

    }
}
