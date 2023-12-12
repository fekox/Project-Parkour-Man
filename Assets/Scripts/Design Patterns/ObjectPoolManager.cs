using UnityEngine;
using UnityEngine.Pool;

/// <summary>
/// ObjectPool for the coins and the turrets.
/// </summary>
public class ObjectPoolManager : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private GameObject coinPrefab;

    [SerializeField] private GameObject turretPrefab;

    [Header("Max Objects On Pools")]
    [SerializeField] private int maxCoinsInPool;

    [SerializeField] private int maxTurretsInPool;

    [Header("Objects Positions")]
    [SerializeField] private Transform[] coinsPositions;

    [SerializeField] private Transform[] turretsPositions;

    [Header("Audio Source")]
    [SerializeField] private AudioManager audioSource;

    [Header("Objects Pools")]
    private ObjectPool<GameObject> coinsPool;

    private ObjectPool<GameObject> turretsPool;

    private int currentCoinPosition;

    private int currentTurretPosition;

    /// <summary>
    /// Sets the pools.
    /// </summary>
    private void Awake()
    {
        coinsPool = new ObjectPool<GameObject>(GetCoin, OnTakeCoinFromPool, OnReturnCoinToPool, OnDestroyCoinPoolObject, true, maxCoinsInPool);

        turretsPool = new ObjectPool<GameObject>(GetTurret, OnTakeTurretFromPool, OnReturnTurretToPool, OnDestroyTurretPoolObject, true, maxTurretsInPool);
    }

    /// <summary>
    /// Coins and turrets are positioned in the level.
    /// </summary>
    private void Start()
    {
        for (int i = 0; i < coinsPositions.Length; i++) 
        {
            coinsPool.Get(out var temp);
        }

        for (int i = 0; i < turretsPositions.Length; i++) 
        {
            turretsPool.Get(out var temp);
        }
    }

    /// <summary>
    /// Creates an instance of a coin, positions it, increments a position in the array of coin positions, and then returns the coin.
    /// </summary>
    /// <returns></returns>
    public GameObject GetCoin()
    {
        var auxCoin = Instantiate(coinPrefab, Vector3.zero, Quaternion.identity);

        auxCoin.transform.position = coinsPositions[currentCoinPosition].position;
        currentCoinPosition++;

        return auxCoin;
    }

    /// <summary>
    /// Creates an instance of a turret, positions it, increments a position in the array of turrets positions, and then returns the turret.
    /// </summary>
    /// <returns></returns>
    public GameObject GetTurret()
    {
        var auxTurret = Instantiate(turretPrefab);

        auxTurret.transform.position = turretsPositions[currentTurretPosition].position;
        currentTurretPosition++;

        return auxTurret;
    }

    /// <summary>
    /// When the coin returns to the coin pool the game object is deactivated.
    /// </summary>
    /// <param name="coin"></param>
    private void OnReturnCoinToPool(GameObject coin)
    {
        Coin auxCoint = coin.GetComponent<Coin>();

        coin.transform.parent.gameObject.SetActive(false);

        auxCoint.onDeath.RemoveListener(OnReturnCoinToPool);
    }

    /// <summary>
    /// When the turret returns to the coin pool the game object is deactivated.
    /// </summary>
    /// <param name="turret"></param>
    private void OnReturnTurretToPool(GameObject turret)
    {
        DestroyTurret auxTurret = turret.GetComponent<DestroyTurret>();

        turret.gameObject.SetActive(false);

        auxTurret.onDeath.RemoveListener(OnReturnTurretToPool);
    }

    /// <summary>
    /// When a coin is taken from the pool the game object is activated.
    /// </summary>
    /// <param name="coin"></param>
    private void OnTakeCoinFromPool(GameObject coin)
    {
        Coin auxCoin = coin.GetComponentInChildren<Coin>();

        auxCoin.soundsPlayer.audioManager = audioSource;

        coin.gameObject.SetActive(true);

        auxCoin.onDeath.AddListener(OnReturnCoinToPool);
    }

    /// <summary>
    /// When a turret is taken from the pool the game object is activated.
    /// </summary>
    /// <param name="turret"></param>
    private void OnTakeTurretFromPool(GameObject turret)
    {
        DestroyTurret auxTurret = turret.GetComponent<DestroyTurret>();

        auxTurret.soundsPlayer.audioManager = audioSource;

        turret.gameObject.SetActive(true);

        auxTurret.onDeath.AddListener(OnReturnTurretToPool);
    }

    /// <summary>
    /// Destroy one coin from the pool object.
    /// </summary>
    /// <param name="coin"></param>
    private void OnDestroyCoinPoolObject(GameObject coin)
    {
        Destroy(coin.transform.parent.gameObject);
    }

    /// <summary>
    /// Destroy one turret from the pool object.
    /// </summary>
    /// <param name="turret"></param>
    private void OnDestroyTurretPoolObject(GameObject turret)
    {
        Destroy(turret.transform.parent.gameObject);
    }
}