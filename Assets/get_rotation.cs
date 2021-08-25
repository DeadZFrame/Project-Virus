using UnityEngine;

public class get_rotation : MonoBehaviour
{
    public static Quaternion gfx_rot;
    private void Awake()
    {
        gfx_rot = transform.rotation;
    }
    private void Update()
    {
        gfx_rot = transform.rotation;
        //Debug.Log(gfx_rot);
    }
}
