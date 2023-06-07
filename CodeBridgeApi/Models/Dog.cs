using Sieve.Attributes;
using System.ComponentModel.DataAnnotations;

namespace CodeBridgeApi.Models
{
    public class Dog
    {
        [Key]
        [Sieve(CanFilter = true, CanSort = true)]
        public string Name { get; set; }
        [Sieve(CanFilter = true, CanSort = true)]
        public string Color { get; set; }
        [Sieve(CanFilter = true, CanSort = true)]
        public string Tail_Length { get; set; }
        [Sieve(CanFilter = true, CanSort = true)]
        public string Weight { get; set; }


    }
}
