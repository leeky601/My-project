using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    private LifeText lifetext;
    public int HeartNum;

    void Start()
    {
        lifetext = GameObject.Find("LifeText").GetComponent<LifeText>();
    }

    private void Update()
    {
        if(lifetext.life < HeartNum )
        {
            gameObject.SetActive(false);
        }
    }


}
