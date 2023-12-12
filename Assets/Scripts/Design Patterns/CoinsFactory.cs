/// <summary>
/// Class to create pickup and collect it.
/// </summary>
public class PickUp
{
    private int value;

    private SoundsPlayer soundsPlayer;

    private string coinSFX;

    /// <summary>
    /// Pickup Builder.
    /// </summary>
    public PickUp(int value, SoundsPlayer soundsPlayer, string coinSFX)
    {
        this.value = value;
        this.soundsPlayer = soundsPlayer;
        this.coinSFX = coinSFX;
    }
}

/// <summary>
/// Creates the coin and return it.
/// </summary>
public class CoinsFactory
{
    public PickUp CreateCoin(int value, SoundsPlayer soundsPlayer, string coinSFX)
    {
        return new PickUp(value, soundsPlayer, coinSFX);
    }
}