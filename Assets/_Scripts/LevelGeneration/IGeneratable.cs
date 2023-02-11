namespace LevelGeneration
{
    internal interface IGeneratable
    {
        public GenerateOrder Order { get; }
        public void Generate();
    }
}