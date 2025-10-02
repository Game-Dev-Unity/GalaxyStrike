using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    bool isFiring = false;
    [SerializeField] GameObject laser;
    [SerializeField] RectTransform crosshair;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        MoveCrossHair();
        ProcessFiring();
    }
    void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
        // Laser.emission.enabled = true;
    }
    void ProcessFiring()
    {
        var emissionModule = laser.GetComponent<ParticleSystem>().emission;
        emissionModule.enabled = isFiring;
    }
    void MoveCrossHair()
    {
        crosshair.position = Mouse.current.position.ReadValue();
    }
}
