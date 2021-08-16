using DevIO.Business.Interfaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DevIO.Data.Respository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(DataContext context) : base(context) { }

        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId)
        {
            return await _context.Enderecos.AsNoTracking()
                .FirstOrDefaultAsync(f => f.FornecedorId == fornecedorId);
        }
    }
}
