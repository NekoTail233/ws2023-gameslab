public interface ICommand
{
    void Execute();
    ICommand setC()
    {
        return this;
    }
}