class StandardGame : GameBase
{
    public override int CalculateRating()
    {
        return new Random().Next(10, 30);
    }
}
