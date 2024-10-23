using System;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
	public interface IReservationDal : IGenericDal<Reservation>
	{
		List<Reservation> GetListWithReservationByWaitApproval(int id);
		List<Reservation> GetListWithReservationByAccepted(int id);
        List<Reservation> GetListWithReservationByDenied(int id);
	}
}

