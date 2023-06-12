using WebApplication5.Models;

namespace WebApplication5.Interfaces
{
    public interface IMascotaRepository 
    {
        Task deleteMascota(Mascota mascota);
        Task<bool> ExistMascota(int id);
        Task<Mascota> getMascotaById(int mascotaId);
        Task<IEnumerable<Mascota>> getMascotas();
        Task insertMascota(Mascota mascota);
        Task updataMascota(Mascota mascota);
    }
}
