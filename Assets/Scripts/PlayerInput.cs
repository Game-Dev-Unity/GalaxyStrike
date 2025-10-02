using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{

    [SerializeField] float moveSpeed = 30f;
    [SerializeField] float xClampRange = 5f;
    [SerializeField] float yClampRange = 5f;
    [SerializeField] float controlRollFactor = 20f;
    [SerializeField] float controlPitchFactor = 20f;
    [SerializeField] float rotationSpeed = 5f;
    

    Vector2 movement;
    // Update is called once per frame
    void Update()
    {
        ProcessLocalPosition();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        float xRotation = -controlRollFactor * movement.x;
        float yRotation = -controlPitchFactor * movement.y;
        Quaternion targetRotation = Quaternion.Euler(yRotation, 0f, xRotation);
        float lerpSpeed = rotationSpeed * Time.deltaTime;
        transform.localRotation = Quaternion.Lerp(transform.localRotation,targetRotation, lerpSpeed);       
    }

    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }
    private void ProcessLocalPosition()
    {
        float xOffset = movement.x * moveSpeed * Time.deltaTime;
        float yOffset = movement.y * moveSpeed * Time.deltaTime;
        float xPosition = transform.localPosition.x + xOffset;
        float yPosition = transform.localPosition.y + yOffset;
        float clampedXPosition = Mathf.Clamp(xPosition, -xClampRange, xClampRange);
        float clampedYPosition = Mathf.Clamp(yPosition, -yClampRange, yClampRange);
        transform.localPosition = new Vector3(clampedXPosition, clampedYPosition, 0f);
    }
}
