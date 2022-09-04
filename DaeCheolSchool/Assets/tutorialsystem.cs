using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialsystem : MonoBehaviour
{
    public int istutorialed = 0;
    public GameObject popup1;
    public GameObject popup2;
    public AudioSource bell;
    // Start is called before the first frame update
    void Start()
    {
        statload();
        if (DaySystem.todaydate == 1)
        {
            StartCoroutine(tutorial());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (DaySystem.todaydate == 1)
        {
            if ((Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Alpha5) || Input.GetAxis("Mouse ScrollWheel") > 0f || Input.GetAxis("Mouse ScrollWheel") < 0f) && popup2.activeInHierarchy == false)
            {
                StopAllCoroutines();
                popup1.SetActive(false);
                bell.Play();
                popup2.SetActive(true);
            }

            if (Input.GetMouseButtonDown(0))
            {
                    if (popup2.activeInHierarchy == true)
                    {
                        popup1.SetActive(false);
                        popup2.SetActive(false);
                        gameObject.SetActive(false);
                    }
            }
        }
    }

    void statload()
    {

    }

    IEnumerator tutorial()
    {
        yield return new WaitForSeconds(2f);
        bell.Play();
        popup1.SetActive(true);
    }
}
