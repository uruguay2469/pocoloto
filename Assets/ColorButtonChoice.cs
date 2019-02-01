﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ColorButtonChoice : MonoBehaviour {

    public int index;
    public string nome;

    public void OnClick()
    {
        foreach (Selectable selectable in Selectable.allSelectables)
        {
            if (selectable.CompareTag("ShopItem"))
            {
                selectable.colors = AvatarChoice.defaultColor;
            }
        }
        this.GetComponent<Button>().colors = AvatarChoice.highlightedColor;

        SaveManager.player.colorSelecionadoIndex = index;
        GameObject.Find("Main Camera").GetComponent<CustomizeScreen>().UpdateScreen();
    }
}
