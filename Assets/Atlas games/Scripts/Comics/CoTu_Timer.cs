using UnityEngine;

public class CoTu_Timer 
{
    public float timer = 0f;                // مقدار زمان سپری‌شده
    public float startDelay = 1f;           // تأخیر قبل از شروع تایمر (اختیاری)
    public bool isCounting = false;         // آیا تایمر در حال شمردن است؟
    public bool comicClosed = false;        // آیا کمیک بسته شده است؟

    private void Update()
    {
        // اگر کمیک بسته شده و تایمر هنوز شروع نشده، تایمر را شروع کن
        if (comicClosed && !isCounting)
        {
            StartTimer();
        }

        // اگر تایمر فعال است، زمان را افزایش بده
        if (isCounting)
        {
            timer += Time.deltaTime;
        }
    }

    // زمانی که تایمر شروع شود
    private void StartTimer()
    {
        isCounting = true;
        timer = 0f;
        Debug.Log("Tutorial timer started!");
    }

    // این تابع را از ShowComic صدا بزن وقتی کمیک بسته شد
    public void OnComicClosed()
    {
        comicClosed = true;
        Debug.Log("Comic closed — timer ready to start.");
    }

    // تابع اختیاری برای ریست تایمر
    public void ResetTimer()
    {
        timer = 0f;
        isCounting = false;
        comicClosed = false;
        Debug.Log("Timer reset.");
    }
}
