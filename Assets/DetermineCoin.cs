using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetermineCoin : MonoBehaviour
{
    // Private and visible in inspector
    [SerializeField]
    private Coin coin;

    // Private and invisible in inspector
    private int worthCoin;
    
    // Public
    public int worthToAdd{
        get {return worthCoin;}
    }

    // Use this for initialization
    void Start()
    {
        // Set the variables
        this.GetComponent<SpriteRenderer>().sprite = coin.coinSprite;
        worthCoin = coin.worth;
    }

}
