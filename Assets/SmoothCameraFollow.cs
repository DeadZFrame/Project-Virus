using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is makes the minimap camera smoothly follow the player from bird's eye view.
/// !Use the Vector3 named offset to change camera's position!
/// Decrease smoothSpeed for more smooth following or increase for more accurate following. !!! Up to 1 !!!
/// </summary>

public class SmoothCameraFollow : MonoBehaviour
{
    public float smoothSpeed = 0.125f;

    public Transform player;

    public Vector3 offset;
    Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        Vector3 cameraPos = player.position + offset;
        Vector3 smoothTrack = Vector3.SmoothDamp(transform.position, cameraPos, ref velocity, smoothSpeed);
        transform.position = smoothTrack;
    }
}
