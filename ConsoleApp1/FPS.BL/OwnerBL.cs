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

        OwnerDAO ownerDao = null;
        public OwnerBL()
        {
            ownerDao = new OwnerDAO();
        }
        public bool AddOwner(Owner ownObj)
        {
            //Calling DAO class Function
            return ownerDao.AddOwner(ownObj);
        }

        public bool UpdateOwner(int ownID, Owner ownObj)
        {
            return ownerDao.UpdateOwner(ownID, ownObj);
        }

        public bool DropOwner(int ownID)
        {
            return ownerDao.DropOwner(ownID);
        }
    }

}
