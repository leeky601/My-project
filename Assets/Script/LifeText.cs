using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeText : MonoBehaviour
{
    // Start is called before the first frame update
    public Text life_text;

    public int life;
    void Start()
    {
        life = 2;
    }

    // Update is called once per frame
    void Update()
    {
        life_text.text = "Life : " + life;
    }

    public void Dead()
    {
        life -= 1;
    }

    public void Heal()
    {
        life += 1;
    }
}