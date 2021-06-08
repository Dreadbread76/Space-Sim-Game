using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum RenderRate
{
    r16,
    r32
}
public class ChangeRenderTexture : MonoBehaviour
{
   
    [SerializeField] private RawImage raw;
    [SerializeField] private Camera cam;
    [SerializeField] RenderRate rate = RenderRate.r32;

    public RenderRate Rate
    {
        get
        {
            return rate;
        }
        set
        {
            rate = value;
            ChangeBitRate(value);
        }
    }
    private void Start()
    {
        ChangeBitRate(rate);
    }

    // Start is called before the first frame update
    void ChangeBitRate(RenderRate _rate)
    {
        if (cam.targetTexture != null)
        {
            cam.targetTexture.Release();
        }

        RenderTexture texture3;
        switch (_rate)
        {
            case  RenderRate.r16:
                texture3 = new RenderTexture(Screen.width, Screen.height, 16);
                break;
            case  RenderRate.r32:
                texture3 = new RenderTexture(Screen.width, Screen.height, 32);
                break;
            default:
                return;
        }

        cam.targetTexture = texture3;
        raw.texture = texture3;
    }

    
}
