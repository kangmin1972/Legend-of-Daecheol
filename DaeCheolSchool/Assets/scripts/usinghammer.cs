using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class usinghammer : MonoBehaviour
{
    public Animation hammerd;
    public AudioSource swinging;
    public static bool ishammerused;
    public bool twsting;
    public float randomaized;
    public Animation recoil;
    public GameObject hammer;
    public Animation HammerIntro;

    public bool mobilesupport;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (weaponsystem.canusehammer == true)
        {
            hammer.SetActive(true);
            {
                if (Input.GetMouseButton(0) && Pausescript.gamepaused == false)
                {
                    hammerd.Stop("weponsheadbob");
                    if (!hammerd.IsPlaying("HAMMER") && !hammerd.IsPlaying("hammer2") && !hammerd.IsPlaying("hammer3"))
                    {
                        hammer.SetActive(true);
                        PlayerMove.canmove = false;
                        StartCoroutine(asdf());
                        randomaized = Random.Range(0, 3);

                        if (randomaized == -1)
                        {
                            hammerd.Play("HAMMER");
                            swinging.Play();
                        }
                        if (randomaized == 0)
                        {
                            hammerd.Play("hammer2");
                            swinging.Play();
                        }
                        if (randomaized == 2)
                        {
                            hammerd.Play("hammer3");
                            swinging.Play();
                        }
                        recoil.Play("recoil");
                    }
                }
            }
            if (!hammerd.IsPlaying("HAMMER") && !hammerd.IsPlaying("hammer2") && !hammerd.IsPlaying("hammer3"))
            {
                ishammerused = false;
            }
            else
            {
                ishammerused = true;
            }
        }
        else
        {
            hammer.SetActive(false);
        }

        IEnumerator asdf()
        {
            yield return new WaitForSeconds(0.03f);
            PlayerMove.canmove = true;
        }
    }

    public void HammerSwing()
    {
        if (!hammerd.isPlaying)
        {
            randomaized = Random.Range(0, 3);

            if (randomaized == -1)
            {
                hammerd.Play("HAMMER");
                swinging.Play();
            }
            if (randomaized == 0)
            {
                hammerd.Play("hammer2");
                swinging.Play();
            }
            if (randomaized == 2)
            {
                hammerd.Play("hammer3");
                swinging.Play();
            }
        }
    }
}
