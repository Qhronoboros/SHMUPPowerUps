using System;

public class Timer
{
    public bool counting = false;
    public float duration = 0.0f;
    public float _elapsedTime;
    
	public event Action OnTimerEnd;
	public event Action OnTimerStopped;
	
	public Timer(float duration = 0.0f)
	{
	    this.duration = duration;
	}
	
    public void StartTimer()
    {
        if (counting)
            StopTimer();
            
        counting = true;
    }
    
    public void StopTimer()
    {
        ResetTimerValues();
        OnTimerStopped?.Invoke();
    }
    
    private void ResetTimerValues()
    {
        counting = false;
        _elapsedTime = 0.0f;
    }
    
    public void CountTimer(float deltaTime)
    {
        if (!counting) return;
        
        _elapsedTime += deltaTime;
        
        if (_elapsedTime >= duration)
        {
            ResetTimerValues();
            OnTimerEnd?.Invoke();
        }
    }
}
