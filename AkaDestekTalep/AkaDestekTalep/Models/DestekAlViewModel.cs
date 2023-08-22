using Entity.Entitys;

namespace AkaDestekTalep.Models
{
    public class DestekAlViewModel
    {
        public List<DestekTur> Turler { get; set; }
        public List<DestekKonu> Konular { get; set; }
        public IList<User> Adminler { get; set; }
        public int SecilenKonu { get; set; }
        public int SecilenTur  { get; set; }
        public string SecilenAdmin  { get; set; }
        public string Aciklama { get; set; }
    }
}
