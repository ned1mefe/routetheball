public class Player
{
    public short health { get; private set; }
    //private long score;

    public void Instantiate()
    {
        //score = 0;
        health = 4;
    }

    public void loseHealth() => health--;
}
