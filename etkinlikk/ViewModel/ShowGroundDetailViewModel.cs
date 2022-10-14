using etkinlikk.Models;

namespace etkinlikk.ViewModel
{
    public class ShowGroundDetailViewModel
    {
        public ShowGround ShowGround { get; set; }
        public District District { get; set; }
        public List<ShowGround> RelatedShowGroundList { get; set; }
        public List<Commentt> ShowGroundCommenttsList    { get; set; }

    }
}
