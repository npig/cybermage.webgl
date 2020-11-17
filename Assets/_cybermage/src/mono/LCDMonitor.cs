using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LCDMonitor : MonoBehaviour
{
    public float TimePerFrame = 2.5f;
    private int MaterialIndex = 1;
    public bool PauseOnLastFrame = false;
    private Renderer _mat;
    private Vector2 _v2 = new Vector2(.2f, 0);
    private float time = 0;
    private float _frameTimer;
    private int _frameIndex = 1;
    private Vector2 Offset { get; set; }
    private int FrameIndex
    {
        get
        {
            return _frameIndex;
        }

        set
        {
            if (value > 5)
            {
                value = 1;
            }
            _frameIndex = value;
        }
    }

    void Start () 
    {
        _mat = GetComponent<Renderer>();
        _frameTimer = TimePerFrame;
    }
	
	void FixedUpdate () 
    {
        time += Time.deltaTime;
        
        if (time > _frameTimer)
        {
            FrameIndex++;
            _frameTimer = Frames(FrameIndex);
            time = 0;
        }
    }

    private float Frames(int index)
    {
        switch (index)
        {
            case 1:
                Offset = _v2 * 0;
                _mat.materials[MaterialIndex].SetTextureOffset("_MainTex", Offset);
                return TimePerFrame;
            case 2:
                Offset = _v2 * 1;
                _mat.materials[MaterialIndex].SetTextureOffset("_MainTex", Offset);
                return TimePerFrame;
            case 3:
                Offset = _v2 * 2;
                _mat.materials[MaterialIndex].SetTextureOffset("_MainTex", Offset);
                return TimePerFrame;
            case 4:
                Offset = _v2 * 3;
                _mat.materials[MaterialIndex].SetTextureOffset("_MainTex", Offset);
                return TimePerFrame;
            case 5:
                Offset = _v2 * 4;
                _mat.materials[MaterialIndex].SetTextureOffset("_MainTex", Offset);
                if (PauseOnLastFrame)
                {
                    return TimePerFrame * 2;
                }
                return TimePerFrame;
        }
        return TimePerFrame = 0f ;
   }
}
