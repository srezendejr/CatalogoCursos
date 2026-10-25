using Cted.CatalogoCursos.Database;
using Cted.CatalogoCursos.Repository.Interface;
using Cted.CatalogoCursos.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cted.CatalogoCursos.Repository.Repository
{
    public class ModalidadeRepository : IModalidadeRepository
    {
        private readonly AppDbContext _appDbContext;
        public ModalidadeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<IEnumerable<ModalidadeViewModel>> BuscarModalidades()
        {
            var modalidades = await (from m in _appDbContext.Modalidades
                                    select new ModalidadeViewModel
                                    {
                                        IdModalidade = m.IdModalidade,
                                        Descricao = m.Descricao
                                    }).ToListAsync();
            return modalidades;
        }
    }
}
