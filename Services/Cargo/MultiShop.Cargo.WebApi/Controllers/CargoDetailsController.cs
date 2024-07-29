using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _CargoDetailSevice;

        public CargoDetailsController(ICargoDetailService CargoDetailSevice)
        {
            _CargoDetailSevice = CargoDetailSevice;
        }

        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var values = _CargoDetailSevice.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
        {
            CargoDetail CargoDetail = new CargoDetail()
            {
               Barcode = createCargoDetailDto.Barcode,
               CargoCompanyId = createCargoDetailDto.CargoCompanyId,
               ReceiverCustomer = createCargoDetailDto.ReceiverCustomer,
               SenderCustomer = createCargoDetailDto.SenderCustomer,
            };
            _CargoDetailSevice.TInsert(CargoDetail);
            return Ok("Kargo Detayları Başarıyla Oluşturuldu");
        }

        [HttpDelete]
        public IActionResult RemoveCargoDetail(int id)
        {
            _CargoDetailSevice.TDelete(id);
            return Ok("Kargo Detayları Başarıyla Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoDetailById(int id)
        {
            var values = _CargoDetailSevice.TGetById(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
        {
            CargoDetail CargoDetail = new CargoDetail()
            {
               Barcode = updateCargoDetailDto.Barcode,
               CargoCompanyId = updateCargoDetailDto.CargoCompanyId,
               CargoDetailId = updateCargoDetailDto.CargoDetailId,
               ReceiverCustomer = updateCargoDetailDto.ReceiverCustomer,
               SenderCustomer = updateCargoDetailDto.SenderCustomer,
            };
            _CargoDetailSevice.TUpdate(CargoDetail);
            return Ok("Kargo Detayları Başarıyla Güncellendi");
        }
    }
}
