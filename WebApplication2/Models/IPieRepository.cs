﻿namespace WebApplication2.Models
{
    public interface IPieRepository
    {
        IEnumerable<Pie> AllPies {  get; }
        IEnumerable<Pie> PiesOfTheWeek { get; }
        Pie? GetPieById (int Pieid);

        IEnumerable<Pie> searchPies(string searchQuery);
    }
}
