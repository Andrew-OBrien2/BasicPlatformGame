using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float time;
    private TMP_Text guiTime;
    // Start is called before the first frame update
    void Start()
    {
        guiTime = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;
        guiTime.text = "Time: " + curTime.ToString();
    }
}
