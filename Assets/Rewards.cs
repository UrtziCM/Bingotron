using System;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class Rewards : CustomService
{
    [HideInInspector]
    public ScriptableObject Selected;
    private ShopItem[] items = new ShopItem[6];
    
    [Header("Internal references")]
    [SerializeField]
    private Canvas rewardsCanvas;
    [SerializeField]
    private GameObject[] RewardPanels;
    private List<BingoTile> possibleTiles = new();
    private const int MAX_BUYS = 2;
    public int boughtItems = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        ServiceLocator.AddService<Rewards>(this);
    }

    void Start()
    {
        foreach (var rewardPanel in RewardPanels)
            rewardPanel.GetComponentInChildren<Button>().onClick.AddListener(()=>{ ToggleHide(); rewardPanel.GetComponentInChildren<Button>().interactable = false; });
        GUID[] guids = AssetDatabase.FindAssetGUIDs("Bingo"); 
        foreach (var guid in guids)
            possibleTiles.Add(AssetDatabase.LoadAssetByGUID<BingoTile>(guid));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Open()
    {
        Debug.Log("Open shop");
        GenerateRandomShop();
        boughtItems = 0;
    }

    private void GenerateRandomShop()
    {
        foreach (var rewardPanel in RewardPanels)
        {
            BingoTile generatedTile = GenerateObject();
            //rewardPanel.transform.GetChild(0).GetComponent<TMP_Text>().text = generatedTile.name;
        }
        ToggleHide();
    }

    private BingoTile GenerateObject()
    {
        var generated = possibleTiles[UnityEngine.Random.Range(0, possibleTiles.Count)];
        possibleTiles.Remove(generated);
        return generated;
    }

    public void Close()
    {
        Debug.Log("Close shop");
        Utils.RoundManager.StartRound();
    }

    public void ToggleHide()
    {
        Debug.Log("Toggle hide");
        rewardsCanvas.enabled = !rewardsCanvas.enabled;
        if (boughtItems >= MAX_BUYS)
        {
            Close();
            return;
        }
        if (rewardsCanvas.enabled)
        {
            Utils.BingoCard.ConstructionMode = false;
        }
        else
        {
            Utils.BingoCard.ConstructionMode = true;
        }
    }
}
