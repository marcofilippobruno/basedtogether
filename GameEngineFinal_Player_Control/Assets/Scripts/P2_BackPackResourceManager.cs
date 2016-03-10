using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class P2_BackPackResourceManager : MonoBehaviour {

    public static int backpackSizeMax = 30;
    private static int backpackSizeCurrent;

    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
        //bag = GetComponent<BagResourceManager>();
        backpackSizeCurrent = P2_BagResourceManager.GetResourcesSum();
    }

    // Update is called once per frame
    void Update()
    {
        backpackSizeCurrent = P2_BagResourceManager.GetResourcesSum();
        text.text = backpackSizeCurrent.ToString();
    }

    public static int GetBackpackSize()
    {
        return backpackSizeMax;
    }
}
