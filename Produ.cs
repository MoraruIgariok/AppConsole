using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DepozitApp
{
    public partial class Produ
    {
        
        public Produ()
        {

            
            Console.WriteLine("Dati denumirea produsului:");
            Name = Console.ReadLine();
            Console.WriteLine("Descrieti produsul: ");
            Description = Console.ReadLine(); 
            Console.WriteLine("Cine este producatorul: ");
            Owner = Console.ReadLine();
            Commands = new HashSet<Command>();
        }

        public int Id { get; set; }
        
        [MaxLength(100)]
        public string? Name { get; set; }

        [MaxLength(100)]
        public string? Description { get; set; }

        [MaxLength(100)]
        public string? Owner { get; set; }

        public virtual ICollection<Command> Commands { get; set; }
    }
}
