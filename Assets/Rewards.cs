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
    private List<ScriptableObject> possibleRewards;
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
        possibleRewards = new(Resources.LoadAll<BingoTile>("ScriptableObjects/Tiles"));
        possibleRewards.AddRange(Resources.LoadAll<BingoSticker>("ScriptableObjects/Stickers"));
        foreach (var possibility in possibleRewards)
            Debug.Log(possibility);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Open()
    {
        boughtItems = 0;
        GenerateRandomShop();
    }

    private void GenerateRandomShop()
    {
        items.Clear();
        foreach (var rewardPanel in RewardPanels)
        {
            ScriptableObject generatedItem = GenerateObject();
            if (generatedItem is BingoTile generatedTile)
            {
                generatedTile = Instantiate(generatedTile);
                rewardPanel.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = generatedTile.Name;
                rewardPanel.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = generatedTile.sprite;
                rewardPanel.transform.GetChild(1).GetComponent<TMP_Text>().text = generatedTile.Description;
            } else if (generatedItem is BingoStickerNumeric generatedSticker)
            {
                generatedSticker = Instantiate(generatedSticker);
                generatedSticker.Number = Random.Range(1, 51);
                rewardPanel.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = generatedSticker.Name;
                //rewardPanel.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = generatedSticker.sprite;
                rewardPanel.transform.GetChild(1).GetComponent<TMP_Text>().text = generatedSticker.Description;

            }
            Button thisButton = rewardPanel.transform.GetComponentInChildren<Button>(true);
            thisButton.interactable = true;
            items.Add(thisButton.GetInstanceID(), generatedItem);
        }
        ToggleHide();
    }

    private ScriptableObject GenerateObject()
    {
        var generated = possibleRewards[UnityEngine.Random.Range(0, possibleRewards.Count)];
        //possibleTiles.Remove(generated);
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
