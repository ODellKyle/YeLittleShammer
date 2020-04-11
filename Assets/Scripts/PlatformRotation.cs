using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformRotation : MonoBehaviour
{
    [Range(0f, 180f)] [SerializeField] public float rotateAngleX = 180f;
    [Range(0f, 90f)] [SerializeField] public float rotateAngleY = 15f;
    [Range(0f, 90f)] [SerializeField] public float rotateAngleZ = 15f;



    void LateUpdate()
    {
        if (Player.Instance.jump && Player.Instance.mvmt.onGround)
            this.transform.Rotate(this.transform.rotation.x + rotateAngleX, this.transform.rotation.y + rotateAngleY, this.transform.rotation.z + rotateAngleZ);
    }
}
