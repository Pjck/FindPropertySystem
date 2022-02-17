using FPS.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using FPS.DAL;
    namespace FPS.BL

{
    public class PropertyBL
    {
        PropertyDAO propDao = null;
        public PropertyBL()
        {
            propDao = new PropertyDAO();
        }
        public bool AddProperty(Property propObj)
        {
            //Calling DAO class Function
            return propDao.AddProperty(propObj);
        }

        public bool UpdateProperty(int propId, Property propObj)
        {
            return propDao.UpdateProperty(propId, propObj);
        }

        public bool DropProperty(int propID)
        {
            return propDao.DropProperty(propID);
        }

        public Property SearchPropertyByID(int propID)
        {
            return propDao.SearchPropertyByID(propID);
        }

        public List<Property> SearchPropertyByName(string propName)
        {
            return propDao.SearchPropertyByName(propName);
        }

        public List<Property> SearchPropertyByPrice(int price)
        {
            return propDao.SearchPropertyByPrice(price);
        }

        public List<Property> ShowAllProperty()
        {
            return propDao.ShowAllProperty();
        }

    }
}
