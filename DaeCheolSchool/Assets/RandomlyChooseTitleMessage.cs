using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RandomlyChooseTitleMessage : MonoBehaviour
{
    int random;
    public TextMeshProUGUI all;

    // Start is called before the first frame update
    void Start()
    {
        random = Random.Range(-1, 5);

        switch(random)
        {
            case 0:
                all.text = "대철중학교에 오신걸 환영합니다!";
                break;
            case 1:
                all.text = "Wings 대철! 날아라 대철!";
                break;
            case 2:
                all.text = "모두의 혁신학교! 대철중학교!";
                break;
            case 3:
                all.text = "모두가 행복한 대철중학교!";
                break;
            case 4:
                all.text = "꿈과 희망이 넘치는 대철중학교!";
                break;
        }
    }
}
