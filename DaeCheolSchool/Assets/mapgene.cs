using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapgene : MonoBehaviour
{
    public GameObject left;
    public GameObject right;
    public GameObject up;
    public GameObject down;
    public GameObject center;
    public int l;
    public int r;
    public int u;
    public int d;

    // Start is called before the first frame update
    void Start()
    {
        left.SetActive(false);
        right.SetActive(false);
        up.SetActive(false);
        down.SetActive(false);
        center.SetActive(true);
        generator();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            generator();
        }
    }

    // Update is called once per frame
    void generator()
    {
        left.SetActive(false);
        right.SetActive(false);
        up.SetActive(false);
        down.SetActive(false);
        center.SetActive(true);

        l = Random.Range(0, 2);
        r = Random.Range(0, 2);
        u = Random.Range(0, 2);
        d = Random.Range(0, 2);

        if (l==1)
        {
            left.SetActive(true);
        }
        if (r == 1)
        {
            right.SetActive(true);
        }
        if (u == 1)
        {
            up.SetActive(true);
        }
        if (d == 1)
        {
            down.SetActive(true);
        }
        if (l==0 && r == 0 && u == 0 && d == 0)
        {
            center.SetActive(false);
        }
    }
}
