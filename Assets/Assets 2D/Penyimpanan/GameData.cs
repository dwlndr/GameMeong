[System.Serializable]
public class GameData 
{
    public float health;
    public int score;
    public float x, y, z;

    public GameData(int score, float health)
    {
        this.health = health;
        this.score = score;
    }
}
