﻿
using Microsoft.AspNetCore.Components;
using WebApplication2.Models;
using WebApplication2.Models.IRepository;

namespace WebApplication2.App.Pages
{
    public partial class SearchBlazor
    {
        public string SearchText = "";
        public List<Pie> FilteredPies { get; set; } = new List<Pie>();

        [Inject]
        public IPieRepository? PieRepository { get; set; }

        private void Search()
        {
            FilteredPies.Clear();
            if (PieRepository is not null)
            {
                if (SearchText.Length >= 3)
                    FilteredPies = PieRepository.searchPies(SearchText).ToList();
            }
        }
    }
}
