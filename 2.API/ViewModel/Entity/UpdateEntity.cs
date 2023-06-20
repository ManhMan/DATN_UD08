namespace _2.API.ViewModel.Entity
{
    public class UpdateEntity
    {
        public Guid CreateBy { get; set; }
        public Guid UpdateBy { get; set; }
        public Guid DeleteBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public bool? isDelete { get; set; }
    }
}
