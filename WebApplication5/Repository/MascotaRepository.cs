using Microsoft.EntityFrameworkCore;
using WebApplication5.Interfaces;
using WebApplication5.Models;

namespace WebApplication5.Repository
{
    public class MascotaRepository : IMascotaRepository 
    {
        private readonly ApplicationDbContext context;

        public MascotaRepository(ApplicationDbContext context) 
        {
            this.context = context;
        }

        public async Task<IEnumerable<Mascota>> getMascotas()
        {
            return await  context.Mascotas.AsNoTracking().ToListAsync();
        }

        public async Task<Mascota> getMascotaById(int mascotaId)
        {
            return await context.Mascotas.AsNoTracking().Where(x => x.IdMascotaId ==mascotaId).FirstAsync();
        }


        public async Task insertMascota(Mascota mascota)
        {
            context.Add(mascota);
            await context.SaveChangesAsync();
        }

        public async Task updataMascota (Mascota mascota) 
        {
            //context.Entry(mascota).State = EntityState.Modified;
            context.Update(mascota);
            await context.SaveChangesAsync();
            
        }

        public async Task deleteMascota(Mascota mascota)
        {
            //context.Entry(mascota).State = EntityState.Deleted;
            context.Remove(mascota);
            await context.SaveChangesAsync();
        }

        public async Task<Boolean> ExistMascota(int id)
        {
            Mascota mascotaResult = await context.Mascotas.AsNoTracking().FirstOrDefaultAsync(x => x.IdMascotaId == id);
            if(mascotaResult is null)
            {
                return false;
            }

            return true;
        }


       

    }
}
