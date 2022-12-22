using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraEffect : MonoBehaviour
{
    public Transform realCamera;

    private void Awake()
    {
        realCamera = this.gameObject.transform; 
        ShakeCamera();
    }
    void Update()
    {
        ShakeCamera();
    }
    [ContextMenu("ShakeCamera")]
    public void ShakeCamera(float duration = 0.3f, float strength = 1, int vibrato = 10, float randomness = 90, bool snapping = false, bool fadeOut = true)
    {
        realCamera.transform.DOShakePosition(duration, strength, vibrato, randomness, snapping, fadeOut);
    }
}
