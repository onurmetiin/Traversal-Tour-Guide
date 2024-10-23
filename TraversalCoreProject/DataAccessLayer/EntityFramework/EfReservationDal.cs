using System;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EfReservationDal : GenericRepository<Reservation>, IReservationDal
    {
        List<Reservation> IReservationDal.GetListWithReservationByAccepted(int id)
        {
            using (var context = new Context())
            {
                return context.Reservations
                    .Include(x => x.Destination)
                    .Where(x => x.Status == "Onaylandı" && x.appUserID == id)
                    .ToList();
            }
        }

        List<Reservation> IReservationDal.GetListWithReservationByDenied(int id)
        {
            using (var context = new Context())
            {
                return context.Reservations
                    .Include(x => x.Destination)
                    .Where(x => x.Status == "Reddedildi" && x.appUserID == id)
                    .ToList();
            }
        }

        List<Reservation> IReservationDal.GetListWithReservationByWaitApproval(int id)
        {
            using (var context = new Context())
            {
                return context.Reservations
                    .Include(x => x.Destination)
                    .Where(x=>x.Status == "Onay Bekliyor" && x.appUserID == id)
                    .ToList();
            }

        }
    }
}

