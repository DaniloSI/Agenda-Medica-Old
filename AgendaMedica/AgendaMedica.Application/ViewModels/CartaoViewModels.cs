using System;
using System.Collections.Generic;
using System.Text;

namespace AgendaMedica.Application.ViewModels
{
    public class CartaoViewModel
    {
        public string CardNumber { get; set; }
        public string Cvc { get; set; }
        public string Expiry { get; set; }
    }
}
