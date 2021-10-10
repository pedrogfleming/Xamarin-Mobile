using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroCervezas
{
    
    public class CervezaViewModel
    {       
        private string name;
        private string brand;
        private string style;
        #region Constructores
        public CervezaViewModel()
        {
        }
        public CervezaViewModel(string name, string brand, string style)
        {
            this.Name = name;
            this.Brand = brand;
            this.Style = style;
        }
        #endregion
        #region Propiedades
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public string Brand
        {
            get { return this.brand; }
            set { this.brand = value; }
        }
        public string Style
        {
            get { return this.style; }
            set { this.style = value; }
        }
        #endregion

    }
}
