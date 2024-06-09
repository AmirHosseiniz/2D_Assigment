using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// a scriptable object wich holds a refrence to input manager and spawn it 

[CreateAssetMenu(menuName = "InputManager")]
public class InputProvider : ScriptableObject
{
    [SerializeField] InputManager _prefab;
    InputManager _cachedInputManager;

    public event Action<Vector2> InputValueEvent { add { InputManager.InputValueEvent += value; } remove { InputManager.InputValueEvent -= value; } }
    public event Action JumpEvent { add { InputManager.JumpEvent += value; } remove { InputManager.JumpEvent -= value; } }

    InputManager InputManager
    {
        get
        {
            if (_cachedInputManager != null)
                return _cachedInputManager;

            var currentInputManager = FindObjectOfType<InputManager>();
            if (currentInputManager != null)
                _cachedInputManager = currentInputManager;
            else
            {
                _cachedInputManager = Instantiate(_prefab);
                DontDestroyOnLoad(_cachedInputManager);
            }
            return _cachedInputManager;
        }
    }
}