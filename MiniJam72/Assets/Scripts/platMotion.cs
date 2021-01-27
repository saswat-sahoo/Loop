using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platMotion : MonoBehaviour
{
    [SerializeField]private float amplitude;
    [SerializeField] private float speed;
    [SerializeField]private string Dierection;
    private Vector3 temp;

    private void Update()
    {
        if (Dierection == "up")
        {
            temp = Vector3.up;
        }

        if (Dierection == "right")
        {
            temp = Vector3.right;
        }

        transform.Translate(temp * Mathf.Sin(Time.time*speed)*amplitude, Space.World);
        //ChangeAnimationState(run);
    }
}
