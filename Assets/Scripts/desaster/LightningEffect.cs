using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Appends light effect to Thunder
public class LightningEffect : MonoBehaviour
{
    public Light thunderLight;

    public void Lightning()
    {
        thunderLight.enabled = true;
    }
}
