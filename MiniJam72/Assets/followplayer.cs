using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class followplayer : MonoBehaviour
{
    public Transform player;
    public float  Cameraspeed =0.2f;
    public Vector3 difference;
    void FixedUpdate()
    {
        Vector3 movetopos = player.position + difference;
        Vector3 lerpmotionpos = Vector3.Lerp(transform.position, movetopos, Cameraspeed);
        transform.position = lerpmotionpos;
        if (Input.GetMouseButtonDown(0))
        {
            CameraShaker.Instance.ShakeOnce(4f, 2f, 0.1f,1f);
        }
    }
}
