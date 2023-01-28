namespace Store.Domain.Entites
{
    public class Customer : EntityBase
    {
        public Customer(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}
