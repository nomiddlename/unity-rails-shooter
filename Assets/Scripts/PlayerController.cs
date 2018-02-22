using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [Tooltip("In m/s")]
    [SerializeField]
    float speed = 5;
    [SerializeField] float xRange = 8;
    [SerializeField] float yRange = 4;

    [Header("Position-related")]
    [SerializeField]
    float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = -5f;

    [Header("Throw-related")]
    [SerializeField]
    float throwPitchFactor = -10f;
    [SerializeField] float throwRollFactor = -10f;

    private float horizontalThrow = 0f;
    private float verticalThrow = 0f;

    private bool controlsDisabled = false;

    // Update is called once per frame
    void Update()
    {
        if (!controlsDisabled)
        {
            Position();
            Rotation();
        }
    }

    private void Rotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + verticalThrow * throwPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = horizontalThrow * throwRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void Position()
    {
        horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = speed * horizontalThrow * Time.deltaTime;

        verticalThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = speed * verticalThrow * Time.deltaTime;

        transform.localPosition = new Vector3(
            Mathf.Clamp(transform.localPosition.x + xOffset, -xRange, xRange),
            Mathf.Clamp(transform.localPosition.y + yOffset, -yRange, yRange),
            transform.localPosition.z
        );
    }

    private void PlayerDeath()
    {
        controlsDisabled = true;
    }
}
