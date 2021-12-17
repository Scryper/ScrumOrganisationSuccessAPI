namespace Application.UseCases.Utils
{
    public interface IQueryFilteringTwoFilters<out TO, in TI, in TX>
    {
        TO Execute(TI filter, TX filter2);
    }
}