using _1_API.ViewModel.NhanVien;
using _4.CusView.ModelRequest;

namespace _4.CusView.IServices
{
    public interface IAllServices
    {
        Task<T> GetById<T>(string url,Guid id);
        Task<T> Add<T>(string url,T model);
        Task<bool> Remove<T>(string urlGetById, string urlRemove, Guid id);
        Task<T> Update<T>(string url, T model, Guid id);
        Task<List<T>> GetAll<T>(string url);
        Task<SanPhamChiTietRequest> GetAllViewSPCT<SanPhamChiTietRequest>(string url);
        Task<CartRequest> GetAllViewCart<CartRequest>(string url);
    }
}
