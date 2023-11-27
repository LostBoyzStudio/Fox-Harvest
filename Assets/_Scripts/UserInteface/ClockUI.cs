using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ClockUI : MonoBehaviour
{
    [SerializeField]
    Image fillImage;
    DaySystem daySystem;

    // Start is called before the first frame update
    void Start()
    {
        daySystem = FindObjectOfType<DaySystem>();
        daySystem.onStartDay += OnStartDay;
    }
    
    void OnStartDay(float duration) {
        fillImage.fillAmount = 1;
        StartCoroutine(ClockStep(duration, 10));
    }

    IEnumerator ClockStep(float clockDuration, float clockTicks) {
        float time = clockDuration/clockTicks;
        while (fillImage.fillAmount > 0) {
            yield return new WaitForSeconds(time);
            fillImage.fillAmount -= 1/clockTicks;
        }
        StopAllCoroutines();
    }

    void OnDestroy() {
        StopAllCoroutines();
        daySystem.onStartDay -= OnStartDay;
    }
}
