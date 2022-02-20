using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FPS.Entity;
using FPS.DAL;
namespace FPS.BL
{
    public class OwnerBL
    {

        OwnerDAO custDao = null;
        public OwnerBL()
        {
            custDao = new OwnerDAO();
        }
        public bool AddOwner(Owner ownObj)
        {
            //Calling DAO class Function
            return custDao.AddOwner(ownObj);
        }

        public bool UpdateOwner(int ownID, Owner ownObj)
        {
            return custDao.UpdateOwner(ownID, ownObj);
        }

        public bool DropOwner(int ownID)
        {
            return custDao.DropOwner(ownID);
        }
    }

}
