using DatabaseAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace ProductBooking.Controllers
{
    public class AirController:ApiController
    {
        [HttpGet]
        public IEnumerable<Air> AirList()
        {

            using (ProductBookEntities Entities = new ProductBookEntities())
            {


                return Entities.Airs.ToList();
            }
        }
        [HttpPost]
        public void AddAir([FromBody]Air air)
        {

            using (ProductBookEntities Entities = new ProductBookEntities())
            {
                //int id = Car.Id;

                var id = Entities.Airs.Max(p => p.Id);
                air.Id = id + 1;

                Entities.Airs.Add(air);

                Entities.SaveChanges();
                //return Entities.Airs.Add(Air);
            }
        }

        [HttpPut]
        public void book([FromBody]Models.ItemUrl obj)
        {

            using (ProductBookEntities Entities = new ProductBookEntities())
            {
                Air existAir = null;
                existAir = Entities.Airs.Find(obj.id);


                if (obj.type.Equals("book"))
                {
                    if (existAir != null)
                    {
                        existAir.Book = 1;
                        Entities.SaveChanges();

                    };
                }

                else if (obj.type.Equals("save"))
                {
                    if (existAir != null)
                    {
                        existAir.SaveProduct = 0;
                        Entities.SaveChanges();

                    };
                }

            }



        }



    }
}