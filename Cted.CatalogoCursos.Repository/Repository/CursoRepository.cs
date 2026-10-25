using Cted.CatalogoCursos.Database;
using Cted.CatalogoCursos.Repository.Interface;
using Cted.CatalogoCursos.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cted.CatalogoCursos.Repository.Repository
{
    public class CursoRepository : ICursoRepository
    {
        AppDbContext appDbContext;
        public CursoRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<IEnumerable<CursoViewModel>> BuscarCursos()
        {
            var cursos = await (from c in appDbContext.Cursos 
                                join cat in appDbContext.Categorias on c.IdCategoria equals cat.IdCategoria
                                join mod in appDbContext.Modalidades on c.IdModalidade equals mod.IdModalidade
                                join sta in appDbContext.Status on c.IdStatus equals sta.IdStatus
                                select new CursoViewModel
                                {
                                    IdCurso = c.IdCurso,
                                    NomeCompleto = c.NomeCompleto,
                                    NomeBreve = c.NomeBreve,
                                    Descricao = c.Descricao,
                                    PublicoAlvo = c.PublicoAlvo,
                                    CargaHoraria = c.CargaHoraria,
                                    DataDisponibilizacao = c.DataDisponibilizacao ?? DateTime.Today,
                                    Categoria = cat.Descricao,
                                    Modalidade = mod.Descricao,
                                    IdStatus = c.IdStatus,
                                    Status = sta.Descricao
                                }).ToListAsync();
            
            return cursos; 
        }
    }
}
