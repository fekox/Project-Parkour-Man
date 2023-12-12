using UnityEngine;
using UnityEngine.Pool;

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

    private void Awake()
    {
        coinsPool = new ObjectPool<GameObject>(GetCoin, OnTakeCoinFromPool, OnReturnCoinToPool, OnDestroyCoinPoolObject, true, maxCoinsInPool);

        turretsPool = new ObjectPool<GameObject>(GetTurret, OnTakeTurretFromPool, OnReturnTurretToPool, OnDestroyTurretPoolObject, true, maxTurretsInPool);
    }

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

    public GameObject GetCoin()
    {
        var auxCoin = Instantiate(coinPrefab, Vector3.zero, Quaternion.identity);

        auxCoin.transform.position = coinsPositions[currentCoinPosition].position;
        currentCoinPosition++;

        return auxCoin;
    }

    public GameObject GetTurret()
    {
        var auxTurret = Instantiate(turretPrefab);

        auxTurret.transform.position = turretsPositions[currentTurretPosition].position;
        currentTurretPosition++;

        return auxTurret;
    }

    private void OnReturnCoinToPool(GameObject coin)
    {
        Coin auxCoint = coin.GetComponent<Coin>();

        coin.transform.parent.gameObject.SetActive(false);

        auxCoint.onDeath.RemoveListener(OnReturnCoinToPool);
    }

    private void OnReturnTurretToPool(GameObject turret)
    {
        DestroyTurret auxTurret = turret.GetComponent<DestroyTurret>();

        turret.gameObject.SetActive(false);

        auxTurret.onDeath.RemoveListener(OnReturnTurretToPool);
    }

    private void OnTakeCoinFromPool(GameObject coin)
    {
        Coin auxCoin = coin.GetComponentInChildren<Coin>();

        auxCoin.soundsPlayer.audioManager = audioSource;

        coin.gameObject.SetActive(true);

        auxCoin.onDeath.AddListener(OnReturnCoinToPool);
    }

    private void OnTakeTurretFromPool(GameObject turret)
    {
        DestroyTurret auxTurret = turret.GetComponent<DestroyTurret>();

        auxTurret.soundsPlayer.audioManager = audioSource;

        turret.gameObject.SetActive(true);

        auxTurret.onDeath.AddListener(OnReturnTurretToPool);
    }

    private void OnDestroyCoinPoolObject(GameObject coin)
    {
        Destroy(coin.transform.parent.gameObject);
    }

    private void OnDestroyTurretPoolObject(GameObject turret)
    {
        Destroy(turret.transform.parent.gameObject);
    }
}