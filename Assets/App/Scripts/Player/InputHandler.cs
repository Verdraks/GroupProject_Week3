using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class InputHandler : MonoBehaviour
{
    [Header("Output")]
    [SerializeField] private UnityEvent<Vector2> onSwipe;
    
    private Vector2 _startTouchPos, _endTouchPos;
    private bool _swipeRunning;
    
    private static readonly Vector2[] Directions = { Vector2.left, Vector2.right, Vector2.up, Vector2.down };
    
    private void Update()
    {
        UpdateInput();
    }

    private void UpdateInput()
    {
        if (Input.GetMouseButtonDown(0) && !_swipeRunning) 
            StartCoroutine(SwipeInputHandle());
        if (Input.GetMouseButtonUp(0)) _swipeRunning = false;
    }

    private IEnumerator SwipeInputHandle()
    {
        _swipeRunning = true;
        _startTouchPos = Input.mousePosition;
        yield return new WaitWhile(()=>_swipeRunning);
        _endTouchPos = Input.mousePosition;
        
        SwipeCalculation();
    }

    private void SwipeCalculation()
    {
        Vector2 swipeDirN = (_endTouchPos - _startTouchPos).normalized;
        
        onSwipe.Invoke(GetDirectionClamped(swipeDirN));
    }

    private Vector2 GetDirectionClamped(Vector2 direction)
    {
        Vector2 clampedDirection = Vector2.zero;
        float maxDot = -Mathf.Infinity;

        foreach (Vector2 dir in Directions)
        {
            float dot = Vector2.Dot(direction, dir);
            if (dot > maxDot)
            {
                maxDot = dot;
                clampedDirection = dir;
            }
        }
        
        return clampedDirection;
    }
}