using Azure;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Interfaces;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MascotaController : ControllerBase
    {

        private readonly ILogger<MascotaController> _logger;

        ResponseMessage _responseMessage = new ResponseMessage();
        private readonly IMascotaRepository _mascotaRepository;
        
        public MascotaController(ILogger<MascotaController> logger , IMascotaRepository mascotaRepository)
        {
            _logger = logger;
            _mascotaRepository = mascotaRepository;
        }

        [HttpGet(Name = "mascotas")]
        public async Task<ResponseMessage> Get()
        {
            try
            {
             var response =  await _mascotaRepository.getMascotas();

               return _responseMessage.setResponseMessage("Success", response, "Registros Retornados Correctamente");
            }catch (Exception ex)
            {
                return _responseMessage.setResponseMessage("Error", null, ex.Message);
            }
        }
        

        [HttpGet("{id:int}")]
        public async Task <ResponseMessage> getMascotaById(int id)
        {
            try
            {
                var response =  await _mascotaRepository.getMascotaById(id);
                List<Mascota> mascotaList = new List<Mascota>();
                mascotaList.Add(response);
                return _responseMessage.setResponseMessage("Success", mascotaList, "Informacion Retornados Correctamente");
            }
            catch (Exception ex)
            {
                return _responseMessage.setResponseMessage("Error", null, ex.Message);
            }

        }

        [HttpPost]
        public async Task<ResponseMessage> insertData(Mascota mascota)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return _responseMessage.setResponseMessage("Error", null, "Algo salio mal :(");
                }
                await _mascotaRepository.insertMascota(mascota);
                return _responseMessage.setResponseMessage("Success", null, "Informacion insertada Correctamente");
            }
            catch (Exception ex)
            {
                return _responseMessage.setResponseMessage("Error", null, ex.Message);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ResponseMessage> updateMascota(Mascota mascota , int id)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return _responseMessage.setResponseMessage("Error", null, "Verifique informaicion :(");
                }

                var existMascota = await _mascotaRepository.ExistMascota(id);
                if (!existMascota)
                {
                    return _responseMessage.setResponseMessage("Error", null, "Registro no existe :(");
                }
                mascota.IdMascotaId = id;
                await _mascotaRepository.updataMascota(mascota);
                return _responseMessage.setResponseMessage("Success", null, "Informacion Actualizada Correctamente");
            }
            catch (Exception ex)
            {
                return _responseMessage.setResponseMessage("Error", null,  ex.Message);
            } 
        }

        [HttpDelete("{id:int}")]
        public async Task<ResponseMessage> DeleteMascota(int id)
        {
            try
            {
                var existMascota = await _mascotaRepository.ExistMascota(id);
                if (!existMascota)
                {
                    return _responseMessage.setResponseMessage("Error", null, "Registro no existe :(");
                }

                var MascotaToDelete = await _mascotaRepository.getMascotaById(id);
                await _mascotaRepository.deleteMascota(MascotaToDelete);
                return _responseMessage.setResponseMessage("Success", null, "Informacion Eliminada Correctamente");
            }
            catch (Exception ex)
            {
                return _responseMessage.setResponseMessage("Error", null, ex.Message);
            }
        }
    }
}