using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PausableObject : MonoBehaviour
{
    private bool isPause;
    public Action pauseHandler;
    public Action resumeHandler;

    public void AddPauseHandler(Action handler)
    {
        pauseHandler += handler;
    }

    public void AddResumeHandler(Action handler)
    {
        resumeHandler += handler;
    }

    public virtual void Pause()
    {
        Time.timeScale = 0; // Stops FixedUpdate
        isPause = true; // Stops Logically

        pauseHandler?.Invoke();
    }

    public virtual void Resume()
    {
        Time.timeScale = 1f;
        isPause = false;

        resumeHandler?.Invoke();
    }

    protected virtual void OnDisable()
    {
        Resume();
    }
}
