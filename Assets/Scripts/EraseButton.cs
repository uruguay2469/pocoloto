﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EraseButton : MonoBehaviour {

    //Button currentButton;
    AudioSource click;

    void Start()
    {
       // currentButton = this.GetComponent<Button>();
        click = GetComponent<AudioSource>();
    }

    //public void buttonPressed1()
    //{
    //    click.Play(0);
    //    if (LevelController.SilabaDigitada.Length >= 1)
    //    {
    //        LevelController.SilabaDigitada = LevelController.SilabaDigitada.Remove(LevelController.SilabaDigitada.Length - 1);
    //        LevelController.BotaoConfirmaResposta = false;
    //    }       
    //}

    public void buttonPressed()
    {
        click.Play(0);
        int i = LevelController.NumeroDeSilabasDaPalavra - 1; 

        while (i > -1)
        {
            if (LevelController.silabasDigitadas[i].Length > 0)
            {
                LevelController.silabasDigitadas[i] = "";//.Remove(LevelController.silabasDigitadas[1].Length - 1);
            }
            i--;
        }
    }
}