using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    bool isFiring = false;
    [SerializeField] GameObject laser;
    [SerializeField] RectTransform crosshair;
    [SerializeField] GameObject Target;
    [SerializeField] float targetDistance = 250f;
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
        MoveTarget();
        RotateLaserDirection();
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
    void MoveTarget()
    {
        Vector3 TargetPosition = new Vector3(Mouse.current.position.ReadValue().x, Mouse.current.position.ReadValue().y, targetDistance);
        Target.transform.position = Camera.main.ScreenToWorldPoint(TargetPosition);
    }
    void RotateLaserDirection()
    {
        Vector3 rotation = Target.transform.position - this.transform.position;
        Quaternion rotationToTarget = Quaternion.LookRotation(rotation);
        laser.transform.rotation = rotationToTarget;
    }
}
