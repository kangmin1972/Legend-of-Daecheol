using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class loadingtip : MonoBehaviour
{
    public int tips;
    public bool gogogogo;
    public int scenenumber;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        if (gogogogo == false)
        {
            tips = Random.Range(1, 6);
            if (tips == 1)
            {
                text.text = "대철중학교에 오신걸 환영합니다!";
            }
            if (tips == 2)
            {
                text.text = "Wings 대철! 날아라 대철!";
            }
            if (tips == 3)
            {
                text.text = "즐거운 마음으로 관광해 보세요.";
            }
            if (tips == 4)
            {
                text.text = "더불어 행복한 품위 있는 대철중학교!";
            }
            if (tips == 5)
            {
                text.text = "보류";
            }
        }
        StartCoroutine(movetostart());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator movetostart()
    {
        yield return new WaitForSeconds(3);
        AsyncOperation operation = SceneManager.LoadSceneAsync(scenenumber);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            Debug.Log(progress);
            yield return null;
        }
    }
}
