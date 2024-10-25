class SinglePlayerGame : GameBase
{
    public override int CalculateRating()
    {
        return new Random().Next(5, 20); 
    }
}