using System;
using System.Collections.Generic;
using System.Text;

namespace Cted.CatalogoCursos.Models
{
    public class Curso
    {
        public int IdCurso { get; set; }
        public string NomeCompleto { get; set; } = string.Empty;
        public string NomeBreve { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public int CargaHoraria { get; set; }
        public DateTime? DataDisponibilizacao { get; set; }
        public int IdCategoria { get; set; }
        public int IdModalidade { get; set; }
        public int IdStatus { get; set; }
        public string PublicoAlvo { get; set; } = string.Empty;
    }
}
