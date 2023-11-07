namespace SimpleJudicialProcessAPI.Models
{
    public abstract class BaseModel<T> where T : BaseModel<T>
    {
        public int Id { get; set; }

        public abstract void Atualizar(T model);
    }
}
