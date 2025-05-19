using System;
using UnityEngine;

public class Timer
{
    private float _elapsedTime;
    private bool _counting = false;
    
    public float duration = 0.0f;
    
	public event Action OnTimerEnd;
	public event Action OnTimerStopped;
	
	public Timer(float duration = 0.0f)
	{
	    this.duration = duration;
	}
	
    public void StartTimer()
    {
        if (_counting)
            StopTimer();
            
        _counting = true;
    }
    
    public void StopTimer()
    {
        ResetTimerValues();
        OnTimerStopped?.Invoke();
    }
    
    private void ResetTimerValues()
    {
        _counting = false;
        _elapsedTime = 0.0f;
    }
    
    public void CountTimer(float deltaTime)
    {
        if (!_counting) return;
        
        _elapsedTime += deltaTime;
        
        if (_elapsedTime >= duration)
        {
            ResetTimerValues();
            OnTimerEnd?.Invoke();
        }
    }
}
