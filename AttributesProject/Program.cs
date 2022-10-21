using System.ComponentModel.DataAnnotations;

namespace AttributesProject
{
    class Employe
    {
        public string? Name { set; get; }
        public int Age { set; get; }

        [RegularExpression(@"\+[1-9] \(\d{3}\) \d{3}-\d{2}-\d{2}", ErrorMessage = "Неправильный телефон")]
        public string? Phone { set; get; }
        
        [Required]
        public string Password { set; get; }
        
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { set; get; }
        public Employe(string? name, int age, string? phone)
        {
            Name = name;
            Age = age;
            Phone = phone;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "Bob";
            string phone = "+7 (999) 1123-45-67";
            int age = 19;

            Employe employe = new Employe(name, age, phone);
            ValidationContext context = new(employe);
            List<ValidationResult> results = new();

            if(Validator.TryValidateObject(employe, context, results, true))
                Console.WriteLine("User create correct");
            else
            {
                Console.WriteLine("User create incorrect");
                foreach(var item in results)
                    Console.WriteLine(item.ErrorMessage);
            }
        }
    }
}