﻿using Cybermage;
using UnityEngine;

public static class MainCamera
{
    private static Transform _isometricAlignment;
    public static Camera Camera { get; private set; }

    public static void Awake(int orthographicSize)
    {
        _isometricAlignment = MonoBehaviour.Instantiate(
            Resources.Load<GameObject>("prefabs/isometricAlignment"))
            .transform;

        Camera = Utilities.FindDeepChild<Camera>(_isometricAlignment, "mainCamera");
        Camera.orthographicSize = orthographicSize;
        MonoBehaviour.DontDestroyOnLoad(_isometricAlignment);
    }
}
