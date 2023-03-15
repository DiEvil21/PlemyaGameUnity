using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flameIndicator : MonoBehaviour
{
    public GameObject flameInd;
    public Image image;
    public GameObject particalFlame;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //image = gameObject.GetComponent<Image>();
        image.fillAmount = particalFlame.GetComponent<ParticleSystem>().startSize / 2.14f;
    }
}
