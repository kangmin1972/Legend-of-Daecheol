using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class loadingtip : MonoBehaviour
{
    public int tips;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        tips = Random.Range(1, 5);
        if (tips == 1)
        {
            text.text = "CCTV를 조심하고 항상 조용히 행동하세요.";
        }
        if (tips == 2)
        {
            text.text = "욕심내서 빨리 부수지 마세요.";
        }
        if (tips == 3)
        {
            text.text = "맵에 각종 함정이 존재합니다.";
        }
        if (tips == 4)
        {
            text.text = "망치를 잘 이용하세요.";
        }
        if (tips == 5)
        {
            text.text = "대철중학교와 완전히 똑같지는 않습니다.";
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
        AsyncOperation operation = SceneManager.LoadSceneAsync(3);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            Debug.Log(progress);
            yield return null;
        }
    }
}
