using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTracker : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        Vector3 cameraPos = player.position + offset;
        Vector3 smoothTrack = Vector3.SmoothDamp(transform.position, cameraPos, ref velocity, 0.1f);
        transform.position = smoothTrack;
    }
}
