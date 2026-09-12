using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartGame : MonoBehaviour
{
    public Image image

    public void MulaiGame()
    {
        StartCoroutine(KelapKelip());
    }

    IEnumerator KelapKelip()
    {
        for (int i = 0; i < 6; i++)
        {
            tombolImage.enabled = false;
            yield return new WaitForSeconds(0.2f);

            tombolImage.enabled = true;
            yield return new WaitForSeconds(0.2f);
        }
    }
}

