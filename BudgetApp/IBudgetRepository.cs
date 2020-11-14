namespace BudgetApp
{
    public interface IBudgetRepository
    {
        decimal Get();

        void Add(decimal budget);
    }
}
