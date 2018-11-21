﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    [Header("Detalhes do nível")]
    [Tooltip("Nível atual (int)")]
    public int currentLevel;//Nível atual
    [Tooltip("Total de caracteres juntas nas sílabas deste nível")]
    public int CharLimitForThisLevel;//total de caracteres das silabas deste nivel juntas
    [Tooltip("Número de sílabas diferentes")]
    public int NumeroDeSilabasDaPalavra;
    [Tooltip("Nome da scene do próximo nível")]
    public string NextLevel;
    [Tooltip("Nome da scene do nível anterior")]
    public string PreviousLevel;
    [Tooltip("Diretório de sons do nível")]
    public string soundsDirectory;

    public static StageManager instance = null;
    private Score score;
    private GameObject LevelClearMsg;//gameobject da imagem de proximo nivel ou nivel anterior
    private GameObject GameOver;//gameobject da imagem de gameover    
    private Button BotaoConfirmaResposta;//botão para conferir a resposta

    private Button BotaoDicaVisual;

    private AudioClip erro;//audio do X vermelho de erro
    private AudioClip acerto;//audio das estrelas de acerto
    private Text[] TelaSilabaDigitada;//caixa onde vão as letras digitadas pelo usuário
    private Image[] RespostaCerta;//imagem quando acerta a resposta
    private Image[] RespostaErrada;//imagem quando erra a resposta
    private SilabaControl silabaControl;

    private ButtonDicaAudio buttonDicaAudio;
    private ButtonDicaVisual buttonDicaVisual;
    private ButtonConfirmar buttonConfirmar;

    private Object[] PalavrasNivelAtual;//array de objetos par armazenar os áudios (sílabas)
    private int randomNumber;

    public GameObject GetLevelClearMsg()
    {
        return LevelClearMsg;
    }

    public GameObject GetGameOver()
    {
        return GameOver;
    }

    public AudioClip GetAcerto()
    {
        return acerto;
    }

    public AudioClip GetErro()
    {
        return erro;
    }

    public Image[] GetRespostaCerta()
    {
        return RespostaCerta;
    }

    public Image[] GetRespostaErrada()
    {
        return RespostaErrada;
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }

        LevelController.currentLevel = currentLevel;

        TelaSilabaDigitada = new Text[NumeroDeSilabasDaPalavra];
        for (int i =0; i < NumeroDeSilabasDaPalavra; i++)
        {
            TelaSilabaDigitada[i] = GameObject.Find(string.Concat("Silaba Digitada ", i.ToString())).GetComponent <UnityEngine.UI.Text>();
        }

       
        RespostaCerta = new Image[NumeroDeSilabasDaPalavra];
        for (int i = 0; i < NumeroDeSilabasDaPalavra; i++)
        {
            RespostaCerta[i] = GameObject.Find(string.Concat("RespostaCerta", i.ToString())).GetComponent<UnityEngine.UI.Image>();
        }

        RespostaErrada = new Image[NumeroDeSilabasDaPalavra];
        for (int i = 0; i < NumeroDeSilabasDaPalavra; i++)
        {
            RespostaErrada[i] = GameObject.Find(string.Concat("RespostaErrada", i.ToString())).GetComponent<UnityEngine.UI.Image>();
        }

        LevelClearMsg = GameObject.Find("Level Clear");
        GameOver = GameObject.Find("Level Failed");

        erro = (AudioClip)Resources.Load("Sounds/sfx/erro_slot01");         
        acerto = (AudioClip)Resources.Load("Sounds/sfx/acerto_slot01");

        LevelController.NumeroDeSilabasDaPalavra = NumeroDeSilabasDaPalavra;
        LevelController.InitializeVars();
    }

    void Start()
    {
        silabaControl = SilabaControl.instance;
        silabaControl.SilabaSetup(soundsDirectory);

        buttonConfirmar = ButtonConfirmar.instance;
        buttonDicaAudio = ButtonDicaAudio.instance;
        buttonDicaVisual = ButtonDicaVisual.instance;

        score = Score.instance;
        score.ScoreSetup();

        LevelController.CharLimitForLevel = CharLimitForThisLevel;//define limite de caracteres para o nível atual
        for (int i = 0; i < LevelController.NumeroDeSilabasDaPalavra; i++)//inicializa imagens de resposta certa e errada para que não apareça a princípio
        {
            RespostaCerta[i].enabled = false;
            RespostaErrada[i].enabled = false;
        }
        LevelClearMsg.SetActive(false);
        GameOver.SetActive(false);
        StartCoroutine(silabaControl.CallSilaba(1f));
    }

    void Update()
    {
        if (!LevelController.DicaVisualAtiva)
        {
            for (int i = 0; i<NumeroDeSilabasDaPalavra; i++)
            {
                TelaSilabaDigitada[i].text = LevelController.silabasDigitadas[i];
            }
        }
    }

    public Text[] GetTelaSilabaDigitada()
    {
        return TelaSilabaDigitada;
    }

    
    public static IEnumerator CallAnotherLevel(float secondsBefore, string levelName)//espera seconds e chama outro nivel
    {
        yield return new WaitForSeconds(secondsBefore);
        SceneManager.LoadScene(levelName);
    }

}