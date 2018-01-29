using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In m/s")] [SerializeField] float speed = 5;
    [SerializeField] float xRange = 8;
    [SerializeField] float yRange = 4;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = speed * horizontalThrow * Time.deltaTime;

        float verticalThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = speed * verticalThrow * Time.deltaTime;

        transform.localPosition = new Vector3(
            Mathf.Clamp(transform.localPosition.x + xOffset, -xRange, xRange),
            Mathf.Clamp(transform.localPosition.y + yOffset, -yRange, yRange),
            transform.localPosition.z
        );
    }
}
