using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using DatabaseAccessLayer;
using System.Data.Entity;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using ProductBooking.Models;

namespace ProductBooking.Controllers
{
    public class CarController:ApiController

    {
        [HttpGet]
        public IEnumerable<Car> CarsList()
        {

            using (ProductBookEntities Entities = new ProductBookEntities())
            {


                return Entities.Cars.ToList();
            }
        }
        [HttpPost]
        public void AddCar([FromBody]Car car)
        {

            using (ProductBookEntities Entities = new ProductBookEntities())
            {
                //int id = Car.Id;

                var id = Entities.Cars.Max(p=>p.Id);
                car.Id = id + 1;

                Entities.Cars.Add(car);

                Entities.SaveChanges();
                //return Entities.Cars.Add(car);
            }
        }

        [HttpPut]
        public void book([FromBody]ItemUrl obj)
        {

            using (ProductBookEntities Entities = new ProductBookEntities())
            {
                Car existcar = null;
                existcar = Entities.Cars.Find(obj.id);


                if (obj.type.Equals("book")) {
                    if (existcar != null)
                    {
                        existcar.Book = 1;
                        Entities.SaveChanges();

                    };
                }

             else   if (obj.type.Equals("save"))
                    {
                        if (existcar != null)
                        {
                            existcar.SaveProduct = 0;
                            Entities.SaveChanges();

                        };
                    }

                }



            }
        



}
}





      