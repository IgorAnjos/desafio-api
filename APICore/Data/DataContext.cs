using APICore.Models;
using Microsoft.EntityFrameworkCore;

namespace APICore.Data
{
    public class DataContext : DbContext
    {
        public DbSet<FuncionarioModel> Funcionarios { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}
