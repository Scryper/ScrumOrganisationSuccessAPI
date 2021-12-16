namespace Application.UseCases.Utils
{
    public interface IWritingMultipleKeys<out TO, in TI, in TI2>
    {
        TO Execute(TI id1, TI2 id2);
    }
}