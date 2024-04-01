using WebApplication2.Models;
using Microsoft.AspNetCore.Components;

namespace WebApplication2.App.Pages
{
    public partial class PieCard
    {
        [Parameter]
        public Pie? Pie { get; set; }
    }
}
