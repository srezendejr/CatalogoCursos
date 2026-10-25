using System;
using System.Collections.Generic;
using System.Text;

namespace Cted.CatalogoCursos.ViewModel
{
    public class CursoViewModel
    {
        public int IdCurso { get; set; }
        public required string NomeCompleto { get; set; }
        public required string NomeBreve { get; set; }
        public required string Descricao { get; set; }
        public int CargaHoraria { get; set; }
        public string PublicoAlvo { get; set; } = string.Empty;
        public DateTime DataDisponibilizacao { get; set; }
        public required string Categoria { get; set; }
        public required string Modalidade { get; set; }
        public int IdStatus { get; set; }
        public required string Status { get; set; }
    }
}
