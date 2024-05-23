namespace AgendaAi.Models
{
    public class LegalPerson : Person
    {
        //public string Cnpj { get; set; }
        //public string SocialName { get; set; }
    }

    public class LegalPersonDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        //public string Address { get; set; }
        //public string Cnpj { get; set; }
        //public string SocialName { get; set; }
    }
}
