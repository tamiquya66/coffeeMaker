public interface Element
{
    string Name { get; set; }
    public void Display(int i = 0);
    public void Execute();
    public void AddMessage();
}