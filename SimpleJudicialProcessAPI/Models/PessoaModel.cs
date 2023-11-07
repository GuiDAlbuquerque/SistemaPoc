namespace SimpleJudicialProcessAPI.Models
{
    public abstract class PessoaModel<T> : BaseModel<T> where T : PessoaModel<T>
    { 
        public PessoaModel()
        {
            Nome = string.Empty;
        }

        public string Nome { get; set; }
    }
}
