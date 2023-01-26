using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaySystem : MonoBehaviour
{
    [SerializeField]
    float dayDuration;

    #region Callbacks
    public delegate void OnStartDay(float duration);
    public OnStartDay onStartDay;
    #endregion
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) {
            StartDay();
        }        
    }

    void StartDay() {
        Debug.Log("Day start");
        onStartDay?.Invoke(dayDuration);
        StartCoroutine(StartDayRotine(dayDuration));
    }

    IEnumerator StartDayRotine(float time) {
        yield return new WaitForSeconds(time);
        EndDay();
    }

    void EndDay() {
        Debug.Log("Day end");
        StopAllCoroutines();
    }
}
