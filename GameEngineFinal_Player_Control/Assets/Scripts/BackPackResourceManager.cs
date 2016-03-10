using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BackPackResourceManager : MonoBehaviour {

    public static int backpackSizeMax = 30;
    private int backpackSizeCurrent;
    private BagResourceManager bag;

    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
        bag = GetComponent<BagResourceManager>();
        backpackSizeCurrent = bag.GetResourcesSum();
    }

    // Update is called once per frame
    void Update()
    {
        backpackSizeCurrent = bag.GetResourcesSum();
        text.text = backpackSizeCurrent.ToString();
    }

    public static int GetBackpackSize()
    {
        return backpackSizeMax;
    }
}
