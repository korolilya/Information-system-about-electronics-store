using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Information_system_in_electronics_store
{
   
    public class Product
    {
        private string _type;

      
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private string _firm;

      
        public string Firm
        {
            get { return _firm; }
            set { _firm = value; }
        }


        private string _model;

       
        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }

        private int _quantity;

       
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        private Country _country;

       
        public Country Country
        {
            get { return _country; }
            set { _country = value; }
        }



        // в наличии или нет в наличии 
        /*private string _availability;

        public string Availability
        {
            get { return _availability; }
            set
            {
                if (Quantity != 0)
                {
                    Availability = "Товар есть в наличии";
                } //_availability = value; }
                else
                { Availability = "Товара нет в наличии"; } }
        }*/

        public Product(string type, string firm, string model, int quantity)
        {
            _type = type;
            _firm = firm;
            _model = model;
            _quantity = quantity;
            //_availability = availability;
        }

        public string Information
        {
            get
            {
               // return $"{_type}-{_firm}-{_model}-{_quantity}-{_country.Name}";
                return $"{_type}-{_firm}-{_model}-{_country.Name}-{_quantity}";
            }
        }

        #region DynamicSearch
        public string InfType
        {
            get { return $"{_type}"; }
        }

        public string InfFirm
        {
            get { return $"{_firm}"; }
        }

        public string InfModel
        {
            get { return $"{_model}"; }
        }

        public string InfQuant
        {
            get { return $"{_quantity}"; }
        }

        public string InfCountry
        {
            get { return $"{_country.Name}"; }
        }
        #endregion






    }
}
