public interface PickUpInterface
{
    void CollectObject();
}

public class PickUp : PickUpInterface
{
    private int value;

    private SoundsPlayer soundsPlayer;

    private string coinSFX;

    public PickUp(int value, SoundsPlayer soundsPlayer, string coinSFX)
    {
        this.value = value;
        this.soundsPlayer = soundsPlayer;
        this.coinSFX = coinSFX;
    }

    public void CollectObject()
    {
        CoinCounter.instance.IncreaseCoins(value);

        soundsPlayer.PlaySFX(coinSFX);
    }
}

public class CoinsFactory
{
    public PickUpInterface CreateCoin(int value, SoundsPlayer soundsPlayer, string coinSFX)
    {
        return new PickUp(value, soundsPlayer, coinSFX);
    }
}