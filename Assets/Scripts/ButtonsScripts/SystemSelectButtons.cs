﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemSelectButtons : MonoBehaviour {

    private bool[] sistemasLiberados;
    private int systemNumber;
    private string systemName;

    // Libera a seleção do sistema no systemSelect
	void Start () {
        sistemasLiberados = SaveManager.player.sistemaLiberado;
        systemName = this.GetComponent<UnityEngine.UI.Button>().name;
        systemNumber = System.Int32.Parse(systemName.Substring(systemName.Length - 1));

        if (sistemasLiberados[systemNumber])
        {
            this.GetComponent<UnityEngine.UI.Button>().interactable = true;
        }
	}
}
