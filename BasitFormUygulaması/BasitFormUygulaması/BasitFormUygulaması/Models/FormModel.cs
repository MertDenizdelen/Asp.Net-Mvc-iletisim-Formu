using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BasitFormUygulaması.Models
{
    public class FormModel
    {
        [Required(ErrorMessage = "AdıSoyadı gereklidir!!!")]
        public string AdiSoyadi { get; set; }
        [Required (ErrorMessage = "Boş Geçilemez")]
        [EmailAddress(ErrorMessage = "Email Geçersiz")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Boş Olmaz!!!")]
        [MaxLength(500,ErrorMessage = "500 karateri geçmeyin")]
        public string Mesaj { get; set; }

        // Eger Kayıt Edilecekse ve mail gönderene geri dönüş olacaksa
        //public DateTime Tarih { get; set; }

    }
}