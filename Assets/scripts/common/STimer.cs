using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;
using System.Collections;

public class STimer : MonoBehaviour
{
    public delegate void TimerCallback();

    // 启动一个定时器
    public bool StartTimer(float delay, TimerCallback callback)
    {
        StartCoroutine(ExecuteAfterDelay(delay, callback));
        return true;
    }

    // 启动一个重复定时器
    public void StartRepeatingTimer(float interval, int repeatCount, TimerCallback callback)
    {
        StartCoroutine(ExecuteRepeatedly(interval, repeatCount, callback));
    }

    // 在指定时间后执行的协程
    private IEnumerator ExecuteAfterDelay(float delay, TimerCallback callback)
    {
        yield return new WaitForSeconds(delay);
        callback?.Invoke();
    }

    // 在指定间隔重复执行的协程
    private IEnumerator ExecuteRepeatedly(float interval, int repeatCount, TimerCallback callback)
    {
        for (int i = 0; i < repeatCount; i++)
        {
            yield return new WaitForSeconds(interval);
            callback?.Invoke();
        }
    }
}
