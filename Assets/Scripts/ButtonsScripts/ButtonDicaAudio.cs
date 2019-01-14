﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class ButtonDicaAudio : MonoBehaviour
{

    public static ButtonDicaAudio instance = null;
    private Button botaoDicaAudio;
    private SilabaControl silabaControl;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        botaoDicaAudio = GameObject.FindGameObjectWithTag("Button Sound").GetComponent<UnityEngine.UI.Button>();
    }

    private void Start()
    {
        silabaControl = SilabaControl.instance;
    }

    public void ActiveButton()
    {
        botaoDicaAudio = GameObject.FindGameObjectWithTag("Button Sound").GetComponent<UnityEngine.UI.Button>(); //Como o canvas é destruído entre as scenes, é necessário reestabelecer a referência.
        botaoDicaAudio.interactable = true;
    }

    public void DeactiveButton()
    {
        botaoDicaAudio.interactable = false;
    }
    
    public void AcionaDicaAudio()//botao dica audio
    {
        if (!LevelController.bloqueiaBotao)
        {
            silabaControl.TocarSilabaAtual();//toca silaba atual
            DeactiveButton();
        }
    }
}
