using FluffyDuffyMunchkinCats.Data.Models;
using System.Collections.Generic;

namespace FluffyDuffyMunchkinCats.ViewModels
{
    public class IndexViewModel
    {
        public string ProjectName { get; set; }

        public ICollection<string> CatNames { get; set; }
    }
}
