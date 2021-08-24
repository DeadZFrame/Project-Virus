using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Appends light effect to Thunder
public class LightningEffect : MonoBehaviour
{
    public Light light;

    public void Lightning()
    {
        light.enabled = true;
    }
}
