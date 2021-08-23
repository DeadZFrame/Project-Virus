using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningEffect : MonoBehaviour
{
    public Light light;

    public void Lightning()
    {
        light.enabled = true;
    }
}
