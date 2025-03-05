using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Bank2
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Account {  get; set; }
        public string Bank { get; set; }
        public string Password { get; set; }
    }
}
