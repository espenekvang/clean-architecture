namespace Application
{
    public interface IQueryHandler<in T, TResult>
    {
        ValueTask<TResult> Run(T query, CancellationToken cancellationToken);
    }
}
