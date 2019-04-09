using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;





public class SUB_temperat : MonoBehaviour {
   public Sprite temp_red;
    public Text startText;
    public int temp = 32;
    // Use this for initialization
    void Start()
    {
       
    }

   

    // Update is called once per frame
    void Update()
    {
         startText.text = "<b>" + temp.ToString() + "</b>";
        if (temp < 32 || temp >= 100) {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = temp_red;
        }
    }
}

