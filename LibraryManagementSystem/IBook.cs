using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public interface IBook
    {
        int Id { get; set; }
        string Title { get; set; }
        string Author { get; set; }
        string Genre { get; set; }
        int Year { get; set; }
        int Pages { get; set; }
        bool IsAvailable { get; set; }
    }
}
