public interface Element
{
    string Name { get; set; }
    void Display(int i = 0);
    void Execute();
    void AddMessage();
}