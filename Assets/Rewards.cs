using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Rewards : CustomService
{
    public ScriptableObject Selected;
    private Dictionary<int, ScriptableObject> items = new();

    [Header("Internal references")]
    [SerializeField]
    private Canvas rewardsCanvas;
    [SerializeField]
    private GameObject[] RewardPanels;
    private List<BingoTile> possibleTiles;
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
            rewardPanel.GetComponentInChildren<Button>().onClick.AddListener(
                () =>
                {
                    ToggleHide();
                    rewardPanel.GetComponentInChildren<Button>().interactable = false;
                    Selected = items[rewardPanel.GetComponentInChildren<Button>().GetInstanceID()];
                });
        possibleTiles = new(Resources.LoadAll<BingoTile>("ScriptableObjects/Tiles"));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Open()
    {
        Debug.Log("Open shop");
        boughtItems = 0;
        GenerateRandomShop();
    }

    private void GenerateRandomShop()
    {
        items.Clear();
        foreach (var rewardPanel in RewardPanels)
        {
            BingoTile generatedTile = GenerateObject();
            rewardPanel.transform.GetChild(0).GetComponent<TMP_Text>().text = generatedTile.Name;
            rewardPanel.transform.GetChild(1).GetComponent<TMP_Text>().text = generatedTile.Description;
            Button thisButton = rewardPanel.transform.GetComponentInChildren<Button>(true);
            thisButton.interactable = true;
            items.Add(thisButton.GetInstanceID(), generatedTile);
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
        Utils.RoundManager.NextRound();
    }

    public void ToggleHide()
    {
        if (boughtItems >= MAX_BUYS)
        {
            rewardsCanvas.enabled = false;
            Utils.BingoCard.ConstructionMode = false;
            Selected = null;
            Close();
            return;
        }
        rewardsCanvas.enabled = !rewardsCanvas.enabled;
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
