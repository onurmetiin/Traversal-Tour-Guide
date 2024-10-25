using System;
using System.Linq.Expressions;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
	public interface IReservationService : IGenericService<Reservation>
	{
        List<Reservation> GetListWithReservationByWaitApproval(int id);
        List<Reservation> GetListWithReservationByAccepted(int id);
        List<Reservation> GetListWithReservationByDenied(int id);
    }
}

