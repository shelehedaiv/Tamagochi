namespace Model.ConstructionModules.Observer
{
    public interface ISubject
    {
        void Notify();
        void AttachListener(IListener listener);
    }
}