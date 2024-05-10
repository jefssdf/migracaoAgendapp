namespace AgendaAi.Models
{
    public class NaturalPerson : Person
    {
        public string Cpf { get; set; }
        public DateTime BirthDate { get; set; }
    }

    public class NaturalPersonDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Cpf { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
