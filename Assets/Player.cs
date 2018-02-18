using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In m/s")] [SerializeField] float speed = 5;
    [SerializeField] float xRange = 8;
    [SerializeField] float yRange = 4;

    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float positionYawFactor = -5f;
    [SerializeField] float throwPitchFactor = -10f;
    [SerializeField] float throwRollFactor = -10f;

    private float horizontalThrow = 0f;
    private float verticalThrow = 0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Position();
        Rotation();
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
}
