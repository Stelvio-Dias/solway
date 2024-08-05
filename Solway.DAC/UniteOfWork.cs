using Solway.Interfaces;

namespace Solway.DAC;

public class UniteOfWork : IUniteOfWork
{
    private readonly SolwayDbContext _context;

    public UniteOfWork(SolwayDbContext context) => _context = context;

    public async Task SaveAsync() => await _context.SaveChangesAsync();

    public async Task Dispose() => await _context.DisposeAsync();
}