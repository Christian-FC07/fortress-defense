using UnityEngine;

public class CoTu_Timer : MonoBehaviour
{
    public float timer = 0f;
    public bool isCounting = false;
    public bool comicClosed = false;
    public bool hasStartedTutorial = false;

    private void Update()
    {
        if (comicClosed && !isCounting)
        {
            Debug.Log("💡 ComicClosed detected in Update!");
            StartTimer();
        }

        if (isCounting)
            timer += Time.deltaTime;
    }

    private void StartTimer()
    {
        isCounting = true;
        timer = 0f;
        Debug.Log("📗 Tutorial timer started!");
    }

    public void OnComicClosed()
    {
        if (!comicClosed) // فقط یه بار انجام بده
        {
            comicClosed = true;
            Debug.Log("✅ Comic closed — flag set TRUE.");
        }
    }
}
