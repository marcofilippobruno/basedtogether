using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class P1_BackPackResourceManager : MonoBehaviour {

    public static int backpackSizeMax = 30;
    private static int backpackSizeCurrent;

    Text text;

    void Awake()
    {
        text = GetComponent<Text>();
        //bag = GetComponent<BagResourceManager>();
        backpackSizeCurrent = P1_BagResourceManager.GetResourcesSum();
    }

    // Update is called once per frame
    void Update()
    {
        backpackSizeCurrent = P1_BagResourceManager.GetResourcesSum();
        text.text = backpackSizeCurrent.ToString();
    }

    public static int GetBackpackSize()
    {
        return backpackSizeMax;
    }
}
