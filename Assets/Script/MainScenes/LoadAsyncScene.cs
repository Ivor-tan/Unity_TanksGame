using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadAsyncScene : MonoBehaviour
{

    private AsyncOperation async = null;

    //进度条的数值
    private float progressValue;
    //进度条
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = FindObjectOfType<Slider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Loading(String ss)
    {
        StartCoroutine("LoadScene");
    }

    IEnumerator LoadScene()
    {
        async = SceneManager.LoadSceneAsync("TankGame");
        async.allowSceneActivation = false;
        while (!async.isDone)
        {
            if (async.progress < 0.9f)
                progressValue = async.progress;
            else
                progressValue = 1.0f;

            slider.value = progressValue;
            //progress.text = (int)(slider.value * 100) + " %";

            //if (progressValue >= 0.9)
            //{
            //    progress.text = "按任意键继续";
            //    if (Input.anyKeyDown)
            //    {
            //        async.allowSceneActivation = true;
            //    }
            //}

            yield return null;
        }

    }

    private void StartGame()
    {
        async.allowSceneActivation = true;
    }
}
