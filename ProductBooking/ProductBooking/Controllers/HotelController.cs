using DatabaseAccessLayer;
using ProductBooking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;



namespace ProductBooking.Controllers
{
    public class HotelController : ApiController
    {
        [HttpGet]
        public IEnumerable<Hotel> HotelsList()
        {

            using (ProductBookEntities Entities = new ProductBookEntities())
            {


                return Entities.Hotels.ToList();
            }
        }
        [HttpPost]
        public void AddHotel([FromBody]Hotel Hotel)
        {

            using (ProductBookEntities Entities = new ProductBookEntities())
            {

                var id = Entities.Hotels.Max(p => p.Id);
                Hotel.Id = id + 1;

                Entities.Hotels.Add(Hotel);

                Entities.SaveChanges();
                //return Entities.Hotels.Add(Hotel);
            }
        }

        [HttpPut]
        public void book([FromBody]ItemUrl obj)
        {

            using (ProductBookEntities Entities = new ProductBookEntities())
            {
                Hotel existHotel = null;
                existHotel = Entities.Hotels.Find(obj.id);


                if (obj.type.Equals("book"))
                {
                    if (existHotel != null)
                    {
                        existHotel.Book = 1;
                        Entities.SaveChanges();

                    };
                }

                else if (obj.type.Equals("save"))
                {
                    if (existHotel != null)
                    {
                        existHotel.SaveProduct = 0;
                        Entities.SaveChanges();

                    };
                }

            }



        }



    }
}